using System;
using System.Collections.Generic;

namespace Lc
{
    public class Lc15
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var list = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int lo = i + 1, hi = nums.Length - 1, sum = 0 - nums[i];
                    while (lo < hi)
                    {
                        if (nums[lo] + nums[hi] == sum)
                        {
                            list.Add(new List<int>() { nums[i], nums[lo], nums[hi] });
                            while (lo < hi && nums[lo] == nums[lo + 1]) lo++;
                            while (lo < hi && nums[hi] == nums[hi - 1]) hi--;
                            lo++;
                            hi--;
                        }
                        else if (nums[lo] + nums[hi] < sum)
                        {
                            lo++;
                        }
                        else
                        {
                            hi--;
                        }
                    }
                }
            }
            return list;
        }
    }
}
