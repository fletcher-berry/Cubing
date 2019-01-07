using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class PllCube : FullCube
    {
        public const int NumPositions = 21;

        /// <summary>
        /// Creates a new OLL cube in a solved state
        /// </summary>
        public PllCube()
        {
            UF = URF = UR = URB = UB = ULB = UL = ULF = Ucenter = CubeColor.Yellow;
            RDF = RD = RDB = RF = RB = Rcenter = CubeColor.Green;
            BDR = BD = BDL = BR = BL = Bcenter = CubeColor.Orange;
            LDF = LD = LDB = LF = LB = Lcenter = CubeColor.Blue;
            FDR = FD = FDL = FR = FL = Fcenter = CubeColor.Red;
            DF = DRF = DR = DRB = DB = DLB = DL = DLF = Dcenter = CubeColor.White;
            FU = BU = LU = RU = RUF = RUB = LUB = LUF = FUL = BUL = FUR = BUR = CubeColor.None;
        }

        public PllCube(LastLayerCubeStickers stickers) : base(stickers) { }

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
            if (posNum < 12)
                SetUpPll(posNum);
            if (posNum == 10)
                Ui();
            if (posNum == 0)
                U2();
            if (posNum == 1)
                U();
            if (posNum == 12)
                EPerm();
            if (posNum == 13)
                NaPerm();
            if (posNum == 14)
                NbPerm();
            if (posNum == 15)
                VPerm();
            if (posNum == 16)
                YPerm();
            if (posNum == 17)
                HPerm();
            if (posNum == 18)
                ZPerm();
            if (posNum == 19)
            {
                UaPerm();
                U2();
            }
            if (posNum == 20)
                UbPerm();
        }
    }
}
