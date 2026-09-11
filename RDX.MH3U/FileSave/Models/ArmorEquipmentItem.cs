using RDX.MH3U.Hex;

namespace RDX.MH3U.FileSave.Models;

public class ArmorEquipmentItem : EquipmentItemBase
{
    public ArmorEquipmentItem(HexValueCategory category, byte[] buffer)
        : base(category, buffer) => ParseBuffer(category, buffer);

    private ushort _upgradeLevel;
    public ushort UpgradeLevel
    {
        get => _upgradeLevel;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                    $"Armor level can be greater than 0.");
            }

            _upgradeLevel = value;
        }
    }

    protected override void ParseBuffer(HexValueCategory category, byte[] buffer)
    {
        base.ParseBuffer(category, buffer);

        UpgradeLevel = buffer[Constants.UpgradeLevelPosition];
    }
}
