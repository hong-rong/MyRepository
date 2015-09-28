using System;

public class GroupedWordChecker
{
    public int howMany(string[] words)
    {
        int groupCount = 0;
        for (int i = 0; i < words.Length; i++)
        {
            if (IsGrouped(words[i])) groupCount++;
        }

        return groupCount;
    }

    private bool IsGrouped(string word)
    {
        for (int i = 0; i < word.Length - 1; i++)
        {
            if (word[i] != word[i + 1])
            {
                for (int j = i + 1; j < word.Length; j++)
                    if (word[i] == word[j])
                        return false;
            }
        }

        return true;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new GroupedWordChecker()).howMany(new string[] { "ccazzzzbb", "code", "aabbbccb", "topcoder" }), 2);
            eq(1, (new GroupedWordChecker()).howMany(new string[] { "ab", "aa", "aca", "ba", "bb" }), 4);
            eq(2, (new GroupedWordChecker()).howMany(new string[] { "happy", "new", "year" }), 3);
            eq(3, (new GroupedWordChecker()).howMany(new string[] { "yzyzy", "zyzyz" }), 0);
            eq(4, (new GroupedWordChecker()).howMany(new string[] { "z" }), 1);
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
