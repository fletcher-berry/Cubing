using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class Move
    {
        private int FaceCode;
        private int DirectionCode;
        public bool OpenBracket;
        public bool CloseBracket    ;

        public static readonly Move EndMove = new Move{FaceCode = 31, DirectionCode = 7};
        public const byte EndMoveCode = 255;

        private static readonly string[] Faces = { "R", "U", "F", "L", "D", "B", "r", "u", "f", "l", "d", "b",
            "M", "E", "S", "x", "y", "z",
            "Rw", "Uw", "Fw", "Lw", "Dw", "Bw", "3Rw", "3Uw", "3Fw", "3Lw", "3Dw", "3Bw" };

        private static readonly string[] Directions = { "", "2", "'", "2'", "3", "3'" };

        private Move() { }

        public Move(byte b)
        {
            FaceCode = (byte)(b >> 3);
            DirectionCode = (byte)(b & 7);
            if ((FaceCode >= 30 || DirectionCode >= 6 ) && b != EndMoveCode)
                throw new ArgumentException("byte value not parsable as a Move object: " + b);
        }

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

        public byte ToByte()
        {
            if (this == EndMove)
                return EndMoveCode;
            return (byte)((FaceCode << 3) + DirectionCode);
        }
    }
}
