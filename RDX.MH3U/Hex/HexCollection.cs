namespace RDX.MH3U.Hex;

public class HexCollection
{
    private readonly List<HexValue> _values = new();

    public HexValue[] this[HexValueCategory category] =>
        _values.Where(x => x.Category == category).ToArray();

    public HexValue this[HexValueCategory category, string hex]
    {
        get
        {
            Func<HexValue, bool> func = x =>
                x.Category == category && x.Hex == hex;

            if (_values.Any(func))
            {
                return _values.First(func);
            }

            return HexValue.Placeholder();
        }
    }

    public async Task AddFromCSV(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(path);
        }

        var lines = await File.ReadAllLinesAsync(path);

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var split = line.Split(';');
            var category = Enum.Parse<HexValueCategory>(split[0]);

            try
            {
                HexValue value = new(split[1], category, split[2]);
                _values.Add(value);
            }
            catch
            {
            }
        }
    }
}
