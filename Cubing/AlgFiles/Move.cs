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
        protected int FaceCode;
        protected int DirectionCode;
        public bool OpenBracket;
        public bool CloseBracket;

        public static readonly Move EndMove = new Move{FaceCode = 31, DirectionCode = 7};
        public const byte EndMoveCode = 255;

        protected static readonly string[] Faces = { "R", "U", "F", "L", "D", "B", "r", "u", "f", "l", "d", "b",
            "M", "E", "S", "x", "y", "z",
            "Rw", "Uw", "Fw", "Lw", "Dw", "Bw", "3Rw", "3Uw", "3Fw", "3Lw", "3Dw", "3Bw" };

        protected static readonly string[] Directions = { "", "2", "'", "2'", "3", "3'" };

        protected Move() { }

        protected Move(int faceCode, int directionCode)
        {
            FaceCode = faceCode;
            DirectionCode = directionCode;
        }

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
        /// <exception cref="ArgumentException">Thrown if the parameter is not parsable as an algorithm</exception>
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
    }
}
