using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class ZbllAlgsInCode : IAlgClient
    {

        

        public string GetAlg(int num)
        {
            String alg = "";

            if (num == 0)
                alg = "U' R U2 R' U2 R U' R' U L' U R U' L U' R'";
            else if (num == 1)
                alg = "y' x U R U' L U R' U' L'";
            else if (num == 2)
                alg = "U' R' U' R U R' U L' R U R' U' R L";
            else if (num == 3)
                alg = "R' U2 R F U' R' U R U F' R' U R";
            else if (num == 4)
                alg = "L U' R' U' R U L' U' R' U' R U R' U R";
            else if (num == 5)
                alg = "U2 R U2 L' U2 L U2 R' U' L' U L";
            else if (num == 6)
                alg = "U r' F R U2 y' R U2 R' U2 S'";
            else if (num == 7)
                alg = "U r' F2 r U2 r U' r' U' r' F r F";
            else if (num == 8)
                alg = "R2 F2 R U2 R U2 R' F2 R U' R' U R";
            else if (num == 9)
                alg = "U2 F R2 D R' U' R D' R2' U' R U2 R' U' F'";
            else if (num == 10)
                alg = "R2 U2 R' U R U' R U2 R U L' U R U' L";
            else if (num == 11)
                alg = "U R' U' R U' R' U' R U2 R' L' U R U' L";
            else if (num == 12)
                alg = "y' x R' U2 R' D2 R U2 R' D2 R2";
            else if (num == 13)
                alg = "y' x' R U2 R D2 R' U2 R D2 R2";
            else if (num == 14)
                alg = "U2 F R U R' U' R U' R' U' R U R' F'";
            else if (num == 15)
                alg = "U2 R U2 R2 U' R2 U' R' U2 R' U R L' U R' U' R L";
            else if (num == 16)
                alg = "U R U R D R' U' R D' R' U R' U R U2 R'";
            else if (num == 17)
                alg = "R U R' U L' U2 L U L' U2 R U' M' ";
            else if (num == 18)
                alg = "L' U' L U' R U2 R' U' R U2 L' U M'";
            else if (num == 19)
                alg = "U' L' U' L' D' L U L' D L U' L U' L' U2 L";
            else if (num == 20)
                alg = "R' U R' U' D R' U R D' U2 R2 U R2 U R";
            else if (num == 21)
                alg = "L U' L U D' L U' L' D U2 L2 U' L2 U' L'";
            else if (num == 22)
                alg = "U R U R' L' U2 R U' R' U2 L U R U' R'";
            else if (num == 23)
                alg = "U R' U' R U' F U' R' U R U F' R' U R";
            else if (num == 24)
                alg = "R U R D R' U' R D' R2";
            else if (num == 25)
                alg = "U' R' U2 R U2 R' U R U' L U' R' U L' U R";
            else if (num == 26)
                alg = "U' R U R' U' R U' M' x' U' R U R' L'";
            else if (num == 27)
                alg = "U' R U2 R2 D R' U' R D' U R U' R2 U' R'";
            else if (num == 28)
                alg = "U' R U2' R' U2' R' F R U R U' R' F'";
            else if (num == 29)
                alg = "U' R U' R' U' R U R D R' U2 R D' R' U' R'";
            else if (num == 30)
                alg = "U' F' U' L' U2 L U' L' U' L F";
            else if (num == 31)
                alg = "U R' U' R U R' U' R2 D R' U2 R D' R' U R' U R";
            else if (num == 32)
                alg = "U R2 U' R2 U' R2 U R' D' R U R' D R'";
            else if (num == 33)
                alg = "L2 F2 L' U2 L' U2 L F2 L' U L U' L'";
            else if (num == 34)
                alg = "U' L U L' U L U R U L' R' U2 R U R'";
            else if (num == 35)
                alg = "U2 F R U R' U' R' F' U2 R U R U' R2 U2 R";
            else if (num == 36)
                alg = "F R U' R' U' R U2 R' U' F' R' U' R U' R' U2 R";
            else if (num == 37)
                alg = "R2 U R U' R2 U R U2' x M U R U' R' M'";
            else if (num == 38)
                alg = "U2 r U' r U2 R' F R U2 r2 F";
            else if (num == 39)
                alg = "R U R' U' R' U L' U2 R U' R' U2 L R2 U' R'";
            else if (num == 40)
                alg = "U L' U2 R U2' R' U2 L U R U R' U' R U' R'";
            else if (num == 41)
                alg = "R U R' U R U' R' U' L' U2 R U2' R' U2 L";
            else if (num == 42)
                alg = "R U' R' U (R U R' U') (R U R' U') (R' D' R U' R' D R)";
            else if (num == 43)
                alg = "F U' R' U2 R U F' R' U' R U R' U R";
            else if (num == 44)
                alg = "R' U R U2 L' R' U R U' L";
            else if (num == 45)
                alg = "U2 R U' R' U2 L R U' R' U L'";
            else if (num == 46)
                alg = "L U L' y R' U' R U R2 F R F' R";
            else if (num == 47)
                alg = "U' R U R D R' U' R D' R' U2 R' U' R U' R'";
            else if (num == 48)
                alg = "U' R' U2 R' U2 R2 U R F R U R U' R' F' R2";
            else if (num == 49)
                alg = "R U2 R' U L U' R U L2 U R' U' L";
            else if (num == 50)
                alg = "L U' L2 D' l U2 l' D L2 U L'";
            else if (num == 51)
                alg = "R' U R2 D r' U2 r D' R2 U' R";
            else if (num == 52)
                alg = "U R U' R2' D' r U2 r' D R2 U' R' U' R U' R'";
            else if (num == 53)
                alg = "F R U2' R' U R2 U2 R' U' R U' R2' U F'";
            else if (num == 54)
                alg = "R' U D' R U2 R' D R' U' R U2 R' U' R2";
            else if (num == 55)
                alg = "U R U R' U R U R2' D' r U2 r' D R2 U R'";
            else if (num == 56)
                alg = "U2 L2 U' L2 U' L' D L' U L D' L' U L2";
            else if (num == 57)
                alg = "U2 R2 U R2 U R D' R U' R' D R U' R2";
            else if (num == 58)
                alg = "R2 U R' D' R U R' D R' U' R2 U' R2";
            else if (num == 59)
                alg = "U2 R2 U' R D R' U' R D' R U R2 U R2";
            else if (num == 60)
                alg = "x' U' R' D R U R2 U2 R D' R' U2 R2";
            else if (num == 61)
                alg = "U' (R U R' U R U2 R') (L' U' L U' L' U2 L)";
            else if (num == 62)
                alg = "U2 R' U2 R U R' U R2 U2 R' U' R U' R'";
            else if (num == 63)
                alg = "R U2 R' U' R U' R2 U2 R U R' U R";
            else if (num == 64)
                alg = "U' R' U' R2 U R2 U R2 U2 R' U R' U R";
            else if (num == 65)
                alg = "U' R' U' R U' R' U R U' R U R2' U R2 U2 R'";
            else if (num == 66)
                alg = "U' (R' U' R U' R' U2 R) U (R' U2 R U R' U R)";
            else if (num == 67)
                alg = "(R U2 R' U' R U' R') U (R U R' U R U2 R')";
            else if (num == 68)
                alg = "U' (R U R' U R U2 R') U' (R U2 R' U' R U' R')";
            else if (num == 69)
                alg = "U' R U R' U R U' R' U R' U' R2' U' R2 U2 R";
            else if (num == 70)
                alg = "U' R U R2 U' R2 U' R2 U2 R U' R U' R'";
            else if (num == 71)
                alg = "U2 (R' U2 R U R' U R) U' (R' U' R U' R' U2 R)";
            else if (num == 72)
                alg = "U' R U2 R2 D' R U2 R' D R2 U' R' U2 R U2 R'";
            else if (num == 73)
                alg = "U2 R2 D R' U2 R D' R' U2 R'";
            else if (num == 74)
                alg = "R' U' R U R U R' U' R' U F R U R U' R' F'";
            else if (num == 75)
                alg = "R U R' y' R' U' R2 u R' U R' U' R u' R'";
            else if (num == 76)
                alg = "U L' U' L U' R U' L' U2 R' U2 L U' R U2 R'";
            else if (num == 77)
                alg = "R D' R' U R2 D' r' u2 l' U' R2 U' r2";
            else if (num == 78)
                alg = "U' R U' R' U R U R' U2 R' D' R U R' D R2 U R'";
            else if (num == 79)
                alg = "U R2' U F' R2 U' R2' U' R2 U2 R2' U' F U' R2";
            else if (num == 80)
                alg = "U2 R2 D r' U2 r D' R' U2 R'";
            else if (num == 81)
                alg = "U R2 D R' U R D' R2 U R U2 R'";
            else if (num == 82)
                alg = "U' R U2 R D R' U2 R D' R' U2 R' U' R U' R'";
            else if (num == 83)
                alg = "R' U' R U' R' U2 R2 U' L' U R' U' L";
            else if (num == 84)
                alg = "x' R2 D2 R' U2 R D2 R' U2 R'";
            else if (num == 85)
                alg = "y2 x R2 D2 R U2 R' D2 R U2 R";
            else if (num == 86)
                alg = "F R U' R' U R U R' U R U' R' F'";
            else if (num == 87)
                alg = "U2 R U' R2' F R U R U' R2' F' R U' F' U F";
            else if (num == 88)
                alg = "U L U2 L' U2 R U' R' U2 L U' L' U R U' R'";
            else if (num == 89)
                alg = "R U R' F' R U R' F' R U R' U' R' F R2 U' R' F R U' R'";
            else if (num == 90)
                alg = "R' U2 R U R' U R' D' R U' R' D R U R";
            else if (num == 91)
                alg = "U' R' U2 R U2 L' U L U2 R' U R U' L' U L";
            else if (num == 92)
                alg = "U2 R2 F2 R U2 R U R2 F2 R2 U R' F2 R";
            else if (num == 93)
                alg = "R U R' U R U' R' U2 R' D' R U2 R' D R2 U' R'";
            else if (num == 94)
                alg = "U2 R U R' B' U R U R' U' f z' U' R U' R'";
            else if (num == 95)
                alg = "R' U' R U L U2 R' U' L' U' L R U2 L'";
            else if (num == 96)
                alg = "R2 D' R U2 R' D R U2 R";
            else if (num == 97)
                alg = "U L' U2' L2' D L' U2' L D' L2' U L U2' L' U2' L";
            else if (num == 98)
                alg = "R U' R' D R' U' R D' R2 U R' U' R' U2 R'";
            else if (num == 99)
                alg = "U2 R' U' R y R U R2 u' R U' R U R' u R";
            else if (num == 100)
                alg = "R U' R' D R' U' R D' R2 U2 R2 U' R' U' R2";
            else if (num == 101)
                alg = "U' R' U (R U' R' U') (R U R' U') (R U R' U') L' U R U' L";
            else if (num == 102)
                alg = "U' R2 F' R U2 R U2 R' F U' R U R' U' R";
            else if (num == 103)
                alg = "U' R U R' U2 F2 R U2 R' U2 R' F2 R2 U R'";
            else if (num == 104)
                alg = "U' L2 D' L U' L' D L2 U' L' U2 L";
            else if (num == 105)
                alg = "R2 D' r U2 r' D R U2 R";
            else if (num == 106)
                alg = "U2 R U R' U R U2 R2 U L U' R U L'";
            else if (num == 107)
                alg = "(R' U L U' R U L') (R U R' U R U2 R')";
            else if (num == 108)
                alg = "U' R U R' B' R2 D R' U' R D' R2 U f";
            else if (num == 109)
                alg = "U L' U' L B L2 D' L U L' D L2 U' B'";
            else if (num == 110)
                alg = "U R' U' R U R' F' R U R' U' R' F R2 U' R' U2 R U' R' U2 R";
            else if (num == 111)
                alg = "U2 R U2 x R U2 R U2 R' U2 L U2 r' U2 R U2 R' U2 R'";
            else if (num == 112)
                alg = "F R U R U2 R' U' R U' R' U2 R' U2 R U' R' U' F'";
            else if (num == 113)
                alg = "U' R U2 R' U2 R' F R U R U2' R' U' R U2 R' U' F'";
            else if (num == 114)
                alg = "U' R' U2 R' U' F' U F R2 U' R' F R' F' R2";
            else if (num == 115)
                alg = "U' r U R' U' r' F R2 U' R' U' R U2 R' U' F'";
            else if (num == 116)
                alg = "R' (F R U' R' U' R U R' F' R U R' U' R' F R F') R";
            else if (num == 117)
                alg = "U' (F2 R U' R' U' R U R' F') (R U R' U' R' F R F2)";
            else if (num == 118)
                alg = "U' F (R' U R' d' R' F' R2 U' R' U R' F R F) L'";
            else if (num == 119)
                alg = "z D' U' R2 U R2 D R' U' R D' R D R' U' R";
            else if (num == 120)
                alg = "(R' U L U' R U L') (R U' L' U R' U' L)";
            else if (num == 121)
                alg = "F R U' R' U' R U2 R' U' R U' R' U' R U2 R' U' F'";
            else if (num == 122)
                alg = "U' L' U L R U2 L' U' L R' U' R U' R'";
            else if (num == 123)
                alg = "U R U R' L' U2 R U R' L U L' U L";
            else if (num == 124)
                alg = "R U R' U L' U R U' M' x' U' R U' R'";
            else if (num == 125)
                alg = "U R' L' U2 L U2 R U' L' U R' U R2 U' L U R'";
            else if (num == 126)
                alg = "U' L R U2 R' U2 L' U R U' L U' L2 U R' U' L";
            else if (num == 127)
                alg = "R U2 R' L' U R U L U L' U M'";
            else if (num == 128)
                alg = "R U' R' U' R U R D R' U R D' R2";
            else if (num == 129)
                alg = "U' F U' R' U R U F' R' U2 R";
            else if (num == 130)
                alg = "U2 L' U2 L U R U2 L' U' L U2 R'";
            else if (num == 131)
                alg = "U2 R U2 R' U' L' U2 R U R' U2 L";
            else if (num == 132)
                alg = "R U R' U' R U' R U2 R2 U' R U R' U' R2 U' R2";
            else if (num == 133)
                alg = "U (R U2 R' U' R U' R') (L' U2 L U L' U L)";
            else if (num == 134)
                alg = "U2 R U R' U R U2 R2 U' R U' R' U2 R";
            else if (num == 135)
                alg = "R' U' R U' R' U2 R2 U R' U R U2 R'";
            else if (num == 136)
                alg = "U2 R U R' U R' U2 R2 U R2 U R2 U' R'";
            else if (num == 137)
                alg = "U (R' U2 R U R' U R) U (R' U' R U' R' U2 R)";
            else if (num == 138)
                alg = "U' R' U' R U R' U R U2 R' U R U2 R' U' R";
            else if (num == 139)
                alg = "U R' U2' R2 U R2' U R U' R U R' U' R U' R'";
            else if (num == 140)
                alg = "U' R U R' U' R U' R' U2 R U' R' U2 R U R'";
            else if (num == 141)
                alg = "U (R U2 R' U' R U' R') U' (R U R' U R U2 R')";
            else if (num == 142)
                alg = "R' U' R U' R U2 R2 U' R2 U' R2 U R";
            else if (num == 143)
                alg = "U R U2 R2 U' R2 U' R' U R' U' R U R' U R";
            else if (num == 144)
                alg = "U R' U2 R U2 R' U' R2 D R' U2 R D' R2 U2 R";
            else if (num == 145)
                alg = "U' L' U2 L' D' L U2 L' D L2";
            else if (num == 146)
                alg = "U2 R U2 R U R U' R2 D R' U R D' R U R'";
            else if (num == 147)
                alg = "U R U R' U2 R U R' U2 y' R' U2 R U' R' U' R";
            else if (num == 148)
                alg = "U R' U R2 D R' U R D' R' U2 R' U R U R' U' R";
            else if (num == 149)
                alg = "U R2 U' R' U' R2 U R U D' R U2 R' D R2";
            else if (num == 150)
                alg = "R U' R2 F2 R U2 R U2 R' F2 U2 R U' R'";
            else if (num == 151)
                alg = "U R U R' U' R U' R' U L' U R U' L U' R'";
            else if (num == 152)
                alg = "R' U2 R U R2' D' R U R' D R2";
            else if (num == 153)
                alg = "U' L' U2 L' D' l U2 l' D L2";
            else if (num == 154)
                alg = "L U' R' U L' U' R2 U2 R' U' R U' R'";
            else if (num == 155)
                alg = "R' U' R U' R' U2 R' D' R U2 R' D R U2 R";
            else if (num == 156)
                alg = "U2 R U2 R D R' U2 R D' R2";
            else if (num == 157)
                alg = "U2 R U2' R' U2 R U R2' D' R U2 R' D R2 U2' R'";
            else if (num == 158)
                alg = "U' F R U R' U' R' F' U' R U R U' R' U' R' U R";
            else if (num == 159)
                alg = "U2 R u R' U R U' R u' R2 U' F' U' F R";
            else if (num == 160)
                alg = "U2 R' U' R U R' U R U' L U' R' U L' U R";
            else if (num == 161)
                alg = "U L' U L2 F2 L' U2 L' U2 L F2 U2 L' U L";
            else if (num == 162)
                alg = "U2 R' U F U' F' U2 R F R' U R U2 F'";
            else if (num == 163)
                alg = "U2 L U' R U L' U' R' U R U' R' U R U' R' U' R U R'";
            else if (num == 164)
                alg = "U2 R U2 R D r' U2 r D' R2";
            else if (num == 165)
                alg = "U' R U2 R' U' (R2 D R' U' R D' R2)";
            else if (num == 166)
                alg = "y x' M' U L' U L U2' L' U' L U' R U L'";
            else if (num == 167)
                alg = "U R' U L U' R U L2 U2 L U L' U L";
            else if (num == 168)
                alg = "U' R' U' L U' R U L' U R' U' R U2 R' U2 R";
            else if (num == 169)
                alg = "y x' R U' R' D R U R' D'";
            else if (num == 170)
                alg = "U R F U' R' U R U R' U R U' F' R'";
            else if (num == 171)
                alg = "R' U2 R U2 D' R U' R U R U' R2 D";
            else if (num == 172)
                alg = "U2 R U R D R' U2 R D' R' U' R' U R U R'";
            else if (num == 173)
                alg = "U2 F R U R' U' R' F' R U2 R U2 R'";
            else if (num == 174)
                alg = "U R U R' U R U' R' U' L' U R U' M'";
            else if (num == 175)
                alg = "R' F' R U R' U' R' F R U' R U R' U R";
            else if (num == 176)
                alg = "U2 R D' R U' R' D R U' R2 U R2 U R2";
            else if (num == 177)
                alg = "F R U' R' U' R U R D R' U R D' R2 U' F'";
            else if (num == 178)
                alg = "U L U' R U R' L' U2 R U' R' U' R U' R'";
            else if (num == 179)
                alg = "U' R' U2 R2 U R' U' R' U2 F R U R U' R' F'";
            else if (num == 180)
                alg = "x' L' U L D' L' U' L D";
            else if (num == 181)
                alg = "R U L' U R' U' L U' R U R' U2 R U2 R'";
            else if (num == 182)
                alg = "U2 R' L' U R U' L (R' U' R U' R' U R)";
            else if (num == 183)
                alg = "U2 R' U' R F U' R' U' R U F' R' U2 R";
            else if (num == 184)
                alg = "F R U' R' U' R U2 R' U' F'";
            else if (num == 185)
                alg = "(L' U' L U') (L' U L U) (R U' L' U M')";
            else if (num == 186)
                alg = "U' R U2 R' U' R U R D R' U' R D' R' U' R'";
            else if (num == 187)
                alg = "M' U2 y R U2 R' U2 f' U' F";
            else if (num == 188)
                alg = "U2 R2 U' R U R U' R D' U R U' R' D";
            else if (num == 189)
                alg = "U R U R' U2 L U' R U' R' U R U2' R' L'";
            else if (num == 190)
                alg = "R' U L' U' R U' L' U2 L' U L' U' L U2 L2";
            else if (num == 191)
                alg = "R' U L' U' L R U2 L' U L U L' U L";
            else if (num == 192)
                alg = "R' U L2 D' L' U2 L D L' U R U L'";
            else if (num == 193)
                alg = "U2 R U' R F' R' U R F' R2 F U' F' R2 F2 R2";
            else if (num == 194)
                alg = "F R U R' U' R' F R2 U' R' U' R U R' F2";
            else if (num == 195)
                alg = "U' B' R U R' U' R' F R2 U' R' U' R U R' F' B";
            else if (num == 196)
                alg = "L' U2 L U R U2 L' U' L R' U' R U' R'";
            else if (num == 197)
                alg = "U F R U R' U' R U' R' U2 R U2 R' U' F'";
            else if (num == 198)
                alg = "U R U2 R' U' L' U2 R U R' L U L' U L";
            else if (num == 199)
                alg = "F (R U' R' U' R U R D R' U' R D' R' U2 R' U') F'";
            else if (num == 200)
                alg = "U2 r U2 r2 F R F' R' r2 U2 r'";
            else if (num == 201)
                alg = "L' U2 R U' R' U2 L R U' R'";
            else if (num == 202)
                alg = "U r U2 R r2 F R' F' r2 U2 r'";
            else if (num == 203)
                alg = "R' U' R U R' F' R U R' U' R' F R2";
            else if (num == 204)
                alg = "R U R' U (R U' R' U) (R U' R' U) R U2 R'";
            else if (num == 205)
                alg = "U R U' R' L' U2 L U L' U L R U2 R'";
            else if (num == 206)
                alg = "U2 (R U R' U R U2 R') U2 (R U2 R' U' R U' R')";
            else if (num == 207)
                alg = "U2 (R U2 R' U' R U' R') U2 (R U R' U R U2 R')";
            else if (num == 208)
                alg = "U (R' U' R U' R' U2 R) U' (R U R' U R U2 R')";
            else if (num == 209)
                alg = "U (R' U2 R U R' U R) U' (R U2 R' U' R U' R')";
            else if (num == 210)
                alg = "R2 U R' U R' U' R U' R' U' R U R U' R2";
            else if (num == 211)
                alg = "U2 R2 U' R U R U' R' U' R U' R' U R' U R2";
            else if (num == 212)
                alg = "U2 (R U2 R' U' R U' R') U (R' U2 R U R' U R)";
            else if (num == 213)
                alg = "U2 (R U R' U R U2 R') U (R' U' R U' R' U2 R)";
            else if (num == 214)
                alg = "U R2 U R' U' R' U R U R' U R U' R U' R2";
            else if (num == 215)
                alg = "U' R2 U' R U' R U R' U R U R' U' R' U R2";
            else if (num == 216)
                alg = "U2 R U2 R' (L' U2 R U R' U2 L) R U2 R'";
            else if (num == 217)
                alg = "U2 B L' U2 L B' L' B U2 B' L";
            else if (num == 218)
                alg = "U2 L' U' L U' R U2 L' U' R' U2 L U' R U' R'";
            else if (num == 219)
                alg = "U' R U R' U' R' U' y' R2 U B R2 B' R2 B R2 U' R2";
            else if (num == 220)
                alg = "L' F2 L U L U L' U2 L U L2 F2 L";
            else if (num == 221)
                alg = "R U R' U R U' R D R' U' R D' R2";
            else if (num == 222)
                alg = "U2 R D' R2 U' F2 U' F2 R U2 R2 D R2";
            else if (num == 223)
                alg = "U' R2 D' R U' R' D R U' R U R' U R";
            else if (num == 224)
                alg = "U2 L' U2 L U' R U' L2 U R' U' L2 U' L' U L";
            else if (num == 225)
                alg = "U' L U' L B2 L' U2 L' U L U2 L' U L2 B2 L2";
            else if (num == 226)
                alg = "U2 R' U' F2 U' R2 U R2 U F2 R2 U2 R'";
            else if (num == 227)
                alg = "U' R U2 R' U L' U2 R U R' U2 L U R U' R'";
            else if (num == 228)
                alg = "U R U' L' U R' U' L";
            else if (num == 229)
                alg = "R' U2 R2 U R D' R U R' D R2 U' R U' R'";
            else if (num == 230)
                alg = "U L' U' L U' L' U' R U' L U' R' U' R U' R'";
            else if (num == 231)
                alg = "U' R U R' F' R U R' U R U' R' U' R' F R2 U' R'";
            else if (num == 232)
                alg = "R' U' D R' U R U2 D' R2 U R' U' R'";
            else if (num == 233)
                alg = "U' L U' R' U L' R' U' R' U' R' U R U R2";
            else if (num == 234)
                alg = "R' U' F R U' R' U' R U2 R' U' F' U2 R";
            else if (num == 235)
                alg = "U R2' U R U R' U' R' U' R' L' U R' U' L";
            else if (num == 236)
                alg = "U R U R' U' F' L' U2 L U F2 R' F' R";
            else if (num == 237)
                alg = "U R' U2 L R U2 R' U L' U' L U' R U2 L'";
            else if (num == 238)
                alg = "U L U2 L F L' U' L' U L F' U2 L'";
            else if (num == 239)
                alg = "R' U2 F' R U R' U' R' F R U2 R";
            else if (num == 240)
                alg = "U L' R U R' U' L U R U2 L' U R' U' L";
            else if (num == 241)
                alg = "R' U' R U' R B' U R2 U R2 U' B U' R'";
            else if (num == 242)
                alg = "U' F R U R2 U' R2 U' R2 U2 R U R U R' F'";
            else if (num == 243)
                alg = "U R' U L' U2 R U' R' U2 R U2 L U L' U L";
            else if (num == 244)
                alg = "U R U R2' F' R U2 R U2' R' F R U' R'";
            else if (num == 245)
                alg = "R' U2 R' D R' U R D' R' U' R' U R' U R";
            else if (num == 246)
                alg = "U R U R' U' L U' R U L' U' R' U' R U2 R'";
            else if (num == 247)
                alg = "U' R U R' U R2 D R' U2 R D' R2";
            else if (num == 248)
                alg = "U2 L' U R U' L U' R2 U' R2 U' R2 U2 R";
            else if (num == 249)
                alg = "U2 L' R U2 R2 U' R2 U' R2 U' L U' R";
            else if (num == 250)
                alg = "U2 R U2 R D R' U' R D' R2 U R U2 R'";
            else if (num == 251)
                alg = "U L' U2 L U2 R U' L' U M' ";
            else if (num == 252)
                alg = "U2 R U' L' U R' U2 L U R U' L' U M'";
            else if (num == 253)
                alg = "U2 F R' U' R2 U' R2 U2 F R F' R U' R' F'";
            else if (num == 254)
                alg = "U' R2 D' r U2 r' D R2 U R' U R";
            else if (num == 255)
                alg = "U R' D R' U R D' U R U' R' U' R2 U R U' R'";
            else if (num == 256)
                alg = "U R' U2 R U R' U R' D' R U2 R' D R U2 R";
            else if (num == 257)
                alg = "U' R2 D' R U2 R' D R2 U R' U R";
            else if (num == 258)
                alg = "U R2 F R U R U' R' F' R U' R' U R";
            else if (num == 259)
                alg = "R U2 R' U2 L' U R U' R' L2 U2 L' U' L U' L'";
            else if (num == 260)
                alg = "U2 R U' r' F U2 F U2 F' U2 M'";
            else if (num == 261)
                alg = "L' U L U2 R U' L' U R2 U L U' R";
            else if (num == 262)
                alg = "U L' R U R' U' L U2 R U2 R'";
            else if (num == 263)
                alg = "L' U2 L U L2 D' L U' L' D L U2 L";
            else if (num == 264)
                alg = "U F (R U R' U) R U2 R U2 R2 U' R2 U' R2 F'";
            else if (num == 265)
                alg = "R U' L' U R' U' R U' L U R' U' L' U L";
            else if (num == 266)
                alg = "R U2 R' U' R U R' U' F' R U2 R' U' R U' R' F R U' R'";
            else if (num == 267)
                alg = "R U2 L' U R' U' R L U' R' U R U2 R'";
            else if (num == 268)
                alg = "F' L' U' L U L' U' L F' L F L' U F";
            else if (num == 269)
                alg = "U' (R U R' F') (R U R' U R U2 R') (F R U' R')";
            else if (num == 270)
                alg = "U2 R' L' U2 L U R U2 L U' R' U L2 U' L U' R";
            else if (num == 271)
                alg = "U F U' R' U R U F' R U R2 U R2 U2 R'";
            else if (num == 272)
                alg = "R2 U2 R U' R' U R' U L' U R' U' L U' R'";
            else if (num == 273)
                alg = "U' R U R' U L' U R U' L U2 R'";
            else if (num == 274)
                alg = "U2 R U2 R' L' U2 R U2 R' U2 L U' R U' R'";
            else if (num == 275)
                alg = "U R' U2 L U' R U L' U R' U R";
            else if (num == 276)
                alg = "R' U2' R2 U R2 U R U' R U' R'";
            else if (num == 277)
                alg = "R U2 R' U' R U' R' U' R U2 R2 U' R2 U' R2 U2 R";
            else if (num == 278)
                alg = "R' U' R U R U R' U' R' U R U R U' R'";
            else if (num == 279)
                alg = "R U R' U' R' U2 R U R U' R' U R' U R";
            else if (num == 280)
                alg = "R2 U' R2 U' R' U2 R U' R' U' R' U R2";
            else if (num == 281)
                alg = "R' U2 R U R' U R";
            else if (num == 282)
                alg = "U R U R' U R U2 R'";
            else if (num == 283)
                alg = "R2 U R' U' R' U' R U2 R' U' R2 U' R2";
            else if (num == 284)
                alg = "U R' U2 R2 U2 R2 U' R2 U' R2 U R";
            else if (num == 285)
                alg = "R2 U R U' R' U' R U2 R U' R2 U' R2";
            else if (num == 286)
                alg = "R2 U' R2 U' R U2 R U' R' U' R U R2";
            else if (num == 287)
                alg = "U R U R2 U' R2 U' R2 U2 R2 U2 R'";
            else if (num == 288)
                alg = "U2 R U R' U R' F U' R2 U' R2 U F' U R";
            else if (num == 289)
                alg = "F' U2 R' U L U' R U2 r' D r U' r'";
            else if (num == 290)
                alg = "U L' U' L U' L2 D' l U2 l' D L2";
            else if (num == 291)
                alg = "U' L U' R U2 L' U L U2 L' U2 R' U' R U' R'";
            else if (num == 292)
                alg = "U L' U' L U' L2 D' L U2 L' D L2";
            else if (num == 293)
                alg = "U2 R' U' R U' R' U R U' R' U R' F' R U R U' R' F R";
            else if (num == 294)
                alg = "U2 R U2 R' U' F' r U R' U' r' F R2 U' R'";
            else if (num == 295)
                alg = "U R' U' R U R' F R U R' U' R' F' R2";
            else if (num == 296)
                alg = "U2 R U2 R' U' F' R U R' U' R' F R2 U' R'";
            else if (num == 297)
                alg = "L U' R' U L' U R2 U R2 U R2 U2 R'";
            else if (num == 298)
                alg = "U R U2' R' U2 L' U R U' M' ";
            else if (num == 299)
                alg = "U R' U' R U' R' U' L' U2 R U' R' U2 R L";
            else if (num == 300)
                alg = "U2 R U2 R2 U' R' D R' U' R D' R2 U R' U R";
            else if (num == 301)
                alg = "U' L' U R U' L U R'";
            else if (num == 302)
                alg = "U' R U R' U R U L' U R' U L U L' U L";
            else if (num == 303)
                alg = "U L' U' L F L' U' L U' L' U L U L F' L2 U L";
            else if (num == 304)
                alg = "U' F R U' R' U R U R2 F' R U R U R' U' R U' R'";
            else if (num == 305)
                alg = "L U2 L' U' L U2 L B2 L' U L' U' L2 B2 L2";
            else if (num == 306)
                alg = "R U2 R' U' R U L' U' L U2 R' U L' U2 L";
            else if (num == 307)
                alg = "R' D' R2 U R2 U' R2 D R U' R2 U R U R";
            else if (num == 308)
                alg = "R U2 R' U' R U R D R' U2 R D' R2";
            else if (num == 309)
                alg = "U R2 D' R U2 R' D R U R U' R' U2 R";
            else if (num == 310)
                alg = "U' F U R U' R' U R U' R2 F' R U2 R U2 R'";
            else if (num == 311)
                alg = "U' R' U2 R' F' R U R U' R' F U2 R";
            else if (num == 312)
                alg = "y L' B U2 B' L B L' U2 L B'";
            else if (num == 313)
                alg = "U R' U L U' R2 D2 R' U R D2 R' L'";
            else if (num == 314)
                alg = "U2 R U R' U L' U2 R U L U2 R' U L' U L";
            else if (num == 315)
                alg = "R2 U R2 B' R2 B R2 B' U' R2 U y R U R U' R'";
            else if (num == 316)
                alg = "U' R2 D R' U R D' R' U R' U' R U' R'";
            else if (num == 317)
                alg = "U2 R U R' U2 L' U2 R U2 L U L' R' U2 L";
            else if (num == 318)
                alg = "L' U' L U' L' U L' D' L U L' D L2";
            else if (num == 319)
                alg = "U2 R' U L U' R U' R' L' U L U' R U2 L'";
            else if (num == 320)
                alg = "U R' U' R U R2 U L U' R2 U L' U R' U2 R";
            else if (num == 321)
                alg = "R U2 R U2' R' U' R' U R F' R U2' R' U2 R' F";
            else if (num == 322)
                alg = "U R U2' R2' F2 U' R2 U' R2' U F2 U R";
            else if (num == 323)
                alg = "R U R' U' L' U2 R U' R' U2 L U' R U2 R'";
            else if (num == 324)
                alg = "U2 R U R' U R' U' R' D R' U' R D' R U2 R";
            else if (num == 325)
                alg = "U2 L' U R U' L U2 R' U' L' U R U' L R'";
            else if (num == 326)
                alg = "U' R2 D r' U2 r D' R2 U' R U' R'";
            else if (num == 327)
                alg = "U R' U' R U' R' U2 L' U2 L U L' U2 R U' L";
            else if (num == 328)
                alg = "R' U' R U R U' R' U2 R L U' R2 U L' U2 R";
            else if (num == 329)
                alg = "U R U R' F' R U2 R' U2 R' F R2 U' R'";
            else if (num == 330)
                alg = "U' R2 D R' U2 R D' R2 U' R U' R'";
            else if (num == 331)
                alg = "U R U2 R' U R U L U' R' U L' U R U' R'";
            else if (num == 332)
                alg = "U R' U' F' R U R' U' R' F R2 U' R' U R";
            else if (num == 333)
                alg = "R' U L' U R2 U R2 U R2 U2 M'";
            else if (num == 334)
                alg = "U L R U2 R' U' R U2 L' U' R' U' R U' R'";
            else if (num == 335)
                alg = "y x' M' U' R U L' U2 R' U2 R";
            else if (num == 336)
                alg = "U R U2 R' U' R U L' U L U2 R' U' L' U2 L";
            else if (num == 337)
                alg = "L' U R U' L U L' U R' U' L U R U' R'";
            else if (num == 338)
                alg = "U2 R' U2 L U' R U L' R' U R U' R' U2 R";
            else if (num == 339)
                alg = "R U2 R' U' R U R' L' U R U' L U2 R'";
            else if (num == 340)
                alg = "R U2 R2 U' R2 U' R' F U' R' U' R U F'";
            else if (num == 341)
                alg = "U2 L R U2 R' U' L' U2 R' U L U' R2 U R' U L'";
            else if (num == 342)
                alg = "U R U R' F' R U2 R' U' R U' R' F R U' R'";
            else if (num == 343)
                alg = "F R U R' U' R U R' F R' F' R U' F'";
            else if (num == 344)
                alg = "U L' U' L U' R U' L' U R' U2 L";
            else if (num == 345)
                alg = "U2 R U R' U L' U2 R U2 L U2 L' R' U2 L";
            else if (num == 346)
                alg = "U' L U2 R' U L' U' R U' L U L'";
            else if (num == 347)
                alg = "R' U2 R L U2 R' U2 R U2 L' U R' U R";
            else if (num == 348)
                alg = "U R U R' U R' U' R2 U' R2 U2 R";
            else if (num == 349)
                alg = "U2 R2 U' R' U R' U2 R' U R' U2 R' U R' U' R2 U";
            else if (num == 350)
                alg = "U2 R' U' R U R U2 R' U' R' U R U' R U' R'";
            else if (num == 351)
                alg = "U2 R U R' U' R' U' R U R U' R' U' R' U R";
            else if (num == 352)
                alg = "U R' U' R U' R' U R U' R U R2 U R U' R U' R'";
            else if (num == 353)
                alg = "U2 R2 U' R' U R U R' U2 R' U R2 U R2";
            else if (num == 354)
                alg = "U R U2 R2 U2 R2 U R2 U R2 U' R'";
            else if (num == 355)
                alg = "U R' U' R2 U R2 U R2 U2 R2 U2 R";
            else if (num == 356)
                alg = "U R' U' R U' R' U2 R";
            else if (num == 357)
                alg = "U2 R U2 R' U' R U' R'";
            else if (num == 358)
                alg = "U2 R2 U R2 U R U2 R' U R U R U' R2";
            else if (num == 359)
                alg = "U2 L2 B2 L' U2 L' U' L U' L B2 L2";
            else if (num == 360)
                alg = "";
            else if (num == 361)
                alg = "";
            else if (num == 362)
                alg = "";
            else if (num == 363)
                alg = "";
            else if (num == 364)
                alg = "";
            else if (num == 365)
                alg = "";
            else if (num == 366)
                alg = "";
            else if (num == 367)
                alg = "";
            else if (num == 368)
                alg = "";
            else if (num == 369)
                alg = "";
            else if (num == 370)
                alg = "";
            else if (num == 371)
                alg = "";
            else if (num == 372)
                alg = "R U R' U' R' F R2 U R' U' R U R' U' F'";
            else if (num == 373)
                alg = "U2 R U2 R' U2' R' F R2 U' R' U2 R U2' R' U' F'";
            else if (num == 374)
                alg = "U2 R' U' R U' R' U' R U' x' U L' U L U2 R U' R' U";
            else if (num == 375)
                alg = "r' F' r U r U2' r' F2 U' R U R' U' R U' R'";
            else if (num == 376)
                alg = "U' R' U2 R U R' U R2 U' L' U R' U' L";
            else if (num == 377)
                alg = "U' R U R' U F2 R U2 R' U2 R' F2 R";
            else if (num == 378)
                alg = "U' L U' R' U L' U' R2 U R' U R U2 R'";
            else if (num == 379)
                alg = "U2 L F2 L' U2 L' U2 L F2 U L' U L";
            else if (num == 380)
                alg = "U L' U' L U' L' U L U' L2 D' L U L' D L U L";
            else if (num == 381)
                alg = "R U2 R' U' R U R' U2 L' U R U' M'";
            else if (num == 382)
                alg = "R' F R U R' U' R' F' R2 U' R' U R U' R' U2 R";
            else if (num == 383)
                alg = "L R' U2' R2 U R2' U R U L' U' R U2 R'";
            else if (num == 384)
                alg = "";
            else if (num == 385)
                alg = "";
            else if (num == 386)
                alg = "";
            else if (num == 387)
                alg = "";
            else if (num == 388)
                alg = "";
            else if (num == 389)
                alg = "";
            else if (num == 390)
                alg = "";
            else if (num == 391)
                alg = "";
            else if (num == 392)
                alg = "";
            else if (num == 393)
                alg = "";
            else if (num == 394)
                alg = "";
            else if (num == 395)
                alg = "";
            else if (num == 396)
                alg = "R U' L' U R' U' L U' R U' L' U R' U' L";
            else if (num == 397)
                alg = "U F U R U' R' U R U' R2' F' R U R U' R'";
            else if (num == 398)
                alg = "U' R2 U' F' U F U R2 U' R2 U' R2 F R2 F'";
            else if (num == 399)
                alg = "U' R U R' U R U' R' U F2 r U2 r' U' r' F r";
            else if (num == 400)
                alg = "R' F2 R U2 R U2 R' F2 U' R U' R'";
            else if (num == 401)
                alg = "U' R' U L U' R U L2 U' L U' L' U2 L";
            else if (num == 402)
                alg = "U L U2 L' U2 L2 B2 L2 U L U' L B2 L2";
            else if (num == 403)
                alg = "U R U2 R' U' R U' R2 U L U' R U L'";
            else if (num == 404)
                alg = "U2 L' U2 L U L' U' L U2 R U' L' U M'";
            else if (num == 405)
                alg = "U L' R U R' U' L U2 R U' R' U R U2 R'";
            else if (num == 406)
                alg = "L' R U2 R2 U' R2 U' R' U' L U R' U2 R";
            else if (num == 407)
                alg = "U L U2 L B2 L2 U' L U' L' U L2 B2 L2";
            // R U2 R' U2 R2 F2 R2 U R U' R F2 R2
            // U L U2 L' U2 L2 B2 L2 U L U' L B2 L2
            // R U2 R F2 R2 U' R U' R' U R2 F2 R2
            else if (num == 408)
                alg = "";
            else if (num == 409)
                alg = "";
            else if (num == 410)
                alg = "";
            else if (num == 411)
                alg = "";
            else if (num == 412)
                alg = "";
            else if (num == 413)
                alg = "";
            else if (num == 414)
                alg = "";
            else if (num == 415)
                alg = "";
            else if (num == 416)
                alg = "";
            else if (num == 417)
                alg = "";
            else if (num == 418)
                alg = "";
            else if (num == 419)
                alg = "";
            else if (num == 420)
                alg = "(R U2 R' U' R U' R') U' (R U2 R' U' R U' R')";
            else if (num == 421)
                alg = "";
            else if (num == 422)
                alg = "";
            else if (num == 423)
                alg = "";
            else if (num == 424)
                alg = "";
            else if (num == 425)
                alg = "";
            else if (num == 426)
                alg = "R U2 R2 U' R2 U' R2 U2 R";
            else if (num == 427)
                alg = "";
            else if (num == 428)
                alg = "";
            else if (num == 429)
                alg = "";
            else if (num == 430)
                alg = "R' U2 R2 U R2 U R2 U2 R'";
            else if (num == 431)
                alg = "";
            else if (num == 432)
                alg = "";
            else if (num == 433)
                alg = "";
            else if (num == 434)
                alg = "";
            else if (num == 435)
                alg = "";
            else if (num == 436)
                alg = "";
            else if (num == 437)
                alg = "";
            else if (num == 438)
                alg = "";
            else if (num == 439)
                alg = "";
            else if (num == 440)
                alg = "";
            else if (num == 441)
                alg = "";
            else if (num == 442)
                alg = "";
            else if (num == 443)
                alg = "";
            else if (num == 444)
                alg = "";
            else if (num == 445)
                alg = "";
            else if (num == 446)
                alg = "";
            else if (num == 447)
                alg = "";
            else if (num == 448)
                alg = "";
            else if (num == 449)
                alg = "";
            else if (num == 450)
                alg = "";
            else if (num == 451)
                alg = "";
            else if (num == 452)
                alg = "";
            else if (num == 453)
                alg = "";
            else if (num == 454)
                alg = "";
            else if (num == 455)
                alg = "";
            else if (num == 456)
                alg = "";
            else if (num == 457)
                alg = "";
            else if (num == 458)
                alg = "";
            else if (num == 459)
                alg = "";
            else if (num == 460)
                alg = "";
            else if (num == 461)
                alg = "";
            else if (num == 462)
                alg = "";
            else if (num == 463)
                alg = "";
            else if (num == 464)
                alg = "";
            else if (num == 465)
                alg = "";
            else if (num == 466)
                alg = "";
            else if (num == 467)
                alg = "";
            else if (num == 468)
                alg = "";
            else if (num == 469)
                alg = "";
            else if (num == 470)
                alg = "";
            else if (num == 471)
                alg = "";
            else if (num == 472)
                alg = "";
            else if (num == 473)
                alg = "";
            else if (num == 474)
                alg = "";
            else if (num == 475)
                alg = "";
            else if (num == 476)
                alg = "";
            else if (num == 477)
                alg = "";
            else if (num == 478)
                alg = "";
            else if (num == 479)
                alg = "";
            else if (num == 480)
                alg = "U' F (R U R' U') (R U R' U') (R U R' U') F'";
            else if (num == 481)
                alg = "";
            else if (num == 482)
                alg = "";
            else if (num == 483)
                alg = "";
            else if (num == 484)
                alg = "";
            else if (num == 485)
                alg = "";
            else if (num == 486)
                alg = "";
            else if (num == 487)
                alg = "";
            else if (num == 488)
                alg = "";
            else if (num == 489)
                alg = "";
            else if (num == 490)
                alg = "";
            else if (num == 491)
                alg = "";
            else if (num == 492)
                alg = "";
            else if (num == 493)
                alg = "";
            else if (num == 494)
                alg = "";
            else if (num == 495)
                alg = "";
            else if (num == 496)
                alg = "";
            else if (num == 497)
                alg = "";
            else if (num == 498)
                alg = "";
            else if (num == 499)
                alg = "";
            else if (num == 500)
                alg = "";
            else if (num == 501)
                alg = "";
            else if (num == 502)
                alg = "";
            else if (num == 503)
                alg = "";

            return alg;
        }

        public void Terminate()
        {

        }
        
    }
}
