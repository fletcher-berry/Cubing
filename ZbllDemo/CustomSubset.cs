using Cubing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbllDemo
{
    /// <summary>
    /// Represents a subset defined by a user.
    /// </summary>
    public class CustomSubset
    {
        /// <summary>
        /// The name of the subset
        /// </summary>
        public string Name;

        /// <summary>
        /// The inputted string of ranges and subset names used to generate this subset
        /// </summary>
        public string RangeStr;

        /// <summary>
        /// The AlgSet that this subset is a subset of
        /// </summary>
        public AlgSet AlgSet;

        public CustomSubset(string name, string rangeStr, AlgSet set)
        {
            Name = name;
            RangeStr = rangeStr;
            AlgSet = set;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
