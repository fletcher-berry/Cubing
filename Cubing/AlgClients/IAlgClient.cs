using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// This interface is used to retrieve rubik's cub algorithms
    /// </summary>
    public interface IAlgClient
    {
        /// <summary>
        /// Retrieves the algorithm for a given position
        /// </summary>
        /// <param name="posNum">The number of a rubik's cube position</param>
        /// <returns></returns>
        string GetAlg(int posNum);

        /// <summary>
        /// Releases all resources associated with the alg client
        /// </summary>
        void Terminate();
    }
}
