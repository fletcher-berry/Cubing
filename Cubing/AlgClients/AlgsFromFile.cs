using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Retrieves algorithms from a file when requested
    /// </summary>
    public class AlgsFromFile : IAlgClient
    {
        private AlgFile _file;

        /// <summary>
        /// creates a new instance of AlgsFromFile
        /// </summary>
        /// <param name="fileName">The .alg file from which to retrieve algorithms</param>
        public AlgsFromFile(string fileName)
        {
            _file = new AlgFile(fileName, AlgFileMode.Open, AlgFileAccess.Read);
        }

        /// <summary>
        /// Retrieves the algorithm for a given position
        /// </summary>
        /// <param name="posNum">The number of a rubik's cube position</param>
        /// <returns></returns>
        public string GetAlg(int posNum)
        {
            if (posNum < 0 || posNum >= _file.NumAlgs)
                throw new ArgumentOutOfRangeException("illegal position number: " + posNum);
            Algorithm alg = _file.Read(posNum);
            return alg.ToString();
        }

        /// <summary>
        /// Closes the .alg file associated with this object
        /// </summary>
        public void Terminate()
        {
            _file.Close();
        }
    }
}
