using RDX.MH3U.FileSave.Models;

namespace RDX.MH3U.Forms;

public sealed class ItemBoxCell : ItemCell<BoxItem>
{
    public ItemBoxCell(BoxItem item, Action<BoxItem, int> addHandler, int index)
        : base(item, addHandler, index)
    {
    }

    protected override string GetHeaderText() => Item.Quantity.ToString();
    protected override string GetBodyText() => Item.Value.Description;

    protected override void OnItemClick() => new ItemForm(this).ShowDialog();
}
