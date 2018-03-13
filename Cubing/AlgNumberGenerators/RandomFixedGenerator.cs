using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class RandomFixedGenerator : IAlgNumberGenerator
    {
        private List<int> _algs;
        private int _lastAlg;
        private int _numGenerated;
        private int _numAlgs;
        private Random _rand;

        public RandomFixedGenerator(List<int> algs, int numAlgs)
        {
            _algs = algs;
            _numAlgs = numAlgs;
            _lastAlg = -1;
            _numGenerated = 0;
            _rand = new Random();
        }

        public int Generate()
        {
            if (_numGenerated == _numAlgs)
                return -1;
            _numGenerated++;
            if (_algs.Count == 0)
                return _algs[0];
            int next = _rand.Next(_algs.Count - 1);
            if (next >= _lastAlg)
                next++;
            _lastAlg = next;
            return next;

        }

        public int GetNumAlgs()
        {
            return _algs.Count;
        }
    }
}
