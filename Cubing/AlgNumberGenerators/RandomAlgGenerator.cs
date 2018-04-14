using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Generates case numbers randomly
    /// </summary>
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

        // irrelevant because the sequence does not end
        int IAlgNumberGenerator.GetNumAlgs()
        {
            return Algs.Count;
        }
    }
}
