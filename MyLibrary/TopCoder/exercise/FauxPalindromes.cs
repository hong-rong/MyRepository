using System;

public class FauxPalindromes
{
    public string classifyIt(string word)
    {
        if (IsPalindrome(word))
            return "PALINDROME";

        char[] faux = new char[word.Length];
        int index = 0;
        for (int i = 0; i < word.Length; i++)
        {
            if (i == 0) faux[index++] = word[i];
            else if (word[i] != word[i - 1]) faux[index++] = word[i];
        }

        if (IsPalindrome(new string(faux, 0, index))) return "FAUX";

        return "NOT EVEN FAUX";
    }

    public bool IsPalindrome(string word)
    {
        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
                return false;
        }

        return true;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            //eq(0, (new FauxPalindromes()).classifyIt("ANA"), "PALINDROME");
            eq(1, (new FauxPalindromes()).classifyIt("AAAAANNAA"), "FAUX");
            eq(2, (new FauxPalindromes()).classifyIt("LEGENDARY"), "NOT EVEN FAUX");
            eq(3, (new FauxPalindromes()).classifyIt("XXXYTYYTTYX"), "FAUX");
            eq(4, (new FauxPalindromes()).classifyIt("TOPCOODEREDOOCPOT"), "PALINDROME");
            eq(5, (new FauxPalindromes()).classifyIt("TOPCODEREDOOCPOT"), "FAUX");
            eq(6, (new FauxPalindromes()).classifyIt("XXXXYYYYYZZXXYYY"), "NOT EVEN FAUX");
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
