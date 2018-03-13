using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class AlgUtilities
    {
        //private static readonly string[] Faces = { "R", "U", "F", "L", "D", "B", "r", "u", "f", "l", "d", "b",
        //    "M", "E", "S", "x", "y", "z",
        //    "Rw", "Uw", "Fw", "Lw", "Dw", "Bw", "3Rw", "3Uw", "3Fw", "3Lw", "3Dw", "3Bw" };

        //private static readonly string[] Directions = { "", "2", "'", "2'", "3", "3'" };


        //public static string ByteToDirection(byte b)
        //{
        //    if (b > 6)
        //        throw new IndexOutOfRangeException("Direction code must be between 0 and 5. Value was " + b);
        //    return Directions[b];
        //}

        //public static string ByteToFace(byte b)
        //{
        //    if (b > 29)
        //        throw new IndexOutOfRangeException("Face code must be between 0 and 29. Value was " + b);
        //    return Faces[b];
        //}

        //public static Move ByteToMove(byte b)
        //{
        //    if (b == 255)
        //        return Move.EndMove;
        //    byte faceIndex = (byte)(b >> 3);
        //    byte directionIndex = (byte)(b & 7);
        //    return new Move { FaceCode = faceIndex, DirectionCode = directionIndex };
        //}
    }
}
