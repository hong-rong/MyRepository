using System;

public class TwoWaysSorting
{
    public string sortingMethod(string[] stringList)
    {
        bool isLexicographical = true;
        bool isSortedByLength = true;
        for (int i = 0; i < stringList.Length - 1; i++)
        {
            if (isLexicographical && stringList[i].CompareTo(stringList[i + 1]) > 0)
                isLexicographical = false;

            if (isSortedByLength && stringList[i].Length > stringList[i + 1].Length)
                isSortedByLength = false;

            if (!isLexicographical && !isSortedByLength)
                break;
        }

        if (isSortedByLength && isLexicographical)
            return "both";
        else if (isSortedByLength)
            return "lengths";
        else if (isLexicographical)
            return "lexicographically";
        else
            return "none";
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new TwoWaysSorting()).sortingMethod(new string[] { "a", "aa", "bbb" }), "both");
            eq(1, (new TwoWaysSorting()).sortingMethod(new string[] { "c", "bb", "aaa" }), "lengths");
            eq(2, (new TwoWaysSorting()).sortingMethod(new string[] { "etdfgfh", "aio" }), "none");
            eq(3, (new TwoWaysSorting()).sortingMethod(new string[] { "aaa", "z" }), "lexicographically");
            eq(4, (new TwoWaysSorting()).sortingMethod(new string[] { "z" }), "both");
            eq(5, (new TwoWaysSorting()).sortingMethod(new string[] { "abcdef", "bcdef", "cdef", "def", "ef", "f", "topcoder" }), "lexicographically");
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
