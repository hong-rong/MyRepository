namespace Lc
{
    public class Lc7
    {
        public int Reverse(int x)
        {
            int result = 0;

            while (x != 0)
            {
                int tail = x % 10;
                int newResult = result * 10 + tail;
                if ((newResult - tail) / 10 != result)
                { return 0; }
                result = newResult;
                x = x / 10;
            }

            return result;
        }

        public int Reverse_MyLessCrapWayVersion(int x)
        {
            long res = 0;

            while (x != 0)
            {
                res = res * 10 + x % 10;

                if (res > int.MaxValue || res < int.MinValue) return 0;

                x = x / 10;
            }

            return (int)res;
        }

        public int Reverse_MyCrapWayVersion(int x)
        {
            bool isNeg = x < 0;
            if (isNeg) x = -1 * x;

            string s = x.ToString();
            char[] arr = new char[s.Length];

            for (int i = 0; i < s.Length; i++)
                arr[i] = s[s.Length - 1 - i];

            if (!int.TryParse(new string(arr), out x))
                return 0;

            return isNeg ? -1 * x : x;
        }
    }
}
