using Cubing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing.ConstructPosition
{
    public class Action
    {
        public List<ListNode<CubeColor>> Pieces;

        public Action()
        {
            Pieces = new List<ListNode<CubeColor>>();
        }
    }
}
