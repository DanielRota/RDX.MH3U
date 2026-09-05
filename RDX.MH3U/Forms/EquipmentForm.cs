using RDX.MH3U.FileSave.Models;
using RDX.MH3U.Hex;

namespace RDX.MH3U.Forms;

public partial class EquipmentForm : Form
{
    private bool _initializing;

    private HexValueCategory _category;

    private readonly ItemCell<EquipmentItem> _cell;
    private HexValue[] _items = Array.Empty<HexValue>();

    private EquipmentItem Item => _cell.Item;
    private HexValue[] Decorations => HexData.Collection[HexValueCategory.Decoration];

    public EquipmentForm(ItemCell<EquipmentItem> cell)
    {
        InitializeComponent();

        _cell = cell;
    }

    private void EquipmentForm_Load(object sender, EventArgs e)
    {
        _initializing = true;

        ConfigureControls();
        LoadEquipment();

        _initializing = false;
    }

    private void ConfigureControls()
    {
        ConfigureComboBox(cbValue);
        ConfigureComboBox(cbSlot1);
        ConfigureComboBox(cbSlot2);
        ConfigureComboBox(cbSlot3);

        cbClass.DataSource = HexData.Categories;

        cbSlot1.DataSource = Decorations;
        cbSlot2.DataSource = Decorations;
        cbSlot3.DataSource = Decorations;
    }

    private static void ConfigureComboBox(ComboBox combo)
    {
        combo.ValueMember = nameof(HexValue.Hex);
        combo.DisplayMember = nameof(HexValue.Description);
    }

    private void LoadEquipment()
    {
        cbClass.SelectedItem = Item.Category;

        SetCategory(Item.Category);

        cbValue.SelectedItem = HexData.Collection[Item.Category, Item.Value.Hex];

        cbSlot1.SelectedIndex = GetIndex(Decorations, Item.DecoValue_1);
        cbSlot2.SelectedIndex = GetIndex(Decorations, Item.DecoValue_2);
        cbSlot3.SelectedIndex = GetIndex(Decorations, Item.DecoValue_3);

        txtUpgrade.Text = Item.UpgradeLevel.ToString();
    }

    private void SetCategory(HexValueCategory category)
    {
        _category = category;
        _items = HexData.Collection[category];
        cbValue.DataSource = _items;
        txtUpgrade.Enabled = HexData.ArmorCategories.Contains(category);
    }

    private static int GetIndex(HexValue[] values, HexValue value) =>
        Array.FindIndex(values, x => x.Hex == value.Hex && x.Category == value.Category);

    private void EquipmentForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _cell.Selected = false;
        _cell.Update();
    }

    private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_initializing ||
            cbClass.SelectedItem is not HexValueCategory category)
        {
            return;
        }

        if (_category != category)
        {
            cbValue.SelectedIndex = -1;
        }

        SetCategory(category);

        Item.Status = HexItemStatus.Written;
    }

    private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_initializing ||
            cbValue.SelectedItem is not HexValue value)
        {
            return;
        }

        Item.Value = value;
        Item.Status = HexItemStatus.Written;
    }

    private void cbSlot1_SelectedIndexChanged(object sender, EventArgs e) =>
        UpdateDecoration(cbSlot1, value => Item.DecoValue_1 = value);

    private void cbSlot2_SelectedIndexChanged(object sender, EventArgs e) =>
        UpdateDecoration(cbSlot2, value => Item.DecoValue_2 = value);

    private void cbSlot3_SelectedIndexChanged(object sender, EventArgs e) =>
        UpdateDecoration(cbSlot3, value => Item.DecoValue_3 = value);

    private void UpdateDecoration(ComboBox combo, Action<HexValue> setter)
    {
        if (_initializing ||
            combo.SelectedItem is not HexValue value)
        {
            return;
        }

        setter(value);
        Item.Status = HexItemStatus.Written;
    }

    private void txtUpgrade_TextChanged(object sender, EventArgs e)
    {
        if (ushort.TryParse(txtUpgrade.Text, out var level))
        {
            Item.UpgradeLevel = level;
        }
    }

    private void txtUpgrade_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }
}
