using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Generates a sequence of case numbers
    /// </summary>
    public interface IAlgNumberGenerator
    {
        /// <summary>
        /// Generates a case number, -1 if the sequence has ended
        /// </summary>
        /// <returns></returns>
        int Generate();

        /// <summary>
        /// Gets the number of case numbers in the sequence
        /// </summary>
        /// <returns></returns>
        int GetNumAlgs();
    }
}
