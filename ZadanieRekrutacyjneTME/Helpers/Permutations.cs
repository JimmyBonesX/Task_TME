namespace ZadanieRekrutacyjneTME.Helpers;

public class Permutations
{
    public static IEnumerable<List<T>> GetPermutations<T>(List<T> list, int length)
    {
        if (length == 1)
        {
            return list.Select(x => new List<T> { x });
        }
        return GetPermutations(list, length - 1)
            .SelectMany(p => list.Where(x => !p.Contains(x)), (p, n) => new List<T>(p) { n });
    }
}