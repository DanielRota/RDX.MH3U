using RDX.MH3U.FileSave.Models;
using RDX.MH3U.Hex;

namespace RDX.MH3U.Forms;

public partial class EquipmentForm : Form
{
    private bool _initializing = true;

    private HexValueCategory _category;

    private readonly ItemCell<EquipmentItemBase> _cell;
    private HexValue[] _items = Array.Empty<HexValue>();

    private EquipmentItemBase Item => _cell.Item;
    private HexValue[] Decorations => HexData.Collection[HexValueCategory.Decoration];
    private HexValue[] Skills => HexData.Collection[HexValueCategory.Skill];

    public EquipmentForm(ItemCell<EquipmentItemBase> cell)
    {
        InitializeComponent();

        _cell = cell;
    }

    private void SetWritten() => Item.Status = HexItemStatus.Written;

    private void EquipmentForm_Load(object sender, EventArgs e)
    {
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
        ConfigureComboBox(cbSkill1);
        ConfigureComboBox(cbSkill2);

        cbClass.DataSource = HexData.Categories;

        cbSlot1.DataSource = Decorations;
        cbSlot2.DataSource = Decorations;
        cbSlot3.DataSource = Decorations;

        cbSkill1.DataSource = Skills;
        cbSkill2.DataSource = Skills;
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

        if (Item is ArmorEquipmentItem armor)
        {
            txtUpgrade.Text = armor.UpgradeLevel.ToString();

            return;
        }
        if (Item is CharmEquipmentItem charm)
        {
            cbSkill1.SelectedIndex = GetIndex(Skills, charm.Skill_1);
            cbSkill2.SelectedIndex = GetIndex(Skills, charm.Skill_2);

            txtPoints1.Text = charm.SkillPoints_1.ToString();
            txtPoints2.Text = charm.SkillPoints_2.ToString();

            txtSlots.Text = charm.SlotsCount.ToString();

            return;
        }
    }

    private void SetCategory(HexValueCategory category)
    {
        _category = category;

        _items = HexData.Collection[category];
        cbValue.DataSource = _items;

        txtUpgrade.Enabled = HexData.ArmorCategories.Contains(category);

        cbSkill1.Enabled = category == HexValueCategory.Charm;
        cbSkill2.Enabled = category == HexValueCategory.Charm;
        txtPoints1.Enabled = category == HexValueCategory.Charm;
        txtPoints2.Enabled = category == HexValueCategory.Charm;
        txtSlots.Enabled = category == HexValueCategory.Charm;
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
        SetWritten();
    }

    private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_initializing ||
            cbValue.SelectedItem is not HexValue value ||
            Item.Value == value)
        {
            return;
        }

        Item.Value = value;
        SetWritten();
    }

    private void txtUpgrade_TextChanged(object sender, EventArgs e)
    {
        if (ushort.TryParse(txtUpgrade.Text, out var level) && level >= 0 &&
            Item is ArmorEquipmentItem armor &&
            armor.UpgradeLevel != level)
        {
            armor.UpgradeLevel = level;
            SetWritten();
        }
    }

    private void txtUpgrade_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }

    private void UpdateComboValue(ComboBox combo, Action<HexValue> setter)
    {
        if (_initializing ||
            combo.SelectedItem is not HexValue value)
        {
            return;
        }

        setter(value);
        SetWritten();
    }

    private void cbSlot1_SelectedIndexChanged(object sender, EventArgs e) =>
        UpdateComboValue(cbSlot1, value => Item.DecoValue_1 = value);

    private void cbSlot2_SelectedIndexChanged(object sender, EventArgs e) =>
        UpdateComboValue(cbSlot2, value => Item.DecoValue_2 = value);

    private void cbSlot3_SelectedIndexChanged(object sender, EventArgs e) =>
        UpdateComboValue(cbSlot3, value => Item.DecoValue_3 = value);

    private void cbSkill1_SelectedIndexChanged(object sender, EventArgs e) =>
        UpdateComboValue(cbSkill1, value =>
        {
            if (Item is CharmEquipmentItem charm)
            {
                charm.Skill_1 = value;
                SetWritten();
            }
        });

    private void cbSkill2_SelectedIndexChanged(object sender, EventArgs e) =>
        UpdateComboValue(cbSkill2, value =>
        {
            if (Item is CharmEquipmentItem charm)
            {
                charm.Skill_2 = value;
                SetWritten();
            }
        });

    private void EquipmentForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }

    private void txtPoints1_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }

    private void txtPoints2_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }

    private void txtPoints1_TextChanged(object sender, EventArgs e)
    {
        if (int.TryParse(txtPoints1.Text, out var points1) &&
            Item is CharmEquipmentItem charm &&
            charm.SkillPoints_1 != points1)
        {
            charm.SkillPoints_1 = points1;
            SetWritten();
        }
    }

    private void txtPoints2_TextChanged(object sender, EventArgs e)
    {
        if (int.TryParse(txtPoints2.Text, out var points2) &&
            Item is CharmEquipmentItem charm &&
            charm.SkillPoints_2 != points2)
        {
            charm.SkillPoints_2 = points2;
            SetWritten();
        }
    }

    private void txtSlots_TextChanged(object sender, EventArgs e)
    {
        if (int.TryParse(txtSlots.Text, out var slots) &&
            Item is CharmEquipmentItem charm &&
            charm.SlotsCount != slots &&
            slots >= 0 && slots <= 3)
        {
            charm.SlotsCount = slots;
            SetWritten();
        }
    }

    private void txtSlots_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }
}
