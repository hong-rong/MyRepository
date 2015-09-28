using System;

public class TopFox
{
    public int possibleHandles(string familyName, string givenName)
    {
        string[] handles = new string[familyName.Length * givenName.Length];
        int index = 0;
        for (int i = 0; i < familyName.Length; i++)
        {
            for (int j = 0; j < givenName.Length; j++)
            {
                handles[index++] = familyName.Substring(0, i + 1) + givenName.Substring(0, j + 1);
            }
        }

        Array.Sort(handles);

        int count = 1;
        for (int k = 1; k < handles.Length; k++)
        {
            if (handles[k] != null && handles[k] != handles[k - 1]) count++;
        }

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new TopFox()).possibleHandles("ab", "cd"), 4);
            eq(1, (new TopFox()).possibleHandles("abb", "bbc"), 7);
            eq(2, (new TopFox()).possibleHandles("fox", "ciel"), 12);
            eq(3, (new TopFox()).possibleHandles("abbbb", "bbbbbbbc"), 16);
            eq(4, (new TopFox()).possibleHandles("abxy", "xyxyxc"), 21);
            eq(5, (new TopFox()).possibleHandles("ababababab", "bababababa"), 68);
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
