using System;

public class ColorfulBoxesAndBalls
{
    public int getMaximum(int numRed, int numBlue, int onlyRed, int onlyBlue, int bothColors)
    {
        if (onlyRed + onlyBlue > bothColors * 2)
            return numRed * onlyRed + numBlue * onlyBlue;

        return numRed > numBlue ? bothColors * 2 * numBlue + (numRed - numBlue) * onlyRed : bothColors * 2 * numRed + (numBlue - numRed) * onlyBlue;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ColorfulBoxesAndBalls()).getMaximum(2, 3, 100, 400, 200), 1400);
            eq(1, (new ColorfulBoxesAndBalls()).getMaximum(2, 3, 100, 400, 300), 1600);
            eq(2, (new ColorfulBoxesAndBalls()).getMaximum(5, 5, 464, 464, 464), 4640);
            eq(3, (new ColorfulBoxesAndBalls()).getMaximum(1, 4, 20, -30, -10), -100);
            eq(4, (new ColorfulBoxesAndBalls()).getMaximum(9, 1, -1, -10, 4), 0);
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
