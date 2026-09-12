namespace RDX.MH3U.Hex;

public class HexCollection
{
    private readonly List<HexValue> _items = new();

    public HexValue[] this[HexValueCategory category] =>
        _items.Where(x => x.Category == category).ToArray();

    public HexValue this[HexValueCategory category, string hex]
    {
        get
        {
            Func<HexValue, bool> func = x =>
                x.Category == category && x.Hex == hex;

            if (_items.Any(func))
            {
                return _items.First(func);
            }

            return HexValue.Placeholder();
        }
    }

    public async Task AddFromCSV(string path, Action<string> Log)
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

            if (split.Length == 3)
            {
                var category = Enum.Parse<HexValueCategory>(split[0]);
                var hex = split[1];
                var description = split[2];

                if (!string.IsNullOrWhiteSpace(description) && !string.IsNullOrWhiteSpace(hex) &&
                    category > HexValueCategory.Placeholder)
                {
                    try
                    {
                        HexValue value = new(split[1], category, split[2]);
                        _items.Add(value);
                    }
                    catch (Exception ex)
                    {
                        Log($"{line} | {ex.Message}");
                    }
                }
            }
        }
    }
}
