using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class RecognitionTools
    {
        public static ColorCompare CompareColors(CubeColor a, CubeColor b)
        {
            if (!((a == CubeColor.Orange || a == CubeColor.Blue || a == CubeColor.Green || a == CubeColor.Red) &&
                (b == CubeColor.Orange || b == CubeColor.Blue || b == CubeColor.Green || b == CubeColor.Red)))
                throw new ArgumentException("invalid cube color");

            if (GetRelativeColor(a, ColorCompare.Same) == b)
                return ColorCompare.Same;
            if (GetRelativeColor(a, ColorCompare.Opposite) == b)
                return ColorCompare.Opposite;
            if (GetRelativeColor(a, ColorCompare.Right) == b)
                return ColorCompare.Right;
            return ColorCompare.Left;
        }

        public static Tuple<bool, ColorCompare?> IsMatch(CubeColor color1, CubeColor color2, ColorCompare? start)
        {
            if((color1 == CubeColor.Yellow && color1 == CubeColor.Yellow) || (color1 == CubeColor.None && color2 == CubeColor.None))
            {
                return Tuple.Create<bool, ColorCompare?>(true, start);
            }
            if(color1 == CubeColor.Yellow || color1 == CubeColor.None || color2 == CubeColor.Yellow || color2 == CubeColor.None)
            {
                return Tuple.Create<bool, ColorCompare?>(false, null);
            }
            var compare = CompareColors(color1, color2);
            if (start == null)
                start = compare;
            if(start == compare)
                return Tuple.Create<bool, ColorCompare?>(true, start);
            else
                return Tuple.Create<bool, ColorCompare?>(false, null);

        }

       

        public static CubeColor GetRelativeColor(CubeColor col, ColorCompare rel)
        {
            if (!(col == CubeColor.Orange || col == CubeColor.Blue || col == CubeColor.Green || col == CubeColor.Red))
                throw new ArgumentException("invalid cube color");
            if (rel == ColorCompare.Same)
                return col;
            if(rel == ColorCompare.Opposite)
            {
                if (col == CubeColor.Blue)
                    return CubeColor.Green;
                if (col == CubeColor.Green)
                    return CubeColor.Blue;
                if (col == CubeColor.Red)
                    return CubeColor.Orange;
                return CubeColor.Red;
            }
            if(rel == ColorCompare.Right)
            {
                if (col == CubeColor.Orange)
                    return CubeColor.Blue;
                if (col == CubeColor.Blue)
                    return CubeColor.Red;
                if (col == CubeColor.Red)
                    return CubeColor.Green;
                return CubeColor.Orange;
            }
            if (col == CubeColor.Orange)
                return CubeColor.Green;
            if (col == CubeColor.Green)
                return CubeColor.Red;
            if (col == CubeColor.Red)
                return CubeColor.Blue;
            return CubeColor.Orange;
        }


    }
}
