using System;
using System.Threading.Tasks;
using CanMonitor.WinForms.Models;

namespace CanMonitor.WinForms.Adapters
{
    public interface ICanAdapter : IDisposable
    {
        string Name { get; }
        bool IsConnected { get; }
        event EventHandler<CanFrame>? FrameReceived;

        Task ConnectAsync();
        Task DisconnectAsync();
        Task SendAsync(CanFrame frame);
        void StartSimulation();
    }
}
