using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class EllcpCube : FullCube
    {
        public EllcpCube(double ratio)
        {
            SizeRatio = ratio;
        }

        public override int GetNumPositions()
        {
            return 134;
        }

        public override void SetUpPosition(int posNum)
        {
            Solve();
            RandomUMove();
            if (posNum < 72)
            {
                SetUpPll(posNum);
                FlipLB();
            }
            else if (posNum < 112)
            {
                int num = posNum - 72;
                if (num < 24)
                {
                    SetUpPll(num);
                }
                else if (num >= 24 && num < 32)
                {
                    if (num == 28 || num == 29)
                        VPerm();
                    else if (num == 30 || num == 31)
                        YPerm();
                    else if (num == 24 || num == 25)
                        EPerm();
                    else if (num == 26)
                        NaPerm();
                    else
                        NbPerm();
                    if (num % 2 == 1 && num != 27)
                        U();
                }
                else
                {
                    if (num == 36 || num == 37)
                        UaPerm();
                    else if (num == 38 || num == 39)
                        UbPerm();
                    else if (num == 34 || num == 35)
                        ZPerm();
                    else if (num == 32)
                        HPerm();
                    if (num % 2 == 1 && num != 33)
                        U();
                }
                FlipFB();
                if (posNum >= 84 && posNum < 96)
                    U2();
                if (posNum == 101 || posNum == 110)
                    U2();
            }
            else
            {
                if (posNum < 124)
                    SetUpPll(posNum - 112);
                if (posNum == 124)
                    EPerm();
                if (posNum == 125)
                    NaPerm();
                if (posNum == 126)
                    NbPerm();
                if (posNum == 127)
                    VPerm();
                if (posNum == 128)
                    YPerm();
                if (posNum == 130)
                    HPerm();
                if (posNum == 131)
                    ZPerm();
                if (posNum == 132)
                    UaPerm();
                if (posNum == 133)
                {
                    UbPerm();
                    U2();
                }

                FlipFB();
                FlipRL();
            }
        }

        
    }
}
