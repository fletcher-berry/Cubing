using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Retrieves algorithms from a file.  File is only accessed upon creation of an instance of this class
    /// </summary>
    public class AlgsFromFileStored : IAlgClient
    {
        private List<Algorithm> _algs;

        /// <summary>
        /// Creates a new instance of AlgsFromFileStored
        /// </summary>
        /// <param name="fileName"></param>
        public AlgsFromFileStored(string fileName)
        {
            _algs = new List<Algorithm>();
            var file = new AlgFile(fileName, AlgFileMode.Open, AlgFileAccess.Read);
            for(int k = 0; k < file.NumAlgs; k++)
            {
                _algs.Add(file.Read(k));
            }
            file.Close();
        }

        /// <summary>
        /// Retrieves the algorithm for a given position
        /// </summary>
        /// <param name="posNum">The number of a rubik's cube position</param>
        /// <returns></returns>
        public string GetAlg(int posNum)
        {
            if (posNum < 0 || posNum >= _algs.Count)
                throw new ArgumentOutOfRangeException("illegal position number: " + posNum);
            return _algs[posNum].ToString();
        }

        public void Terminate()
        {
            
        }
    }
}
