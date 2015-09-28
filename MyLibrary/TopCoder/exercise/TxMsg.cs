
using System;
using System.Text;

public class TxMsg
{
    public string getMessage(string original)
    {
        string[] words = original.Split(new Char[] { ' ' });
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < words.Length; i++)
        {
            string oneWord = null;
            if (AreAllVowels(words[i]))
            {
                oneWord = words[i];
            }
            else
            {
                char[] w = new char[words[i].Length];
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (j == 0)
                    {
                        if (IsVowel(words[i][j])) w[j] = ' ';
                        else w[j] = words[i][j];
                    }
                    else if (!IsVowel(words[i][j]) && IsVowel(words[i][j - 1]))
                    {
                        w[j] = words[i][j];
                    }
                    else
                    {
                        w[j] = ' ';
                    }
                }

                oneWord = new string(w);
                oneWord = oneWord.Replace(" ", "");
            }

            if (i != words.Length - 1) sb.Append(string.Format("{0} ", oneWord));
            else sb.Append(string.Format("{0}", oneWord));
        }

        return sb.ToString();
    }

    private bool IsVowel(char c)
    {
        if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') return true;

        return false;
    }

    private bool AreAllVowels(string word)
    {
        //throw exception if empty or null

        for (int i = 0; i < word.Length; i++)
        {
            if (!IsVowel(word[i])) return false;
        }

        return true;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new TxMsg()).getMessage("text message"), "tx msg");
            eq(1, (new TxMsg()).getMessage("ps i love u"), "p i lv u");
            eq(2, (new TxMsg()).getMessage("please please me"), "ps ps m");
            eq(3, (new TxMsg()).getMessage("back to the ussr"), "bc t t s");
            eq(4, (new TxMsg()).getMessage("aeiou bcdfghjklmnpqrstvwxyz"), "aeiou b");
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
