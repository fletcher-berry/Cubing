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

        //// makes list from set of ranges or set names
        //public static List<int> MakeList(string posRange, int max)
        //{
        //    List<int> nums = new List<int>();
        //    posRange = posRange.Trim();
        //    string[] ranges = posRange.Split(',');
        //    foreach (string range in ranges)
        //    {
        //        List<int> values = GetAlgs(range.Trim(), max);
        //        foreach (var val in values)
        //            nums.Add(val);
        //    }

        //    return nums;
        //}

        //// makes list from range or set name
        //public static List<int> GetAlgs(string token, int max)
        //{
        //    List<int> algs = new List<int>();
        //    if(token.ToUpper().Equals("ALL"))
        //    {
        //        for (int k = 0; k < max; k++)
        //            algs.Add(k);
        //        return algs;
        //    }
        //    StreamReader reader = new StreamReader(shortcutPath);
        //    string line = "";
        //    while((line = reader.ReadLine()) != null)
        //    {
        //        if (line.Equals(string.Empty))
        //            continue;
        //        string[] ranges = line.Split(' ');
        //        if (!ranges[0].Equals(token))
        //            continue;
        //        for(int k = 1; k < ranges.Length; k++)
        //        {
        //            if(ranges[k].EndsWith(","))
        //                ranges[k] = ranges[k].Substring(0, ranges[k].Length - 1);
        //            List<int> result = RangeToList(ranges[k], max);
        //            foreach(var alg in result)
        //            {
        //                algs.Add(alg);
        //            }
        //        }
        //        reader.Close();
        //        return algs;
        //    }
        //    reader.Close();
        //    return RangeToList(token, max);
        //}

        //// make list from single range
        //public static List<int> RangeToList(string range, int max)
        //{
        //    List<int> nums = new List<int>();
        //    string range1 = range.Trim();
        //    string[] ends = range1.Split('-');
        //    if (ends.Length == 1)
        //    {
        //        int num = 0;
        //        bool success = int.TryParse(ends[0], out num);
        //        if (!success || num < 0 || num >= max)
        //            throw new ArgumentException("invalid range: " + range1);
        //        nums.Add(num);
        //    }
        //    else if (ends.Length == 2)
        //    {
        //        int low = 0;
        //        int high = 0;
        //        bool success = int.TryParse(ends[0], out low) && int.TryParse(ends[1], out high);
        //        if (!success || high <= low || low < 0 || high > max)
        //            throw new ArgumentException("invalid range: " + range1);
        //        for (int k = low; k < high; k++)
        //        {
        //            nums.Add(k);
        //        }
        //    }
        //    else
        //        throw new ArgumentException("invalid string " + range1);
        //    return nums;
        //}

        //public static void AddSetName(string name, string posList)
        //{
        //    MakeList(posList, int.MaxValue);        //exception will be thrown if posList is invalid
        //    StreamWriter writer = new StreamWriter(shortcutPath, true);
        //    writer.Write(name + " ");
        //    writer.WriteLine(posList);
        //    writer.Close();

        //}

        

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
                Point p = new Point((int)(points[k].X * ratio), (int)((points[k].Y - 50) * ratio));
                newPoints[k] = p;
            }
            return newPoints;
        }

        public static Point ScalePoint(Point p, double ratio)
        {
            return new Point((int)(p.X * ratio), (int)((p.Y - 50) * ratio));
        }

        public static Point[] ScalePointArray(Point[] points, double ratio, int xShift, int yShift)
        {
            Point[] newPoints = new Point[points.Length];
            for (int k = 0; k < points.Length; k++)
            {
                Point p = new Point((int)(points[k].X * ratio) + xShift, (int)((points[k].Y - 50) * ratio) + yShift);
                newPoints[k] = p;
            }
            return newPoints;
        }

    }
}
