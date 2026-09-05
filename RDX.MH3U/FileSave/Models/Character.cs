namespace RDX.MH3U.FileSave.Models;

public class Character
{
    public enum CharacterGender
    {
        Male,
        Fermale
    }

    public string Name { get; set; } = string.Empty;
    public CharacterGender Gender { get; set; }
    public uint Zenny { get; set; }
    public uint Points { get; set; }
}
