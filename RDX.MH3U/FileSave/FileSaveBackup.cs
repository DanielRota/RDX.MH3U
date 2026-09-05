namespace RDX.MH3U.FileSave;

public static class FileSaveBackup
{
    public static void Create(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(path);
        }

        string backup = Path.Combine(path, "_", DateTime.Now.Ticks.ToString());
        File.Copy(path, backup);
    }
}
