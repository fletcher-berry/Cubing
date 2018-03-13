using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing.ConstructPosition
{
    public class CircularLinkedList<T>
    {
        public ListNode<T> Head;

        public CircularLinkedList()
        {
            Head = null;
        }

        public CircularLinkedList(params T[] values)
        {
            if(values == null || values.Length == 0)
            {
                Head = null;
            }
            else
            {
                ListNode<T> first = new ListNode<T>(values[0]);
                ListNode<T> last = first;
                for(int k = 1; k < values.Length; k++)
                {
                    ListNode<T> curr = new ListNode<T>(values[k]);
                    curr.Left = last;
                    last.Right = curr;
                    last = curr;
                }
                last.Right = first;
                first.Left = last;
                Head = first;
            }
        }
    }
}
