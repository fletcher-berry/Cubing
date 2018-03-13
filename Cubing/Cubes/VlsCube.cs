using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cubing
{
    public class VlsCube : AbstractCube
    {
        public VlsCube(double ratio)
        {
            SizeRatio = ratio;
            SetUpPosition(0);
        }

        public override int GetNumPositions()
        {
            return 864;
        }

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

        public void SetupTogether()
        {
            ULB = URB = URF = UL = UB = UR = Ucenter = CubeColor.Yellow;
            LUB = LU = BUL = BU = BUR = RUB = RU = RUF = FUR = CubeColor.None;
            ULF = UF = CubeColor.Red;
            FUL = FU = CubeColor.Green;
            LUF = CubeColor.White;
        }

        public void SetupSplit()
        {
            URB = ULB = ULF = UR = UF = UL = Ucenter = CubeColor.Yellow;
            FU = FUL = LUF = LU = LUB = BUL = BUR = RUB = RU = CubeColor.None;
            FUR = UB = CubeColor.Red;
            URF = BU = CubeColor.Green;
            RUF = CubeColor.White;
        }

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

        public void Ui()
        {
            U();
            U();
            U();
        }

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

        /* Flip the back edge */
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

        public override void Paint(PaintEventArgs e)
        {
            Paint2D(e.Graphics, SizeRatio, 0, 0, 15);
        }
    }
}
