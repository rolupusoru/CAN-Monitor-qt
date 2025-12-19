using System;
using System.Globalization;
using System.Linq;

namespace CanMonitor.WinForms.Models
{
    public record CanFrame
    {
        public DateTimeOffset Timestamp { get; init; } = DateTimeOffset.Now;

        public int Id { get; init; }

        public byte[] Data { get; init; } = Array.Empty<byte>();

        public int Length => Data?.Length ?? 0;

        public string HexId => $"0x{Id:X3}";

        public string DataAsHex => string.Join(" ", Data.Select(b => b.ToString("X2", CultureInfo.InvariantCulture)));
    }
}
