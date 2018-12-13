 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Constants for the colors on a Cube
    /// </summary>
    public enum CubeColor
    {
        Green, Yellow, Red, Blue, White, Orange, None
    };

    /// <summary>
    /// Constants for describing color comparisons with the side faces, not white and yellow.
    /// </summary>
    public enum ColorCompare
    {
        Same, Opposite, Left, Right
    };
}
