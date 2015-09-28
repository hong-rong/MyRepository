using System;

public class EasyConversionMachine
{
    public string isItPossible(string originalWord, string finalWord, int k)
    {
        int diff = 0;
        for (int i = 0; i < originalWord.Length; i++)
        {
            if (originalWord[i] != finalWord[i]) diff++;
        }

        if (diff > k) return "IMPOSSIBLE";
        else if (diff == k) return "POSSIBLE";
        else if ((k - diff) % 2 == 0) return "POSSIBLE";
        else return "IMPOSSIBLE";
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new EasyConversionMachine()).isItPossible("aababba", "bbbbbbb", 2), "IMPOSSIBLE");
            eq(1, (new EasyConversionMachine()).isItPossible("aabb", "aabb", 1), "IMPOSSIBLE");
            eq(2, (new EasyConversionMachine()).isItPossible("aaaaabaa", "bbbbbabb", 8), "POSSIBLE");
            eq(3, (new EasyConversionMachine()).isItPossible("aaa", "bab", 4), "POSSIBLE");
            eq(4, (new EasyConversionMachine()).isItPossible("aababbabaa", "abbbbaabab", 9), "IMPOSSIBLE");
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
