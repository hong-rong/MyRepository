using System;

public class BinaryIncrementation
{
    public string plusOne(string x)
    {
        char[] value = new char[x.Length];
        bool carry = false;
        for (int i = x.Length - 1; i >= 0; i--)
        {
            if (i == x.Length - 1)
            {
                if (x[i] == '0')
                {
                    value[i] = '1';
                    carry = false;
                }
                else
                {
                    value[i] = '0';
                    carry = true;
                }
            }
            else if (carry)
            {
                if (x[i] == '0')
                {
                    value[i] = '1';
                    carry = false;
                }
                else
                {
                    value[i] = '0';
                    carry = true;
                }
            }
            else
                value[i] = x[i];
        }

        if (carry)
            return "1" + (new string(value));
        else
            return new string(value);
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new BinaryIncrementation()).plusOne("10011"), "10100");
            eq(1, (new BinaryIncrementation()).plusOne("10000"), "10001");
            eq(2, (new BinaryIncrementation()).plusOne("1111"), "10000");
            eq(3, (new BinaryIncrementation()).plusOne("1"), "10");
            eq(4, (new BinaryIncrementation()).plusOne("101010101010101010101010101010"), "101010101010101010101010101011");
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
