using RDX.MH3U.Extensions;
using RDX.MH3U.Hex;

namespace RDX.MH3U.FileSave.Models;

public class EquipmentItemBase
{
    private static readonly byte[] PlaceholderBuffer = new byte[Constants.EquipmentLength];

    public EquipmentItemBase() => ParseBuffer(HexValueCategory.Placeholder, PlaceholderBuffer);

    public EquipmentItemBase(HexValueCategory category, byte[] buffer) => ParseBuffer(category, buffer);

    public HexItemStatus Status { get; set; } = HexItemStatus.Read;

    public HexValue Value { get; set; }

    public HexValue DecoValue_1 { get; set; }
    public HexValue DecoValue_2 { get; set; }
    public HexValue DecoValue_3 { get; set; }

    public HexValueCategory Category => Value.Category;

    protected virtual void ParseBuffer(HexValueCategory category, byte[] buffer)
    {
        Value = ParseValue(category, buffer);

        byte[] deco_1 = buffer[Constants.DecoStartPosition_1..Constants.DecoStartPosition_2];
        string decoHex_1 = ByteArrayExtensions.GetHexFromDecimal255(deco_1, true);
        DecoValue_1 = HexData.Collection[HexValueCategory.Decoration, decoHex_1];

        byte[] deco_2 = buffer[Constants.DecoStartPosition_2..Constants.DecoStartPosition_3];
        string decoHex_2 = ByteArrayExtensions.GetHexFromDecimal255(deco_2, true);
        DecoValue_2 = HexData.Collection[HexValueCategory.Decoration, decoHex_2];

        byte[] deco_3 = buffer[Constants.DecoStartPosition_3..Constants.DecoEndPosition_3];
        string decoHex_3 = ByteArrayExtensions.GetHexFromDecimal255(deco_3, true);
        DecoValue_3 = HexData.Collection[HexValueCategory.Decoration, decoHex_3];
    }

    protected virtual HexValue ParseValue(HexValueCategory category, byte[] buffer)
    {
        byte[] bytes = ByteArrayExtensions.SelectIndexes(
            buffer,
            Constants.EquipmentValuePosition_2,
            Constants.EquipmentValuePosition_1);
        string hex = ByteArrayExtensions.GetHexFromDecimal255(bytes);
        return HexData.Collection[category, hex];
    }
}
