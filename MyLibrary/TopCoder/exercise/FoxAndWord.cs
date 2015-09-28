using System;

public class FoxAndWord
{
    public int howManyPairs(string[] words)
    {
        int count = 0;
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                if (words[i].Length == words[j].Length && words[i].Length > 1)
                {
                    for (int k = 0; k < words[i].Length - 1; k++)
                    {
                        string A = words[i].Substring(0, k + 1) + words[i].Substring(k + 1);
                        string B = words[j].Substring(k + 1) + words[j].Substring(0, k + 1);
                        if (A == B)
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
        }

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new FoxAndWord()).howManyPairs(new string[] { "tokyo", "kyoto" }), 1);
            eq(1, (new FoxAndWord()).howManyPairs(new string[] { "aaaaa", "bbbbb" }), 0);
            eq(2, (new FoxAndWord()).howManyPairs(new string[] { "ababab", "bababa", "aaabbb" }), 1);
            eq(3, (new FoxAndWord()).howManyPairs(new string[] { "eel", "ele", "lee" }), 3);
            eq(4, (new FoxAndWord()).howManyPairs(new string[] { "aaa", "aab", "aba", "abb", "baa", "bab", "bba", "bbb" }), 6);
            eq(5, (new FoxAndWord()).howManyPairs(new string[] { "top", "coder" }), 0);
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
