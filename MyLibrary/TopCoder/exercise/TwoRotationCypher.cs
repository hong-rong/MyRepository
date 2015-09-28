using System;

public class TwoRotationCypher
{
    public string encrypt(int firstSize, int firstRotate, int secondRotate, string message)
    {
        char[] m = new char[message.Length];
        for (int i = 0; i < message.Length; i++)
        {
            if (message[i] == ' ') m[i] = ' ';
            else if (message[i] < firstSize + 97)
            {
                if (message[i] + firstRotate >= firstSize + 97)
                    m[i] = Convert.ToChar((message[i] + firstRotate) % (firstSize + 97) + 97);
                else
                    m[i] = Convert.ToChar(message[i] + firstRotate);
            }
            else
            {
                if (message[i] + secondRotate > 122)
                    m[i] = Convert.ToChar((message[i] + secondRotate) % 123 + firstSize + 97);
                else
                    m[i] = Convert.ToChar(message[i] + secondRotate);
            }
        }

        return new string(m);
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new TwoRotationCypher()).encrypt(13, 0, 0, "this string will not change at all"), "this string will not change at all");
            eq(1, (new TwoRotationCypher()).encrypt(13, 7, 0, "only the letters a to m in this string change"), "onfy tbl flttlrs h to g cn tbcs strcna jbhnal");
            eq(2, (new TwoRotationCypher()).encrypt(9, 0, 16, "j to z will change here"), "z sn y vikk chamge heqe");
            eq(3, (new TwoRotationCypher()).encrypt(17, 9, 5, "the quick brown fox jumped over the lazy dog"), "yqn izalc kwgsf ogt bzehnm grnw yqn djvu mgp");
            eq(4, (new TwoRotationCypher()).encrypt(3, 1, 2, "  watch   out for strange  spacing "), "  ybvaj   qwv hqt uvtbpig  urbakpi ");
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
