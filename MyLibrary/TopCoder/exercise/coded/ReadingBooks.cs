using System;
using System.Linq;

public class ReadingBooks
{
    public int countBooks(string[] readParts)
    {
        if (readParts.Length < 3) return 0;

        int count = 0;
        int index = 2;
        while (index < readParts.Length)
        {
            if (readParts[index - 2] != readParts[index - 1] &&
               readParts[index - 1] != readParts[index] &&
               readParts[index] != readParts[index - 2])
            {
                index = index + 3;
                count++;
            }
            else
            {
                index++;
            }
        }

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ReadingBooks()).countBooks(new string[] { "introduction", "story", "introduction", "edification" }), 1);
            eq(1, (new ReadingBooks()).countBooks(new string[] { "introduction", "story", "edification", "introduction", "story", "edification" }), 2);
            eq(2, (new ReadingBooks()).countBooks(new string[] { "introduction", "story", "introduction", "edification", "story", "introduction" }), 1);
            eq(3, (new ReadingBooks()).countBooks(new string[] {"introduction", "story", "introduction", "edification", "story",
                "story", "edification", "edification", "edification", "introduction",
                "introduction", "edification", "story", "introduction", "story",
                "edification", "edification", "story", "introduction", "edification",
                "story", "story", "edification", "introduction", "story"}), 5);
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
