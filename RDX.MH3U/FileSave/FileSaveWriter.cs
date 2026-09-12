using RDX.MH3U.Extensions;
using RDX.MH3U.FileSave.Models;
using RDX.MH3U.Hex;

namespace RDX.MH3U.FileSave;

public static class FileSaveWriter
{
    private static FileSaveObject _save;
    private static FileStream _stream;

    private static int _offset;

    public static async Task WriteChanges(FileSaveObject save, FileStream stream)
    {
        _save = save;
        _stream = stream;

        await WriteCharacter();
        await WriteItemsPouch();
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

            _offset = Constants.ItemsBoxOffset + (i * Constants.ItemFullLength);

            await WriteItemValue(item);
            await WriteItemQuantity(item);
        }
    }

    private static async Task WriteItemsPouch()
    {
        for (int i = 0; i < _save.ItemsPouch.Length; i++)
        {
            BoxItem item = _save.ItemsPouch[i];

            if (item.Status != HexItemStatus.Written)
            {
                continue;
            }

            _offset = Constants.ItemsPouchOffset + (i * Constants.ItemFullLength);

            await WriteItemValue(item);
            await WriteItemQuantity(item);
        }
    }

    private static async Task WriteItemValue(BoxItem item)
    {
        var buffer = item.Value.GetBytesOrDefault(Constants.ItemIdentifierLength);

        int pos = 0;
        for (int j = Constants.ItemIdentifierLength - 1; j >= 0; j--)
        {
            await WriteByteAt(
                buffer[j], _offset + pos++);
        }
    }

    private static async Task WriteItemQuantity(BoxItem item)
    {
        await WriteByteAt((byte)item.Quantity,
            _offset + Constants.ItemQuantityLength);
    }

    private static async Task WriteEquipmentBox()
    {
        for (int i = 0; i < _save.EquipmentBox.Length; i++)
        {
            EquipmentItemBase item = _save.EquipmentBox[i];

            if (item.Status != HexItemStatus.Written)
            {
                continue;
            }

            _offset = Constants.EquipmentBoxOffset + (i * Constants.EquipmentLength);

            await WriteEquipmentCategory(item);
            await WriteEquipmentUpgradeLevel(item);
            await WriteEquipmentValue(item);
            await WriteEquipmentDecorations(item);
            await WriteEquipmentCustom(item);
        }
    }

    private static async Task WriteEquipmentCategory(EquipmentItemBase item)
    {
        KeyValuePair<byte, HexValueCategory> prefix = HexData.Prefixes
            .First(x => x.Value == item.Category);

        await WriteByteAt(prefix.Key, _offset);
    }

    private static async Task WriteEquipmentDecorations(EquipmentItemBase item)
    {
        byte[] deco_1 = item.DecoValue_1.GetBytesOrDefault(Constants.ItemIdentifierLength);
        byte[] deco_2 = item.DecoValue_2.GetBytesOrDefault(Constants.ItemIdentifierLength);
        byte[] deco_3 = item.DecoValue_3.GetBytesOrDefault(Constants.ItemIdentifierLength);

        int pos = 0;
        for (int j = Constants.EquipmentIdentifierLength - 1; j >= 0; j--)
        {
            await WriteByteAt(deco_1[j],
                _offset + Constants.DecoStartPosition_1 + pos++);
        }
        pos = 0;
        for (int j = Constants.EquipmentIdentifierLength - 1; j >= 0; j--)
        {
            await WriteByteAt(deco_2[j],
                _offset + Constants.DecoStartPosition_2 + pos++);
        }
        pos = 0;
        for (int j = Constants.EquipmentIdentifierLength - 1; j >= 0; j--)
        {
            await WriteByteAt(deco_3[j],
                _offset + Constants.DecoStartPosition_3 + pos++);
        }
    }

    private static async Task WriteEquipmentValue(EquipmentItemBase item) =>
        await item.WriteEquipmentValue(_stream, _offset);

    private static async Task WriteEquipmentUpgradeLevel(EquipmentItemBase item) =>
        await item.WriteEquipmentUpgradeLevel(_stream, _offset);

    private static async Task WriteEquipmentCustom(EquipmentItemBase item) =>
        await item.WriteEquipmentCustom(_stream, _offset);

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
