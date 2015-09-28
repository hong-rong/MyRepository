using System;

public class MagicalGirlLevelOneDivTwo
{
    public double theMinDistance(int d, int x, int y)
    {
        int xg = 0;
        if (x >= -1 * d && x <= d) xg = 0;
        else if (x >= 0) xg = x - d;
        else xg = x + d;

        int yg = 0;
        if (y >= -1 * d && y <= d) yg = 0;
        else if (y >= 0) yg = y - d;
        else yg = y + d;

        return Math.Sqrt(Math.Pow(xg - 0, 2) + Math.Pow(yg - 0, 2));
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new MagicalGirlLevelOneDivTwo()).theMinDistance(5, 10, 10), 7.0710678118654755);
            eq(1, (new MagicalGirlLevelOneDivTwo()).theMinDistance(5, 10, 3), 5.0);
            eq(2, (new MagicalGirlLevelOneDivTwo()).theMinDistance(5, -8, -6), 3.1622776601683795);
            eq(3, (new MagicalGirlLevelOneDivTwo()).theMinDistance(5, 3, 2), 0.0);
            eq(4, (new MagicalGirlLevelOneDivTwo()).theMinDistance(24, 24, -24), 0.0);
            eq(5, (new MagicalGirlLevelOneDivTwo()).theMinDistance(345, -471, 333), 126.0);
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
