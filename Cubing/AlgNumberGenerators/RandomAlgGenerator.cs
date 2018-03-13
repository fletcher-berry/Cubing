using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{

    public class RandomAlgGenerator : IAlgNumberGenerator
    {
        List<int> Algs;
        Random Rand;

        public RandomAlgGenerator(List<int> algs)
        {
            Algs = algs;
            Rand = new Random();
        }

        public int Generate()
        {
            int index = Rand.Next(Algs.Count);
            return Algs[index];
        }

        int IAlgNumberGenerator.GetNumAlgs()
        {
            return Algs.Count;
        }
    }
}
