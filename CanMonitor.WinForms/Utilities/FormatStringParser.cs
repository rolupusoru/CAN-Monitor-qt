using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Globalization;
using CanMonitor.WinForms.Models;

namespace CanMonitor.WinForms.Utilities
{
    internal sealed class FormatStringParser
    {
        private readonly Dictionary<string, Func<ReadOnlySpan<byte>, double>> _readers = new(StringComparer.OrdinalIgnoreCase)
        {
            ["u8"] = data => ReadUnsigned(data, 1, false),
            ["u16"] = data => ReadUnsigned(data, 2, false),
            ["u32"] = data => ReadUnsigned(data, 4, false),
            ["U16"] = data => ReadUnsigned(data, 2, true),
            ["U32"] = data => ReadUnsigned(data, 4, true),
            ["s8"] = data => ReadSigned(data, 1, false),
            ["s16"] = data => ReadSigned(data, 2, false),
            ["s32"] = data => ReadSigned(data, 4, false),
            ["S16"] = data => ReadSigned(data, 2, true),
            ["S32"] = data => ReadSigned(data, 4, true),
            ["f"] = data => ReadFloat(data)
        };

        public bool TryFormat(CanFrame frame, string? formatString, out string result)
        {
            if (string.IsNullOrWhiteSpace(formatString))
            {
                result = string.Empty;
                return true;
            }

            var tokens = formatString.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var offset = 0;
            var parts = new List<string>();
            foreach (var token in tokens)
            {
                if (!TryConsumeToken(frame.Data, token, ref offset, out var segment, out var error))
                {
                    result = error;
                    return false;
                }

                parts.Add(segment);
            }

            result = string.Join(", ", parts);
            return true;
        }

        private bool TryConsumeToken(ReadOnlySpan<byte> data, string token, ref int offset, out string segment, out string error)
        {
            error = string.Empty;
            segment = string.Empty;

            var type = token;
            var multiplier = 1.0;
            var freeText = string.Empty;
            var decimals = (int?)null;

            if (token.Contains(":", StringComparison.Ordinal))
            {
                var parts = token.Split(':', 2);
                type = parts[0];
                freeText = parts[1];
            }

            var typeParts = type.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (typeParts.Length > 1 && double.TryParse(typeParts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var parsedMultiplier))
            {
                multiplier = parsedMultiplier;
                type = typeParts[0];
                var digits = typeParts[1].Split('.', 2);
                if (digits.Length == 2)
                {
                    decimals = digits[1].Length;
                }
            }
            else
            {
                type = typeParts[0];
            }

            var writer = GetWriter(type, out var width);
            if (writer is null)
            {
                error = $"Unsupported type '{type}'.";
                return false;
            }

            if (offset + width > data.Length)
            {
                error = $"Format '{type}' exceeds payload length.";
                return false;
            }

            var slice = data.Slice(offset, width);
            offset += width;
            var rawValue = writer(slice);
            var scaled = rawValue * multiplier;
            var number = decimals.HasValue ? Math.Round(scaled, decimals.Value) : scaled;

            var formattedNumber = decimals.HasValue
                ? number.ToString($"F{decimals.Value}", CultureInfo.InvariantCulture)
                : number.ToString(CultureInfo.InvariantCulture);

            segment = string.IsNullOrWhiteSpace(freeText)
                ? formattedNumber
                : freeText.Replace("%v", formattedNumber, StringComparison.Ordinal);
            return true;
        }

        private Func<ReadOnlySpan<byte>, double>? GetWriter(string type, out int width)
        {
            width = type.Equals("f", StringComparison.OrdinalIgnoreCase) ? 4 : type.Contains("16", StringComparison.Ordinal) ? 2 : type.Contains("32", StringComparison.Ordinal) ? 4 : 1;
            if (_readers.TryGetValue(type, out var reader))
            {
                return reader;
            }

            return null;
        }

        private static double ReadUnsigned(ReadOnlySpan<byte> data, int width, bool bigEndian)
        {
            return (width, bigEndian) switch
            {
                (1, _) => data[0],
                (2, false) => BinaryPrimitives.ReadUInt16LittleEndian(data),
                (2, true) => BinaryPrimitives.ReadUInt16BigEndian(data),
                (4, false) => BinaryPrimitives.ReadUInt32LittleEndian(data),
                (4, true) => BinaryPrimitives.ReadUInt32BigEndian(data),
                _ => 0
            };
        }

        private static double ReadSigned(ReadOnlySpan<byte> data, int width, bool bigEndian)
        {
            return (width, bigEndian) switch
            {
                (1, _) => (sbyte)data[0],
                (2, false) => BinaryPrimitives.ReadInt16LittleEndian(data),
                (2, true) => BinaryPrimitives.ReadInt16BigEndian(data),
                (4, false) => BinaryPrimitives.ReadInt32LittleEndian(data),
                (4, true) => BinaryPrimitives.ReadInt32BigEndian(data),
                _ => 0
            };
        }

        private static double ReadFloat(ReadOnlySpan<byte> data)
        {
            if (data.Length < 4)
            {
                return 0;
            }

            return BitConverter.ToSingle(data[..4]);
        }
    }
}
