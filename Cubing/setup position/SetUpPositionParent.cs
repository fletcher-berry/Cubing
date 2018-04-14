using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cubing.ConstructPosition
{
    /// <summary>
    /// Interface for any class that makes use of the SetupForm.  
    /// </summary>
    public interface ISetUpPositionParent 
    {
        /// <summary>
        /// Defines how the client will process the position received from the SetupForm
        /// </summary>
        /// <param name="set">The selected algorithm set</param>
        /// <param name="value">The number of the constructed position</param>
        void PosNumReceived(AlgSet set, int value);
    }
}
