using RDX.MH3U.Extensions;
using RDX.MH3U.FileSave.Models;
using RDX.MH3U.Hex;

namespace RDX.MH3U.FileSave;

public static class FileSaveWriter
{
    private static FileSaveObject _save;
    private static FileStream _stream;

    public static async Task WriteChanges(FileSaveObject save, FileStream stream)
    {
        _save = save;
        _stream = stream;

        await WriteCharacter();
        await WriteItemsBox();
        await WriteEquipmentBox();
    }

    private static async Task WriteCharacter()
    {
        Character obj = _save.Character;

        await WriteValueAt(obj.Name,
            Constants.NameOffset,
            Constants.NameLength);

        await WriteValueAt((int)obj.Gender,
            Constants.GenderOffset,
            Constants.GenderLength);

        await WriteValueAt(obj.Zenny,
            Constants.MoneyOffset,
            Constants.MoneyLength);

        await WriteValueAt(obj.Points,
            Constants.PointsOffset,
            Constants.PointsLength);
    }

    private static async Task WriteItemsBox()
    {
        for (int i = 0; i < _save.ItemsBox.Length; i++)
        {
            BoxItem item = _save.ItemsBox[i];

            if (item.Status != HexItemStatus.Written)
            {
                continue;
            }

            var offset = Constants.ItemsBoxOffset + (i * Constants.ItemFullLength);
            var buffer = item.Value.GetBytesOrDefault(Constants.ItemIdentifierLength);

            int pos = 0;
            for (int j = Constants.ItemIdentifierLength - 1; j >= 0; j--)
            {
                await WriteByteAt(
                    buffer?[j] ?? 0,
                    offset + pos++);
            }

            await WriteByteAt(
                (byte)(buffer != null ? item.Quantity : 0),
                offset + Constants.ItemQuantityLength);
        }
    }

    private static async Task WriteEquipmentBox()
    {
        for (int i = 0; i < _save.EquipmentBox.Length; i++)
        {
            EquipmentItem item = _save.EquipmentBox[i];

            if (item.Status != HexItemStatus.Written)
            {
                continue;
            }

            var offset = Constants.EquipmentBoxOffset + (i * Constants.EquipmentLength);

            var prefix = HexData.Prefixes.First(x => x.Value == item.Category);
            await WriteByteAt(prefix.Key, offset);

            await WriteByteAt((byte)item.UpgradeLevel,
                offset + Constants.UpgradeLevelPosition);

            var Value = item.Value.GetBytesOrDefault(Constants.ItemIdentifierLength);
            var Deco_1 = item.DecoValue_1.GetBytesOrDefault(Constants.ItemIdentifierLength);
            var Deco_2 = item.DecoValue_2.GetBytesOrDefault(Constants.ItemIdentifierLength);
            var Deco_3 = item.DecoValue_3.GetBytesOrDefault(Constants.ItemIdentifierLength);

            int pos = 0;
            for (int j = Constants.EquipmentIdentifierLength - 1; j >= 0; j--)
            {
                await WriteByteAt(
                    Value?[j] ?? 0,
                    offset + Constants.EquipmentIdentifierStartPosition + pos++);
            }
            for (int j = 0; j < Constants.EquipmentIdentifierLength; j++)
            {
                await WriteByteAt(
                    Deco_1?[j] ?? 0,
                    offset + Constants.DecoStartPosition_1 + j);
            }
            for (int j = 0; j < Constants.EquipmentIdentifierLength; j++)
            {
                await WriteByteAt(
                    Deco_2?[j] ?? 0,
                    offset + Constants.DecoStartPosition_2 + j);
            }
            for (int j = 0; j < Constants.EquipmentIdentifierLength; j++)
            {
                await WriteByteAt(
                    Deco_3?[j] ?? 0,
                    offset + Constants.DecoStartPosition_3 + j);
            }
        }
    }

    private static async Task WriteValueAt(object value, int offset, int size)
    {
        byte[] buffer = ByteArrayExtensions
            .GetBytesOfLength(value, size);

        _stream.Seek(offset, SeekOrigin.Begin);
        await _stream.WriteAsync(buffer, 0, buffer.Length);
    }

    private static async Task WriteByteAt(byte b, int offset)
    {
        _stream.Seek(offset, SeekOrigin.Begin);
        _stream.WriteByte(b);
    }
}
