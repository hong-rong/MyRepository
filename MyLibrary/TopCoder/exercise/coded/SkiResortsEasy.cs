using System;

public class SkiResortsEasy
{
    public int minCost(int[] altitude)
    {
        int diffSum = 0;
        for (int i = 1; i < altitude.Length; i++)
        {
            if (altitude[i] > altitude[i - 1])
            {
                diffSum = diffSum + altitude[i] - altitude[i - 1];
                altitude[i] = altitude[i - 1];
            }
        }

        return diffSum;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new SkiResortsEasy()).minCost(new int[] { 30, 20, 20, 10 }), 0);
            eq(1, (new SkiResortsEasy()).minCost(new int[] { 5, 7, 3 }), 2);
            eq(2, (new SkiResortsEasy()).minCost(new int[] { 6, 8, 5, 4, 7, 4, 2, 3, 1 }), 6);
            eq(3, (new SkiResortsEasy()).minCost(new int[] { 749, 560, 921, 166, 757, 818, 228, 584, 366, 88 }), 2284);
            eq(4, (new SkiResortsEasy()).minCost(new int[] { 712, 745, 230, 200, 648, 440, 115, 913, 627, 621, 186, 222, 741, 954, 581, 193, 266, 320, 798, 745 }), 6393);
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
