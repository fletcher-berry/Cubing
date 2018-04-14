using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Represents a rubik's cube algorithm
    /// </summary>
    public class Algorithm
    {

        public List<Move> Moves;

        /// <summary>
        /// The maximum numbr of moves in an algorithm
        /// </summary>
        public const int MaxMoves = 25;

        /// <summary>
        /// Creates an algorithm from a string representation in rubik's cube notation
        /// </summary>
        /// <param name="str">A string representation if the algorithm in rubik's cube notation</param>
        /// <exception cref="OverflowException">Thrown if the algorithm has too many moves</exception>
        public Algorithm(string str)
        {
            str = str.Replace('’', '\'');
            str = str.Trim();
            if(str.Equals(string.Empty))
            {
                Moves = new List<Move>();
                return;
            }
            string[] moves = str.Split(' ');
            if (moves.Length > MaxMoves)
                throw new OverflowException("Too many moves in the algorithm");
            Moves = new List<Move>();
            foreach(string move in moves)
            {
                Moves.Add(new Move(move));
            }
        }

        /// <summary>
        /// Creates an Algorithm from the bytes of a .alg file
        /// </summary>
        /// <param name="moves">an array of 32 bytes from a .alg file</param>
        /// <exception cref="ArgumentException">Thrown if the number of bytes is not 32</exception>
        public Algorithm(byte[] moves)
        {
            if (moves.Length != 32)
                throw new ArgumentException("expected length of array is 32");
            Moves = new List<Move>();
            for (int k = 0; k < MaxMoves; k++)
            {
                byte b = moves[k];
                if (b == Move.EndMoveCode)
                    break;
                Moves.Add(new Move(b));
            }
            for(int k = MaxMoves + 1; k < 32; k++)
            {
                int moveNum = moves[k];
                if(moveNum != 255)
                {
                    if (k % 2 == 0)
                    {
                        Moves[moveNum].OpenBracket = true;
                    }
                    else
                    {
                        Moves[moveNum].CloseBracket = true;
                    }
                }
            }

        }

        /// <summary>
        /// Converts an algorithm to a rubik's cube notation string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = String.Empty;
            foreach(Move move in Moves)
            {
                str += move.ToString() + " ";
            }
            str = str.Trim();
            return str;
        }

        /// <summary>
        /// Converts an algorithm to a byte array to save to a .alg file
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OverflowException">Thrown if there are too many moves in the algorithm</exception>
        /// <exception cref="ArgumentException">Thrown if there are too many parentheses in the algorithm</exception>
        public byte[] ToByteArray()
        {
            if (Moves.Count > MaxMoves)
                throw new OverflowException("Too many moves in the algorithm");
            byte[] arr = new byte[32];
            for(int i = MaxMoves + 1; i < 32; i++)
            {
                arr[i] = 255;
            }
            int k = 0;
            int numOpenBracket = 0;
            int numCloseBracket = 0;
            for(; k < Moves.Count; k++)
            {
                byte b = Moves[k].ToByte();
                arr[k] = b;
                if(Moves[k].OpenBracket)
                {
                    numOpenBracket++;
                    if (numOpenBracket > 3)
                        throw new ArgumentException("too many parentheses in algorithm");
                    int index = 24 + 2 * numOpenBracket;
                    arr[index] = (byte)k;
                }
                if (Moves[k].CloseBracket)
                {
                    numCloseBracket++;
                    if (numCloseBracket > 3)
                        throw new ArgumentException("too many parentheses in algorithm");
                    int index = 25 + 2 * numCloseBracket;
                    arr[index] = (byte)k;
                }
            }
            arr[k] = Move.EndMoveCode;
            return arr; 

        }
    }
}
