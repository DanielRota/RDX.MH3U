using RDX.MH3U.Extensions;
using RDX.MH3U.FileSave.Models;
using RDX.MH3U.Hex;

namespace RDX.MH3U.FileSave;

public static class FileSaveReader
{
    private static FileSaveObject _save;
    private static FileStream _stream;

    public static async Task Load(FileSaveObject save, FileStream stream)
    {
        _save = save;
        _stream = stream;

        await LoadCharacter(_save.Character);
        await LoadChestBox(_save.ItemsBox);
        await LoadEquipmentBox(_save.EquipmentBox);
    }

    private static async Task LoadCharacter(Character obj)
    {
        obj.Name = await ReadSizeAtAs<string>(
            Constants.NameOffset,
            Constants.NameLength);

        obj.Gender = await ReadSizeAtAs<bool>(
            Constants.GenderOffset,
            Constants.GenderLength)
                ? Character.CharacterGender.Fermale
                : Character.CharacterGender.Male;

        obj.Zenny = await ReadSizeAtAs<uint>(
            Constants.MoneyOffset,
            Constants.MoneyLength);

        obj.Points = await ReadSizeAtAs<uint>(
            Constants.PointsOffset,
            Constants.PointsLength);
    }

    private static async Task LoadChestBox(BoxItem[] box)
    {
        for (int i = 0; i < (Constants.ItemsBoxLength / Constants.ItemFullLength); i++)
        {
            byte[] buffer = new byte[Constants.ItemFullLength];

            _stream.Seek(Constants.ItemsBoxOffset + (i * Constants.ItemFullLength), SeekOrigin.Begin);
            await _stream.ReadExactlyAsync(buffer, 0, Constants.ItemFullLength);

            var ValueBytes = buffer[Constants.ItemsBoxItemStartPos..Constants.ItemsBoxQuantityStartPos];
            var Hex = ByteArrayExtensions.GetHexFromDecimal255(ValueBytes, true)
                .PadLeft(Constants.ItemFullLength, '0');
            var Value = HexData.Collection[HexValueCategory.Items, Hex];

            var QuantityBytes = buffer[Constants.ItemsBoxQuantityStartPos..Constants.ItemsBoxQuantityEndPos];
            var Quantity = ByteArrayExtensions.CastBytesAs<ushort>(QuantityBytes);

            box[i] = new BoxItem(Value, Quantity);
        }
    }

    private static async Task LoadEquipmentBox(EquipmentItem[] box)
    {
        for (int i = 0; i < (Constants.EquipmentBoxLength / Constants.EquipmentLength); i++)
        {
            byte[] buffer = new byte[Constants.EquipmentLength];

            _stream.Seek(Constants.EquipmentBoxOffset + (i * Constants.EquipmentLength), SeekOrigin.Begin);
            await _stream.ReadExactlyAsync(buffer, 0, Constants.EquipmentLength);

            var Prefix = buffer[Constants.EquipmentCategoryPosition];
            HexValueCategory category = HexData.Prefixes[Prefix];

            var Bytes = ByteArrayExtensions.SelectIndexes(buffer,
                Constants.EquipmentValuePosition_2,
                Constants.EquipmentValuePosition_1);
            var Hex = ByteArrayExtensions.GetHexFromDecimal255(Bytes);
            var Value = HexData.Collection[category, Hex];

            var Deco_1 = buffer[Constants.DecoStartPosition_1..Constants.DecoStartPosition_2];
            var DecoHex_1 = ByteArrayExtensions.GetHexFromDecimal255(Deco_1, true);
            var DecoValue_1 = HexData.Collection[HexValueCategory.Decoration, DecoHex_1];

            var Deco_2 = buffer[Constants.DecoStartPosition_2..Constants.DecoStartPosition_3];
            var DecoHex_2 = ByteArrayExtensions.GetHexFromDecimal255(Deco_2, true);
            var DecoValue_2 = HexData.Collection[HexValueCategory.Decoration, DecoHex_2];

            var Deco_3 = buffer[Constants.DecoStartPosition_3..Constants.DecoEndPosition_3];
            var DecoHex_3 = ByteArrayExtensions.GetHexFromDecimal255(Deco_3, true);
            var DecoValue_3 = HexData.Collection[HexValueCategory.Decoration, DecoHex_3];

            var UpgradeLevel = buffer[Constants.UpgradeLevelPosition];

            box[i] = new EquipmentItem(Value, DecoValue_1, DecoValue_2, DecoValue_3, UpgradeLevel);
        }
    }

    private static async Task<T> ReadSizeAtAs<T>(int offset, int size)
    {
        byte[] buffer = new byte[size];

        _stream.Seek(offset, SeekOrigin.Begin);
        await _stream.ReadExactlyAsync(buffer, 0, size);

        return ByteArrayExtensions.CastBytesAs<T>(buffer);
    }
}
