using RDX.MH3U.Hex;

namespace RDX.MH3U.FileSave.Models;

public class EquipmentItem(
    HexValue Value,
    HexValue DecoValue_1,
    HexValue DecoValue_2,
    HexValue DecoValue_3,
    ushort UpgradeLevel)
{
    public HexItemStatus Status { get; set; } = HexItemStatus.Read;

    public HexValue Value { get; set; } = Value;
    public HexValue DecoValue_1 { get; set; } = DecoValue_1;
    public HexValue DecoValue_2 { get; set; } = DecoValue_2;
    public HexValue DecoValue_3 { get; set; } = DecoValue_3;

    private ushort _upgradeLevel = UpgradeLevel;
    public ushort UpgradeLevel
    {
        get => _upgradeLevel;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(UpgradeLevel));
            }

            _upgradeLevel = HexData.ArmorCategories.Contains(Category) ? value : (ushort)0;
        }
    }

    public HexValueCategory Category => Value.Category;
}
