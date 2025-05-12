using ZadanieRekrutacyjneTME.Algorithms;

namespace ZadanieRekrutacyjneTME.Tasks;

public class Zadanie2
{
    public void CalculateDistance()
    {
        var graph = new Graph.Graph();
        var getGraph = graph.CreateGraphForDijkstra();
        
        var dijkstraWarsaw = new Dijkstra();
        var dijkstraResultWarsaw = dijkstraWarsaw.ExecuteAlgorithm(getGraph, "Warszawa");
        var distanceWarsawToLodz = dijkstraResultWarsaw["Łódź"];
        
        var dijkstraLodz = new Dijkstra();
        var dijkstraResultLodz = dijkstraLodz.ExecuteAlgorithm(getGraph, "Łódź");
        var distanceFromLodzToPoznan = dijkstraResultLodz["Poznań"];
        
        var dijkstraPoznan = new Dijkstra();
        var dijkstraResultPoznan = dijkstraPoznan.ExecuteAlgorithm(getGraph, "Poznań");
        var distanceFromPoznanToSzczecin = dijkstraResultPoznan["Szczecin"];
        
        var finalDistance = (int)Math.Ceiling(distanceWarsawToLodz) + (int)Math.Ceiling(distanceFromLodzToPoznan) + (int)Math.Ceiling(distanceFromPoznanToSzczecin);               

        Console.WriteLine($"Warsaw => Lodz => Poznań => Szczecin = {finalDistance} km");
    }
}