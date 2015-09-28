namespace Lc
{
    public class Lc5
    {
        public string LongestPalindrome(string s)
        {
            if (s.Length <= 1) return s;

            int min_start = 0, len = 0;
            for (int i = 0; i < s.Length; )
            {
                if (s.Length - i <= len / 2) break;//optimise 1: end loop earlier by checking left substring length
                //shoudn't be s.Length-i-1<=len/2 because current i counts
                int j = i, k = i;
                while (k < s.Length - 1 && s[k + 1] == s[k]) k++;

                i = k + 1;//optimise 2: duplication check, handle odd/even automatically

                while (k < s.Length - 1 && j > 0 && s[k + 1] == s[j - 1])
                {
                    k++;
                    j--;
                }

                int new_len = k - j + 1;
                if (new_len > len)
                {
                    min_start = j;
                    len = new_len;
                }
            }

            return s.Substring(min_start, len);
        }

        public string LongestPalindrome_MyCrapWayTLE(string s)
        {
            if (s.Length <= 1) return s;

            for (int i = s.Length; i > 0; i--)
            {
                for (int j = 0; i + j <= s.Length; j++)
                {
                    if (IsPalindrome(s.Substring(j, i)))
                        return s.Substring(j, i);
                }
            }

            return "";
        }

        private bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
                if (s[i] != s[s.Length - 1 - i]) return false;

            return true;
        }
    }
}