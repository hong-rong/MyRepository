using System;

namespace Lc
{
    public class Lc8
    {
        public int MyAtoi(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            int i = 0;
            int baseRes = 0;
            bool isNeg = false;
            while (str[i] == ' ' || str[i] == '\t' || str[i] == '\r' || str[i] == '\n') ++i;

            if (str[i] == '+') ++i;
            else if (str[i] == '-')
            {
                ++i;
                isNeg = true;
            }

            while (i < str.Length && str[i] >= '0' && str[i] <= '9')
            {
                checked
                {
                    if (baseRes > int.MaxValue / 10 || (baseRes == int.MaxValue / 10 && str[i] - '0' > 7))//can't use str[i] - '0' >= 7, -2147483647 will fail
                        if (isNeg) return int.MinValue;
                        else return int.MaxValue;

                    baseRes = 10 * baseRes + (str[i++] - '0');//the brackets is necessary
                }
            }

            return isNeg ? -1 * baseRes : baseRes;
        }

        public int MyAtoi_MyCrapWayVersion(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            bool skip = false;
            int start = -1;
            int count = 0;
            bool hasSign = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (!skip && (str[i] == ' ' || str[i] == '\t' || str[i] == '\r' || str[i] == '\n'))
                    continue;
                else
                    skip = true;

                if (str[i] >= '0' && str[i] <= '9')
                {
                    if (start == -1) start = i;
                    count++;
                }
                else if (!hasSign && (str[i] == '-' || str[i] == '+'))
                {
                    hasSign = true;
                    start = i;
                    count++;
                }
                else
                    break;
            }

            if (start == -1 || (hasSign && count == 1)) return 0;

            int result;
            string subStr = str.Substring(start, count);
            try
            {
                result = int.Parse(subStr);
            }
            catch (OverflowException)
            {
                if (subStr.StartsWith("-"))
                    result = int.MinValue;
                else
                    result = int.MaxValue;
            }

            return result;
        }
    }
}