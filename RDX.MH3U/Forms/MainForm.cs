using System.Diagnostics;
using RDX.MH3U.FileSave;
using RDX.MH3U.FileSave.Models;
using RDX.MH3U.Forms;
using RDX.MH3U.Hex;

namespace RDX.MH3U;

public partial class MainForm : Form
{
    private static string DataPath => Path.Combine(Environment.CurrentDirectory, "hex_data.csv");

    private string FileSavePath;
    private readonly FileSaveObject FileSaveObj = new();

    private BoxForm<BoxItem> ItemsBoxForm;
    private BoxForm<BoxItem> ItemsPouchForm;
    private BoxForm<EquipmentItemBase> EquipmentForm;

    public MainForm() => InitializeComponent();

    private void Log(string message) => txtLog.AppendText($" {DateTime.Now.ToString("HH:mm:ss")} | {message}\n");

    private FileStream GetStream() => new FileStream(FileSavePath, FileMode.Open, FileAccess.ReadWrite);

    private async void MainForm_Load(object sender, EventArgs e)
    {
        await HexData.Collection.AddFromCSV(DataPath);

        Log("Save editor data loaded.");
        Log("No file save selected.");

        if (Debugger.IsAttached)
        {
            btnLoad_Click(sender, e);
        }
    }

    private async void btnLoad_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new();

        if (dialog.ShowDialog() == DialogResult.OK &&
            IsValidFile(dialog.FileName))
        {
            try
            {
                FileSavePath = dialog.FileName;

                using var stream = GetStream();
                await FileSaveReader.Load(FileSaveObj, stream);
                LoadInterface();

                Log("--------------------------------------------------------------");
                Log($"Loaded file save: \"{dialog.FileName}\".");
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

    private bool IsValidFile(string path)
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
                var path = FileSaveBackup.Create(FileSavePath);

                Log($"Backup created at: \"{path}\".");
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

        try
        {
            using var stream = GetStream();
            await FileSaveWriter.WriteChanges(FileSaveObj, stream);

            Log("File saved successfully.");
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

    private void btnOpenEquipBox_Click(object sender, EventArgs e)
    {
        const int EquipBoxCols = 10;
        const int EquipBoxRows = 10;

        Action<EquipmentItemBase, int> addHandler = (EquipmentItemBase obj, int index) =>
        {
            FileSaveObj.EquipmentBox[index] = obj;
        };

        EquipmentForm ??= new BoxForm<EquipmentItemBase>(
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
        txtName.Text = FileSaveObj.Character.Name;
        txtZenny.Text = FileSaveObj.Character.Zenny.ToString();
        txtPoints.Text = FileSaveObj.Character.Points.ToString();
        rdbMale.Checked = FileSaveObj.Character.Gender == Character.CharacterGender.Male;
        rdbFemale.Checked = FileSaveObj.Character.Gender == Character.CharacterGender.Fermale;

        groupBox1.Visible = true;
        groupBox2.Visible = true;
        cbBackup.Visible = true;

        btnSave.Enabled = true;
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
        FileSaveObj.Character.Name = txtName.Text;
    }

    private void txtZenny_TextChanged(object sender, EventArgs e)
    {
        if (!uint.TryParse(txtZenny.Text, out uint zenny))
        {
            txtZenny.Undo();
            return;
        }

        FileSaveObj.Character.Zenny = uint.Parse(txtZenny.Text);
    }

    private void txtPoints_TextChanged(object sender, EventArgs e)
    {
        if (!uint.TryParse(txtPoints.Text, out uint points))
        {
            txtPoints.Undo();
            return;
        }

        FileSaveObj.Character.Points = points;
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
