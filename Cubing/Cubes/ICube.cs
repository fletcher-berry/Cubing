using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public interface ICube
    {
        int GetNumPositions();

        void SetUpPosition(int posNum);

        void Paint(System.Windows.Forms.PaintEventArgs e);

    }
}
