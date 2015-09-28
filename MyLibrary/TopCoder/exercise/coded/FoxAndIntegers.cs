using System;

public class FoxAndIntegers
{
    public int[] get(int AminusB, int BminusC, int AplusB, int BplusC)
    {
        int a = (AminusB + AplusB) / 2;
        int b = (AplusB - AminusB) / 2;
        int c = (BplusC - BminusC) / 2;

        if (AminusB == a - b && BminusC == b - c && AplusB == a + b && BplusC == b + c)
            return new int[] { a, b, c };
        else
            return new int[] { };
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new FoxAndIntegers()).get(1, -2, 3, 4), new int[] { 2, 1, 3 });
            eq(1, (new FoxAndIntegers()).get(0, 0, 5, 5), new int[] { });
            eq(2, (new FoxAndIntegers()).get(10, -23, -10, 3), new int[] { 0, -10, 13 });
            eq(3, (new FoxAndIntegers()).get(-27, 14, 13, 22), new int[] { });
            eq(4, (new FoxAndIntegers()).get(30, 30, 30, -30), new int[] { 30, 0, -30 });
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
