using RDX.MH3U.FileSave;
using RDX.MH3U.FileSave.Models;
using RDX.MH3U.Forms;
using RDX.MH3U.Hex;

namespace RDX.MH3U;

public partial class MainForm : Form
{
    public static string DataPath => Path.Combine(Environment.CurrentDirectory, "hex_data.csv");

    public string FileSavePath;
    public FileSaveObject FileSaveObj = new();
    public FileStream FileStream;

    public BoxForm<BoxItem> ItemsBoxForm;
    public BoxForm<BoxItem> ItemsPouchForm;
    public BoxForm<EquipmentItem> EquipmentForm;

    public MainForm() => InitializeComponent();

    private async void MainForm_Load(object sender, EventArgs e) => await HexData.Collection.AddFromCSV(DataPath);

    private async void btnLoad_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new();

        if (dialog.ShowDialog() == DialogResult.OK &&
            ValidFile(dialog.FileName))
        {
            try
            {
                FileSavePath = dialog.FileName;
                FileStream = new FileStream(
                    FileSavePath,
                    FileMode.OpenOrCreate,
                    FileAccess.ReadWrite);

                await FileSaveReader.Load(FileSaveObj, FileStream);
                LoadInterface();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"ERR: {ex.Message}",
                    "Error Occured",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }

    private bool ValidFile(string path)
    {
        var info = new FileInfo(path);

        if (info.Extension != string.Empty || info.Length != Constants.FileSaveSize)
        {
            MessageBox.Show(
                $"File save must be {Constants.FileSaveSize} bytes long and without extension.",
                "Invalid File",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (cbBackup.Checked)
        {
            try
            {
                FileSaveBackup.Create(FileSavePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"ERR: {ex.Message}",
                    "Error Occured",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
        }

        await FileSaveWriter.WriteChanges(FileSaveObj, FileStream);
    }

    private void btnOpenEquipBox_Click(object sender, EventArgs e)
    {
        const int EquipBoxCols = 10;
        const int EquipBoxRows = 10;

        Action<EquipmentItem, int> addHandler = (EquipmentItem obj, int index) =>
        {
            FileSaveObj.EquipmentBox[index] = obj;
        };

        EquipmentForm ??= new BoxForm<EquipmentItem>(
            EquipBoxCols,
            EquipBoxRows,
            FileSaveObj.EquipmentBox,
            (item, index) => new EquipmentCell(item, addHandler, index));

        EquipmentForm.ShowDialog();
    }

    private void btnOpenItemsChest_Click(object sender, EventArgs e)
    {
        const int ChestBoxCols = 10;
        const int ChestBoxRows = 10;

        Action<BoxItem, int> addHandler = (BoxItem obj, int idx) =>
        {
            FileSaveObj.ItemsBox[idx] = obj;
        };

        ItemsBoxForm ??= new BoxForm<BoxItem>(
            ChestBoxCols,
            ChestBoxRows,
            FileSaveObj.ItemsBox,
            (item, index) => new ItemBoxCell(item, addHandler, index));

        ItemsBoxForm.ShowDialog();
    }

    private void btnOpenItemsPouch_Click(object sender, EventArgs e)
    {
        const int PouchBoxCols = 1;
        const int PouchBoxRows = 8;

        Action<BoxItem, int> addHandler = (BoxItem obj, int index) =>
        {
            FileSaveObj.ItemsPouch[index] = obj;
        };

        ItemsPouchForm ??= new BoxForm<BoxItem>(
            PouchBoxCols,
            PouchBoxRows,
            FileSaveObj.ItemsPouch,
            (item, index) => new ItemBoxCell(item, addHandler, index));

        ItemsPouchForm.ShowDialog();
    }

    private void LoadInterface()
    {
        lblPath.Text = FileSavePath;
        txtName.Text = FileSaveObj.Character.Name;
        txtZenny.Text = FileSaveObj.Character.Zenny.ToString();
        txtPoints.Text = FileSaveObj.Character.Points.ToString();
        rdbMale.Checked = FileSaveObj.Character.Gender == Character.CharacterGender.Male;
        rdbFemale.Checked = FileSaveObj.Character.Gender == Character.CharacterGender.Fermale;

        groupBox1.Visible = true;
        groupBox2.Visible = true;
        cbBackup.Visible = true;
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
        FileSaveObj.Character.Name = txtName.Text;
    }

    private void txtZenny_TextChanged(object sender, EventArgs e)
    {
        if (!int.TryParse(txtZenny.Text, out int zenny) || zenny < 0)
        {
            txtZenny.Undo();
        }
        else
        {
            FileSaveObj.Character.Zenny = uint.Parse(txtZenny.Text);
        }
    }

    private void txtPoints_TextChanged(object sender, EventArgs e)
    {
        if (!int.TryParse(txtPoints.Text, out int points) || points < 0)
        {
            txtPoints.Undo();
        }
        else
        {
            FileSaveObj.Character.Points = uint.Parse(txtPoints.Text);
        }
    }

    private void rdbMale_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbMale.Checked)
        {
            FileSaveObj.Character.Gender = Character.CharacterGender.Male;
        }
    }

    private void rdbFemale_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbFemale.Checked)
        {
            FileSaveObj.Character.Gender = Character.CharacterGender.Fermale;
        }
    }
}
