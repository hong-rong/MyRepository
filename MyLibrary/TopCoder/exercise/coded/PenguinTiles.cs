using System;

public class PenguinTiles
{
    public int minMoves(string[] titles)
    {
        for (int i = 0; i < titles.Length; i++)
            for (int j = 0; j < titles[i].Length; j++)
                if (titles[i][j] == '.')
                {
                    if (i == titles.Length - 1 && j == titles[0].Length - 1) return 0;
                    else if (i == titles.Length - 1) return 1;
                    else if (j == titles[0].Length - 1) return 1;
                    else return 2;
                }

        return -1;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new PenguinTiles()).minMoves(new string[] {"PP","P."}), 0);
            eq(1, (new PenguinTiles()).minMoves(new string[] { "PPPPPPPP", ".PPPPPPP" }), 1);
            eq(2, (new PenguinTiles()).minMoves(new string[] { "PPP", "P.P", "PPP" }), 2);
            eq(3, (new PenguinTiles()).minMoves(new string[] { "P.", "PP", "PP", "PP" }), 1);
            eq(4, (new PenguinTiles()).minMoves(new string[] { ".PPP", "PPPP", "PPPP", "PPPP" }), 2);
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
