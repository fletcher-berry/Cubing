using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbllDemo.SetParsing
{
    public class ParsingContext
    {
        public List<int> PrevValue;
        public Operator prevOperator;

        public ParsingContext(List<int> prevValue, Operator prevOperator)
        {
            PrevValue = prevValue;
            this.prevOperator = prevOperator;
        }
    }
}
