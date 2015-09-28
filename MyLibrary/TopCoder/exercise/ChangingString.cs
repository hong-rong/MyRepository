using System;

public class ChangingString
{
    public int distance(string A, string B, int K)
    {
        int[] diff = new int[A.Length];
        for (int i = 0; i < diff.Length; i++)
        {
            diff[i] = Math.Abs(A[i] - B[i]);
        }

        Array.Sort(diff, (a, b) => -1 * a.CompareTo(b));

        for (int j = 0; j < K; j++)
        {
            if (diff[j] != 0) diff[j] = 0;
            else diff[j] = 1;
        }

        int sum = 0;
        for (int k = 0; k < diff.Length; k++)
        {
            sum = sum + diff[k];
        }

        return sum;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ChangingString()).distance("ab", "ba", 2), 0);
            eq(1, (new ChangingString()).distance("aa", "aa", 2), 2);
            eq(2, (new ChangingString()).distance("aaa", "baz", 1), 1);
            eq(3, (new ChangingString()).distance("fdfdfdfdfdsfabasd", "jhlakfjdklsakdjfk", 8), 24);
            eq(4, (new ChangingString()).distance("aa", "bb", 2), 0);
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
