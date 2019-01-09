using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTrainer
{
    public class Subset
    {
        /// <summary>
        /// The name of the subset
        /// </summary>
        public string Name;

        /// <summary>
        /// The list of ranges of position numbers for the subset.
        /// </summary>
        public string SubsetList;

        /// <summary>
        /// The name of the subgroup that this subset is in.  Used for filtering.  Null if the subset is not in a subgroup.
        /// </summary>
        public string Subgroup;

        public override string ToString()
        {
            return Name;
        }
    }
}
