using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Represents a cube for OLLCP positions
    /// </summary>
    public class OllcpCube : LastLayerCube
    {

        public const int NumPositions = 329;

        /// <summary>
        /// Creates a new OLLCP cube in a solved state
        /// </summary>
        public OllcpCube()
        {
            UF = URF = UR = URB = UB = ULB = UL = ULF = Ucenter = CubeColor.Yellow;
            RUF = RUB = RDF = RD = RDB = RF = RB = Rcenter = CubeColor.Green;
            BUR = BUL = BDR = BD = BDL = BR = BL = Bcenter = CubeColor.Orange;
            LUF = LUB = LDF = LD = LDB = LF = LB = Lcenter = CubeColor.Blue;
            FUR = FUL = FDR = FD = FDL = FR = FL = Fcenter = CubeColor.Red;
            DF = DRF = DR = DRB = DB = DLB = DL = DLF = Dcenter = CubeColor.White;
            FU = BU = LU = RU = CubeColor.None;
        }

        /// <summary>
        /// Gets the number of possible OLLCP positions on this cube
        /// </summary>
        /// <returns></returns>
        public override int GetNumPositions()
        {
            return NumPositions;
        }

        /// <summary>
        /// Sets up an OLLCP case on this cube
        /// </summary>
        /// <param name="n">The number of the position to set up</param>
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

        /// <summary>
        /// Retrieves ths number of the current position on this cube
        /// ** Not yet implemented **
        /// </summary>
        /// <returns></returns>
        public int GetPosNum()
        {
            AufToDefault();
            int eoNum = GetEdgeOrientationNum();
            int coNum = GetCornerOrientationNum();
            int result = coNum;
            if (coNum < 6)
            {
                result = result * 48 + 6 * GetEdgeOrientationNum();
                Orient();
                result += GetCpNum();
                return result;
            }
            else if (coNum == 6)
            {
                result = 288;
                if (eoNum == 3 || eoNum == 1)
                {
                    if (eoNum == 1)
                        result += 6;
                    Orient();
                    result += GetCpNum();
                    return result;
                }
                else
                {
                    result = 300;
                    if (eoNum == 4)
                        result += 4;
                    else if (eoNum == 5)
                        result += 8;
                    else if (eoNum == 7)
                        result += 12;
                    Orient();
                    int cpNum = GetCpNum();
                    if (cpNum == 3)
                        result += 1;
                    else if (cpNum == 4)
                        result += 2;
                    else if (cpNum == 5)
                        result += 3;
                    return result;
                }
            }
            else
            {
                if (eoNum == 1)
                {
                    result = 316;
                    Orient();
                    int cpNum = GetCpNum();
                    if (cpNum == 3)
                        result += 1;
                    else if (cpNum == 1)
                        result += 2;
                    else if (cpNum == 0)
                        result += 3;
                    else if (cpNum == 4 || cpNum == 5)
                        result += cpNum;
                    return result;
                }
                else if (eoNum == 4)
                {
                    result = 322;
                    Orient();
                    int cpNum = GetCpNum();
                    if (cpNum == 3)
                        result += 1;
                    else if (cpNum == 4)
                        result += 2;
                    else if (cpNum == 5)
                        result += 3;
                    return result;
                }
                else
                {
                    result = 326;
                    Orient();
                    int cpNum = GetCpNum();
                    if (cpNum == 4)
                        result += 1;
                    else if (cpNum == 5)
                        result += 2;
                    return result;
                }
            }


        }

        /// <summary>
        /// AUFs to default angle for the OLL
        /// </summary>
        /// <returns>The number of U moves made</returns>
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

        public int GetCpNum()
        {
            ColorCompare left = RecognitionTools.CompareColors(LUB, LUF);
            ColorCompare front = RecognitionTools.CompareColors(FUL, FUR);
            if (left == ColorCompare.Same && front == ColorCompare.Same)
            {
                return 5;
            }
            else if (left == ColorCompare.Opposite && front == ColorCompare.Opposite)
            {
                return 4;
            }
            else if (left == ColorCompare.Same)
            {
                return 1;
            }
            else if (left == ColorCompare.Opposite)
            {
                return 0;
            }
            else if (front == ColorCompare.Same)
            {
                return 3;
            }
            else
            {
                return 2;
            }
        }


        /// <summary>
        /// Solves this cube
        /// </summary>
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
