using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class Tools
    {
        // delete when custom subsets xml file is added
        public static readonly string shortcutPath = "keys.txt";

        /// <summary>
        /// Given a cube color get the appropriate brush to fill the color
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Brush GetBrush(CubeColor c)
        {
            if (c == CubeColor.Blue)
                return Brushes.Blue;
            if (c == CubeColor.Green)
                return Brushes.Green;
            if (c == CubeColor.Orange)
                return Brushes.Orange;
            if (c == CubeColor.Red)
                return Brushes.Red;
            if (c == CubeColor.White)
                return Brushes.White;
            if (c == CubeColor.Yellow)
                return Brushes.Yellow;
            return Brushes.DarkGray;
        }

        /// <summary>
        /// Scales all points in an array by a given ratio and returns the new array of points
        /// </summary>
        /// <param name="points">The array of Point objects to scale</param>
        /// <param name="ratio">The ratio which to scale the points</param>
        /// <returns></returns>
        public static Point[] ScalePointArray(Point[] points, double ratio)
        {
            Point[] newPoints = new Point[points.Length];
            for (int k = 0; k < points.Length; k++)
            {
                Point p = new Point((int)(points[k].X * ratio), (int)((points[k].Y) * ratio));
                newPoints[k] = p;
            }
            return newPoints;
        }

        /// <summary>
        /// Scales a point by a given ratio and returns the new Point
        /// </summary>
        /// <param name="p">The Point to scale</param>
        /// <param name="ratio">The ratio which to scale the point</param>
        /// <returns></returns>
        public static Point ScalePoint(Point p, double ratio)
        {
            return new Point((int)(p.X * ratio), (int)((p.Y) * ratio));
        }

        /// <summary>
        /// Scales and translates each point in an array and returns an array of new points.  The translation is done after scaling.
        /// </summary>
        /// <param name="points">The array of points to scale</param>
        /// <param name="ratio">The ratio which to scale the points</param>
        /// <param name="xShift">The number of pixels right to translate the points</param>
        /// <param name="yShift">The number of pixels down to translate the points</param>
        /// <returns></returns>
        public static Point[] ScalePointArray(Point[] points, double ratio, int xShift, int yShift)
        {
            Point[] newPoints = new Point[points.Length];
            for (int k = 0; k < points.Length; k++)
            {
                Point p = new Point((int)(points[k].X * ratio) + xShift, (int)((points[k].Y) * ratio) + yShift);
                newPoints[k] = p;
            }
            return newPoints;
        }

        /// <summary>
        /// Scales and translates a point and returns the new point.  The translation is done after scaling.
        /// </summary>
        /// <param name="p">The point to scale</param>
        /// <param name="ratio">The ratio which to scale the points</param>
        /// <param name="xShift">The number of pixels right to translate the point</param>
        /// <param name="yShift">The number of pixels down to translate the point</param>
        /// <returns></returns>
        public static Point ScalePoint(Point p, double ratio, int xShift, int yShift)
        {
            return new Point((int)(p.X * ratio), (int)((p.Y) * ratio));
        }

    }
}
