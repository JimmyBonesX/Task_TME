using ZadanieRekrutacyjneTME.Helpers;

namespace ZadanieRekrutacyjneTME.Tasks;

public class Zadanie1
{
    public void CalculateEuclideanDistance()
    {
        var firstCity = "Praga";
        var secondCity = "Łódź";

        var coordinates = Parser.LoadFileOne();
       
        if (coordinates.ContainsKey(firstCity) && coordinates.ContainsKey(secondCity))
        {
            var (x1, y1) = coordinates[firstCity];
            var (x2, y2) = coordinates[secondCity];

            var distance = Math.Ceiling(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));
            Console.WriteLine($"Distance between {firstCity} and {secondCity}: {distance} km");
        }
        else
        {
            Console.WriteLine("At least one city was not found");
        }
    }
}