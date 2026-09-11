using RDX.MH3U.Hex;

namespace RDX.MH3U.FileSave.Models;

public class WeaponEquipmentItem : EquipmentItemBase
{
    public WeaponEquipmentItem(HexValueCategory category, byte[] buffer)
        : base(category, buffer) => ParseBuffer(category, buffer);
}
