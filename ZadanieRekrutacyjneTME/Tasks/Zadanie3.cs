using ZadanieRekrutacyjneTME.Algorithms;

namespace ZadanieRekrutacyjneTME.Tasks;

public class Zadanie3
{
    public void CalculateShortestPath()
    {
        var graph = new Graph.Graph();
        var getGraph = graph.CreateGraphForDijkstra();
        
        var dijkstraLodz = new Dijkstra();
        var dijkstraResultLodz = dijkstraLodz.ExecuteAlgorithm(getGraph, "Łódź");
        
        var routeRadom = (int)(Math.Ceiling(dijkstraResultLodz["Radom"]) + 
                               Math.Ceiling(dijkstraLodz.ExecuteAlgorithm(getGraph, "Radom")["Warszawa"]));
        
        var routePlock = (int)(Math.Ceiling(dijkstraResultLodz["Płock"]) + 
                               Math.Ceiling(dijkstraLodz.ExecuteAlgorithm(getGraph, "Płock")["Warszawa"]));
        
        var routePiotrkow = (int)(Math.Ceiling(dijkstraResultLodz["Piotrków Tryb."]) + 
                                  Math.Ceiling(dijkstraLodz.ExecuteAlgorithm(getGraph, "Piotrków Tryb.")["Warszawa"]));
        
        var routes = new Dictionary<string, int>              
        {
            {"through Radom", routeRadom},       
            {"through Płock", routePlock},       
            {"through Piotrków Tryb.", routePiotrkow}
        };
        
        var shorestPath = routes.OrderBy(kv => kv.Value).First(); 
        Console.WriteLine($"Shortest path from Lodz to Warsaw is {shorestPath.Key} and equals {shorestPath.Value} km");
    }
}