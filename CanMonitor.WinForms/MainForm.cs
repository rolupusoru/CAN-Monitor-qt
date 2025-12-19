using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CanMonitor.WinForms.Adapters;
using CanMonitor.WinForms.Models;
using CanMonitor.WinForms.Services;
using CanMonitor.WinForms.Utilities;

namespace CanMonitor.WinForms
{
    public sealed partial class MainForm : Form
    {
        private readonly Dictionary<int, int> _frameCounts = new();
        private readonly Dictionary<int, DateTimeOffset> _lastFrameTimes = new();
        private readonly CanBusService _busService;
        private readonly FormatStringParser _formatParser = new();
        private bool _sortItemsLive = true;

        public MainForm()
        {
            InitializeComponent();

            _busService = new CanBusService(new SimulationAdapter());
            _busService.FrameReceived += BusServiceOnFrameReceived;
            _busService.ConnectionStateChanged += BusServiceOnConnectionStateChanged;

            connectButton.Click += async (_, _) => await ConnectAsync();
            disconnectButton.Click += async (_, _) => await DisconnectAsync();
            startSimulationButton.Click += (_, _) => StartSimulation();
            clearButton.Click += (_, _) => frameGrid.Rows.Clear();
            sendButton.Click += async (_, _) => await SendAsync();

            aboutMenuItem.Click += (_, _) => ShowAbout();
            loadTreeMenuItem.Click += (_, _) => ShowToast("Load Tree not implemented yet.");
            saveTreeMenuItem.Click += (_, _) => ShowToast("Save Tree not implemented yet.");
            traceMenuItem.Click += (_, _) => new TraceForm().Show(this);
            simulatorMenuItem.Click += (_, _) => new SimulatorForm().Show(this);
            commanderDirectoryMenuItem.Click += (_, _) => ShowToast("Commander directory picker not implemented yet.");
            newCommanderMenuItem.Click += (_, _) => new CommanderForm().Show(this);
            openCansoleMenuItem.Click += (_, _) => new CansoleForm().Show(this);

            sortItemsLiveMenuItem.CheckedChanged += (_, _) => _sortItemsLive = sortItemsLiveMenuItem.Checked;
            enableIdMenuItem.CheckedChanged += (_, _) => ToggleColumnVisibility(idColumn, enableIdMenuItem.Checked);
            enableDlcMenuItem.CheckedChanged += (_, _) => ToggleColumnVisibility(dlcColumn, enableDlcMenuItem.Checked);
            enableCountMenuItem.CheckedChanged += (_, _) => ToggleColumnVisibility(countColumn, enableCountMenuItem.Checked);
            enablePeriodMenuItem.CheckedChanged += (_, _) => ToggleColumnVisibility(periodColumn, enablePeriodMenuItem.Checked);
            enableRawDataMenuItem.CheckedChanged += (_, _) => ToggleColumnVisibility(rawDataColumn, enableRawDataMenuItem.Checked);
            enableDecodedMenuItem.CheckedChanged += (_, _) => ToggleColumnVisibility(decodedDataColumn, enableDecodedMenuItem.Checked);
            enableFormatMenuItem.CheckedChanged += (_, _) => ToggleColumnVisibility(formatColumn, enableFormatMenuItem.Checked);

            adapterComboBox.SelectedIndexChanged += (_, _) => UpdateStatus($"Selected adapter: {adapterComboBox.SelectedItem}");

            frameGrid.RowsAdded += (_, _) => ApplySorting();
            Text = "CAN Monitor 3000 (C# port)";
            connectionStatusLabel.Text = "Adapter: disconnected";
            generalStatusLabel.Text = "Ready";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _busService.Dispose();
            base.OnFormClosing(e);
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
            try
            {
                _busService.StartSimulation();
                UpdateStatus("Simulation started");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Simulation failed: {ex.Message}");
            }
        }

        private async Task SendAsync()
        {
            try
            {
                var id = HexUtils.ParseHexId(sendIdTextBox.Text);
                var data = HexUtils.ParseHexData(sendDataTextBox.Text);
                var frame = new CanFrame { Id = id, Data = data };
                await _busService.SendAsync(frame).ConfigureAwait(false);
                UpdateStatus($"Sent frame 0x{id:X3}");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Send failed: {ex.Message}");
            }
        }

        private void BusServiceOnFrameReceived(object? sender, CanFrame frame)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => HandleFrame(frame)));
            }
            else
            {
                HandleFrame(frame);
            }
        }

        private void HandleFrame(CanFrame frame)
        {
            var count = _frameCounts.TryGetValue(frame.Id, out var currentCount) ? currentCount + 1 : 1;
            _frameCounts[frame.Id] = count;

            double? periodMs = null;
            if (_lastFrameTimes.TryGetValue(frame.Id, out var lastTime))
            {
                periodMs = (frame.Timestamp - lastTime).TotalMilliseconds;
            }
            _lastFrameTimes[frame.Id] = frame.Timestamp;

            var decoded = _formatParser.TryFormat(frame, formatStringTextBox.Text, out var result)
                ? result
                : string.Empty;

            var nodeText = $"{frame.HexId} ({frame.Length} bytes)";
            var existingNode = frameTree.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text.StartsWith(frame.HexId, StringComparison.OrdinalIgnoreCase));
            if (existingNode == null)
            {
                frameTree.Nodes.Add(new TreeNode(nodeText));
            }
            else
            {
                existingNode.Text = nodeText;
            }

            frameGrid.Rows.Add(
                frame.HexId,
                frame.Length,
                count,
                periodMs?.ToString("F1"),
                frame.DataAsHex,
                decoded,
                formatStringTextBox.Text);

            ApplySorting();
        }

        private void ApplySorting()
        {
            if (!_sortItemsLive)
            {
                return;
            }

            frameGrid.Sort(idColumn, System.ComponentModel.ListSortDirection.Ascending);
        }

        private void BusServiceOnConnectionStateChanged(object? sender, bool connected)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateConnectionState(connected)));
            }
            else
            {
                UpdateConnectionState(connected);
            }
        }

        private void UpdateConnectionState(bool connected)
        {
            connectionStatusLabel.Text = connected ? "Adapter: connected" : "Adapter: disconnected";
            generalStatusLabel.Text = connected ? "Ready" : "Disconnected";
        }

        private void UpdateStatus(string message)
        {
            generalStatusLabel.Text = message;
        }

        private void ToggleColumnVisibility(DataGridViewColumn column, bool isVisible)
        {
            column.Visible = isVisible;
        }

        private static void ShowToast(string message)
        {
            MessageBox.Show(message, "CAN Monitor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void ShowAbout()
        {
            MessageBox.Show("CAN Monitor 3000 (C#)\nPorted from Qt project with modules for monitoring, transmit, and tools.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
