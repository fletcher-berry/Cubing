using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class OneLookLLCube : FullCube
    {
        public OneLookLLCube(double ratio)
        {
            SizeRatio = ratio;
        }

        public override int GetNumPositions()
        {
            return 3910;
        }

        public override void SetUpPosition(int posNum)
        {
            Solve();
            RandomUMove();
            int posNumCopy = posNum;

            // ZBLL and dot OLLS
            if (posNumCopy >= 480 && posNumCopy < 960)
            {
                FlipAll();
                posNumCopy -= 480;
            }

            if (posNumCopy < 480)
            {
                if (posNumCopy < 432)
                {
                    SetUpPll(posNumCopy % 72);
                }
                else
                {
                    if (posNumCopy < 456)
                    {
                        SetUpPll(posNumCopy % 12);
                        if (posNumCopy >= 444)
                        {
                            Ui();
                        }
                    }
                    else
                    {
                        SetUpPll(posNumCopy - 408);
                    }
                }
                SetUpCornerOrientation(posNumCopy / 72);
            }

            //  all 2 edge cases except H and corners oriented
            else if (posNumCopy < 3552)
            {
                posNumCopy -= 960;
                SetUpPll(posNumCopy % 72);
                SetUpEdgeOrientation(posNumCopy % 432 / 72);
                SetUpCornerOrientation(posNumCopy / 432);
            }

            // H orientation
            else if (posNumCopy < 3552 + 224)    // 3776
            {
                posNumCopy -= 3552;
                if (posNumCopy < 144)
                {
                    SetUpPll(posNumCopy % 72);
                    if (posNumCopy < 72)
                        FlipLF();
                    else
                        FlipLB();
                }
                else
                {
                    int num = (posNumCopy - 144) % 40;
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
                    if (posNumCopy < 184)
                        FlipFB();
                    else
                        FlipRL();
                }

                HOrientation();
                if ((posNumCopy >= 156 && posNumCopy < 168))
                    U2();
                if (posNumCopy == 173 || posNumCopy == 180 || posNumCopy == 181 || posNumCopy == 183)
                    U2();
                if (posNumCopy >= 196 && posNumCopy < 208)
                    U2();
                if (posNumCopy == 214 || posNumCopy == 221)
                    U2();
            }

            // ELLCP
            else
            {
                posNumCopy -= 3776;
                if (posNumCopy < 72)
                {
                    SetUpPll(posNumCopy);
                    FlipLB();
                }
                else if (posNumCopy < 112)
                {
                    int num = posNumCopy - 72;
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
                    if (posNumCopy >= 84 && posNumCopy < 96)
                        U2();
                    if (posNumCopy == 101 || posNumCopy == 110)
                        U2();
                }
                else
                {
                    if (posNumCopy < 124)
                        SetUpPll(posNumCopy - 112);
                    if (posNumCopy == 124)
                        EPerm();
                    if (posNumCopy == 125)
                        NaPerm();
                    if (posNumCopy == 126)
                        NbPerm();
                    if (posNumCopy == 127)
                        VPerm();
                    if (posNumCopy == 128)
                        YPerm();
                    if (posNumCopy == 130)
                        HPerm();
                    if (posNumCopy == 131)
                        ZPerm();
                    if (posNumCopy == 132)
                        UaPerm();
                    if (posNumCopy == 133)
                    {
                        UbPerm();
                        U2();
                    }

                    FlipFB();
                    FlipRL();
                }
            }


            // adjusts the AUF in a way that I prefer for cases where I do not like the default angle
            int ollKey = (posNum - 960) / 72;
            if (ollKey == 0 && posNum >= 960)
                Ui();
            if (ollKey == 1)
                Ui();
            if (ollKey == 5)
                Ui();
            if (ollKey == 7)
                Ui();
            if (ollKey == 10)
                Ui();
            if (ollKey == 11)
                Ui();
            if (ollKey == 12)
                U();
            if (ollKey == 13)
                U2();
            if (ollKey == 14)
                U2();
            if (ollKey == 17)
                U();
            if (ollKey == 30)
                U2();


        }

        public void SetUpEdgeOrientation(int num)
        {
            if (num == 0)
                FlipRB();
            else if (num == 1)
                FlipLB();
            else if (num == 2)
                FlipRF();
            else if (num == 3)
                FlipLF();
            else if (num == 4)
                FlipFB();
            else
                FlipRL();
        }

        public void SetUpCornerOrientation(int num)
        {
            if (num == 0)
                TOrientation();
            else if (num == 1)
                UOrientation();
            else if (num == 2)
                LOrientation();
            else if (num ==  3)
                SuneOrientation();
            else if (num == 4)
                AntisuneOrientation();
            else if (num == 5)
                PiOrientation();
            else
                HOrientation();
        }


        public int GetPllNum()
        {
            try
            {
                ColorCompare left = RecognitionTools.CompareColors(LUB, LUF);
                ColorCompare front = RecognitionTools.CompareColors(FUL, FUR);
                if (left == ColorCompare.Same && front == ColorCompare.Same)
                {
                    return GetEpllNum();
                }
                else if (left == ColorCompare.Opposite && front == ColorCompare.Opposite)
                {
                    return GetDiagSwapNum();
                }
                else if (left == ColorCompare.Same)
                {
                    return GetAdjSwapNum();
                }
                else if (left == ColorCompare.Opposite)
                {
                    U2();
                    int num = GetAdjSwapNum();
                    U2();
                    return num + 24;
                }
                else if (front == ColorCompare.Same)
                {
                    U();
                    int num = GetAdjSwapNum();
                    Ui();
                    return num + 36;
                }
                else
                {
                    Ui();
                    int num = GetAdjSwapNum();
                    U();
                    return num + 12;
                }
            }
            catch (ArgumentException)
            {
                return -1;
            }
        }

        public int GetPosNum()
        {
            int auf = AufToDefault();
            int num = (int)UR;
            // zbll and dot cases
            if((UF == CubeColor.Yellow && UR == CubeColor.Yellow && UL == CubeColor.Yellow && UB == CubeColor.Yellow) ||
                (FU == CubeColor.Yellow && RU == CubeColor.Yellow && LU == CubeColor.Yellow && BU == CubeColor.Yellow))
            {
                bool zbll = UF == CubeColor.Yellow;
                int posNum;
                int coNum = GetCornerOrientationNum();
                if(coNum < 6)
                {
                    Orient();
                    posNum = 72 * coNum + GetPllNum();
                }
                else
                {
                    Orient();
                    int pllNum = GetPllNum();
                    if(pllNum >= 12)
                    {
                        pllNum -= 24;
                    }
                    posNum = 72 * coNum + pllNum;
                }
                if(!zbll)
                {
                    posNum += 480;
                }
                return posNum;
            }

            else
            {
                int coNum = GetCornerOrientationNum();
                // standard 2 edge case
                if(coNum < 6)
                {
                    int ollNum;
                    int eoNum = GetEdgeOrientationNum();
                    ollNum = coNum * 432 + eoNum * 72;
                    Orient();
                    return 960 + ollNum + GetPllNum();
                }
                else if (coNum == 6)
                {
                    int num2 = (int)UR;
                    int posNum = 3552;
                    int eoNum = GetEdgeOrientationNum();
                    if (eoNum == 1 || eoNum == 3)
                    {
                        if (eoNum == 1)
                            posNum += 72;
                        Orient();
                        return posNum + GetPllNum();
                    }
                    
                    else if(eoNum == 4 || eoNum == 5)
                    {
                        posNum += 144;
                        if (eoNum == 5)
                            posNum += 40;
                        var cmp = RecognitionTools.CompareColors(URF, URB);
                        Orient();
                        int pllNum = GetPllNum();

                        if (pllNum >= 12)
                        {
                            pllNum -= 24;
                        }
                        posNum += pllNum;
                        if (eoNum == 4 || eoNum == 5)
                        {
                            // not all pll nums will be covered for no corner swap and diag corner swap
                            if (eoNum == 4)
                            {
                                if (posNum >= 3727 && posNum <= 3729)
                                    posNum -= 2;
                                if (posNum >= 3731 && posNum <= 3735)
                                    posNum -= 4;
                                if (posNum >= 3736 && posNum <= 3740)
                                    posNum -= 6;
                                if (posNum >= 3741 && posNum <= 3743)
                                    posNum -= 8;
                            }
                            else
                            {
                                if (posNum == 3769)
                                    posNum -= 2;
                                if (posNum >= 3770 && posNum <= 3778)
                                    posNum -= 4;
                                if (posNum >= 3779 && posNum <= 3781)
                                    posNum -= 6;
                            }
                        }
                        return posNum;
                    }
                    else return eoNum;
                }
            }
            
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
                if((UF == CubeColor.Yellow && UR == CubeColor.Yellow && UL == CubeColor.Yellow) || (UF != CubeColor.Yellow && UR != CubeColor.Yellow && UL != CubeColor.Yellow))      // ZBLL or dot
                {
                    if(RecognitionTools.CompareColors(URB, ULB) == ColorCompare.Same && RecognitionTools.CompareColors(URF, ULF) == ColorCompare.Opposite)
                    {
                        U2();
                        numAufs += 2;
                    }
                    if (RecognitionTools.CompareColors(URB, URF) == ColorCompare.Opposite && RecognitionTools.CompareColors(ULB, ULF) == ColorCompare.Same)
                    {
                        U2();
                        numAufs += 2;
                    }
                }
                else if(UL == CubeColor.Yellow && UF == CubeColor.Yellow)
                {
                    U2();
                    numAufs += 2;
                }
                else if(UL == CubeColor.Yellow && UB == CubeColor.Yellow)
                {
                    U2();
                    numAufs += 2;
                }
                else if((UL == CubeColor.Yellow && UR == CubeColor.Yellow) || (UF == CubeColor.Yellow && UB == CubeColor.Yellow))
                {
                    if (RecognitionTools.CompareColors(URB, ULB) == ColorCompare.Same && RecognitionTools.CompareColors(URF, ULF) == ColorCompare.Opposite)
                    {
                        U2();
                        numAufs += 2;
                    }
                    else if (RecognitionTools.CompareColors(URB, URF) == ColorCompare.Opposite && RecognitionTools.CompareColors(ULB, ULF) == ColorCompare.Same)
                    {
                        U2();
                        numAufs += 2;
                    }
                    else if((RecognitionTools.CompareColors(URB, URF) == ColorCompare.Same && RecognitionTools.CompareColors(ULB, ULF) == ColorCompare.Opposite)
                        || (RecognitionTools.CompareColors(URB, ULB) == ColorCompare.Opposite && RecognitionTools.CompareColors(URF, ULF) == ColorCompare.Same))
                    {
                        return numAufs;
                    }
                    else if(UL == CubeColor.Yellow)
                    {
                        if((RecognitionTools.CompareColors(ULF, UF) == ColorCompare.Left || RecognitionTools.CompareColors(ULF, UF) == ColorCompare.Right)
                            &&(RecognitionTools.CompareColors(ULB, UB) == ColorCompare.Same || RecognitionTools.CompareColors(ULB, UB) == ColorCompare.Opposite))
                        {
                            U2();
                            numAufs += 2;
                        }
                    }
                    else
                    {
                        if ((RecognitionTools.CompareColors(URF, UR) == ColorCompare.Left || RecognitionTools.CompareColors(URF, UR) == ColorCompare.Right)
                            && (RecognitionTools.CompareColors(ULF, UL) == ColorCompare.Same || RecognitionTools.CompareColors(ULF, UL) == ColorCompare.Opposite))
                        {
                            U2();
                            numAufs += 2;
                        }
                    }

                }
            }
            return numAufs;
        }

        public int GetAdjSwapNum()
        {
            ColorCompare left = RecognitionTools.CompareColors(LUB, LU);
            ColorCompare front = RecognitionTools.CompareColors(FUL, FU);
            if (left == ColorCompare.Same)
            {
                if (front == ColorCompare.Same)
                    return 8;
                if (front == ColorCompare.Opposite)
                    return 3;
                return 9;
            }
            if (left == ColorCompare.Opposite)
            {
                if (front == ColorCompare.Same)
                    return 2;
                if (front == ColorCompare.Opposite)
                    return 4;
                return 7;
            }
            if (left == ColorCompare.Right)
            {
                if (front == ColorCompare.Right)
                    return 1;
                if (front == ColorCompare.Left)
                    return 10;
                return 6;
            }
            if (front == ColorCompare.Right)
                return 5;
            if (front == ColorCompare.Left)
                return 0;
            return 11;
        }


        public int GetDiagSwapNum()
        {
            ColorCompare front = RecognitionTools.CompareColors(FUL, FU);
            ColorCompare right = RecognitionTools.CompareColors(RUF, RU);
            if (front == ColorCompare.Same)
            {
                if (right == ColorCompare.Same)
                    return 51;
                if (right == ColorCompare.Opposite)
                    return 56;
                return 52;
            }
            if (front == ColorCompare.Opposite)
            {
                if (right == ColorCompare.Same)
                    return 55;
                if (right == ColorCompare.Opposite)
                    return 50;
                return 57;
            }
            if (front == ColorCompare.Right)
            {
                if (right == ColorCompare.Right)
                    return 58;
                if (right == ColorCompare.Left)
                    return 48;
                return 59;
            }
            if (right == ColorCompare.Right)
                return 49;
            if (right == ColorCompare.Left)
                return 53;
            return 54;
        }


        public int GetEpllNum()
        {
            ColorCompare front = RecognitionTools.CompareColors(FUR, FU);
            ColorCompare right = RecognitionTools.CompareColors(RUF, RU);
            if (front == ColorCompare.Same)
            {
                if (right == ColorCompare.Same)
                    return 61;
                if (right == ColorCompare.Opposite)
                    return 66;
                return 68;
            }
            if (front == ColorCompare.Opposite)
            {
                if (right == ColorCompare.Same)
                    return 71;
                if (right == ColorCompare.Opposite)
                    return 60;
                return 67;
            }
            if (front == ColorCompare.Right)
            {
                if (right == ColorCompare.Right)
                    return 69;
                if (right == ColorCompare.Left)
                    return 63;
                return 70;
            }
            if (right == ColorCompare.Right)
                return 62;
            if (right == ColorCompare.Left)
                return 64;
            return 65;
        }

        
    }
}
