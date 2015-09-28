using System;

public class LittleElephantAndDouble
{
    public string getAnswer(int[] A)
    {
        Array.Sort(A, (a, b) => { return -1 * a.CompareTo(b); });

        for (int i = 0; i < A.Length; i++)
        {
            for (int j = i; j < A.Length - 1; j++)
            {
                if (A[j] % A[j + 1] != 0) return "NO";
            }
        }

        return "YES";
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new LittleElephantAndDouble()).getAnswer(new int[] { 1, 2 }), "YES");
            eq(1, (new LittleElephantAndDouble()).getAnswer(new int[] { 1, 2, 3 }), "NO");
            eq(2, (new LittleElephantAndDouble()).getAnswer(new int[] { 4, 8, 2, 1, 16 }), "YES");
            eq(3, (new LittleElephantAndDouble()).getAnswer(new int[] { 94, 752, 94, 376, 1504 }), "YES");
            eq(4, (new LittleElephantAndDouble()).getAnswer(new int[] { 148, 298, 1184 }), "NO");
            eq(5, (new LittleElephantAndDouble()).getAnswer(new int[] { 7, 7, 7, 7 }), "YES");
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
