using RDX.MH3U.FileSave.Models;
using RDX.MH3U.Hex;

namespace RDX.MH3U.Forms;

public partial class ItemForm : Form
{
    private bool _initializing;

    private readonly ItemCell<BoxItem> _cell;
    private readonly HexValue[] _items = HexData.Collection[HexValueCategory.Items];

    private BoxItem Item
    {
        get => _cell.Item;
        set => _cell.Item = value;
    }

    public ItemForm(ItemCell<BoxItem> cell)
    {
        InitializeComponent();
        _cell = cell;
    }

    private void ItemForm_Load(object sender, EventArgs e)
    {
        _initializing = true;

        cbValue.ValueMember = nameof(HexValue.Hex);
        cbValue.DisplayMember = nameof(HexValue.Description);
        cbValue.DataSource = _items;

        if (Item != null)
        {
            cbValue.SelectedIndex = Array.FindIndex(
                _items,
                x => x.Hex == Item.Value.Hex);

            txtCount.Text = Item.Quantity.ToString();
        }
        else
        {
            cbValue.SelectedIndex = -1;
            txtCount.Text = "0";
        }

        _initializing = false;
    }

    private void ItemForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _cell.Selected = false;
        _cell.Update();
    }

    private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_initializing || cbValue.SelectedItem is not HexValue value)
        {
            return;
        }

        if (Item == null)
        {
            Item = new BoxItem(value, 0);
            _cell.AddItem(Item);
        }
        else
        {
            Item.Value = value;
        }

        Item.Status = HexItemStatus.Written;
    }

    private void txtCount_TextChanged(object sender, EventArgs e)
    {
        if (_initializing || Item == null)
        {
            return;
        }

        if (ushort.TryParse(txtCount.Text, out ushort quantity) && quantity > 0)
        {
            Item.Quantity = quantity;
            Item.Status = HexItemStatus.Written;
            return;
        }

        if (!string.IsNullOrWhiteSpace(txtCount.Text))
        {
            txtCount.Undo();
        }
    }
}
