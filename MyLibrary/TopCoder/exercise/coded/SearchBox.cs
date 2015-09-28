using System;

public class SearchBox
{
    public int find(string text, string search, string wholeWord, int start)
    {
        int position = -1;
        for (int i = start; i < text.Length; i++)
        {
            if (wholeWord == "N")
            {
                position = text.Substring(start).IndexOf(search);
                if (position != -1) position = position + start;
            }
            else
            {
                if (start > 0 && text[start - 1] == ' ' && text.Substring(start).StartsWith(search + " ") ||
                   start == 0 && text.Substring(start).StartsWith(search + " "))
                {
                    position = start;
                }
                else if (start + 1 <= text.Length - search.Length && text.EndsWith(" " + search))
                {
                    position = text.Length - search.Length;
                }
                else
                {
                    position = text.Substring(start).IndexOf(" " + search + " ");
                    if (position != -1) position = position + start + 1;
                }
            }
        }

        return position;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new SearchBox()).find("We dont need no education", "ed", "N", 13), 16);
            eq(1, (new SearchBox()).find("We dont need no thought control", "We", "Y", 0), 0);
            eq(2, (new SearchBox()).find("No dark sarcasm in the classroom", "The", "Y", 5), -1);
            eq(3, (new SearchBox()).find("Teachers leave them kids alone", "kid", "Y", 1), -1);
            eq(4, (new SearchBox()).find("All in all its just another brick in the wall", "all", "Y", 9), -1);
            eq(5, (new SearchBox()).find("All in all youre just another brick in the wall", "just", "Y", 17), 17);
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
