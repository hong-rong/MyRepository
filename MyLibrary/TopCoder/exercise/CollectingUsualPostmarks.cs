// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class CollectingUsualPostmarks
{
    public int numberOfPostmarks(int[] prices, int[] have)
    {
        int haveSum = 0;
        for (int i = 0; i < have.Length; i++)
        {
            haveSum = haveSum + prices[have[i]];
        }

        Array.Sort(prices);

        int buySum = 0;
        int j = 0;
        for (; j < prices.Length; j++)
        {
            buySum = buySum + prices[j];
            if (buySum > haveSum) break;
        }

        return j;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new CollectingUsualPostmarks()).numberOfPostmarks(new int[] { 13, 10, 14, 20 }, new int[] { 3, 0, 2, 1 }), 4);
            eq(1, (new CollectingUsualPostmarks()).numberOfPostmarks(new int[] { 7, 5, 9, 7 }, new int[] { }), 0);
            eq(2, (new CollectingUsualPostmarks()).numberOfPostmarks(new int[] { 4, 13, 9, 1, 5 }, new int[] { 1, 3, 2 }), 4);
            eq(3, (new CollectingUsualPostmarks()).numberOfPostmarks(new int[] { 16, 32, 13, 2, 17, 10, 8, 8, 20, 17 }, new int[] { 7, 0, 4, 1, 6, 8 }), 8);
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
