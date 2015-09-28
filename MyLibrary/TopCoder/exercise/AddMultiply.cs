using System;

/// <summary>
/// the return solution is not unique so ignore unit tests
/// </summary>
public class AddMultiply
{
    public int[] makeExpression(int y)
    {
        int min = -1000;
        int max = 1000;
        for (int i = min; i <= max; i++)
        {
            if (i == 0 || i == 1) continue;
            for (int j = min; j <= max; j++)
            {
                if (j == 0 || j == 1) continue;
                for (int k = min; k <= max; k++)
                {
                    if (k == 0 || k == 1) continue;
                    if (i * j + k == y) return new int[] { i, j, k };
                }
            }
        }

        return new int[] { };
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new AddMultiply()).makeExpression(6), new int[] { 2, 2, 2 });
            eq(1, (new AddMultiply()).makeExpression(11), new int[] { 2, 3, 5 });
            eq(2, (new AddMultiply()).makeExpression(0), new int[] { 7, 10, -70 });
            eq(3, (new AddMultiply()).makeExpression(500), new int[] { -400, -3, -700 });
            eq(4, (new AddMultiply()).makeExpression(2), new int[] { 2, 2, -2 });
            eq(5, (new AddMultiply()).makeExpression(5), new int[] { 5, 2, -5 });
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
