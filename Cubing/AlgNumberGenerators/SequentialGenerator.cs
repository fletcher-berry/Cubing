using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class SequentialGenerator : IAlgNumberGenerator
    {
        private List<int> _algs;
        private int _index;


        public SequentialGenerator(List<int> algs)
        {
            _algs = algs;
            _index = 0;
        }

        public int Generate()
        {
            if (_index >= _algs.Count)
                return -1;
            int alg = _algs[_index];
            _index++;
            return alg;
        }

        public int GetNumAlgs()
        {
            return _algs.Count;
        }
    }
}
