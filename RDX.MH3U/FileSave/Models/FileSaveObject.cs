namespace RDX.MH3U.FileSave.Models;

public class FileSaveObject
{
    public Character Character = new();
    public BoxItem[] ItemsPouch = new BoxItem[Constants.ItemsPouchLength / Constants.ItemFullLength];
    public BoxItem[] ItemsBox = new BoxItem[Constants.ItemsBoxLength / Constants.ItemFullLength];
    public EquipmentItem[] EquipmentBox = new EquipmentItem[Constants.EquipmentBoxLength / Constants.EquipmentLength];
}
