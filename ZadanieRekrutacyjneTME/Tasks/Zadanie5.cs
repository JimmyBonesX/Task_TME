using ZadanieRekrutacyjneTME.Helpers;

namespace ZadanieRekrutacyjneTME.Tasks;

public class Zadanie5
{
    public void PlanBestRoute()
    {
        var data = Parser.LoadFileTwo();
        
        var graph = new Graph.Graph();
        var getGraph = graph.CreateGraphForDijkstra();
        
        string start = "Łódź", end = "Gdańsk";
        var nodes = data.Keys.Where(c => c != start && c != end).ToList();
        double bestQuality = double.MinValue, shortestDistance = double.MaxValue;
        List<string> bestPath = null!;
        var getPermutations = Permutations.GetPermutations(nodes, 5);
        
        foreach (var perm in getPermutations)
        {
            double distSum = 0;
            for (var i = 0; i <= perm.Count; i++)
            {
                var from = (i == 0 ? start : perm[i - 1]);
                var to   = (i == perm.Count ? end : perm[i]);
                distSum += getGraph[from][to];
                if (distSum > 2000) break;
            }
            if (distSum > 2000) continue;
            var minQuality = perm.Min(city => data[city].airQuality);
            if (minQuality > bestQuality || (Math.Abs(minQuality - bestQuality) < 1e-6 && distSum < shortestDistance ))
            {
                bestQuality = minQuality;
                shortestDistance  = Math.Ceiling(distSum);
                bestPath = perm;
            }
        }
        
        Console.WriteLine(
            bestPath != null
                ? $"Best path from Lodz to Gdansk with distance lesser than 2000 km = {shortestDistance } and air quality {bestQuality:F1} leads through {string.Join(" - ", bestPath)}"
                : "Best path from Lodz to Gdansk with distance lesser than 2000 km was not found");
    }

}