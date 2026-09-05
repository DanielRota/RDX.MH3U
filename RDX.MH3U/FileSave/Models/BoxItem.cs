using RDX.MH3U.Hex;

namespace RDX.MH3U.FileSave.Models;

public class BoxItem(
    HexValue Value,
    ushort Quantity)
{
    public HexItemStatus Status { get; set; } = HexItemStatus.Read;

    public HexValue Value { get; set; } = Value;

    private ushort _quantity = Quantity;
    public ushort Quantity
    {
        get => _quantity;
        set
        {
            if (value < 0 || value > 99)
            {
                throw new ArgumentOutOfRangeException(nameof(Quantity));
            }

            _quantity = value;
        }
    }
}
