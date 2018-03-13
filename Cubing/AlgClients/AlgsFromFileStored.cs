using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class AlgsFromFileStored : IAlgClient
    {
        List<Algorithm> Algs;

        public AlgsFromFileStored(string fileName)
        {
            Algs = new List<Algorithm>();
            var file = new AlgFile(fileName, AlgFileMode.Open, AlgFileAccess.Read);
            for(int k = 0; k < file.NumAlgs; k++)
            {
                Algs.Add(file.Read(k));
            }
            file.Close();
        }

        public string GetAlg(int posNum)
        {
            if (posNum < 0 || posNum >= Algs.Count)
                throw new ArgumentOutOfRangeException("illegal position number: " + posNum);
            return Algs[posNum].ToString();
        }

        public void Terminate()
        {
            
        }
    }
}
