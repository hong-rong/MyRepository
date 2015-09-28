using System;
using System.Linq;

public class OptimalList
{
    public string optimize(string inst)
    {
        int[] count = new int[4];
        for (int i = 0; i < inst.Length; i++)
        {
            if (inst[i] == 'N') count[0]++;
            if (inst[i] == 'S') count[1]++;
            if (inst[i] == 'W') count[2]++;
            if (inst[i] == 'E') count[3]++;
        }

        string newInst = "";
        if (count[0] > count[1])
            newInst = "".PadLeft(count[0] - count[1], 'N');
        else
            newInst = "".PadLeft(count[1] - count[0], 'S');

        if (count[2] > count[3])
            newInst = newInst + "".PadLeft(count[2] - count[3], 'W');
        else
            newInst = "".PadLeft(count[3] - count[2], 'E') + newInst;

        return newInst;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new OptimalList()).optimize("NENENNWWWWWS"), "NNNWWW");
            eq(1, (new OptimalList()).optimize("NNEESSWW"), "");
            eq(2, (new OptimalList()).optimize("NEWSNWESWESSEWSENSEWSEWESEWWEWEEWESSSWWWWWW"), "SSSSSSSSWWW");
            eq(3, (new OptimalList()).optimize("NENENE"), "EEENNN");
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
