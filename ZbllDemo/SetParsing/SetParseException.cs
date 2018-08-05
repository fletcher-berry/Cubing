using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbllDemo.SetParsing
{
    public class SetParseException : ArgumentException
    {
        public SetParseException(string message) : base(message) { }
    }
}
