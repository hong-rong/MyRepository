using System;

public class MostCommonLetters
{
    int[] counts = new int[26];
    public string listMostCommon(string[] text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < text[i].Length; j++)
            {
                if (text[i][j] != ' ')
                    counts[text[i][j] - 'a']++;
            }
        }

        int maxCount = int.MinValue;
        for (int j = 0; j < counts.Length; j++)
        {
            if (maxCount < counts[j]) maxCount = counts[j];
        }

        string l = null;
        for (int j = 0; j < counts.Length; j++)
        {
            if (counts[j] == maxCount) l = l + (Convert.ToChar(j + 'a')).ToString();
        }

        return l;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new MostCommonLetters()).listMostCommon(new string[] { "abc a" }), "a");
            eq(1, (new MostCommonLetters()).listMostCommon(new string[] { "abc", "ab" }), "ab");
            eq(2, (new MostCommonLetters()).listMostCommon(new string[] { "qwerty", "abc", "qwe", "a" }), "aeqw");
            eq(3, (new MostCommonLetters()).listMostCommon(new string[] {"english is a west germanic language originating",
                "in england and is the first language for most",
                "people in the united kingdom the united",
                "states canada australia new zealand ireland",
                "and the anglophone caribbean it is used",
                "extensively as a second language and as an",
                "official language throughout the world",
                "especially in commonwealth countries and in",
                "many international organizations"}), "a");
            eq(4, (new MostCommonLetters()).listMostCommon(new string[] {"amanda forsaken bloomer meditated gauging knolls",
                "betas neurons integrative expender commonalities",
                "latins antidotes crutched bandwidths begetting",
                "prompting dog association athenians christian ires",
                "pompousness percolating figured bagatelles bursted",
                "ninth boyfriends longingly muddlers prudence puns",
                "groove deliberators charter collectively yorks",
                "daringly antithesis inaptness aerosol carolinas",
                "payoffs chumps chirps gentler inexpressive morales"}), "e");
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
