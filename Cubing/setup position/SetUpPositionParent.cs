using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cubing.ConstructPosition
{
    public class SetUpPositionParent : Form
    {
        public virtual void PosNumReceived(AlgSet set, int value) { }
    }
}
