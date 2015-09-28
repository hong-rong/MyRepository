using System;

public class SoldierLabeling
{
    public int count(int n, int lowerBound, int upperBound)
    {
        int l = n.ToString().Length;

        if (l < lowerBound) return 0;

        if (l >= lowerBound && l <= upperBound) return n - getMinimum(lowerBound) + 1;

        return getMaximum(upperBound) - getMinimum(lowerBound) + 1;//if(l>upperBound) 
    }

    private int getMinimum(int length)
    {
        return int.Parse("1".PadRight(length, '0'));
    }

    private int getMaximum(int length)
    {
        return int.Parse("9".PadRight(length, '9'));
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new SoldierLabeling()).count(100, 2, 2), 90);
            eq(1, (new SoldierLabeling()).count(31, 2, 3), 22);
            eq(2, (new SoldierLabeling()).count(1, 2, 8), 0);
            eq(3, (new SoldierLabeling()).count(10000000, 8, 8), 1);
            eq(4, (new SoldierLabeling()).count(2718317, 3, 7), 2718218);
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
