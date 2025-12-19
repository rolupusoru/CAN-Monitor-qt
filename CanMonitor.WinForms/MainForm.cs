using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CanMonitor.WinForms.Adapters;
using CanMonitor.WinForms.Models;
using CanMonitor.WinForms.Services;
using CanMonitor.WinForms.Utilities;

namespace CanMonitor.WinForms
{
    public sealed class MainForm : Form
    {
        private readonly DataGridView _frameGrid = new();
        private readonly TextBox _formatStringTextBox = new();
        private readonly TextBox _sendIdTextBox = new() { PlaceholderText = "0x123" };
        private readonly TextBox _sendDataTextBox = new() { PlaceholderText = "01 02 03" };
        private readonly Label _connectionLabel = new();
        private readonly Label _statusLabel = new();
        private readonly Button _connectButton = new();
        private readonly Button _disconnectButton = new();
        private readonly Button _startSimulationButton = new();
        private readonly Button _sendButton = new();
        private readonly Button _clearButton = new();

        private readonly CanBusService _busService;

        public MainForm()
        {
            Text = "CAN Monitor 3000 (C# port)";
            MinimumSize = new Size(900, 600);

            _busService = new CanBusService(new SimulationAdapter());
            _busService.FrameReceived += BusServiceOnFrameReceived;
            _busService.ConnectionStateChanged += BusServiceOnConnectionStateChanged;

            InitializeLayout();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _busService.Dispose();
            base.OnFormClosing(e);
        }

        private void InitializeLayout()
        {
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
            };
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            layout.Controls.Add(BuildToolbar(), 0, 0);
            layout.Controls.Add(BuildGrid(), 0, 1);
            layout.Controls.Add(BuildFooter(), 0, 2);

            Controls.Add(layout);
        }

        private Control BuildToolbar()
        {
            var toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Padding = new Padding(8),
            };

            _connectButton.Text = "Connect";
            _connectButton.Click += async (_, _) => await ConnectAsync();

            _disconnectButton.Text = "Disconnect";
            _disconnectButton.Click += async (_, _) => await DisconnectAsync();

            _startSimulationButton.Text = "Start Simulation";
            _startSimulationButton.Click += (_, _) => StartSimulation();

            _clearButton.Text = "Clear";
            _clearButton.Click += (_, _) => _frameGrid.Rows.Clear();

            _formatStringTextBox.Width = 360;
            _formatStringTextBox.PlaceholderText = "Format string (e.g. u8,u16,U32)";

            toolbar.Controls.Add(_connectButton);
            toolbar.Controls.Add(_disconnectButton);
            toolbar.Controls.Add(_startSimulationButton);
            toolbar.Controls.Add(_clearButton);
            toolbar.Controls.Add(new Label
            {
                AutoSize = true,
                Text = "Format string:",
                Padding = new Padding(12, 8, 4, 0)
            });
            toolbar.Controls.Add(_formatStringTextBox);

