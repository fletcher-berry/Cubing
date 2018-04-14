using Cubing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing.ConstructPosition
{
    /// <summary>
    /// represents an action taken to color one or more pieces
    /// </summary>
    public class Action
    {
        /// <summary>
        /// A list of nodes affected by this action
        /// </summary>
        public List<ListNode<CubeColor>> Pieces;

        /// <summary>
        /// Creates a new Action
        /// </summary>
        public Action()
        {
            Pieces = new List<ListNode<CubeColor>>();
        }
    }
}
