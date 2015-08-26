using System;
using System.Diagnostics;

namespace Lc
{
    public class Lc4
    {
        public double FindMedianSortedArrays(int[] a, int[] b)
        {
            var total = a.Length + b.Length;

            if (total % 2 == 0)
            {
                var leftvalue = FindKth(a, 0, a.Length - 1, b, 0, b.Length - 1, total / 2);
                var rightvalue = FindKth(a, 0, a.Length - 1, b, 0, b.Length - 1, total / 2 + 1);

                return (leftvalue + rightvalue) / 2.0;
            }
            else
            {
                return FindKth(a, 0, a.Length - 1, b, 0, b.Length - 1, total / 2 + 1);
            }
        }

        public double FindKth(int[] a, int lowA, int highA, int[] b, int lowB, int highB, int k)
        {
            Debug.WriteLine(string.Format("k = {0}", k));

            if (lowA > highA)
            {
                return b[lowB + k - 1];
            }

            if (lowB > highB)
            {
                return a[lowA + k - 1];
            }

            var midA = (lowA + highA) / 2;
            var midB = (lowB + highB) / 2;

            if (a[midA] <= b[midB])
            {
                if (k <= midA - lowA + midB - lowB + 1)
                    return this.FindKth(a, lowA, highA, b, lowB, midB - 1, k);
                else
                    return this.FindKth(a, midA + 1, highA, b, lowB, highB, k - (midA - lowA + 1));
            }
            else
            {
                if (k <= midA - lowA + midB - lowB + 1)
                    return this.FindKth(a, lowA, midA - 1, b, lowB, highB, k);
                else
                    return this.FindKth(a, lowA, highA, b, midB + 1, highB, k - (midB - lowB + 1));
            }
        }
    }
}