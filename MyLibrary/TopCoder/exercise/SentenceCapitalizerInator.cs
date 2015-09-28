using System;

public class SentenceCapitalizerInator
{
    public string fixCaps(string paragraph)
    {
        char[] para = paragraph.ToCharArray();
        para[0] = Char.ToUpper(para[0]);
        for (int i = para.Length - 1; i > 0; i--)
        {
            if (i - 2 <= 0) break;
            if (para[i - 1] == ' ' && para[i - 2] == '.')
                para[i] = Char.ToUpper(para[i]);
        }

        return new string(para);
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new SentenceCapitalizerInator()).fixCaps("hello programmer. welcome to topcoder."), "Hello programmer. Welcome to topcoder.");
            eq(1, (new SentenceCapitalizerInator()).fixCaps("one."), "One.");
            eq(2, (new SentenceCapitalizerInator()).fixCaps("not really. english. qwertyuio. a. xyz."), "Not really. English. Qwertyuio. A. Xyz.");
            eq(3, (new SentenceCapitalizerInator()).fixCaps("example four. the long fourth example. a. b. c. d."), "Example four. The long fourth example. A. B. C. D.");
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
