using System;
using System.Text;

public class EllysNewNickname
{
	public int getLength(string nickName)
	{
	    StringBuilder sb = new StringBuilder();
		for(int i=0;i<nickName.Length;i++)
		{
			if(i==0) 
				sb.Append(nickName[i]);
			else if(!(IsVowels(nickName[i]) && IsVowels(nickName[i-1])))
				sb.Append(nickName[i]);
		}

		return sb.ToString().Length;
	}

	public bool IsVowels(char c)
	{
		return c=='a' || c=='e' || c=='i' || c=='o' || c=='u' || c=='y';
	}

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new EllysNewNickname()).getLength("tourist"), 6);
            eq(1, (new EllysNewNickname()).getLength("eagaeoppooaaa"), 6);
            eq(2, (new EllysNewNickname()).getLength("esprit"), 6);
            eq(3, (new EllysNewNickname()).getLength("ayayayayayaya"), 1);
            eq(4, (new EllysNewNickname()).getLength("wuuut"), 3);
            eq(5, (new EllysNewNickname()).getLength("naaaaaaaanaaaanaananaaaaabaaaaaaaatmaaaaan"), 16);
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
