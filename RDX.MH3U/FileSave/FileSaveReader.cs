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

        await LoadCharacter();
        await LoadItemsPouch();
        await LoadItemsBox();
        await LoadEquipmentBox();
    }

    private static async Task LoadCharacter()
    {
        Character obj = _save.Character;

        obj.Name = await ReadSizeAtAs<string>(
            Constants.NameOffset, Constants.NameLength);

        obj.Gender = await ReadSizeAtAs<bool>(
            Constants.GenderOffset, Constants.GenderLength)
                ? Character.CharacterGender.Fermale
                : Character.CharacterGender.Male;

        obj.Zenny = await ReadSizeAtAs<uint>(
            Constants.MoneyOffset, Constants.MoneyLength);

        obj.Points = await ReadSizeAtAs<uint>(
            Constants.PointsOffset, Constants.PointsLength);
    }

    private static async Task LoadItemsBox()
    {
        for (int i = 0; i < (Constants.ItemsBoxLength / Constants.ItemFullLength); i++)
        {
            byte[] buffer = new byte[Constants.ItemFullLength];

            _stream.Seek(Constants.ItemsBoxOffset + (i * Constants.ItemFullLength), SeekOrigin.Begin);
            await _stream.ReadExactlyAsync(buffer, 0, Constants.ItemFullLength);

            byte[] valueBytes = buffer[Constants.ItemsItemStartPos..Constants.ItemsQuantityStartPos];
            string hex = ByteArrayExtensions.GetHexFromDecimal255(valueBytes, true)
                .PadLeft(Constants.ItemFullLength, '0');
            HexValue value = HexData.Collection[HexValueCategory.Items, hex];

            byte[] quantityBytes = buffer[Constants.ItemsQuantityStartPos..Constants.ItemFullLength];
            ushort quantity = ByteArrayExtensions.CastBytesAs<ushort>(quantityBytes);

            _save.ItemsBox[i] = new BoxItem(value, quantity);
        }
    }

    private static async Task LoadItemsPouch()
    {
        for (int i = 0; i < (Constants.ItemsPouchLength / Constants.ItemFullLength); i++)
        {
            byte[] buffer = new byte[Constants.ItemFullLength];

            _stream.Seek(Constants.ItemsPouchOffset + (i * Constants.ItemFullLength), SeekOrigin.Begin);
            await _stream.ReadExactlyAsync(buffer, 0, Constants.ItemFullLength);

            byte[] valueBytes = buffer[Constants.ItemsItemStartPos..Constants.ItemsQuantityStartPos];
            string hex = ByteArrayExtensions.GetHexFromDecimal255(valueBytes, true)
                .PadLeft(Constants.ItemFullLength, '0');
            HexValue value = HexData.Collection[HexValueCategory.Items, hex];

            byte[] quantityBytes = buffer[Constants.ItemsQuantityStartPos..Constants.ItemFullLength];
            ushort quantity = ByteArrayExtensions.CastBytesAs<ushort>(quantityBytes);

            _save.ItemsPouch[i] = new BoxItem(value, quantity);
        }
    }

    private static async Task LoadEquipmentBox()
    {
        for (int i = 0; i < (Constants.EquipmentBoxLength / Constants.EquipmentLength); i++)
        {
            byte[] buffer = new byte[Constants.EquipmentLength];

            _stream.Seek(Constants.EquipmentBoxOffset + (i * Constants.EquipmentLength), SeekOrigin.Begin);
            await _stream.ReadExactlyAsync(buffer, 0, Constants.EquipmentLength);

            _save.EquipmentBox[i] = ResolveBuffer(buffer);
        }
    }

    private static EquipmentItemBase ResolveBuffer(byte[] buffer)
    {
        byte prefix = buffer[Constants.EquipmentCategoryPosition];
        HexValueCategory category = HexData.Prefixes[prefix];

        if (HexData.ArmorCategories.Contains(category))
        {
            return new ArmorEquipmentItem(category, buffer);
        }
        if (HexData.WeaponsCategories.Contains(category))
        {
            return new WeaponEquipmentItem(category, buffer);
        }
        if (category == HexValueCategory.Charm)
        {
            return new CharmEquipmentItem(category, buffer);
        }

        return new EquipmentItemBase();
    }

    private static async Task<T> ReadSizeAtAs<T>(int offset, int size)
    {
        byte[] buffer = new byte[size];

        _stream.Seek(offset, SeekOrigin.Begin);
        await _stream.ReadExactlyAsync(buffer, 0, size);

        return ByteArrayExtensions.CastBytesAs<T>(buffer);
    }
}
