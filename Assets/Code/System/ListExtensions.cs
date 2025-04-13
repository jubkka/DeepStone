using System.Collections.Generic;

public static class ListExtensions
{
    private static System.Random random = new System.Random();
    
    public static void Shuffle<T>(this List<T> list)
    {
        int n = list.Count;

        while (n-- > 1)
        {
            int k = random.Next(0, n--);
            
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}
