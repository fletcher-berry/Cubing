using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public interface IAlgClient
    {
        string GetAlg(int posNum);
        void Terminate();
    }
}
