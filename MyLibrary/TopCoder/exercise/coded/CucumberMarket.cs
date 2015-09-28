using System;
using System.Linq;

public class CucumberMarket
{
    public string check(int[] price, int budget, int k)
    {
        Array.Sort(price, (a, b) => -1 * a.CompareTo(b));
        int sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum = sum + price[i];
        }

        if (sum > budget)
            return "NO";
        else
            return "YES";
    }
    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new CucumberMarket()).check(new int[] { 1000, 1, 10, 100 }, 1110, 3), "YES");
            eq(1, (new CucumberMarket()).check(new int[] { 1000, 1, 10, 100 }, 1109, 3), "NO");
            eq(2, (new CucumberMarket()).check(new int[] { 33, 4 }, 33, 1), "YES");
            eq(3, (new CucumberMarket()).check(new int[] { 1, 1, 1, 1, 1, 1 }, 2, 4), "NO");
            eq(4, (new CucumberMarket()).check(new int[] { 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000 }, 10000, 9), "YES");
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