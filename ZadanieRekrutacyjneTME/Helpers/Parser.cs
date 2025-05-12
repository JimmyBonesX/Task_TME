using System.Globalization;

namespace ZadanieRekrutacyjneTME.Helpers;

public class Parser
{
    public static Dictionary<string,(double x, double y)> LoadFileOne()
    {
        var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\MiastaWspolrzedne.txt"));
        var coordinates = new Dictionary<string, (double x, double y)>();

        foreach (var line in File.ReadAllLines(path))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var normalized = line.Replace(',', '.');
            var parts = normalized.Split(['\t'], StringSplitOptions.RemoveEmptyEntries);
            
            if (!double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var x)) continue;
            if (!double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var y)) continue;
            coordinates[parts[0]] = (x, y);
        }
        return coordinates;
    }
    
    public static Dictionary<string,(double x, double y, double airQuality)> LoadFileTwo()
    {
        var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\MiastaWspolrzedne2.txt"));
        var cityData = new Dictionary<string, (double x, double y, double airQuality)>();

        foreach (var line in File.ReadAllLines(path))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var normalized = line.Replace(',', '.');
            var parts = normalized.Split(['\t'], StringSplitOptions.RemoveEmptyEntries);
            
            if (!double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var x)) continue;
            if (!double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var y)) continue;
            if (!double.TryParse(parts[3], NumberStyles.Float, CultureInfo.InvariantCulture, out var airQuality)) continue;
            cityData[parts[0]] = (x, y, airQuality);
        }
        return cityData;
    }
    
    public static List<(string a, string b, double d)> LoadFileThree()
    {
        var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\MiastaPołączenia.txt"));
        var data = new List<(string a, string b, double d)>();

        foreach (var line in File.ReadAllLines(path))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var split = line.Split('\t');
            var d = double.Parse(split[2].Replace(',', '.'), CultureInfo.InvariantCulture);
            data.Add((split[0], split[1], d));
        }

        return data;
    }
}

