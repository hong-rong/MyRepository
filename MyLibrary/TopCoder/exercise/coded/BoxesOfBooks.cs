using System;
using System.Linq;

public class BoxesOfBooks
{
    public int boxes(int[] weights, int maxWeight)
    {
        int sum = 0;
        int count = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            if (sum + weights[i] > maxWeight)
            {
                count++;
                sum = weights[i];
            }
            else
            {
                sum = sum + weights[i];
            }

            if (i == weights.Length - 1) count++;
        }

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new BoxesOfBooks()).boxes(new int[] { 5, 5, 5, 5, 5, 5 }, 10), 3);
            eq(1, (new BoxesOfBooks()).boxes(new int[] { 51, 51, 51, 51, 51 }, 100), 5);
            eq(2, (new BoxesOfBooks()).boxes(new int[] { 1, 1, 1, 7, 7, 7 }, 8), 4);
            eq(3, (new BoxesOfBooks()).boxes(new int[] { 12, 1, 11, 2, 10, 3, 4, 5, 6, 6, 1 }, 12), 6);
            eq(4, (new BoxesOfBooks()).boxes(new int[] { }, 7), 0);
            eq(5, (new BoxesOfBooks()).boxes(new int[] { 20, 20, 20, 20, 20, 20, 20, 20, 20, 20,
                 20, 20, 20, 20, 20, 20, 20, 20, 20, 20,
                 20, 20, 20, 20, 20, 20, 20, 20, 20, 20,
                 20, 20, 20, 20, 20, 20, 20, 20, 20, 20,
                 20, 20, 20, 20, 20, 20, 20, 20, 20, 20 }, 1000), 1);
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
