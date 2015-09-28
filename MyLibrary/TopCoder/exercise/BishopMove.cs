using System;

public class BishopMove
{
    public int howManyMoves(int r1, int c1, int r2, int c2)
    {
        if (r1 == r2 && c1 == c2) return 0;
                
        int min = 0;
        int max = 7;
        if (Hit(r1, c1, r2, c2)) return 1;
        
        for (int i = 1; i <= 7; i++)
        {
            if (r1 + i <= max && c1 + i <= max)
                if (Hit(r1 + i, c1 + i, r2, c2)) return 2;

            if (r1 + i <= max && c1 - i >= min)
                if (Hit(r1 + i, c1 - i, r2, c2)) return 2;

            if (r1 - i >= min && c1 + i <= max)
                if (Hit(r1 - i, c1 + i, r2, c2)) return 2;

            if (r1 - i >= min && c1 - i >= min)
                if (Hit(r1 - i, c1 - i, r2, c2)) return 2;
        }

        return -1;
    }

    private bool Hit(int r1, int c1, int r2, int c2)
    {
        int min = 0;
        int max = 7;
        for (int i = 1; i <= 7; i++)
        {
            if (r1 + i <= max && c1 + i <= max)
                if (r1 + i == r2 && c1 + i == c2) return true;
            
            if (r1 + i <= max && c1 - i >= min)
                if (r1 + i == r2 && c1 - i == c2) return true;
            
            if (r1 - i >= min && c1 + i <= max)
                if (r1 - i == r2 && c1 + i == c2) return true;
            
            if (r1 - i >= min && c1 - i >= min)
                if (r1 - i == r2 && c1 - i == c2) return true;
        }

        return false;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new BishopMove()).howManyMoves(4, 6, 7, 3), 1);
            eq(1, (new BishopMove()).howManyMoves(2, 5, 2, 5), 0);
            eq(2, (new BishopMove()).howManyMoves(1, 3, 5, 5), 2);
            eq(3, (new BishopMove()).howManyMoves(4, 6, 7, 4), -1);
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
