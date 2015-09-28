using System;
using System.Linq;

public class GameOfStones
{
    public int count(int[] stones)
    {
        int sum = stones.Sum();
        if (sum % stones.Length != 0) return -1;
        if (sum / stones.Length < 3) return -1;

        int ave = sum / stones.Length;
        int count = 0;
        for (int i = 0; i < stones.Length; i++)
        {
            int diff = stones[i] - ave;
            if (diff % 2 != 0) return -1;
            if (diff > 0) count = count + diff / 2;
        }

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new GameOfStones()).count(new int[] { 7, 15, 9, 5 }), 3);
            eq(1, (new GameOfStones()).count(new int[] { 10, 16 }), -1);
            eq(2, (new GameOfStones()).count(new int[] { 2, 8, 4 }), -1);
            eq(3, (new GameOfStones()).count(new int[] { 17 }), 0);
            eq(4, (new GameOfStones()).count(new int[] { 10, 15, 20, 12, 1, 20 }), -1);
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
