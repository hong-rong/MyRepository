using System;

public class SantaGifts
{
    public string[] distribute(string[] gifts, int N)
    {
        string[] kidGifts = new string[N];
        int count = 0;
        for (int i = 0; i < gifts.Length; i++)
        {
            if (kidGifts[i % N] == null)
                kidGifts[i % N] = gifts[i];
            else
            {
                kidGifts[i % N] = kidGifts[i % N] + " " + gifts[i];
                if (i % N == N - 1 && ++count==3) break;
            }
        }

        for (int j = 0; j < kidGifts.Length; j++)
        {
            if (kidGifts[j] == null)
                kidGifts[j] = "";
        }

        return kidGifts;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new SantaGifts()).distribute(new string[] { "ball", "plane", "robot", "puzzle" }, 3), new string[] { "ball puzzle", "plane", "robot" });
            eq(1, (new SantaGifts()).distribute(new string[] { "ball", "plane", "robot", "puzzle", "bike" }, 1), new string[] { "ball plane robot puzzle" });
            eq(2, (new SantaGifts()).distribute(new string[] { "ball", "ball", "plane", "plane" }, 2), new string[] { "ball plane", "ball plane" });
            eq(3, (new SantaGifts()).distribute(new string[] { "ball", "plane", "robot" }, 5), new string[] { "ball", "plane", "robot", "", "" });
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
