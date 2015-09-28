using System;

public class RedAndGreen
{
    public int minPaints(string row)
    {
        int min = int.MaxValue;
        int minR = 0;
        int minG = 0;
        for (int i = 0; i < row.Length; i++)
        {
            int count = 0;
            for (int j = 0; j <= i; j++)
            {
                if (row[j] == 'G') count++;
            }

            for (int k = i + 1; k < row.Length; k++)
            {
                if (row[k] == 'R') count++;
            }

            if (count < min) min = count;

            if (row[i] == 'R') minR++;
            if (row[i] == 'G') minG++;
        }

        int tempMax = minR < minG ? minR : minG;

        return min < tempMax ? min : tempMax;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new RedAndGreen()).minPaints("RGRGR"), 2);
            eq(1, (new RedAndGreen()).minPaints("RRRGGGGG"), 0);
            eq(2, (new RedAndGreen()).minPaints("GGGGRRR"), 3);
            eq(3, (new RedAndGreen()).minPaints("RGRGRGRGRGRGRGRGR"), 8);
            eq(4, (new RedAndGreen()).minPaints("RRRGGGRGGGRGGRRRGGRRRGR"), 9);
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
