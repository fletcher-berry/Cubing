using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cubing
{
    /// <summary>
    /// Represents a 2x2 cube with the EG alg set.
    /// </summary>
    public class EgCube : AbstractCube2x2
    {
        /// <summary>
        /// creates a new EG cube
        /// </summary>
        public EgCube()
        {
            Solve();
        }

        /// <summary>
        /// Gets the number of positions in the EG alg set
        /// </summary>
        /// <returns></returns>
        public override int GetNumPositions()
        {
            return 120;
        }

        /// <summary>
        /// Paints a 3D representation of this cube
        /// </summary>
        /// <param name="e">PaintEventArgs used to paint the cube</param>
        /// <param name="sizeRatio">The relative size to paint the cube</param>
        public override void Paint(PaintEventArgs e, double SizeRatio)
        {
            Paint3D(e.Graphics, SizeRatio, 0, 0);
        }

        /// <summary>
        /// Sets up an EG case on this cube
        /// </summary>
        /// <param name="posNum"></param>
        public override void SetUpPosition(int posNum)
        {
            var rand = new Random();
            Solve();
            RandomUMove(rand);
            RandomDMove(rand);
            SetUpBottomSwap(posNum / 40);
            SetUpTopSwap(posNum % 40);
            SetUpCornerOrientation(posNum % 40);
        }

        /// <summary>
        /// Rotates the top face clockwise
        /// </summary>
        public void U()
        {
            CubeColor temp1 = URF;
            URF = URB;
            URB = ULB;
            ULB = ULF;
            ULF = temp1;
            CubeColor temp2 = RUF;
            RUF = BUR;
            BUR = LUB;
            LUB = FUL;
            FUL = temp2;
            CubeColor temp3 = FUR;
            FUR = RUB;
            RUB = BUL;
            BUL = LUF;
            LUF = temp3;
        }

        /// <summary>
        /// Rotates the top face 180 degrees
        /// </summary>
        public void U2()
        {
            U();
            U();
        }

        /// <summary>
        /// Rotates the top face counter-clockwise
        /// </summary>
        public void Ui()
        {
            U();
            U();
            U();
        }

        /// <summary>
        /// Rotates the bottom face counter-clockwise
        /// </summary>
        public void Di()
        {
            CubeColor temp1 = DRF;
            DRF = DRB;
            DRB = DLB;
            DLB = DLF;
            DLF = temp1;
            CubeColor temp2 = RDF;
            RDF = BDR;
            BDR = LDB;
            LDB = FDL;
            FDL = temp2;
            CubeColor temp3 = FDR;
            FDR = RDB;
            RDB = BDL;
            BDL = LDF;
            LDF = temp3;
        }

        /// <summary>
        /// Rotates the bottom face clockwise
        /// </summary>
        public void D()
        {
            Di();
            Di();
            Di();
        }

        /// <summary>
        /// Rotates the bottom face 180 degrees
        /// </summary>
        public void D2()
        {
            Di();
            Di();
        }

        /// <summary>
        /// Execute a random U move
        /// </summary>
        public void RandomUMove(Random rand)
        {
            int num = rand.Next(4);
            while (num > 0)
            {
                U();
                num--;
            }
        }

        /// <summary>
        /// Execute a random D move
        /// </summary>
        public void RandomDMove(Random rand)
        {
            double num = rand.Next(4);
            while (num > 0)
            {
                Di();
                num--;
            }
        }

        /// <summary>
        /// Sets up a corner swap on the top layer
        /// </summary>
        /// <param name="num"></param>
        public void SetUpTopSwap(int num)
        {
            if (num < 36)
            {
                if (num % 6 == 0)
                    LeftSwapTop();
                else if (num % 6 == 1)
                    RightSwapTop();
                else if (num % 6 == 2)
                    FrontSwapTop();
                else if (num % 6 == 3)
                    BackSwapTop();
                else if (num % 6 == 4)
                    DiagSwapTop();
            }

            else
            {
                if (num % 6 == 0)
                    RightSwapTop();
                else if (num % 6 == 1)
                    BackSwapTop();
                else if (num % 6 == 2)
                    DiagSwapTop();
            }
        }

        /// <summary>
        /// sets up a cormer swap on the bottom layer
        /// </summary>
        /// <param name="n"></param>
        public void SetUpBottomSwap(int n)
        {
            if (n == 1)
                FrontSwapBottom();
            else if (n == 2)
                DiagSwapBottom();
        }

        /// <summary>
        /// Sets up a corner orientation on this cube
        /// </summary>
        /// <param name="num">The corner orientation number to set up</param>
        public void SetUpCornerOrientation(int num)
        {
            if (num / 6 == 0)
                TOrientation();
            else if (num / 6 == 1)
                UOrientation();
            else if (num / 6 == 2)
                LOrientation();
            else if (num / 6 == 3)
                SuneOrientation();
            else if (num / 6 == 4)
                AntisuneOrientation();
            else if (num / 6 == 5)
                PiOrientation();
            else
                HOrientation();
        }

        /* swaps the right two corners on the top face */
        public void RightSwapTop()
        {
            CubeColor temp1 = URF;
            URF = URB;
            URB = temp1;
            CubeColor temp2 = RUF;
            RUF = BUR;
            BUR = temp2;
            CubeColor temp3 = FUR;
            FUR = RUB;
            RUB = temp3;
        }

        /* swaps the front two corners on the top face */
        public void FrontSwapTop()
        {
            Ui();
            RightSwapTop();
            U();
        }

        /* swaps the left two corners on the top face */
        public void LeftSwapTop()
        {
            U2();
            RightSwapTop();
            U2();
        }

        /* swaps the back two corners on the top face */
        public void BackSwapTop()
        {
            U();
            RightSwapTop();
            Ui();
        }

        /* swaps two diagonal corners on the top face */
        public void DiagSwapTop()
        {
            RightSwapTop();
            LeftSwapTop();
            U();
        }

        /* swaps the front two corners on the bottom face */
        public void FrontSwapBottom()
        {
            CubeColor temp1 = DLF;
            DLF = DRF;
            DRF = temp1;
            CubeColor temp2 = FDL;
            FDL = RDF;
            RDF = temp2;
            CubeColor temp3 = LDF;
            LDF = FDR;
            FDR = temp3;
        }

        /* swaps two diagonal corners on the bottom face */
        public void DiagSwapBottom()
        {
            FrontSwapBottom();
            D2();
            FrontSwapBottom();
            D();
        }

        /*  Sets up a T orientation  */
        public void TOrientation()
        {
            CubeColor temp1 = URB;
            URB = BUR;
            BUR = RUB;
            RUB = temp1;
            CubeColor temp2 = ULB;
            ULB = BUL;
            BUL = LUB;
            LUB = temp2;
        }

        /*  Sets up a U orientation  */
        public void UOrientation()
        {
            TOrientation();
            TOrientation();
        }

        /*  Sets up an L orientation  */
        public void LOrientation()
        {
            UOrientation();
            U();
            UOrientation();
            U();
        }

        /*  Sets up a Sune orientation  */
        public void SuneOrientation()
        {
            TOrientation();
            U();
            UOrientation();
            Ui();
        }

        /*  Sets up an Antisune orientation  */
        public void AntisuneOrientation()
        {
            TOrientation();
            Ui();
            UOrientation();
            U();
        }

        /*  Sets up a Pi orientation  */
        public void PiOrientation()
        {
            Ui();
            TOrientation();
            U2();
            UOrientation();
            Ui();
        }

        /*  Sets up an H orientation  */
        public void HOrientation()
        {
            TOrientation();
            U2();
            TOrientation();
            U2();
        }

        /// <summary>
        /// Solve this cube
        /// </summary>
        public void Solve()
        {
            URF = URB = ULB = ULF = CubeColor.Yellow;
            RUF = RUB = RDF = RDB = CubeColor.Green;
            BUR = BUL = BDR = BDL = CubeColor.Orange;
            LUF = LUB = LDF = LDB = CubeColor.Blue;
            FUR = FUL = FDR = FDL = CubeColor.Red;
            DRF = DRB = DLB = DLF = CubeColor.White;
        }
    }
}
