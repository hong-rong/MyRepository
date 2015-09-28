using System;
using System.Linq;

public class Archery
{
    public double expectedPoints(int N, int[] ringPoints)
    {
        double[] points = new double[ringPoints.Length];
        for (int i = 0; i < ringPoints.Length; i++)
        {
            double pro = (Math.Pow(i + 1, 2) - Math.Pow(i, 2)) / Math.Pow(ringPoints.Length, 2);
            points[i] = ringPoints[i] * pro;
        }

        return points.Sum();
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new Archery()).expectedPoints(1, new int[] { 10, 0 }), 2.5);
            eq(1, (new Archery()).expectedPoints(3, new int[] { 1, 1, 1, 1 }), 1.0);
            eq(2, (new Archery()).expectedPoints(4, new int[] { 100, 0, 100, 0, 100 }), 60.0);
            eq(3, (new Archery()).expectedPoints(9, new int[] { 69, 50, 79, 16, 52, 71, 17, 96, 56, 32 }), 51.96);
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
