using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cubing
{
    /// <summary>
    /// Represents a cube for VLS positions
    /// R U' R' and R U R' inserts are supported along with their mirrors
    /// </summary>
    public class VlsCube : AbstractCube3x3
    {
        /// <summary>
        /// Creates a new VLS cube
        /// </summary>
        public VlsCube()
        {
            SetUpPosition(0);
        }

        /// <summary>
        /// Get the number of possible VLS positions on this cube
        /// </summary>
        /// <returns></returns>
        public override int GetNumPositions()
        {
            return 864;
        }

        /// <summary>
        /// Sets up a VLS case on this cube
        /// </summary>
        /// <param name="posNum">The number of  the position to set up</param>
        public override void SetUpPosition(int posNum)
        {
            bool split = posNum >= 432;
            bool reflect = posNum % 432 >= 216;
            posNum %= 216;
            if (split)
                SetupSplit();
            else
                SetupTogether();
            SetupEdgeOrientation(posNum / 27, split);
            SetupCornerOrientation(posNum % 27, split);
            if (reflect)
                Reflect();
        }

        /// <summary>
        /// Set up an R U' R' insert by taking out the F2L pair
        /// </summary>
        public void SetupTogether()
        {
            ULB = URB = URF = UL = UB = UR = Ucenter = CubeColor.Yellow;
            LUB = LU = BUL = BU = BUR = RUB = RU = RUF = FUR = CubeColor.None;
            ULF = UF = CubeColor.Red;
            FUL = FU = CubeColor.Green;
            LUF = CubeColor.White;
        }

        /// <summary>
        /// Set up an R U R' insert by taking out the F2L pair
        /// </summary>
        public void SetupSplit()
        {
            URB = ULB = ULF = UR = UF = UL = Ucenter = CubeColor.Yellow;
            FU = FUL = LUF = LU = LUB = BUL = BUR = RUB = RU = CubeColor.None;
            FUR = UB = CubeColor.Red;
            URF = BU = CubeColor.Green;
            RUF = CubeColor.White;
        }

        /// <summary>
        /// Set up the corner orientation of a VLS case
        /// </summary>
        /// <param name="num">The number of the corner orientation case (0 - 26)</param>
        /// <param name="split">Whether the F2L pair is split</param>
        public void SetupCornerOrientation(int num, bool split)
        {
            if(!split)
            {
                int numTwists = num % 3;
                for (int k = 0; k < numTwists; k++)
                    ClockWiseTwistRuf();
                U();
                numTwists = num / 3 % 3;
                for (int k = 0; k < numTwists; k++)
                    ClockWiseTwistRuf();
                U();
                numTwists = num / 9;
                for (int k = 0; k < numTwists; k++)
                    ClockWiseTwistRuf();
                U2();
            }
            else
            {
                U();
                int numTwists = num / 9;
                for (int k = 0; k < numTwists; k++)
                    CounterClockWiseTwistRuf();
                U();
                numTwists = num / 3 % 3;
                for (int k = 0; k < numTwists; k++)
                    CounterClockWiseTwistRuf();
                U();
                numTwists = num % 3;
                for (int k = 0; k < numTwists; k++)
                    CounterClockWiseTwistRuf();
                U();
            }
        }

        /// <summary>
        /// Set up the edge orientation of a VLS case
        /// </summary>
        /// <param name="num">The edge orientation number of the position to set up (0 - 7)</param>
        /// <param name="split">Whhether the F2L pair is split</param>
        public void SetupEdgeOrientation(int num, bool split)
        {
            if (!split)
            {
                if (num == 1)
                {
                    FlipL();
                }
                if (num == 2)
                {
                    FlipR();
                }
                if (num == 3)
                {
                    FlipB();
                }
                if (num == 4)
                {
                    FlipL();
                    FlipB();
                }
                if (num == 5)
                {
                    FlipR();
                    FlipB();
                }
                if (num == 6)
                {
                    FlipL();
                    FlipR();
                }
                if (num == 7)
                {
                    FlipL();
                    FlipR();
                    FlipB();
                }
            }
            else
            {
                if(num == 1)
                {
                    FlipL();
                }
                if(num == 2)
                {
                    FlipR();
                }
                if(num == 3)
                {
                    FlipF();
                }
                if(num == 4)
                {
                    FlipL();
                    FlipF();
                }
                if(num == 5)
                {
                    FlipR();
                    FlipF();
                }
                if(num == 6)
                {
                    FlipL();
                    FlipR();
                }
                if(num == 7)
                {
                    FlipL();
                    FlipR();
                    FlipF();
                }
            }
        }

        /// <summary>
        /// Rotate the top face clockwise
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
            CubeColor temp4 = UR;
            UR = UB;
            UB = UL;
            UL = UF;
            UF = temp4;
            CubeColor temp5 = RU;
            RU = BU;
            BU = LU;
            LU = FU;
            FU = temp5;
        }

        /// <summary>
        /// Rotate the top face counter-clockwise
        /// </summary>
        public void Ui()
        {
            U();
            U();
            U();
        }

        /// <summary>
        /// Rotate the top face 180 degrees
        /// </summary>
        protected void U2()
        {
            U();
            U();
        }

        private void ClockWiseTwistRuf()
        {
            var temp = URF;
            URF = FUR;
            FUR = RUF;
            RUF = temp;
        }

        private void CounterClockWiseTwistRuf()
        {
            var temp = URF;
            URF = RUF;
            RUF = FUR;
            FUR = temp;
        }

        private void FlipB()
        {
            CubeColor temp = BU;
            BU = UB;
            UB = temp;
        }

        private void FlipR()
        {
            Ui();
            FlipB();
            U();
        }

        private void FlipL()
        {
            U();
            FlipB();
            Ui();
        }

        private void FlipF()
        {
            U2();
            FlipB();
            U2(); 
        }

        /// <summary>
        /// Reflect a position to solve left pair
        /// </summary>
        public void Reflect()
        {
            var temp = ULF;
            ULF = URF;
            URF = temp;
            temp = UL;
            UL = UR;
            UR = temp;
            temp = ULB;
            ULB = URB;
            URB = temp;
            temp = LUF;
            LUF = RUF;
            RUF = temp;
            temp = LU;
            LU = RU;
            RU = temp;
            temp = LUB;
            LUB = RUB;
            RUB = temp;
            temp = FUL;
            FUL = FUR;
            FUR = temp;
            temp = BUL;
            BUL = BUR;
            BUR = temp;
        }

        /// <summary>
        /// Paints a 2D representation of this cube
        /// </summary>
        /// <param name="e">EventArgs used to paint the cube</param>
        /// <param name="sizeRatio">The relative size to paint the cube</param>
        public override void Paint(PaintEventArgs e, double sizeRatio)
        {
            Paint2D(e.Graphics, sizeRatio, 0, 0, 15);
        }
    }
}
