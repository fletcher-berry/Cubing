using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class AlgsFromFile : IAlgClient
    {
        public AlgFile File;

        public AlgsFromFile(string fileName)
        {
            File = new AlgFile(fileName, AlgFileMode.Open, AlgFileAccess.Read);
        }

        public string GetAlg(int posNum)
        {
            if (posNum < 0 || posNum >= File.NumAlgs)
                throw new ArgumentOutOfRangeException("illegal position number: " + posNum);
            Algorithm alg = File.Read(posNum);
            return alg.ToString();
        }

        public void Terminate()
        {
            File.Close();
        }
    }
}
