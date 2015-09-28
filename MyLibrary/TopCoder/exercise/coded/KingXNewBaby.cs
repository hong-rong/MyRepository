using System;

public class KingXNewBaby
{
    public string isValid(string name)
    {
        if (name.Length != 8) return "NO";

        int vowelCount = 0;
        char firstVowel = '\0';
        char secondVowel = '\0';
        for (int i = 0; i < name.Length; i++)
        {
            if (IsVowel(name[i]))
            {
                vowelCount++;
                if (vowelCount == 1) firstVowel = name[i];
                if (vowelCount == 2) secondVowel = name[i];
            }
        }

        if (vowelCount != 2) return "NO";

        if (firstVowel != secondVowel) return "NO";

        return "YES";
    }

    private bool IsVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' ? true : false;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new KingXNewBaby()).isValid("dengklek"), "YES");
            eq(1, (new KingXNewBaby()).isValid("gofushar"), "NO");
            eq(2, (new KingXNewBaby()).isValid("dolphinigle"), "NO");
            eq(3, (new KingXNewBaby()).isValid("mystictc"), "NO");
            eq(4, (new KingXNewBaby()).isValid("rngringo"), "NO");
            eq(5, (new KingXNewBaby()).isValid("misof"), "NO");
            eq(6, (new KingXNewBaby()).isValid("metelsky"), "YES");
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
