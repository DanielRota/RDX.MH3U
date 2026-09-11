namespace RDX.MH3U.FileSave;

public static class FileSaveBackup
{
    public static string Create(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(path);
        }

        var newPath = $"{path}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}";
        File.Copy(path, newPath);
        return newPath;
    }
}
