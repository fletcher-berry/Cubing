using Cubing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbllDemo
{
    /// <summary>
    /// Used to group subsets. subsets can be grouped based on corner orientation, corner swap, or other criteria. 
    /// </summary>
    public class SubsetGroup
    {
        /// <summary>
        /// The name of the group
        /// </summary>
        public string Name;

        /// <summary>
        /// The subsets in the group
        /// </summary>
        public List<Subset> Subsets;

        /// <summary>
        /// The names of all subgroups in the group. 
        /// </summary>
        public List<string> SubgroupNames;

        /// <summary>
        /// The AlgSet that this group is a part of.
        /// </summary>
        public AlgSet AlgSet;

        public override string ToString()
        {
            return Name;
        }
    }
}
