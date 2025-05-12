namespace ZadanieRekrutacyjneTME.Algorithms;

public class FloydWarshall
{
    private readonly Dictionary<string, Dictionary<string, double>> _graph;
    public Dictionary<string, Dictionary<string, double>>? Distance { get;  private set; }
    public Dictionary<string, Dictionary<string, string>>? Next { get;  private set; }
    
    public FloydWarshall(Dictionary<string, Dictionary<string, double>> graph)
    {
        _graph = graph;
       ExecuteAlgorithm();
    }

    private void ExecuteAlgorithm()
    {
        var nodes = _graph.Keys.ToList(); 
        
        Distance = nodes.ToDictionary(
            i => i,
            i => nodes.ToDictionary(
                j => j,
                j => i == j
                    ? 0.0
                    : (_graph[i].ContainsKey(j) ? _graph[i][j] : double.PositiveInfinity)
            )
        );
        
        Next = nodes.ToDictionary(
            i => i,
            i => nodes.ToDictionary(
                j => j,
                j => _graph[i].ContainsKey(j) ? j : null
            )
        )!;
        
        foreach (var k in nodes)
        {
            foreach (var i in nodes)
            {
                foreach (var j in nodes)
                {
                    var alt = Distance[i][k] + Distance[k][j];           
                    if (alt < Distance[i][j])
                    {
                        Distance[i][j]  = alt;                            
                        Next[i][j]  = Next[i][k];                       
                    }
                }
            }
        }
    }
}