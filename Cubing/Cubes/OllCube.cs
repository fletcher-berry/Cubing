using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Represents a cube for OLL positions
    /// </summary>
    public class OllCube : LastLayerCube
    {
        public const int NumPositions = 57;

        /// <summary>
        /// Creates a new OLL cube in a solved state
        /// </summary>
        public OllCube()
        {
            UF = URF = UR = URB = UB = ULB = UL = ULF = Ucenter = CubeColor.Yellow;
            RDF = RD = RDB = RF = RB = Rcenter = CubeColor.Green;
            BDR = BD = BDL = BR = BL = Bcenter = CubeColor.Orange;
            LDF = LD = LDB = LF = LB = Lcenter = CubeColor.Blue;
            FDR = FD = FDL = FR = FL = Fcenter = CubeColor.Red;
            DF = DRF = DR = DRB = DB = DLB = DL = DLF = Dcenter = CubeColor.White;
            FU = BU = LU = RU = RUF = RUB = LUB = LUF = FUL = BUL = FUR = BUR = CubeColor.None;
        }

        /// <summary>
        /// Gets the number of possible OLL positions on this cube
        /// </summary>
        /// <returns></returns>
        public override int GetNumPositions()
        {
            return NumPositions;
        }

        /// <summary>
        /// Sets up an OLL case on this cube
        /// </summary>
        /// <param name="posNum">The number of the position to set up</param>
        public override void SetUpPosition(int posNum)
        {
            Solve();
            if(posNum < 48)
            {
                if (posNum / 8 == 0)
                    TOrientation();
                else if (posNum / 8 == 1)
                    UOrientation();
                else if (posNum / 8 == 2)
                    LOrientation();
                else if (posNum / 8 == 3)
                    SuneOrientation();
                else if (posNum / 8 == 4)
                    AntisuneOrientation();
                else if (posNum / 8 == 5)
                    PiOrientation();

                if (posNum % 8 == 0)
                    FlipRB();
                else if (posNum % 8 == 1)
                    FlipLB();
                else if (posNum % 8 == 2)
                    FlipRF();
                else if (posNum % 8 == 3)
                    FlipLF();
                else if (posNum % 8 == 4)
                    FlipFB();
                else if (posNum % 8 == 5)
                    FlipRL();
                else if (posNum % 8 == 6)
                    FlipAll();
            }
            else if(posNum < 54)        // H orientation
            {
                HOrientation();
                if (posNum == 48)
                    FlipLF();
                else if (posNum == 49)
                    FlipLB();
                else if (posNum == 50)
                    FlipAll();
                else if (posNum == 51)
                    FlipFB();
                else if (posNum == 52)
                    FlipRL();
            }
            else   // corners oriented
            {
                if (posNum == 54)
                    FlipLB();
                else if (posNum == 55)
                    FlipFB();
                else
                    FlipAll();
            }

            // adjusts the AUF in a way that I prefer for cases where I do not like the default angle
            if (posNum < 2)
                Ui();
            if (posNum == 5)
                Ui();
            if (posNum == 9)
                Ui();
            if (posNum == 12)
                Ui();
            if (posNum == 13)
                Ui();
            if (posNum == 16)
                U();
            if (posNum == 17)
                U2();
            if (posNum == 18)
                U2();
            if (posNum == 21)
                U();
            if (posNum == 40)
                U2();
        }

        /// <summary>
        /// Gets the number of the current position on this cube
        /// </summary>
        /// <returns></returns>
        public int GetPosNum()
        {
            AufToDefault();
            int coNum = GetCornerOrientationNum();
            if (coNum < 6)
                return coNum * 8 + GetEdgeOrientationNum();
            if(coNum == 6)      // H orientation
            {
                int eoNum = GetEdgeOrientationNum();
                if (eoNum == 3)
                    return 48;
                if (eoNum == 1)
                    return 49;
                if (eoNum == 6)
                    return 50;
                if (eoNum == 4)
                    return 51;
                if (eoNum == 5)
                    return 52;
                if (eoNum == 7)
                    return 53;
            }
            if(coNum == 7)
            {
                int eoNum = GetEdgeOrientationNum();
                if (eoNum == 1)
                    return 54;
                if (eoNum == 4)
                    return 55;
                if (eoNum == 6)
                    return 56;
            }



            return 0;
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
                if ((UF == CubeColor.Yellow && UL == CubeColor.Yellow && UR != CubeColor.Yellow)
                    || (UL == CubeColor.Yellow && UB == CubeColor.Yellow && UR != CubeColor.Yellow))
                {
                    U2();
                    numAufs += 2;
                }
            }
            else if(coNum == 7)
            {
                while (!((LU != CubeColor.Yellow && BU != CubeColor.Yellow) || (FU != CubeColor.Yellow && BU != CubeColor.Yellow)))
                {
                    if (numAufs > 4)
                        throw new InvalidOperationException("coding error.");
                }
                U();
                numAufs++;
            }
            return numAufs;

        }

        /// <summary>
        /// Solves this cube
        /// </summary>
        public override void Solve()
        {
            UF = URF = UR = URB = UB = ULB = UL = ULF = Ucenter = CubeColor.Yellow;
            RDF = RD = RDB = RF = RB = Rcenter = CubeColor.Green;
            BDR = BD = BDL = BR = BL = Bcenter = CubeColor.Orange;
            LDF = LD = LDB = LF = LB = Lcenter = CubeColor.Blue;
            FDR = FD = FDL = FR = FL = Fcenter = CubeColor.Red;
            DF = DRF = DR = DRB = DB = DLB = DL = DLF = Dcenter = CubeColor.White;
            FU = BU = LU = RU = RUF = RUB = LUB = LUF = FUL = BUL = FUR = BUR = CubeColor.None;
        }
    }
}
