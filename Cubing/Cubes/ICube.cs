using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Generic cube representing an algorithm set
    /// </summary>
    public interface ICube
    {
        /// <summary>
        /// Gets the number pf positions in the cube's algorithm set
        /// </summary>
        /// <returns></returns> 
        int GetNumPositions();

        /// <summary>
        /// Sets up a position on the cube
        /// </summary>
        /// <param name="posNum">The number of the position to set up</param>
        void SetUpPosition(int posNum);

        /// <summary>
        /// Paints the cube
        /// </summary>
        /// <param name="e">PaintEventArgs used to paint the cube</param>
        /// <param name="sizeRatio">The relative size to paint the cube</param>
        void Paint(System.Windows.Forms.PaintEventArgs e, double sizeRatio);

        void Paint3D(System.Drawing.Graphics g, double sizeRatio, int xShift, int yShift);

        void Paint2D(System.Drawing.Graphics g, double sizeRatio, int xShift, int yShift, int stickerSize); 

    }
}
