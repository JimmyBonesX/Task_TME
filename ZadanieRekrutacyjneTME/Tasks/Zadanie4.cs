using ZadanieRekrutacyjneTME.Algorithms;
using ZadanieRekrutacyjneTME.Helpers;

namespace ZadanieRekrutacyjneTME.Tasks;

public class Zadanie4
{
    public void DesignateTravelRoute()
    {
        var cities = Parser.LoadFileOne();
        
        var graph = new Graph.Graph();
        var getGraph = graph.CreateGraphForDijkstra();
        
        var dijkstra = new Dijkstra();

        
        var intermediates = new List<string> { "Włocławek", "Elbląg", "Toruń", "Olsztyn", "Płock" };
        
        string start = "Szczecin", end = "Warszawa";
        
        var allDist = new Dictionary<string, Dictionary<string, double>>();
        foreach (var city in cities.Keys)                  
            allDist[city] = dijkstra.ExecuteAlgorithm(getGraph, city);
        
        var getPermutations = Permutations.GetPermutations(intermediates, intermediates.Count);

        var minTotal = double.MaxValue;                  
        List<string> bestOrder = null!;                      
        foreach (var perm in getPermutations)
        {
            double sum = allDist[start][perm[0]];          
            for (int i = 0; i < perm.Count - 1; i++)
                sum += allDist[perm[i]][perm[i + 1]];       
            sum += allDist[perm.Last()][end];               
            if (sum < minTotal)
            {
                minTotal = sum;                            
                bestOrder = perm;                         
            }
        }
        Console.WriteLine($"Optimal Route: Szczecin - {string.Join(" - ", bestOrder)} - Warsaw");
        Console.WriteLine("Distance " + Math.Ceiling(minTotal) + " km");
    }
}