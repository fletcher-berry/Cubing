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
        public static readonly string shortcutPath = "keys.txt";


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

        public static Point ScalePoint(Point p, double ratio)
        {
            return new Point((int)(p.X * ratio), (int)((p.Y) * ratio));
        }

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

        public static Point ScalePoint(Point p, double ratio, int xShift, int yShift)
        {
            return new Point((int)(p.X * ratio), (int)((p.Y) * ratio));
        }

    }
}
