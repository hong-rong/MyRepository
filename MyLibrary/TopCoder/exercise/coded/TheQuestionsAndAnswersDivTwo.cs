using System;

public class TheQuestionsAndAnswersDivTwo
{
    public int find(string[] questions)
    {
        if (questions.Length == 1) return 2;

        Array.Sort(questions);

        int unique = 1;
        for (int i = 1; i < questions.Length; i++)
        {
            if (questions[i] != questions[i - 1]) unique++;
        }

        if (unique == 1) return 2;

        return (int)Math.Pow(unique, 2);
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new TheQuestionsAndAnswersDivTwo()).find(new string[] { "How_are_you_doing?", "How_do_you_like_our_country?", "How_are_you_doing?" }), 4);
            eq(1, (new TheQuestionsAndAnswersDivTwo()).find(new string[] { "Whazzup?" }), 2);
            eq(2, (new TheQuestionsAndAnswersDivTwo()).find(new string[] { "Are_you_ready?", "Are_you_ready?", "Are_you_ready?", "Are_you_ready?" }), 2);
            eq(3, (new TheQuestionsAndAnswersDivTwo()).find(new string[] { "Do_you_like_my_story?", "Do_you_like_my_story", "DO_YOU_LIKE_MY_STORY?", "Do__you__like__my__story?" }), 16);
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
