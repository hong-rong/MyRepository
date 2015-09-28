using System;
using System.Linq;

public class ComparerInator
{
    public int makeProgram(int[] A, int[] B, int[] wanted)
    {
        int length = 0;

        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] != wanted[i]) break;
            if (i == A.Length - 1) return 1;
        }

        for (int j = 0; j < B.Length; j++)
        {
            if (B[j] != wanted[j]) break;
            if (j == B.Length - 1) return 1;
        }

        for (int k = 0; k < A.Length; k++)
        {
            if ((A[k] < B[k] ? A[k] : B[k]) != wanted[k]) break;
            if (k == A.Length - 1) return 7;
        }

        for (int l = 0; l < A.Length; l++)
        {
            if ((A[l] < B[l] ? B[l] : A[l]) != wanted[l]) break;
            if (l == A.Length - 1) return 7;
        }

        return -1;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ComparerInator()).makeProgram(new int[] { 1 }, new int[] { 2 }, new int[] { 2 }), 1);
            eq(1, (new ComparerInator()).makeProgram(new int[] { 1, 3 }, new int[] { 2, 1 }, new int[] { 2, 3 }), 7);
            eq(2, (new ComparerInator()).makeProgram(new int[] { 1, 3, 5 }, new int[] { 2, 1, 7 }, new int[] { 2, 3, 5 }), -1);
            eq(3, (new ComparerInator()).makeProgram(new int[] { 1, 3, 5 }, new int[] { 2, 1, 7 }, new int[] { 1, 3, 5 }), 1);
            eq(4, (new ComparerInator()).makeProgram(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, new int[] { 5, 4, 7, 8, 3, 1, 1, 2, 3, 4, 6 }, new int[] { 1, 2, 3, 4, 3, 1, 1, 2, 3, 4, 6 }), 7);
            eq(5, (new ComparerInator()).makeProgram(new int[] { 1, 5, 6, 7, 8 }, new int[] { 1, 5, 6, 7, 8 }, new int[] { 1, 5, 6, 7, 8 }), 1);
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
