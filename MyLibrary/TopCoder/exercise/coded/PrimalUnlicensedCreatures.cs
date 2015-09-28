using System;

public class PrimalUnlicensedCreatures
{
    public int maxWins(int initialLevel, int[] grezPower)
    {
        Array.Sort(grezPower);
        int count = 0;
        for (int i = 0; i < grezPower.Length; i++)
        {
            if (initialLevel > grezPower[i])
            {
                initialLevel = initialLevel + grezPower[i] / 2;
                count++;
            }
            else
                break;
        }

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new PrimalUnlicensedCreatures()).maxWins(31, new int[] { 10, 20, 30 }), 3);
            eq(1, (new PrimalUnlicensedCreatures()).maxWins(20, new int[] { 24, 5, 6, 38 }), 3);
            eq(2, (new PrimalUnlicensedCreatures()).maxWins(20, new int[] { 3, 3, 3, 3, 3, 1, 25 }), 6);
            eq(3, (new PrimalUnlicensedCreatures()).maxWins(4, new int[] { 3, 13, 6, 4, 9 }), 5);
            eq(4, (new PrimalUnlicensedCreatures()).maxWins(7, new int[] { 7, 8, 9, 10 }), 0);
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
