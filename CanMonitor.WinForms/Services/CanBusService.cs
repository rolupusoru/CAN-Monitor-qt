using System;
using System.Threading.Tasks;
using CanMonitor.WinForms.Adapters;
using CanMonitor.WinForms.Models;
using CanMonitor.WinForms.Utilities;

namespace CanMonitor.WinForms.Services
{
    internal sealed class CanBusService : IDisposable
    {
        private readonly ICanAdapter _adapter;
        private readonly FormatStringParser _parser = new();
        private bool _disposed;

        public event EventHandler<CanFrame>? FrameReceived;
        public event EventHandler<bool>? ConnectionStateChanged;

        public bool IsConnected => _adapter.IsConnected;
        public string AdapterName => _adapter.Name;

        public CanBusService(ICanAdapter adapter)
        {
            _adapter = adapter;
            _adapter.FrameReceived += AdapterOnFrameReceived;
        }

        public async Task ConnectAsync()
        {
            EnsureNotDisposed();
            if (_adapter.IsConnected)
            {
                return;
            }

            await _adapter.ConnectAsync().ConfigureAwait(false);
            ConnectionStateChanged?.Invoke(this, _adapter.IsConnected);
        }

        public async Task DisconnectAsync()
        {
            EnsureNotDisposed();
            if (!_adapter.IsConnected)
            {
                return;
            }

            await _adapter.DisconnectAsync().ConfigureAwait(false);
            ConnectionStateChanged?.Invoke(this, _adapter.IsConnected);
        }

        public async Task SendAsync(CanFrame frame)
        {
            EnsureNotDisposed();
            await _adapter.SendAsync(frame).ConfigureAwait(false);
        }

        public void StartSimulation()
        {
            EnsureNotDisposed();
            _adapter.StartSimulation();
        }

        public bool TryDecode(CanFrame frame, string? format, out string result)
        {
            EnsureNotDisposed();
            return _parser.TryFormat(frame, format, out result);
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _adapter.FrameReceived -= AdapterOnFrameReceived;
            _adapter.Dispose();
            _disposed = true;
        }

        private void AdapterOnFrameReceived(object? sender, CanFrame e)
        {
            FrameReceived?.Invoke(this, e);
        }

        private void EnsureNotDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(CanBusService));
            }
        }
    }
}
