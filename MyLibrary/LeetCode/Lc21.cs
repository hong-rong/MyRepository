using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lc
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) { val = x; }
     * }
     */
    public class Lc21
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            ListNode p1 = new ListNode(0);
            ListNode p2 = new ListNode(0);
            ListNode prev = new ListNode(0);
            p1.next = l1;
            p2.next = l2;

            while (p2.next != null && p1.next.val >= p2.next.val)
            {
                prev.next = p2.next;
                p2.next = p2.next.next;
                prev.next.next = p1.next;
                l1 = prev.next;
            }
            while (p1.next != null && p2.next != null)
            {
                if (p1.next.val < p2.next.val)
                {
                    prev.next = p1.next;
                    p1.next = p1.next.next;
                }
                else
                {
                    prev.next.next = p2.next;
                    p2.next = p2.next.next;
                    prev.next.next.next = p1.next;
                }
            }
            if (p1.next == null)
            {
                prev.next = p2.next;
            }

            return l1;
        }
    }
}
