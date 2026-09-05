namespace RDX.MH3U.Hex;

public static class HexData
{
    public readonly static HexCollection Collection = new();

    public static HexValueCategory[] ArmorCategories =
    [
        HexValueCategory.Head,
        HexValueCategory.Chest,
        HexValueCategory.Arms,
        HexValueCategory.Waist,
        HexValueCategory.Legs
    ];

    public readonly static Dictionary<byte, HexValueCategory> Prefixes = new()
    {
        { 0x00, HexValueCategory.Placeholder },
        { 0x01, HexValueCategory.Chest },
        { 0x02, HexValueCategory.Arms },
        { 0x03, HexValueCategory.Waist },
        { 0x04, HexValueCategory.Legs },
        { 0x05, HexValueCategory.Head },
        { 0x06, HexValueCategory.Arms },
        { 0x07, HexValueCategory.GreatSword },
        { 0x08, HexValueCategory.SwordAndShield },
        { 0x09, HexValueCategory.Hammer },
        { 0x0A, HexValueCategory.Lance },
        { 0x0B, HexValueCategory.HeavyBowgun },
        { 0x0C, HexValueCategory.DualBlades },
        { 0x0D, HexValueCategory.LightBowgun },
        { 0x0E, HexValueCategory.LongSword },
        { 0x0F, HexValueCategory.SwitchAxe },
        { 0x10, HexValueCategory.Gunlance },
        { 0x11, HexValueCategory.Bow },
        { 0x12, HexValueCategory.DualBlades },
        { 0x13, HexValueCategory.HuntingHorn }
    };

    public readonly static HexValueCategory[] Categories = Prefixes.Select(x => x.Value).ToArray();
}
