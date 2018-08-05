using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cubing
{
    /// <summary>
    /// Represents a 2x2 cube and an algorithm set on that cube
    /// </summary>
    public abstract class AbstractCube2x2 : ICube
    {

        // the Colors of stickers of the cube.  The letters define a piece, and the first letter is the face the sticker is on.
        protected CubeColor URF;
        protected CubeColor URB;
        protected CubeColor ULB;
        protected CubeColor ULF;
        protected CubeColor RUB;
        protected CubeColor RUF;
        protected CubeColor BUR;
        protected CubeColor BUL;
        protected CubeColor LUB;
        protected CubeColor LUF;
        protected CubeColor FUL;
        protected CubeColor FUR;

        protected CubeColor DRF;
        protected CubeColor DRB;
        protected CubeColor DLB;
        protected CubeColor DLF;
        protected CubeColor RDB;
        protected CubeColor BDR;
        protected CubeColor BDL;
        protected CubeColor LDB;
        protected CubeColor LDF;
        protected CubeColor FDL;
        protected CubeColor FDR;
        protected CubeColor RDF;


        /// <summary>
        /// Gets the number pf positions in the cube's algorithm set
        /// </summary>
        /// <returns></returns>
        public abstract int GetNumPositions();

        /// <summary>
        /// Paints the cube, impelmentations can paint either 2D or 3D
        /// </summary>
        /// <param name="e">PaintEventArgs used to paint the cube</param>
        /// <param name="sizeRatio">The relative size to paint the cube</param>
        public abstract void Paint(PaintEventArgs e, double SizeRatio);

        /// <summary>
        /// Sets up a position on the cube
        /// </summary>
        /// <param name="posNum">The number of the position to set up</param>
        public abstract void SetUpPosition(int posNum);

        /// <summary>
        /// Paints a 3D representation of this cube
        /// </summary>
        /// <param name="g">Graphics used to paint the cube</param>
        /// <param name="sizeRatio">The relative size to paint the cube</param>
        /// <param name="xShift">x location relative to default location</param>
        /// <param name="yShift">y location relative to default location</param>
        public void Paint3D(Graphics g, double sizeRatio, int xShift, int yShift)
        {
            g.FillPolygon(Brushes.Black, Tools.ScalePointArray(new Point[] { new Point(300, 98), new Point(475, 200), new Point(475, 404), new Point(300, 504), new Point(125, 404), new Point(125, 200) }, sizeRatio, xShift, yShift));  // BUL


            // top face
            g.FillPolygon(Tools.GetBrush(ULB), Tools.ScalePointArray(new Point[] { new Point(300, 102), new Point(384, 150), new Point(299, 199), new Point(216, 151) }, sizeRatio, xShift, yShift));  // BUL
            g.FillPolygon(Tools.GetBrush(URB), Tools.ScalePointArray(new Point[] { new Point(386, 152), new Point(470, 200), new Point(387, 247), new Point(303, 200) }, sizeRatio, xShift, yShift));  // URB
            g.FillPolygon(Tools.GetBrush(ULF), Tools.ScalePointArray(new Point[] { new Point(213, 153), new Point(297, 200), new Point(214, 247), new Point(130, 200) }, sizeRatio, xShift, yShift));  // ULF
            g.FillPolygon(Tools.GetBrush(URF), Tools.ScalePointArray(new Point[] { new Point(299, 202), new Point(384, 249), new Point(300, 297), new Point(216, 249) }, sizeRatio, xShift, yShift));  // URF

            // front face
            g.FillPolygon(Tools.GetBrush(FUL), Tools.ScalePointArray(new Point[] { new Point(129, 203), new Point(213, 251), new Point(213, 348), new Point(129, 301) }, sizeRatio, xShift, yShift));  // FUL
            g.FillPolygon(Tools.GetBrush(FUR), Tools.ScalePointArray(new Point[] { new Point(216, 253), new Point(298, 300), new Point(298, 399), new Point(216, 350) }, sizeRatio, xShift, yShift));  //FUR
            g.FillPolygon(Tools.GetBrush(FDL), Tools.ScalePointArray(new Point[] { new Point(129, 304), new Point(213, 351), new Point(213, 450), new Point(129, 402) }, sizeRatio, xShift, yShift));  //FDL
            g.FillPolygon(Tools.GetBrush(FDR), Tools.ScalePointArray(new Point[] { new Point(216, 354), new Point(298, 402), new Point(298, 499), new Point(216, 452) }, sizeRatio, xShift, yShift));  //FRD

            // right face
            g.FillPolygon(Tools.GetBrush(RUB), Tools.ScalePointArray(new Point[] { new Point(471, 203), new Point(387, 251), new Point(387, 348), new Point(471, 301) }, sizeRatio, xShift, yShift));  // RUB
            g.FillPolygon(Tools.GetBrush(RUF), Tools.ScalePointArray(new Point[] { new Point(384, 253), new Point(302, 300), new Point(302, 399), new Point(384, 350) }, sizeRatio, xShift, yShift));  // RUF
            g.FillPolygon(Tools.GetBrush(RDB), Tools.ScalePointArray(new Point[] { new Point(471, 304), new Point(387, 351), new Point(387, 450), new Point(471, 402) }, sizeRatio, xShift, yShift));  // RDB
            g.FillPolygon(Tools.GetBrush(RDF), Tools.ScalePointArray(new Point[] { new Point(384, 354), new Point(302, 402), new Point(302, 499), new Point(384, 452) }, sizeRatio, xShift, yShift));  // RFD

        }

        /// <summary>
        /// Paints a 2D representation of the top layter of this cube
        /// </summary>
        /// <param name="g">Graphics used to paint the cube</param>
        /// <param name="sizeRatio">The relative size to paint the cube</param>
        /// <param name="xShift">x location relative to default location</param>
        /// <param name="yShift">y location relative to default location</param>
        /// <param name="stickerSize">Outwadr dimension of the non top face stickers</param>
        public void Paint2D(Graphics g, double sizeRatio, int xShift, int yShift, int stickerSize)
        {


            g.FillPolygon(Brushes.Black, Tools.ScalePointArray(new Point[] { new Point(148, 98), new Point(452, 98), new Point(452, 402), new Point(148, 402) }, sizeRatio, xShift, yShift));  // BUL


            g.FillPolygon(Tools.GetBrush(ULB), Tools.ScalePointArray(new Point[] { new Point(152, 102), new Point(298, 102), new Point(298, 248), new Point(152, 248) }, sizeRatio, xShift, yShift));  // ULB
            g.FillPolygon(Tools.GetBrush(URB), Tools.ScalePointArray(new Point[] { new Point(302, 102), new Point(448, 102), new Point(448, 248), new Point(302, 248) }, sizeRatio, xShift, yShift));  // URB
            g.FillPolygon(Tools.GetBrush(ULF), Tools.ScalePointArray(new Point[] { new Point(152, 302), new Point(298, 302), new Point(298, 398), new Point(152, 398) }, sizeRatio, xShift, yShift));  // ULF
            g.FillPolygon(Tools.GetBrush(URF), Tools.ScalePointArray(new Point[] { new Point(302, 302), new Point(448, 302), new Point(448, 398), new Point(302, 398) }, sizeRatio, xShift, yShift));  // URF

            g.FillPolygon(Tools.GetBrush(BUL), Tools.ScalePointArray(new Point[] { new Point(152, 98), new Point(298, 98), new Point(298 - stickerSize, 98 - stickerSize), new Point(152 + stickerSize, 98 - stickerSize) }, sizeRatio, xShift, yShift));  // BUL
            g.FillPolygon(Tools.GetBrush(BUR), Tools.ScalePointArray(new Point[] { new Point(302, 98), new Point(448, 98), new Point(448 - stickerSize, 98 - stickerSize), new Point(302 + stickerSize, 98 - stickerSize) }, sizeRatio, xShift, yShift));  // BUR

            g.FillPolygon(Tools.GetBrush(FUL), Tools.ScalePointArray(new Point[] { new Point(152, 402), new Point(298, 402), new Point(298 - stickerSize, 402 + stickerSize), new Point(152 + stickerSize, 402 + stickerSize) }, sizeRatio, xShift, yShift));  // FUL
            g.FillPolygon(Tools.GetBrush(FUR), Tools.ScalePointArray(new Point[] { new Point(302, 402), new Point(448, 402), new Point(448 - stickerSize, 402 + stickerSize), new Point(302 + stickerSize, 402 + stickerSize) }, sizeRatio, xShift, yShift));  // FUR

            g.FillPolygon(Tools.GetBrush(LUB), Tools.ScalePointArray(new Point[] { new Point(148, 100), new Point(148, 250), new Point(148 - stickerSize, 250 - stickerSize), new Point(148 - stickerSize, 100 + stickerSize) }, sizeRatio, xShift, yShift));  // LUB
            g.FillPolygon(Tools.GetBrush(LUF), Tools.ScalePointArray(new Point[] { new Point(148, 300), new Point(148, 400), new Point(148 - stickerSize, 400 - stickerSize), new Point(148 - stickerSize, 300 + stickerSize) }, sizeRatio, xShift, yShift));  // LUF

            g.FillPolygon(Tools.GetBrush(RUB), Tools.ScalePointArray(new Point[] { new Point(452, 100), new Point(452, 250), new Point(452 + stickerSize, 250 - stickerSize), new Point(452 + stickerSize, 100 + stickerSize) }, sizeRatio, xShift, yShift));  // RUB
            g.FillPolygon(Tools.GetBrush(RUF), Tools.ScalePointArray(new Point[] { new Point(452, 300), new Point(452, 400), new Point(452 + stickerSize, 400 - stickerSize), new Point(452 + stickerSize, 300 + stickerSize) }, sizeRatio, xShift, yShift));  // RUF

        }
    }
}
