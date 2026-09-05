using RDX.MH3U.FileSave.Models;

namespace RDX.MH3U.Forms;

public sealed class EquipmentCell : ItemCell<EquipmentItem>
{
    public EquipmentCell(EquipmentItem item, Action<EquipmentItem, int> addHandler, int index)
        : base(item, addHandler, index)
    {
    }

    protected override string GetHeaderText() => Item.Category.ToString();
    protected override string GetBodyText() => Item.Value.Description;

    protected override void OnItemClick() => new EquipmentForm(this).ShowDialog();
}
