using System;

public class PeacefulLine
{
    public string makeLine(int[] x)
    {
        int[] ages = new int[25];
        for (int i = 0; i < x.Length; i++)
        {
            ages[x[i] - 1]++;
        }

        Array.Sort(ages, (a, b) => -1 * a.CompareTo(b));

        if (x.Length % 2 == 0)
            return ages[0] > x.Length / 2 ? "impossible" : "possible";
        else
            return ages[0] > (x.Length + 1) / 2 ? "impossible" : "possible";
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new PeacefulLine()).makeLine(new int[] { 1, 2, 3, 4 }), "possible");
            eq(1, (new PeacefulLine()).makeLine(new int[] { 1, 1, 1, 2 }), "impossible");
            eq(2, (new PeacefulLine()).makeLine(new int[] { 1, 1, 2, 2, 3, 3, 4, 4 }), "possible");
            eq(3, (new PeacefulLine()).makeLine(new int[] { 3, 3, 3, 3, 13, 13, 13, 13 }), "possible");
            eq(4, (new PeacefulLine()).makeLine(new int[] { 3, 7, 7, 7, 3, 7, 7, 7, 3 }), "impossible");
            eq(5, (new PeacefulLine()).makeLine(new int[] { 25, 12, 3, 25, 25, 12, 12, 12, 12, 3, 25 }), "possible");
            eq(6, (new PeacefulLine()).makeLine(new int[] { 3, 3, 3, 3, 13, 13, 13, 13, 3 }), "possible");
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
