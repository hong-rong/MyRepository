using System;

public class ChessboardPattern
{
    public string[] makeChessboard(int rows, int columns)
    {
        string[] board = new string[rows];
        for (int i = board.Length - 1; i >= 0; i--)
        {
            char[] row = new char[columns];
            for (int j = 0; j < row.Length; j++)
            {
                if (j == 0)
                {
                    if (i == board.Length - 1) row[j] = '.';
                    else if (board[i + 1][j] == '.') row[j] = 'X';
                    else row[j] = '.';
                }
                else
                {
                    if (row[j - 1] == '.') row[j] = 'X';
                    else row[j] = '.';
                }
            }

            board[i] = new string(row);
        }

        return board;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ChessboardPattern()).makeChessboard(8, 8), new string[] { "X.X.X.X.", ".X.X.X.X", "X.X.X.X.", ".X.X.X.X", "X.X.X.X.", ".X.X.X.X", "X.X.X.X.", ".X.X.X.X" });
            eq(1, (new ChessboardPattern()).makeChessboard(1, 20), new string[] { ".X.X.X.X.X.X.X.X.X.X" });
            eq(2, (new ChessboardPattern()).makeChessboard(5, 1), new string[] { ".", "X", ".", "X", "." });
            eq(3, (new ChessboardPattern()).makeChessboard(5, 13), new string[] { ".X.X.X.X.X.X.", "X.X.X.X.X.X.X", ".X.X.X.X.X.X.", "X.X.X.X.X.X.X", ".X.X.X.X.X.X." });
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
