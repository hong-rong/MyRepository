using System;

public class AlphabetPath
{
    public string doesItExist(string[] letterMaze)
    {
        int r = -1; int c = -1;
        for (int i = 0; i < letterMaze.Length; i++)
        {
            for (int j = 0; j < letterMaze[i].Length; j++)
            {
                if (letterMaze[i][j] == 'A')
                {
                    r = i;
                    c = j;
                }
            }
        }

        if (r == -1 && c == -1) return "NO";

        for (int m = 66; m <= 90; m++)
        {
            if (r - 1 >= 0 && letterMaze[r - 1][c] == m)
            {
                r = r - 1;
                continue;//up
            }
            if (r + 1 <= letterMaze.Length - 1 && letterMaze[r + 1][c] == m)
            {
                r = r + 1;
                continue;//down
            }
            if (c - 1 >= 0 && letterMaze[r][c - 1] == m)
            {
                c = c - 1;
                continue;//left
            }
            if (c + 1 <= letterMaze[r].Length - 1 && letterMaze[r][c + 1] == m)
            {
                c = c + 1;
                continue;//right
            }

            return "NO";
        }

        return "YES";
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new AlphabetPath()).doesItExist(new string[] { "ABCDEFGHIJKLMNOPQRSTUVWXYZ" }), "YES");
            eq(1, (new AlphabetPath()).doesItExist(new string[] {"ADEHI..Z",
                "BCFGJK.Y",
                ".PONML.X",
                ".QRSTUVW"}
               ), "YES");
            eq(2, (new AlphabetPath()).doesItExist(new string[] { "ACBDEFGHIJKLMNOPQRSTUVWXYZ" }), "NO");
            eq(3, (new AlphabetPath()).doesItExist(new string[] {"ABC.......",
                "...DEFGHIJ",
                "TSRQPONMLK",
                "UVWXYZ...."}), "NO");
            eq(4, (new AlphabetPath()).doesItExist(new string[] {"..............",
                "..............",
                "..............",
                "...DEFGHIJK...",
                "...C......L...",
                "...B......M...",
                "...A......N...",
                "..........O...",
                "..ZY..TSRQP...",
                "...XWVU.......",
                ".............."}), "YES");
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
