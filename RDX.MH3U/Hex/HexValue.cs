namespace RDX.MH3U.Hex;

public readonly record struct HexValue(
    string Hex,
    HexValueCategory Category,
    string Description)
{
    public string Hex { get; } = Hex;
    public HexValueCategory Category { get; } = Category;

    public string Description { get; } = Description;

    public static HexValue Placeholder() =>
        new(string.Empty, HexValueCategory.Placeholder, string.Empty);

    public byte[] GetBytesOrDefault(int length) =>
        !string.IsNullOrWhiteSpace(Hex) ? Convert.FromHexString(Hex) : new byte[length];
}
