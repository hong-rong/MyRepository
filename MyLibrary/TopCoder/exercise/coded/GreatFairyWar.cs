using System;

public class GreatFairyWar
{
    public int minHP(int[] dps, int[] hp)
    {
        int sum = 0;
        for (int i = 0; i < hp.Length; i++)
        {
            int tempSum = 0;
            for (int j = i; j < dps.Length; j++)
            {
                tempSum = tempSum + dps[j];
            }
            sum = sum + tempSum * hp[i];
        }

        return sum;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new GreatFairyWar()).minHP(new int[] { 1, 2 }, new int[] { 3, 4 }), 17);
            eq(1, (new GreatFairyWar()).minHP(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }), 55);
            eq(2, (new GreatFairyWar()).minHP(new int[] { 20, 12, 10, 10, 23, 10 }, new int[] { 5, 7, 7, 5, 7, 7 }), 1767);
            eq(3, (new GreatFairyWar()).minHP(new int[] { 5, 7, 7, 5, 7, 7 }, new int[] { 20, 12, 10, 10, 23, 10 }), 1998);
            eq(4, (new GreatFairyWar()).minHP(new int[] { 30, 2, 7, 4, 7, 8, 21, 14, 19, 12 }, new int[] { 2, 27, 18, 19, 14, 8, 25, 13, 21, 30 }), 11029);
            eq(5, (new GreatFairyWar()).minHP(new int[] { 1 }, new int[] { 1 }), 1);
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
