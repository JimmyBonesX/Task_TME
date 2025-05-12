namespace ZadanieRekrutacyjneTME.Algorithms;

public class Dijkstra
{
    public Dictionary<string, double> ExecuteAlgorithm(Dictionary<string, Dictionary<string, double>> graph,
        string startCity)
    {
        var distances = graph.Keys.ToDictionary(k => k, k => double.PositiveInfinity);
        distances[startCity] = 0;
        
        var queue = new PriorityQueue<string,double>();
        queue.Enqueue(startCity, 0);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            foreach (var (adjNode, d) in graph[node])
            {
                double alternativePath = distances[node] + d;
                if (alternativePath < distances[adjNode])
                {
                    distances[adjNode] = alternativePath;
                    queue.Enqueue(adjNode, alternativePath);
                }
            }
        }

        return distances;
    }
}