            return toolbar;
        }

        private Control BuildGrid()
        {
            _frameGrid.Dock = DockStyle.Fill;
            _frameGrid.ReadOnly = true;
            _frameGrid.AllowUserToAddRows = false;
            _frameGrid.AllowUserToDeleteRows = false;
            _frameGrid.RowHeadersVisible = false;
            _frameGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _frameGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _frameGrid.Columns.Add("Time", "Time");
            _frameGrid.Columns.Add("Id", "ID");
            _frameGrid.Columns.Add("Length", "Len");
            _frameGrid.Columns.Add("Data", "Data");
            _frameGrid.Columns.Add("Decoded", "Decoded");

            return _frameGrid;
        }

        private Control BuildFooter()
        {
            var footer = new TableLayoutPanel
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Padding = new Padding(8)
            };
            footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));

            var sendPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Dock = DockStyle.Fill
            };

            sendPanel.Controls.Add(new Label { AutoSize = true, Text = "Send ID (hex):", Padding = new Padding(0, 8, 4, 0) });
            sendPanel.Controls.Add(_sendIdTextBox);
            sendPanel.Controls.Add(new Label { AutoSize = true, Text = "Data (hex bytes):", Padding = new Padding(12, 8, 4, 0) });
            _sendDataTextBox.Width = 220;
            sendPanel.Controls.Add(_sendDataTextBox);

            _sendButton.Text = "Send";
            _sendButton.Click += async (_, _) => await SendAsync();
            sendPanel.Controls.Add(_sendButton);

            footer.Controls.Add(sendPanel, 0, 0);

            var statusPanel = new TableLayoutPanel
            {
                RowCount = 2,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            _connectionLabel.AutoSize = true;
            _connectionLabel.Text = "Adapter: disconnected";

            _statusLabel.AutoSize = true;
            _statusLabel.Text = "Ready";

            statusPanel.Controls.Add(_connectionLabel, 0, 0);
            statusPanel.Controls.Add(_statusLabel, 0, 1);

            footer.Controls.Add(statusPanel, 1, 0);

            return footer;
        }

        private async Task ConnectAsync()
        {
            try
            {
                await _busService.ConnectAsync().ConfigureAwait(false);
                UpdateStatus($"Connected to {_busService.AdapterName}");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Connect failed: {ex.Message}");
            }
        }

        private async Task DisconnectAsync()
        {
            try
            {
                await _busService.DisconnectAsync().ConfigureAwait(false);
                UpdateStatus("Disconnected");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Disconnect failed: {ex.Message}");
            }
        }

        private void StartSimulation()
        {
            _busService.StartSimulation();
            UpdateStatus("Simulation running");
        }

        private async Task SendAsync()
        {
            if (!_busService.IsConnected)
            {
                UpdateStatus("Connect before sending frames.");
                return;
            }

            if (!TryParseIdentifier(_sendIdTextBox.Text, out var id))
            {
                UpdateStatus("Enter a valid hexadecimal identifier (e.g. 0x123).");
                return;
            }

            if (!HexUtils.TryParseBytes(_sendDataTextBox.Text, out var data))
            {
                UpdateStatus("Enter valid hex bytes (e.g. 01 02 03).");
                return;
            }

            if (data.Length > 8)
            {
                UpdateStatus("CAN frames support up to 8 bytes.");
                return;
            }

            var frame = new CanFrame
            {
                Id = id,
                Data = data,
                Timestamp = DateTimeOffset.Now
            };

            await _busService.SendAsync(frame).ConfigureAwait(false);
            UpdateStatus($"Sent {frame.Data.Length} bytes to 0x{frame.Id:X3}");
        }

        private void BusServiceOnConnectionStateChanged(object? sender, bool connected)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<object?, bool>(BusServiceOnConnectionStateChanged), sender, connected);
                return;
            }

            _connectionLabel.Text = connected ? $"Adapter: {_busService.AdapterName}" : "Adapter: disconnected";
            _connectButton.Enabled = !connected;
            _disconnectButton.Enabled = connected;
            _startSimulationButton.Enabled = connected;
            _sendButton.Enabled = connected;
        }

        private void BusServiceOnFrameReceived(object? sender, CanFrame frame)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<object?, CanFrame>(BusServiceOnFrameReceived), sender, frame);
                return;
            }

            if (!_busService.TryDecode(frame, _formatStringTextBox.Text, out var decoded))
            {
                decoded = "Format error";
            }

            _frameGrid.Rows.Insert(0, frame.Timestamp.ToString("HH:mm:ss.fff"), frame.HexId, frame.Length, frame.DataAsHex, decoded);
            if (_frameGrid.Rows.Count > 1000)
            {
                _frameGrid.Rows.RemoveAt(_frameGrid.Rows.Count - 1);
            }
        }

        private static bool TryParseIdentifier(string? text, out int id)
        {
            id = 0;
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            var sanitized = text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? text[2..] : text;
            return int.TryParse(sanitized, System.Globalization.NumberStyles.HexNumber, null, out id);
        }

        private void UpdateStatus(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(UpdateStatus), message);
                return;
            }

            _statusLabel.Text = message;
        }
    }
}
