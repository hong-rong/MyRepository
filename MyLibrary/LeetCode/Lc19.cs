using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lc
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Lc19
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var p = new ListNode(0);
            var tmp = new ListNode(0);
            p.next = head;
            tmp.next = head;
            while (--n >= 0)
            {
                p = p.next;
            }
            if (p.next == null)
            {
                head = head.next;
            }
            else
            {
                while (p.next != null)
                {
                    p = p.next;
                    tmp = tmp.next;
                }
                tmp = tmp.next;
            }
            return head;
        }
    }
}
