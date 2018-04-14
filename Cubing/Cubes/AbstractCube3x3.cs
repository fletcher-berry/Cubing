using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cubing
{
    /// <summary>
    /// Represents a 3x3 cube and an algorithm set on that cube
    /// </summary>
    public abstract class AbstractCube3x3 : ICube
    {

        // the Colors of stickers of the cube.  The letters define a piece, and the first letter is the face the sticker is on.
        protected CubeColor UF;
        protected CubeColor URF;
        protected CubeColor UR;
        protected CubeColor URB;
        protected CubeColor UB;
        protected CubeColor ULB;
        protected CubeColor UL;
        protected CubeColor ULF;
        protected CubeColor RU;
        protected CubeColor RUB;
        protected CubeColor BUR;
        protected CubeColor BU;
        protected CubeColor BUL;
        protected CubeColor LUB;
        protected CubeColor LU;
        protected CubeColor LUF;
        protected CubeColor FUL;
        protected CubeColor FU;
        protected CubeColor FUR;
        protected CubeColor RUF;
        protected CubeColor Ucenter;

        protected CubeColor DF;
        protected CubeColor DRF;
        protected CubeColor DR;
        protected CubeColor DRB;
        protected CubeColor DB;
        protected CubeColor DLB;
        protected CubeColor DL;
        protected CubeColor DLF;
        protected CubeColor RD;
        protected CubeColor RDB;
        protected CubeColor BDR;
        protected CubeColor BD;
        protected CubeColor BDL;
        protected CubeColor LDB;
        protected CubeColor LD;
        protected CubeColor LDF;
        protected CubeColor FDL;
        protected CubeColor FD;
        protected CubeColor FDR;
        protected CubeColor RDF;
        protected CubeColor Dcenter;

        protected CubeColor RF;
        protected CubeColor FR;
        protected CubeColor LF;
        protected CubeColor FL;
        protected CubeColor BR;
        protected CubeColor RB;
        protected CubeColor BL;
        protected CubeColor LB;

        protected CubeColor Lcenter;
        protected CubeColor Rcenter;
        protected CubeColor Fcenter;
        protected CubeColor Bcenter;

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
            g.FillPolygon(Tools.GetBrush(ULB), Tools.ScalePointArray(new Point[] { new Point(300, 102), new Point(355, 133), new Point(300, 165), new Point(245, 133) }, sizeRatio, xShift, yShift));  // BUL
            g.FillPolygon(Tools.GetBrush(UB), Tools.ScalePointArray(new Point[] { new Point(358, 135), new Point(412, 167), new Point(358, 198), new Point(303, 167) }, sizeRatio, xShift, yShift));   // UB
            g.FillPolygon(Tools.GetBrush(UL), Tools.ScalePointArray(new Point[] { new Point(242, 135), new Point(297, 167), new Point(242, 198), new Point(188, 167) }, sizeRatio, xShift, yShift));   // UL
            g.FillPolygon(Tools.GetBrush(URB), Tools.ScalePointArray(new Point[] { new Point(415, 169), new Point(470, 200), new Point(415, 231), new Point(361, 200) }, sizeRatio, xShift, yShift));  // URB
            g.FillPolygon(Tools.GetBrush(ULF), Tools.ScalePointArray(new Point[] { new Point(185, 169), new Point(239, 200), new Point(185, 231), new Point(130, 200) }, sizeRatio, xShift, yShift));  // ULF
            g.FillPolygon(Tools.GetBrush(Ucenter), Tools.ScalePointArray(new Point[] { new Point(300, 169), new Point(355, 200), new Point(300, 231), new Point(245, 200) }, sizeRatio, xShift, yShift));  // center
            g.FillPolygon(Tools.GetBrush(UR), Tools.ScalePointArray(new Point[] { new Point(358, 202), new Point(412, 233), new Point(358, 265), new Point(303, 233) }, sizeRatio, xShift, yShift));   // UR
            g.FillPolygon(Tools.GetBrush(UF), Tools.ScalePointArray(new Point[] { new Point(242, 202), new Point(297, 233), new Point(242, 265), new Point(188, 233) }, sizeRatio, xShift, yShift));   // UF
            g.FillPolygon(Tools.GetBrush(URF), Tools.ScalePointArray(new Point[] { new Point(300, 235), new Point(355, 267), new Point(300, 298), new Point(245, 267) }, sizeRatio, xShift, yShift));  // URF

            // front face
            g.FillPolygon(Tools.GetBrush(FUL), Tools.ScalePointArray(new Point[] { new Point(129, 204), new Point(183, 235), new Point(183, 298), new Point(129, 267) }, sizeRatio, xShift, yShift));  // FUL
            g.FillPolygon(Tools.GetBrush(FU), Tools.ScalePointArray(new Point[] { new Point(187, 237), new Point(240, 269), new Point(240, 331), new Point(187, 300) }, sizeRatio, xShift, yShift));   // FU
            g.FillPolygon(Tools.GetBrush(FL), Tools.ScalePointArray(new Point[] { new Point(129, 271), new Point(183, 302), new Point(183, 365), new Point(129, 333) }, sizeRatio, xShift, yShift));   //FL
            g.FillPolygon(Tools.GetBrush(Fcenter), Tools.ScalePointArray(new Point[] { new Point(187, 304), new Point(240, 335), new Point(240, 398), new Point(187, 367) }, sizeRatio, xShift, yShift));  // center
            g.FillPolygon(Tools.GetBrush(FUR), Tools.ScalePointArray(new Point[] { new Point(244, 271), new Point(298, 302), new Point(298, 365), new Point(244, 333) }, sizeRatio, xShift, yShift));  //FUR
            g.FillPolygon(Tools.GetBrush(FDL), Tools.ScalePointArray(new Point[] { new Point(129, 337), new Point(183, 370), new Point(183, 432), new Point(129, 400) }, sizeRatio, xShift, yShift));  //FDL
            g.FillPolygon(Tools.GetBrush(FR), Tools.ScalePointArray(new Point[] { new Point(244, 337), new Point(298, 370), new Point(298, 433), new Point(244, 400) }, sizeRatio, xShift, yShift));   //FR
            g.FillPolygon(Tools.GetBrush(FD), Tools.ScalePointArray(new Point[] { new Point(187, 371), new Point(240, 403), new Point(240, 465), new Point(187, 433) }, sizeRatio, xShift, yShift));   //FD
            g.FillPolygon(Tools.GetBrush(FDR), Tools.ScalePointArray(new Point[] { new Point(244, 404), new Point(298, 437), new Point(298, 498), new Point(244, 466) }, sizeRatio, xShift, yShift));  //FRD

            // right face
            g.FillPolygon(Tools.GetBrush(RUB), Tools.ScalePointArray(new Point[] { new Point(471, 204), new Point(417, 235), new Point(417, 300), new Point(471, 267) }, sizeRatio, xShift, yShift));  // RUB
            g.FillPolygon(Tools.GetBrush(RU), Tools.ScalePointArray(new Point[] { new Point(413, 237), new Point(360, 269), new Point(360, 332), new Point(413, 301) }, sizeRatio, xShift, yShift));   // RU
            g.FillPolygon(Tools.GetBrush(RB), Tools.ScalePointArray(new Point[] { new Point(471, 271), new Point(417, 304), new Point(417, 365), new Point(471, 333) }, sizeRatio, xShift, yShift));   // RB
            g.FillPolygon(Tools.GetBrush(Rcenter), Tools.ScalePointArray(new Point[] { new Point(413, 305), new Point(360, 336), new Point(360, 398), new Point(413, 367) }, sizeRatio, xShift, yShift));  // center
            g.FillPolygon(Tools.GetBrush(RUF), Tools.ScalePointArray(new Point[] { new Point(356, 271), new Point(302, 302), new Point(302, 365), new Point(356, 333) }, sizeRatio, xShift, yShift));  // RUF
            g.FillPolygon(Tools.GetBrush(RDB), Tools.ScalePointArray(new Point[] { new Point(471, 337), new Point(417, 370), new Point(417, 432), new Point(471, 400) }, sizeRatio, xShift, yShift));  // RDB
            g.FillPolygon(Tools.GetBrush(RF), Tools.ScalePointArray(new Point[] { new Point(356, 337), new Point(302, 370), new Point(302, 433), new Point(356, 400) }, sizeRatio, xShift, yShift));   // RF
            g.FillPolygon(Tools.GetBrush(RD), Tools.ScalePointArray(new Point[] { new Point(413, 372), new Point(360, 403), new Point(360, 465), new Point(413, 433) }, sizeRatio, xShift, yShift));   // RD
            g.FillPolygon(Tools.GetBrush(RDF), Tools.ScalePointArray(new Point[] { new Point(356, 404), new Point(302, 437), new Point(302, 498), new Point(356, 466) }, sizeRatio, xShift, yShift));  // RFD

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


            g.FillPolygon(Tools.GetBrush(ULB), Tools.ScalePointArray(new Point[] { new Point(152, 102), new Point(248, 102), new Point(248, 198), new Point(152, 198) }, sizeRatio, xShift, yShift));  // ULB
            g.FillPolygon(Tools.GetBrush(UB), Tools.ScalePointArray(new Point[] { new Point(252, 102), new Point(348, 102), new Point(348, 198), new Point(252, 198) }, sizeRatio, xShift, yShift));  // UB
            g.FillPolygon(Tools.GetBrush(URB), Tools.ScalePointArray(new Point[] { new Point(352, 102), new Point(448, 102), new Point(448, 198), new Point(352, 198) }, sizeRatio, xShift, yShift));  // URB
            g.FillPolygon(Tools.GetBrush(UL), Tools.ScalePointArray(new Point[] { new Point(152, 202), new Point(248, 202), new Point(248, 298), new Point(152, 298) }, sizeRatio, xShift, yShift));  // UL
            g.FillPolygon(Tools.GetBrush(Ucenter), Tools.ScalePointArray(new Point[] { new Point(252, 202), new Point(348, 202), new Point(348, 298), new Point(252, 298) }, sizeRatio, xShift, yShift));  // UCenter
            g.FillPolygon(Tools.GetBrush(UR), Tools.ScalePointArray(new Point[] { new Point(352, 202), new Point(448, 202), new Point(448, 298), new Point(352, 298) }, sizeRatio, xShift, yShift));  // UR
            g.FillPolygon(Tools.GetBrush(ULF), Tools.ScalePointArray(new Point[] { new Point(152, 302), new Point(248, 302), new Point(248, 398), new Point(152, 398) }, sizeRatio, xShift, yShift));  // ULF
            g.FillPolygon(Tools.GetBrush(UF), Tools.ScalePointArray(new Point[] { new Point(252, 302), new Point(348, 302), new Point(348, 398), new Point(252, 398) }, sizeRatio, xShift, yShift));  // UF
            g.FillPolygon(Tools.GetBrush(URF), Tools.ScalePointArray(new Point[] { new Point(352, 302), new Point(448, 302), new Point(448, 398), new Point(352, 398) }, sizeRatio, xShift, yShift));  // URF

            g.FillPolygon(Tools.GetBrush(BUL), Tools.ScalePointArray(new Point[] { new Point(152, 98), new Point(248, 98), new Point(248 - stickerSize, 98 - stickerSize), new Point(152 + stickerSize, 98 - stickerSize) }, sizeRatio, xShift, yShift));  // BUL
            g.FillPolygon(Tools.GetBrush(BU), Tools.ScalePointArray(new Point[] { new Point(252, 98), new Point(348, 98), new Point(348 - stickerSize, 98 - stickerSize), new Point(252 + stickerSize, 98 - stickerSize) }, sizeRatio, xShift, yShift));  // BU
            g.FillPolygon(Tools.GetBrush(BUR), Tools.ScalePointArray(new Point[] { new Point(352, 98), new Point(448, 98), new Point(448 - stickerSize, 98 - stickerSize), new Point(352 + stickerSize, 98 - stickerSize) }, sizeRatio, xShift, yShift));  // BUR

            g.FillPolygon(Tools.GetBrush(FUL), Tools.ScalePointArray(new Point[] { new Point(152, 402), new Point(248, 402), new Point(248 - stickerSize, 402 + stickerSize), new Point(152 + stickerSize, 402 + stickerSize) }, sizeRatio, xShift, yShift));  // FUL
            g.FillPolygon(Tools.GetBrush(FU), Tools.ScalePointArray(new Point[] { new Point(252, 402), new Point(348, 402), new Point(348 - stickerSize, 402 + stickerSize), new Point(252 + stickerSize, 402 + stickerSize) }, sizeRatio, xShift, yShift));  // FU
            g.FillPolygon(Tools.GetBrush(FUR), Tools.ScalePointArray(new Point[] { new Point(352, 402), new Point(448, 402), new Point(448 - stickerSize, 402 + stickerSize), new Point(352 + stickerSize, 402 + stickerSize) }, sizeRatio, xShift, yShift));  // FUR

            g.FillPolygon(Tools.GetBrush(LUB), Tools.ScalePointArray(new Point[] { new Point(148, 100), new Point(148, 200), new Point(148 - stickerSize, 200 - stickerSize), new Point(148 - stickerSize, 100 + stickerSize) }, sizeRatio, xShift, yShift));  // LUB
            g.FillPolygon(Tools.GetBrush(LU), Tools.ScalePointArray(new Point[] { new Point(148, 200), new Point(148, 300), new Point(148 - stickerSize, 300 - stickerSize), new Point(148 - stickerSize, 200 + stickerSize) }, sizeRatio, xShift, yShift));  // LU
            g.FillPolygon(Tools.GetBrush(LUF), Tools.ScalePointArray(new Point[] { new Point(148, 300), new Point(148, 400), new Point(148 - stickerSize, 400 - stickerSize), new Point(148 - stickerSize, 300 + stickerSize) }, sizeRatio, xShift, yShift));  // LUF

            g.FillPolygon(Tools.GetBrush(RUB), Tools.ScalePointArray(new Point[] { new Point(452, 100), new Point(452, 200), new Point(452 + stickerSize, 200 - stickerSize), new Point(452 + stickerSize, 100 + stickerSize) }, sizeRatio, xShift, yShift));  // RUB
            g.FillPolygon(Tools.GetBrush(RU), Tools.ScalePointArray(new Point[] { new Point(452, 200), new Point(452, 300), new Point(452 + stickerSize, 300 - stickerSize), new Point(452 + stickerSize, 200 + stickerSize) }, sizeRatio, xShift, yShift));  // RU
            g.FillPolygon(Tools.GetBrush(RUF), Tools.ScalePointArray(new Point[] { new Point(452, 300), new Point(452, 400), new Point(452 + stickerSize, 400 - stickerSize), new Point(452 + stickerSize, 300 + stickerSize) }, sizeRatio, xShift, yShift));  // RUF

        }

        /* Dont think this is used */
        //public void SaveImage3D(string path, int sizeX, int sizeY)
        //{
        //    Bitmap b = new Bitmap(sizeX, sizeY);
        //    Graphics g = Graphics.FromImage(b);

        //    int xShift = -40;
        //    int yShift = 0;

        //    g.FillPolygon(Brushes.Black, Tools.ScalePointArray(new Point[] { new Point(300, 98), new Point(475, 200), new Point(475, 404), new Point(300, 504), new Point(125, 404), new Point(125, 200) }, SizeRatio));  // BUL


        //    // top face
        //    g.FillPolygon(Tools.GetBrush(ULB), Tools.ScalePointArray(new Point[] { new Point(300, 102), new Point(355, 133), new Point(300, 165), new Point(245, 133) }, SizeRatio, xShift, yShift));  // BUL
        //    g.FillPolygon(Tools.GetBrush(UB), Tools.ScalePointArray(new Point[] { new Point(358, 135), new Point(412, 167), new Point(358, 198), new Point(303, 167) }, SizeRatio, xShift, yShift));   // UB
        //    g.FillPolygon(Tools.GetBrush(UL), Tools.ScalePointArray(new Point[] { new Point(242, 135), new Point(297, 167), new Point(242, 198), new Point(188, 167) }, SizeRatio, xShift, yShift));   // UL
        //    g.FillPolygon(Tools.GetBrush(URB), Tools.ScalePointArray(new Point[] { new Point(415, 169), new Point(470, 200), new Point(415, 231), new Point(361, 200) }, SizeRatio, xShift, yShift));  // URB
        //    g.FillPolygon(Tools.GetBrush(ULF), Tools.ScalePointArray(new Point[] { new Point(185, 169), new Point(239, 200), new Point(185, 231), new Point(130, 200) }, SizeRatio, xShift, yShift));  // ULF
        //    g.FillPolygon(Tools.GetBrush(Ucenter), Tools.ScalePointArray(new Point[] { new Point(300, 169), new Point(355, 200), new Point(300, 231), new Point(245, 200) }, SizeRatio, xShift, yShift));  // center
        //    g.FillPolygon(Tools.GetBrush(UR), Tools.ScalePointArray(new Point[] { new Point(358, 202), new Point(412, 233), new Point(358, 265), new Point(303, 233) }, SizeRatio, xShift, yShift));   // UR
        //    g.FillPolygon(Tools.GetBrush(UF), Tools.ScalePointArray(new Point[] { new Point(242, 202), new Point(297, 233), new Point(242, 265), new Point(188, 233) }, SizeRatio, xShift, yShift));   // UF
        //    g.FillPolygon(Tools.GetBrush(URF), Tools.ScalePointArray(new Point[] { new Point(300, 235), new Point(355, 267), new Point(300, 298), new Point(245, 267) }, SizeRatio, xShift, yShift));  // URF

        //    // front face
        //    g.FillPolygon(Tools.GetBrush(FUL), Tools.ScalePointArray(new Point[] { new Point(129, 204), new Point(183, 235), new Point(183, 298), new Point(129, 267) }, SizeRatio, xShift, yShift));  // FUL
        //    g.FillPolygon(Tools.GetBrush(FU), Tools.ScalePointArray(new Point[] { new Point(187, 237), new Point(240, 269), new Point(240, 331), new Point(187, 300) }, SizeRatio, xShift, yShift));   // FU
        //    g.FillPolygon(Tools.GetBrush(FL), Tools.ScalePointArray(new Point[] { new Point(129, 271), new Point(183, 302), new Point(183, 365), new Point(129, 333) }, SizeRatio, xShift, yShift));   //FL
        //    g.FillPolygon(Tools.GetBrush(Fcenter), Tools.ScalePointArray(new Point[] { new Point(187, 304), new Point(240, 335), new Point(240, 398), new Point(187, 367) }, SizeRatio, xShift, yShift));  // center
        //    g.FillPolygon(Tools.GetBrush(FUR), Tools.ScalePointArray(new Point[] { new Point(244, 271), new Point(298, 302), new Point(298, 365), new Point(244, 333) }, SizeRatio, xShift, yShift));  //FUR
        //    g.FillPolygon(Tools.GetBrush(FDL), Tools.ScalePointArray(new Point[] { new Point(129, 337), new Point(183, 370), new Point(183, 432), new Point(129, 400) }, SizeRatio, xShift, yShift));  //FDL
        //    g.FillPolygon(Tools.GetBrush(FR), Tools.ScalePointArray(new Point[] { new Point(244, 337), new Point(298, 370), new Point(298, 433), new Point(244, 400) }, SizeRatio, xShift, yShift));   //FR
        //    g.FillPolygon(Tools.GetBrush(FD), Tools.ScalePointArray(new Point[] { new Point(187, 371), new Point(240, 403), new Point(240, 465), new Point(187, 433) }, SizeRatio, xShift, yShift));   //FD
        //    g.FillPolygon(Tools.GetBrush(FDR), Tools.ScalePointArray(new Point[] { new Point(244, 404), new Point(298, 437), new Point(298, 498), new Point(244, 466) }, SizeRatio, xShift, yShift));  //FRD

        //    // right face
        //    g.FillPolygon(Tools.GetBrush(RUB), Tools.ScalePointArray(new Point[] { new Point(471, 204), new Point(417, 235), new Point(417, 300), new Point(471, 267) }, SizeRatio, xShift, yShift));  // RUB
        //    g.FillPolygon(Tools.GetBrush(RU), Tools.ScalePointArray(new Point[] { new Point(413, 237), new Point(360, 269), new Point(360, 332), new Point(413, 301) }, SizeRatio, xShift, yShift));   // RU
        //    g.FillPolygon(Tools.GetBrush(RB), Tools.ScalePointArray(new Point[] { new Point(471, 271), new Point(417, 304), new Point(417, 365), new Point(471, 333) }, SizeRatio, xShift, yShift));   // RB
        //    g.FillPolygon(Tools.GetBrush(Rcenter), Tools.ScalePointArray(new Point[] { new Point(413, 305), new Point(360, 336), new Point(360, 398), new Point(413, 367) }, SizeRatio, xShift, yShift));  // center
        //    g.FillPolygon(Tools.GetBrush(RUF), Tools.ScalePointArray(new Point[] { new Point(356, 271), new Point(302, 302), new Point(302, 365), new Point(356, 333) }, SizeRatio, xShift, yShift));  // RUF
        //    g.FillPolygon(Tools.GetBrush(RDB), Tools.ScalePointArray(new Point[] { new Point(471, 337), new Point(417, 370), new Point(417, 432), new Point(471, 400) }, SizeRatio, xShift, yShift));  // RDB
        //    g.FillPolygon(Tools.GetBrush(RF), Tools.ScalePointArray(new Point[] { new Point(356, 337), new Point(302, 370), new Point(302, 433), new Point(356, 400) }, SizeRatio, xShift, yShift));   // RF
        //    g.FillPolygon(Tools.GetBrush(RD), Tools.ScalePointArray(new Point[] { new Point(413, 372), new Point(360, 403), new Point(360, 465), new Point(413, 433) }, SizeRatio, xShift, yShift));   // RD
        //    g.FillPolygon(Tools.GetBrush(RDF), Tools.ScalePointArray(new Point[] { new Point(356, 404), new Point(302, 437), new Point(302, 498), new Point(356, 466) }, SizeRatio, xShift, yShift));  // RFD

        //    g.Dispose();
        //    b.Save(path, ImageFormat.Png);
        //    b.Dispose();
        //}

        /// <summary>
        /// Sets up a position on the cube
        /// </summary>
        /// <param name="posNum">The number of the position to set up</param>
        public abstract void SetUpPosition(int posNum);
    }
}
