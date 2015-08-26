using System;
using System.Collections.Generic;
using System.Text;

namespace Lc
{
    public class Lc9
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            int n = 0;
            int temp = x;
            while (temp > 0)
            {
                temp = temp / 10;
                ++n;
            }

            int low = 0;
            int high = 0;
            int j = 1;
            while (j <= n / 2)
            {
                low = x % (int)Math.Pow(10, j) / (int)Math.Pow(10, j - 1);

                if (j == 1)
                    high = x / (int)Math.Pow(10, n - j);//highest bit, also can avoid overflow when n=10
                else
                    high = x % (int)Math.Pow(10, n + 1 - j) / (int)Math.Pow(10, n - j);

                if (low != high) return false;
                j++;
            }

            return true;
        }

        public bool isPalindrome_From_Discussion(int x)
        {
            if (x < 0 || (x != 0 && x % 10 == 0)) return false;
            int rev = 0;
            while (x > rev)
            {
                rev = rev * 10 + x % 10;
                x = x / 10;
            }
            return (x == rev || x == rev / 10);
        }

        //wrong
        public bool IsPalindrome3(int x)
        {
            int i = 0;
            int temp = x;
            while (temp > 0)
            {
                temp = temp / 10;
                ++i;
            }

            int remain = 0;
            int high = 0;
            while (x > 0 && i >= 0)
            {
                remain = x % 10;
                high = (int)(x / Math.Pow(10, i));
                if (remain != high) return false;
                i = i - 2;
            }

            return true;
        }

        //wrong
        public bool IsPalindrome2(int x)
        {
            int i = 0;
            int temp = x;
            while (temp > 0)
            {
                temp = temp / 10;
                ++i;
            }

            int low = 0;
            int high = 0;
            int j = 1;
            while (j <= i)
            {
                low = x % (int)Math.Pow(10, j);
                high = x % (int)Math.Pow(10, i - 1);
                if (low != high) return false;
                --i;
                ++j;
            }

            return true;
        }
    }
}
