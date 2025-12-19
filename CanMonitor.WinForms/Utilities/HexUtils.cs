using System;
using System.Collections.Generic;
using System.Globalization;

namespace CanMonitor.WinForms.Utilities
{
    internal static class HexUtils
    {
        public static bool TryParseBytes(string? text, out byte[] result)
        {
            result = Array.Empty<byte>();
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            var sanitized = text.Replace(",", " ").Replace("-", " ");
            var tokens = sanitized.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var bytes = new List<byte>();

            foreach (var token in tokens)
            {
                if (!byte.TryParse(token, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var value))
                {
                    return false;
                }

                bytes.Add(value);
            }

            result = bytes.ToArray();
            return true;
        }
    }
}
