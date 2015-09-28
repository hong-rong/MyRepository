using System;

public class KingdomAndDucks
{
    public int minDucks(int[] duckTypes)
    {
        int[] typeCount = new int[50];
        for (int i = 0; i < duckTypes.Length; i++)
        {
            typeCount[duckTypes[i] - 1]++;
        }

        int max = int.MinValue;
        int count = 0;
        for (int j = 0; j < typeCount.Length; j++)
        {
            if (typeCount[j] != 0)
            {
                count++;
                if (typeCount[j] > max) max = typeCount[j];
            }
        }

        return count * max;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new KingdomAndDucks()).minDucks(new int[] { 5, 8 }), 2);
            eq(1, (new KingdomAndDucks()).minDucks(new int[] { 4, 7, 4, 7, 4 }), 6);
            eq(2, (new KingdomAndDucks()).minDucks(new int[] { 17, 17, 19, 23, 23, 19, 19, 17, 17 }), 12);
            eq(3, (new KingdomAndDucks()).minDucks(new int[] { 50 }), 1);
            eq(4, (new KingdomAndDucks()).minDucks(new int[] { 10, 10, 10, 10, 10 }), 5);
        }
        catch (Exception exx)
        {
            System.Console.WriteLine(exx);
            System.Console.WriteLine(exx.StackTrace);
        }

        Console.ReadKey();
    }
    private static void eq(int n, object have, object need)
    {
        if (eq(have, need))
        {
            Console.WriteLine("Case " + n + " passed.");
        }
        else
        {
            Console.Write("Case " + n + " failed: expected ");
            print(need);
            Console.Write(", received ");
            print(have);
            Console.WriteLine();
        }
    }
    private static void eq(int n, Array have, Array need)
    {
        if (have == null || have.Length != need.Length)
        {
            Console.WriteLine("Case " + n + " failed: returned " + have.Length + " elements; expected " + need.Length + " elements.");
            print(have);
            print(need);
            return;
        }
        for (int i = 0; i < have.Length; i++)
        {
            if (!eq(have.GetValue(i), need.GetValue(i)))
            {
                Console.WriteLine("Case " + n + " failed. Expected and returned array differ in position " + i);
                print(have);
                print(need);
                return;
            }
        }
        Console.WriteLine("Case " + n + " passed.");
    }
    private static bool eq(object a, object b)
    {
        if (a is double && b is double)
        {
            return Math.Abs((double)a - (double)b) < 1E-9;
        }
        else
        {
            return a != null && b != null && a.Equals(b);
        }
    }
    private static void print(object a)
    {
        if (a is string)
        {
            Console.Write("\"{0}\"", a);
        }
        else if (a is long)
        {
            Console.Write("{0}L", a);
        }
        else
        {
            Console.Write(a);
        }
    }
    private static void print(Array a)
    {
        if (a == null)
        {
            Console.WriteLine("<NULL>");
        }
        Console.Write('{');
        for (int i = 0; i < a.Length; i++)
        {
            print(a.GetValue(i));
            if (i != a.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine('}');
    }
    // END CUT HERE
}
