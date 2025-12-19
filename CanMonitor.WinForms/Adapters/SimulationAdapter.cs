using System;
using System.Threading.Tasks;
using System.Timers;
using CanMonitor.WinForms.Models;
using CanMonitor.WinForms.Utilities;

namespace CanMonitor.WinForms.Adapters
{
    public sealed class SimulationAdapter : ICanAdapter
    {
        private readonly Timer _timer;
        private readonly Random _random = new();
        private bool _isConnected;

        public event EventHandler<CanFrame>? FrameReceived;

        public string Name => "Built-in Simulation";
        public bool IsConnected => _isConnected;

        public SimulationAdapter()
        {
            _timer = new Timer(500)
            {
                AutoReset = true
            };
            _timer.Elapsed += OnTimerElapsed;
        }

        public Task ConnectAsync()
        {
            _isConnected = true;
            _timer.Start();
            return Task.CompletedTask;
        }

        public Task DisconnectAsync()
        {
            _timer.Stop();
            _isConnected = false;
            return Task.CompletedTask;
        }

        public void StartSimulation()
        {
            if (_isConnected && !_timer.Enabled)
            {
                _timer.Start();
            }
        }

        public Task SendAsync(CanFrame frame)
        {
            // In a real adapter this would pass the frame to the hardware driver.
            // During simulation we simply echo it back with a short delay so the UI
            // can display how outgoing traffic would look.
            var copy = frame with { Timestamp = DateTimeOffset.Now };
            FrameReceived?.Invoke(this, copy);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer.Elapsed -= OnTimerElapsed;
            _timer.Dispose();
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            if (!_isConnected)
            {
                return;
            }

            var id = _random.Next(0x100, 0x7FF);
            var length = _random.Next(1, 8);
            Span<byte> data = stackalloc byte[8];
            for (var i = 0; i < length; i++)
            {
                data[i] = (byte)_random.Next(0, 255);
            }

            var frame = new CanFrame
            {
                Timestamp = DateTimeOffset.Now,
                Id = id,
                Data = data[..length].ToArray()
            };

            FrameReceived?.Invoke(this, frame);
        }
    }
}
