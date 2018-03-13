using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class OllcpCube : LastLayerCube
    {

        public const int NumPositions = 329;

        public OllcpCube(double ratio)
        {
            UF = URF = UR = URB = UB = ULB = UL = ULF = Ucenter = CubeColor.Yellow;
            RUF = RUB = RDF = RD = RDB = RF = RB = Rcenter = CubeColor.Green;
            BUR = BUL = BDR = BD = BDL = BR = BL = Bcenter = CubeColor.Orange;
            LUF = LUB = LDF = LD = LDB = LF = LB = Lcenter = CubeColor.Blue;
            FUR = FUL = FDR = FD = FDL = FR = FL = Fcenter = CubeColor.Red;
            DF = DRF = DR = DRB = DB = DLB = DL = DLF = Dcenter = CubeColor.White;
            FU = BU = LU = RU = CubeColor.None;
            SizeRatio = ratio;
        }

        public override int GetNumPositions()
        {
            return NumPositions;
        }

        public override void SetUpPosition(int n)
        {
            Solve();
            RandomUMove();

            if (n < 288)
            {
                // n % 6 will determine the corner permutation
                if (n % 6 == 0)
                    LeftSwap();
                else if (n % 6 == 1)
                    RightSwap();
                else if (n % 6 == 2)
                    FrontSwap();
                else if (n % 6 == 3)
                    BackSwap();
                else if (n % 6 == 4)
                    DiagSwap();
                if (n / 48 == 0)
                    TOrientation();
                else if (n / 48 == 1)
                    UOrientation();
                else if (n / 48 == 2)
                    LOrientation();
                else if (n / 48 == 3)
                    SuneOrientation();
                else if (n / 48 == 4)
                    AntisuneOrientation();
                else if (n / 48 == 5)
                    PiOrientation();
                if (n % 48 / 6 == 0)
                    FlipRB();
                else if (n % 48 / 6 == 1)
                    FlipLB();
                else if (n % 48 / 6 == 2)
                    FlipRF();
                else if (n % 48 / 6 == 3)
                    FlipLF();
                else if (n % 48 / 6 == 4)
                    FlipFB();
                else if (n % 48 / 6 == 5)
                    FlipRL();
                else if (n % 48 / 6 == 6)
                    FlipAll();

            }
            else if (n < 316)        // cases with an H corner orientation
            {
                if (n < 300)
                {
                    if (n % 6 == 0)
                        LeftSwap();
                    else if (n % 6 == 1)
                        RightSwap();
                    else if (n % 6 == 2)
                        FrontSwap();
                    else if (n % 6 == 3)
                        BackSwap();
                    else if (n % 6 == 4)
                        DiagSwap();
                    HOrientation();
                    if (n < 294)
                        FlipLF();
                    else
                        FlipLB();

                }
                else
                {
                    if (n % 4 == 0)
                        RightSwap();
                    else if (n % 4 == 1)
                        BackSwap();
                    else if (n % 4 == 2)
                        DiagSwap();
                    HOrientation();
                    if (n < 304)
                        FlipAll();
                    else if (n < 308)
                        FlipFB();
                    else if (n < 312)
                        FlipRL();
                }
            }
            else                    // cases with all corners oriented
            {
                if (n < 322)
                {
                    if (n - 316 == 0)
                        LeftSwap();
                    else if (n - 316 == 1)
                        RightSwap();
                    else if (n - 316 == 2)
                        FrontSwap();
                    else if (n - 316 == 3)
                        BackSwap();
                    else if (n - 316 == 4)
                        DiagSwap();
                    FlipRB();

                }
                else if (n < 326)
                {
                    if (n - 322 == 0)
                        RightSwap();
                    else if (n - 322 == 1)
                        BackSwap();
                    else if (n - 322 == 2)
                        DiagSwap();
                    FlipFB();
                }
                else
                {
                    FlipAll();
                    if (n - 326 == 0)
                        RightSwap();
                    else if (n - 326 == 1)
                        DiagSwap();
                }
            }


            // adjusts the AUF in a way that I prefer for cases where I do not like the default angle
            if (n / 6 < 2)
                Ui();
            if (n / 6 == 5)
                Ui();
            if (n / 6 == 9)
                Ui();
            if (n / 6 == 12)
                Ui();
            if (n / 6 == 13)
                Ui();
            if (n / 6 == 16)
                U();
            if (n / 6 == 17)
                U2();
            if (n / 6 == 18)
                U2();
            if (n / 6 == 21)
                U();
            if (n / 6 == 40)
                U2();
            if (n > 315 && n < 322)
                Ui();
        }

        public int GetPosNum()
        {
            return 0;
        }

        // returns number of U moves
        // works for all cases except H case and cornerrs oriented cases.
        public int AufToDefault()
        {
            int coNum = GetCornerOrientationNum();
            int numAufs = 0;
            if (coNum == 0)
            {
                while (RUB != CubeColor.Yellow)
                {
                    if (numAufs > 4)
                        throw new InvalidOperationException("the cube dos not have the expected corner orientation.");
                    U();
                    numAufs++;
                }
            }
            else if (coNum == 1)
            {
                while (BUR != CubeColor.Yellow)
                {
                    if (numAufs > 4)
                        throw new InvalidOperationException("the cube dos not have the expected corner orientation.");
                    U();
                    numAufs++;
                }
            }
            else if (coNum == 2)
            {
                while (BUR != CubeColor.Yellow)
                {
                    if (numAufs > 4)
                        throw new InvalidOperationException("the cube dos not have the expected corner orientation.");
                    U();
                    numAufs++;
                }
            }
            else if (coNum == 3)
            {
                while (URF != CubeColor.Yellow)
                {
                    if (numAufs > 4)
                        throw new InvalidOperationException("the cube dos not have the expected corner orientation.");
                    U();
                    numAufs++;
                }
            }
            else if (coNum == 4)
            {
                while (ULF != CubeColor.Yellow)
                {
                    if (numAufs > 4)
                        throw new InvalidOperationException("the cube dos not have the expected corner orientation.");
                    U();
                    numAufs++;
                }
            }
            else if (coNum == 5)
            {
                while (LUB != CubeColor.Yellow || LUF != CubeColor.Yellow)
                {
                    if (numAufs > 4)
                        throw new InvalidOperationException("the cube dos not have the expected corner orientation.");
                    U();
                    numAufs++;
                }
            }
            else if (coNum == 6)
            {
                if (RUF != CubeColor.Yellow)
                {
                    U();
                    numAufs++;
                }
            }
            return numAufs;
        }

        public override void Solve()
        {
            UF = URF = UR = URB = UB = ULB = UL = ULF = Ucenter = CubeColor.Yellow;
            RUF = RUB = RDF = RD = RDB = RF = RB = Rcenter = CubeColor.Green;
            BUR = BUL = BDR = BD = BDL = BR = BL = Bcenter = CubeColor.Orange;
            LUF = LUB = LDF = LD = LDB = LF = LB = Lcenter = CubeColor.Blue;
            FUR = FUL = FDR = FD = FDL = FR = FL = Fcenter = CubeColor.Red;
            DF = DRF = DR = DRB = DB = DLB = DL = DLF = Dcenter = CubeColor.White;
            FU = BU = LU = RU = CubeColor.None;
        }
    }
}
