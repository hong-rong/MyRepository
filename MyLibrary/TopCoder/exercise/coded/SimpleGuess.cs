using System;

public class SimpleGuess
{
    public int getMaximum(int[] hints)
    {
        for (int i = 0; i < hints.Length; i++)
        {
            hints[i] = (int)Math.Pow(hints[i], 2);
        }

        Array.Sort(hints);
        for (int j = hints.Length - 1; j > 0; j--)
        {
            for (int k = 0; k < hints.Length; k++)
            {
                if (hints[k] >= hints[j]) break;
                if ((hints[j] - hints[k]) % 4 == 0) return (hints[j] - hints[k]) / 4;
            }
        }

        return -1;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new SimpleGuess()).getMaximum(new int[] { 1, 4, 5 }), 6);
            eq(1, (new SimpleGuess()).getMaximum(new int[] { 1, 4, 5, 8 }), 12);
            eq(2, (new SimpleGuess()).getMaximum(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }), 20);
            eq(3, (new SimpleGuess()).getMaximum(new int[] { 2, 100 }), 2499);
            eq(4, (new SimpleGuess()).getMaximum(new int[] { 50, 58, 47, 57, 40 }), 441);
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
