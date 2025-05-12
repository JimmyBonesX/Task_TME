using System.Globalization;
using System.Text;
using ZadanieRekrutacyjneTME.Algorithms;

namespace ZadanieRekrutacyjneTME.Tasks;

public class Zadanie6
{
    public void CalculateDistanceForSpecifiedCities()
    {
        var graph = new Graph.Graph();
        var getGraph = graph.CreateGraphForFloydWarshall();

        var floydWarshall = new FloydWarshall(getGraph);
        var distance = floydWarshall.Distance;
        var next = floydWarshall.Next;


        var normalizedMap = distance.Keys.ToDictionary(
            k => RemoveDiacritics(k).ToLowerInvariant(),
            k => k);
        
        Console.WriteLine("Press Tab to exit or any other key to continue");
        while (true)
        {
            var key = Console.ReadKey(true); 
            if (key.Key == ConsoleKey.Tab) Environment.Exit(0);
            
            string startCity, endCity;
            while (true)
            {
                Console.Write("Enter starting city: ");
                var enteredstartingCity = Console.ReadLine()?.Trim()!;
                Console.Write("Enter ending city: ");
                var enteredEndingCity = Console.ReadLine()?.Trim()!;

                if (!normalizedMap.TryGetValue(RemoveDiacritics(enteredstartingCity).ToLowerInvariant(),
                        out startCity) ||
                    !normalizedMap.TryGetValue(RemoveDiacritics(enteredEndingCity).ToLowerInvariant(), out endCity))
                {
                    Console.WriteLine("Invalid city entered.");
                    continue;
                }
                break;
            }
        
            var d = distance![startCity!][endCity!];
            if (double.IsInfinity(d))
            {
                Console.WriteLine($"There is no path from {startCity} to {endCity}.");
            }
            else
            {
                var path = new List<string> { startCity };
                var u = startCity;
                while (u != endCity)
                {
                    u = next[u][endCity];
                    path.Add(u);
                }

                Console.WriteLine($"Shortest path from {startCity} to {endCity}: {string.Join(" => ", path)} = {d:F2} km");
            }

            Console.WriteLine("Press Tab to exit or any other key to continue");
        }
    }
    
    private string RemoveDiacritics(string text)
    {
        if (text == null) return null;
        var normalized = text.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();
        foreach (var ch in normalized)
        {
            var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
            if (uc != UnicodeCategory.NonSpacingMark)
                sb.Append(ch);
        }
        return sb.ToString().Normalize(NormalizationForm.FormC);
    }
   
}