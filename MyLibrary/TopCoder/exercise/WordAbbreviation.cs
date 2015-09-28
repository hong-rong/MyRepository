using System;

public class WordAbbreviation
{
    public string[] getAbbreviations(string[] words)
    {
        int maxLength = int.MinValue;
        for (int i = 0; i < words.Length; i++)
        {
            if (maxLength < words[i].Length)
                maxLength = words[i].Length;
        }

        string[] abb = new string[words.Length];
        for (int j = 1; j <= maxLength; j++)
        {
            for (int k = 0; k < words.Length; k++)
            {
                if (j > words[k].Length || abb[k] != null) continue;

                bool unique = true;
                for (int l = 0; l < words.Length; l++)
                {
                    if (j > words[l].Length || abb[l] != null || k == l) continue;

                    if (words[k].Substring(0, j) == words[l].Substring(0, j))
                    {
                        unique = false;
                        break;
                    }
                }

                if (unique) abb[k] = words[k].Substring(0, j);
            }
        }

        return abb;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new WordAbbreviation()).getAbbreviations(new string[] { "abc", "def", "ghi" }), new string[] { "a", "d", "g" });
            eq(1, (new WordAbbreviation()).getAbbreviations(new string[] { "aaab", "aaac", "aaad" }), new string[] { "aaab", "aaac", "aaad" });
            eq(2, (new WordAbbreviation()).getAbbreviations(new string[] { "top", "coder", "contest" }), new string[] { "t", "cod", "con" });
            eq(3, (new WordAbbreviation()).getAbbreviations(new string[] {
                "bababaaaaa",
                "baaabaababa",
                "bbabaaabbaaabbabaabaabbbbbaabb",
                "aaababababbbbababbbaabaaaaaaaabbabbbaaab",
                "baaaaabaababbbaabbbabbababbbabbbbbbbbab"
               }), new string[] { "bab", "baaab", "bb", "a", "baaaa" });
            eq(4, (new WordAbbreviation()).getAbbreviations(new string[] { "oneword" }), new string[] { "o" });
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
