// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class MinDifference
{
    public int closestElements(int A0, int X, int Y, int M, int n)
    {
        int[] a = new int[n];
        a[0] = A0;
        for (int i = 1; i < n; i++)
        {
            a[i] = (a[i - 1] * X + Y) % M;
        }

        Array.Sort(a);

        int min = int.MaxValue;
        for (int k = 1; k < a.Length; k++)
        {
            int diff = Math.Abs(a[k] - a[k - 1]);
            if (diff < min)
                min = diff;
        }

        return min;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new MinDifference()).closestElements(3, 7, 1, 101, 5), 6);
            eq(1, (new MinDifference()).closestElements(3, 9, 8, 32, 8), 0);
            eq(2, (new MinDifference()).closestElements(67, 13, 17, 4003, 23), 14);
            eq(3, (new MinDifference()).closestElements(1, 1221, 3553, 9889, 11), 275);
            eq(4, (new MinDifference()).closestElements(1, 1, 1, 2, 10000), 0);
            eq(5, (new MinDifference()).closestElements(1567, 5003, 9661, 8929, 43), 14);
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
