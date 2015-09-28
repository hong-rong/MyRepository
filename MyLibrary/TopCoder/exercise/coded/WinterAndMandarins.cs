using System;

public class WinterAndMandarins
{
    public int getNumber(int[] bags, int K)
    {
        Array.Sort(bags);

        int minDiff = int.MaxValue;
        for (int i = 0; i <= bags.Length - K; i++)
        {
            int diffSum = 0;
            for (int j = i + 1; j < i + K; j++)
            {
                diffSum = diffSum + bags[j] - bags[j - 1];
            }

            if (diffSum < minDiff)
            {
                minDiff = diffSum;
            }
        }

        return minDiff;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new WinterAndMandarins()).getNumber(new int[] { 10, 20, 30 }, 2), 10);
            eq(1, (new WinterAndMandarins()).getNumber(new int[] { 4, 7, 4 }, 3), 3);
            eq(2, (new WinterAndMandarins()).getNumber(new int[] { 4, 1, 2, 3 }, 3), 2);
            eq(3, (new WinterAndMandarins()).getNumber(new int[] { 5, 4, 6, 1, 9, 4, 2, 7, 5, 6 }, 4), 1);
            eq(4, (new WinterAndMandarins()).getNumber(new int[] { 47, 1000000000, 1, 74 }, 2), 27);
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
