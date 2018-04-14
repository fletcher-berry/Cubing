using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Represents a move of a Rubik's cube algorithm
    /// </summary>
    public class Move
    {
        private int FaceCode;
        private int DirectionCode;
        public bool OpenBracket;
        public bool CloseBracket;

        public static readonly Move EndMove = new Move{FaceCode = 31, DirectionCode = 7};
        public const byte EndMoveCode = 255;

        private static readonly string[] Faces = { "R", "U", "F", "L", "D", "B", "r", "u", "f", "l", "d", "b",
            "M", "E", "S", "x", "y", "z",
            "Rw", "Uw", "Fw", "Lw", "Dw", "Bw", "3Rw", "3Uw", "3Fw", "3Lw", "3Dw", "3Bw" };

        private static readonly string[] Directions = { "", "2", "'", "2'", "3", "3'" };

        private Move() { }

        /// <summary>
        /// Creates a mobe from a byte of a .alg file
        /// </summary>
        /// <param name="b">A byte of a .alg file</param>
        public Move(byte b)
        {
            FaceCode = (byte)(b >> 3);
            DirectionCode = (byte)(b & 7);
            if ((FaceCode >= 30 || DirectionCode >= 6 ) && b != EndMoveCode)
                throw new ArgumentException("byte value not parsable as a Move object: " + b);
        }

        /// <summary>
        /// Creates a move from a string in rubik's cube notation
        /// </summary>
        /// <param name="s">A string containing 1 move in rubik's cube notation</param>
        public Move(string s)
        {
            if(string.IsNullOrEmpty(s))
                throw new ArgumentException("string not parsable as a Move object: " + s);
            if(s.StartsWith("("))
            {
                OpenBracket = true;
                s = s.Substring(1);
            }
            if(s.EndsWith(")"))
            {
                CloseBracket = true;
                s = s.Substring(0, s.Length - 1);
            }
            int face = -1;
            for(int k = 0; k < Faces.Length; k++)
            {
                if(s.StartsWith(Faces[k]))
                {
                    face = k;
                    s = s.Substring(Faces[k].Length);
                    break;
                }
            }
            if (face == -1)
                throw new ArgumentException("string not parsable as a Move object: " + s);
            int direction = -1;
            for (int k = 0; k < Directions.Length; k++)
            {
                if (s.Equals(Directions[k]))
                {
                    direction = k;
                    break;
                }
            }
            if(direction == -1)
                throw new ArgumentException("string not parsable as a Move object: " + s);
            FaceCode = face;
            DirectionCode = direction;
        }

        /// <summary>
        /// Converts a Move to a rubik's cube notation string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this == EndMove)
                throw new ArgumentException("cannot convert end move to a string");
            string str = "";
            if (OpenBracket)
                str += "(";
            str += Faces[FaceCode] + Directions[DirectionCode];
            if (CloseBracket)
                str += ")";
            return str;
        }

        /// <summary>
        /// Converts a move to a byte to save to a .alg file
        /// </summary>
        /// <returns></returns>
        public byte ToByte()
        {
            if (this == EndMove)
                return EndMoveCode;
            return (byte)((FaceCode << 3) + DirectionCode);
        }





        // for algConverter
        private static int GetInverseDirCode(int dirCode)
        {
            if (dirCode == 0)
                return 2;
            else if (dirCode == 2)
                return 0;
            else if (dirCode == 1 || dirCode == 3)
                return 1;
            else if (dirCode == 4)
                return 5;
            else
                return 4;
        }

        private static bool IsOuter(int faceCode)
        {
            return faceCode >= 12 && faceCode <= 17;
        }

        private static int GetYFaceCode(int faceCode)
        {
           

            if (!IsOuter(faceCode))
                return -1;
            if (faceCode % 6 == 0 || faceCode % 6 == 3)
                return faceCode + 2;
            if (faceCode % 6 == 2)
                return faceCode + 1;
            if (faceCode % 6 == 5)
                return faceCode - 5;
            else
                return faceCode;

        }

        private static int GetY2FaceCode(int faceCode)
        {
            if (!IsOuter(faceCode))
                return -1;
            return GetYFaceCode(GetYFaceCode(faceCode));
        }

        private static int GetYiFaceCode(int faceCode)
        {
            if (!IsOuter(faceCode))
                return -1;
            return GetYFaceCode(GetYFaceCode(GetYFaceCode(faceCode)));
        }

        private static int GetXFaceCode(int faceCode)
        {

            if (!IsOuter(faceCode))
                return -1;
            if (faceCode % 6 == 1)
                return faceCode + 4;
            if (faceCode % 6 == 2 || faceCode % 6 == 5)
                return faceCode - 1;
            if (faceCode % 6 == 4)
                return faceCode - 2;
            else
                return faceCode;
        }

        private static int GetX2FaceCode(int faceCode)
        {
            if (!IsOuter(faceCode))
                return -1;
            return GetXFaceCode(GetXFaceCode(faceCode));
        }

        private static int GetXiFaceCode(int faceCode)
        {
            if (!IsOuter(faceCode))
                return -1;
            return GetXFaceCode(GetXFaceCode(GetXFaceCode(faceCode)));
        }

        private static int GetZFaceCode(int faceCode)
        {
            if (!IsOuter(faceCode))
                return -1;
            if (faceCode % 6 == 0)
                return faceCode + 4;
            if (faceCode % 6 == 1 || faceCode % 6 == 4)
                return faceCode - 1;
            if (faceCode % 6 == 3)
                return faceCode - 2;
            else
                return faceCode;
        }

        private static int GetZ2FaceCode(int faceCode)
        {
            if (!IsOuter(faceCode))
                return -1;
            return GetZFaceCode(GetZFaceCode(faceCode));
        }

        private static int GetZiFaceCode(int faceCode)
        {
            if (!IsOuter(faceCode))
                return -1;
            return GetZFaceCode(GetZFaceCode(GetZFaceCode(faceCode)));
        }




        public Move GetInverse()
        {
            return new Move { FaceCode = FaceCode, DirectionCode = GetInverseDirCode(DirectionCode), OpenBracket = OpenBracket, CloseBracket = CloseBracket };
        }

        //public Move GetUAngle()
        //{

        //}
    }
}
