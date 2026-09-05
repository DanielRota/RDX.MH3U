using System.Text;

namespace RDX.MH3U.Extensions;

public static class ByteArrayExtensions
{
    public static byte[] SelectIndexes(byte[] source, params int[] indexes)
    {
        byte[] buffer = new byte[indexes.Length];

        for (int i = 0; i < indexes.Length; i++)
        {
            buffer[i] = source[indexes[i]];
        }

        return buffer;
    }

    public static T CastBytesAs<T>(byte[] buffer)
    {
        object? result = null;

        switch (typeof(T).Name)
        {
            case "Byte":
                result = buffer[0];
                break;

            case "UInt16":
                result = BitConverter.ToUInt16(buffer, 0);
                break;

            case "UInt32":
                result = BitConverter.ToUInt32(buffer, 0);
                break;

            case "Int32":
                result = BitConverter.ToInt32(buffer, 0);
                break;

            case "String":
                result = Encoding.UTF8.GetString(buffer).Replace("\0", string.Empty);
                break;

            case "Boolean":
                result = BitConverter.ToBoolean(buffer, 0);
                break;

            default:
                throw new NotImplementedException();
        }

        return (T)result;
    }

    public static string GetHexFromDecimal255(byte[] buffer, bool reverse = false)
    {
        var builder = new StringBuilder(buffer.Length * 2);

        for (int i = 0; i < buffer.Length; i++)
        {
            int b = buffer[i];
            var hex = b < 16
                ? GetHexFromDecimal16(b, true)
                : GetHexFromDecimal16(b / 16) + GetHexFromDecimal16(b % 16);

            if (reverse)
            {
                builder.Insert(0, hex);
            }
            else
            {
                builder.Append(hex);
            }
        }

        return builder.ToString();
    }

    private const string HexChars = "0123456789ABCDEF";

    private static string GetHexFromDecimal16(int dec, bool padding = false)
    {
        if (dec > 15)
        {
            throw new InvalidCastException();
        }

        var hex = HexChars[dec].ToString();
        return padding ? hex.PadLeft(2, '0') : hex;
    }

    public static byte[] GetBytesOfLength(object value, int length = 0)
    {
        var source = GetObjectBytes(value);
        return GetBytesOfLength(source, length);
    }

    private static byte[] GetBytesOfLength(byte[] source, int length)
    {
        if (length == 0)
        {
            return source;
        }

        var buffer = new byte[length];
        Array.Copy(source, buffer, Math.Min(length, source.Length));
        return buffer;
    }

    private static byte[] GetObjectBytes(object value)
    {
        switch (value.GetType().Name)
        {
            case "String":
                return Encoding.ASCII.GetBytes(value?.ToString() ?? string.Empty);

            case "Boolean":
                return BitConverter.GetBytes((bool)value);

            case "Int32":
                return BitConverter.GetBytes((int)value);

            case "UInt32":
                return BitConverter.GetBytes((uint)value);

            case "UInt16":
                return BitConverter.GetBytes((ushort)value);

            default:
                throw new NotImplementedException();
        }
    }
}
