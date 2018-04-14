using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Generates each provided case number once in a random order
    /// </summary>
    public class SingleCycleGenerator : IAlgNumberGenerator
    {
        List<int> Algs;
        Random Rand;
        int NumAlgs;

        public SingleCycleGenerator(List<int> algs)
        {
            Algs = new List<int>();
            for (int k = 0; k < algs.Count; k++)
                Algs.Add(algs[k]);
            Rand = new Random();
            NumAlgs = algs.Count;
        }

        public int Generate()
        {
            if (Algs.Count == 0)
                return -1;
            int index = Rand.Next(Algs.Count);
            int val = Algs[index];
            Algs.RemoveAt(index);
            return val;
        }

        public int GetNumAlgs()
        {
            return NumAlgs;
        }
    }
}
