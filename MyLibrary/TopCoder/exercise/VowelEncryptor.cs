using System;

public class VowelEncryptor
{
    public string[] encrypt(string[] text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (HasNonVowel(text[i]))
            {
                char[] word = new char[text[i].Length];
                for (int j = 0; j < text[i].Length; j++)
                {
                    if (!IsVowel(text[i][j]))
                    {
                        word[j] = text[i][j];
                    }
                }

                text[i] = (new string(word)).Replace("\0", "");
            }
        }

        return text;
    }

    private bool HasNonVowel(string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (!IsVowel(word[i]))
                return true;
        }

        return false;
    }

    private bool IsVowel(char c)
    {
        if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            return true;

        return false;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new VowelEncryptor()).encrypt(new string[] { "hello", "world" }), new string[] { "hll", "wrld" });
            eq(1, (new VowelEncryptor()).encrypt(new string[] { "a", "b", "c" }), new string[] { "a", "b", "c" });
            eq(2, (new VowelEncryptor()).encrypt(new string[] { "he", "who", "is", "greedy", "is", "disgraced" }), new string[] { "h", "wh", "s", "grdy", "s", "dsgrcd" });
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
