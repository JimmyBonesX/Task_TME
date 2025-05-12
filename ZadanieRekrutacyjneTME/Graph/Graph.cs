using ZadanieRekrutacyjneTME.Helpers;

namespace ZadanieRekrutacyjneTME.Graph;

public class Graph
{
    public Dictionary<string, Dictionary<string, double>> CreateGraphForDijkstra()
    {
        var getCoordinates = Parser.LoadFileOne();
        var graph = new Dictionary<string, Dictionary<string, double>>();

        foreach (var coordsA in getCoordinates)
        {
            graph[coordsA.Key] = new Dictionary<string, double>();
            foreach (var coordsB in getCoordinates)
            {
                if (coordsA.Key == coordsB.Key) continue;
                double axisXDiff = coordsA.Value.x - coordsB.Value.x;
                double axisYDiff = coordsA.Value.y - coordsB.Value.y;
                double distance = Math.Sqrt(Math.Pow(axisXDiff,2) + Math.Pow(axisYDiff,2));
                graph[coordsA.Key][coordsB.Key] = distance;
            }
        }
        
        return graph;
    }

    public Dictionary<string, Dictionary<string, double>> CreateGraphForFloydWarshall()
    {
        var getData = Parser.LoadFileThree();
        var graph = new Dictionary<string, Dictionary<string, double>>();

        foreach (var (a,b,d) in getData)
        {
            if (!graph.ContainsKey(a))
            {
                graph[a] = new Dictionary<string, double>();
            }

            if (!graph.ContainsKey(b))
            {
                graph[b] = new Dictionary<string, double>();
            }
            
            graph[a][b] = d;
            graph[b][a] = d;
        }
        return graph;
    }
    
}