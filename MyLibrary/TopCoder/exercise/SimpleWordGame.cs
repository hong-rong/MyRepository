using System;

public class SimpleWordGame
{
    public int points(string[] player, string[] dictionary)
    {
        int points = 0;
        for (int i = 0; i < player.Length; i++)
        {
            for (int j = 0; j < dictionary.Length; j++)
            {
                if (player[i] == dictionary[j])
                {
                    dictionary[j] = "";
                    points = points + (int)Math.Pow(player[i].Length, 2);
                    break;
                }
            }
        }

        return points;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new SimpleWordGame()).points(new string[] { "apple", "orange", "strawberry" }, new string[] { "strawberry", "orange", "grapefruit", "watermelon" }), 136);
            eq(1, (new SimpleWordGame()).points(new string[] { "apple" }, new string[] { "strawberry", "orange", "grapefruit", "watermelon" }), 0);
            eq(2, (new SimpleWordGame()).points(new string[] { "orange", "orange" }, new string[] { "strawberry", "orange", "grapefruit", "watermelon" }), 36);
            eq(3, (new SimpleWordGame()).points(new string[] { "lidi", "o", "lidi", "gnbewjzb", "kten",
                 "ebnelff", "gptsvqx", "rkauxq", "rkauxq", "kfkcdn"}, new string[] { "nava", "wk", "kfkcdn", "lidi", "gptsvqx",
                 "ebnelff", "hgsppdezet", "ulf", "rkauxq", "wcicx"}), 186);
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
