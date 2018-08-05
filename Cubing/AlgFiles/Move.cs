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

        private Move(int faceCode, int directionCode)
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
            return faceCode < 12 || faceCode > 17;
        }

        
        private static int GetTransfromFaceCode(int original, string transform)
        {
            
            var modded = original % 6;
            if (string.IsNullOrEmpty(transform))
                throw new ArgumentException("invalid input string");
            if (!IsOuter(original))
                throw new ArgumentException("cannot apply face transforms on slice moves and rotations");
            var xList = new List<int> { 1, 2, 4, 5 };
            var yList = new List<int> { 0, 2, 3, 5 };
            var zList = new List<int> { 1, 0, 4, 3 };
            var faceDict = new Dictionary<char, List<int>> { { 'x', xList }, { 'y', yList }, { 'z', zList } };
            var directionDict = new Dictionary<string, int> { { "", 1 }, { "2", 2 }, { "'", 3 } };
            try
            {
                var faceCodeList = faceDict[transform[0]];
                var offset = directionDict[transform.Substring(1)];
                var idx = faceCodeList.IndexOf(modded);
                if (idx == -1)
                    return original;
                idx = (idx + offset) % 4;
                var newModded = faceCodeList[idx];
                var newFaceCode = original - modded + newModded;
                return newFaceCode;
            }
            catch (Exception)
            {
                throw new ArgumentException("invalid input string");
            }
        }


        public Move GetInverse()
        {
            return new Move { FaceCode = FaceCode, DirectionCode = GetInverseDirCode(DirectionCode), OpenBracket = OpenBracket, CloseBracket = CloseBracket };
        }

        public Move GetTransform(string transform)
        {
            if (IsOuter(FaceCode))
                return new Move { FaceCode = GetTransfromFaceCode(FaceCode, transform), DirectionCode = DirectionCode, CloseBracket = CloseBracket, OpenBracket = OpenBracket };
            else
                return GetTransfromSlice(transform);
        }

        public Move GetRLMirror()
        {
            if (IsOuter(FaceCode))
            {
                var newFaceCode = FaceCode;
                if (FaceCode % 6 == 0)
                    newFaceCode += 3;
                else if (FaceCode % 6 == 3)
                    newFaceCode -= 3;
                var newDirectionCode = GetInverseDirCode(DirectionCode);
                return new Move(newFaceCode, newDirectionCode);
            }
            else
            {
                bool switchDirection = FaceCode % 3 != 0;
                var newDirectionCode = switchDirection ? GetInverseDirCode(DirectionCode) : DirectionCode;
                return new Move(FaceCode, newDirectionCode);
            }
        }

        public Move GetFBMirror()
        {
            if (IsOuter(FaceCode))
            {
                var newFaceCode = FaceCode;
                if (FaceCode % 6 == 2)
                    newFaceCode += 3;
                else if (FaceCode % 6 == 5)
                    newFaceCode -= 3;
                var newDirectionCode = GetInverseDirCode(DirectionCode);
                return new Move(newFaceCode, newDirectionCode);
            }
            else
            {
                bool switchDirection = FaceCode % 3 != 2;
                var newDirectionCode = switchDirection ? GetInverseDirCode(DirectionCode) : DirectionCode;
                return new Move(FaceCode, newDirectionCode);
            }
        }

        private Move GetTransfromSlice(string transform)
        {
            var originalDict = new Dictionary<int, int> { { 12, 0 }, { 13, 1 }, { 14, 2 }, { 15, 3 }, { 16, 4 }, { 17, 5 } };
            var transformDict = new Dictionary<char, int> { { 'x', 0 }, { 'y', 1 }, { 'z', 2 } };
            var answers = new Tuple<int, bool>[,] {
                { Tuple.Create(12, false), Tuple.Create(14, true), Tuple.Create(13, false)} ,
                { Tuple.Create(14, true), Tuple.Create(13, false), Tuple.Create(12, false)},
                { Tuple.Create(13, true), Tuple.Create(12, false), Tuple.Create(14, false) },
                { Tuple.Create(12, false), Tuple.Create(14, false), Tuple.Create(13, true)} ,
                { Tuple.Create(14, true), Tuple.Create(13, false), Tuple.Create(12, true)},
                { Tuple.Create(13, true), Tuple.Create(12, false), Tuple.Create(14, false) }};
            try
            {
                char rotationType = transform[0];
                string rotationDirection = transform.Substring(1);
                var answerTuple = answers[originalDict[this.FaceCode], transformDict[rotationType]];
                if (rotationDirection.Equals(""))
                {
                    var newFaceCode = answerTuple.Item1;
                    var newDirectionCode = answerTuple.Item2 ? GetInverseDirCode(this.DirectionCode) : this.DirectionCode;
                    return new Move { FaceCode = newFaceCode, DirectionCode = newDirectionCode };
                }
                if(rotationDirection.Equals("'"))
                {
                    var newFaceCode = answerTuple.Item1;
                    var newDirectionCode = answerTuple.Item2 ? this.DirectionCode : GetInverseDirCode(this.DirectionCode);
                    return new Move { FaceCode = newFaceCode, DirectionCode = newDirectionCode };
                }
                if(rotationDirection.Equals("2"))
                {
                    bool inverseDirection = !answerTuple.Item1.Equals(this.FaceCode);
                    var newDirectionCode = inverseDirection? GetInverseDirCode(this.DirectionCode) : this.DirectionCode;
                    return new Move { FaceCode = this.FaceCode, DirectionCode = newDirectionCode };
                }
                throw new Exception();
            }
            catch(Exception)
            {
                throw new ArgumentException("invalid transform string");
            }
        }
    }
}
