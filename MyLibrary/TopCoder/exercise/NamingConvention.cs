using System;
using System.Text;

public class NamingConvention
{
    public string toCamelCase(string variableName)
    {
        string[] variables = variableName.Split(new char[] { '_' });

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < variables.Length; i++)
        {
            if (i == 0)
                sb.Append(variables[i]);
            else
            {
                sb.Append(variables[i].Substring(0, 1).ToUpper() + variables[i].Substring(1));
            }
        }

        return sb.ToString();
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new NamingConvention()).toCamelCase("sum_of_two_numbers"), "sumOfTwoNumbers");
            eq(1, (new NamingConvention()).toCamelCase("variable"), "variable");
            eq(2, (new NamingConvention()).toCamelCase("t_o_p_c_o_d_e_r"), "tOPCODER");
            eq(3, (new NamingConvention()).toCamelCase("the_variable_name_can_be_very_long_like_this"), "theVariableNameCanBeVeryLongLikeThis");
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
