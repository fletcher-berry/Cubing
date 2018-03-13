using Cubing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice
{
    public class Info
    {
        public static MainScreen MainForm;
        public static readonly string AlgFilePath = System.Configuration.ConfigurationManager.AppSettings["algFilePath"];

        public static ICube GetScreenCube(AlgSet set)
        {
            switch (set)
            {
                case AlgSet.ZBLL:
                    return new ZbllCube(MainScreen.PreviewCubeSize);
                case AlgSet.OLL:
                    return new OllCube(MainScreen.PreviewCubeSize);
                case AlgSet.OLLCP:
                    return new OllcpCube(MainScreen.PreviewCubeSize);
                case AlgSet.ELLCP:
                    return new EllcpCube(MainScreen.PreviewCubeSize);
                case AlgSet.VLS:
                    return new VlsCube(MainScreen.PreviewCubeSize);
                case AlgSet.OneLookLL:
                    return new OneLookLLCube(MainScreen.PreviewCubeSize);
            }
            return null;
        }

        public static ICube GetRunnerCube(AlgSet set)
        {
            switch (set)
            {
                case AlgSet.ZBLL:
                    return new ZbllCube(MainScreen.CubeSize);
                case AlgSet.OLL:
                    return new OllCube(MainScreen.CubeSize);
                case AlgSet.OLLCP:
                    return new OllcpCube(MainScreen.CubeSize);
                case AlgSet.ELLCP:
                    return new EllcpCube(MainScreen.CubeSize);
                case AlgSet.VLS:
                    return new VlsCube(MainScreen.CubeSize);
                case AlgSet.OneLookLL:
                    return new OneLookLLCube(MainScreen.CubeSize);
            }
            return null;
        }

        public static string GetAlgFileName(AlgSet set)
        {
            switch (set)
            {
                case AlgSet.ZBLL:
                    return AlgFilePath + @"\zbll.alg";
                case AlgSet.OLL:
                    return AlgFilePath + @"\oll.alg";
                case AlgSet.OLLCP:
                    return AlgFilePath + @"\ollcp.alg";
                case AlgSet.ELLCP:
                    return AlgFilePath + @"\ellcp.alg";
                case AlgSet.VLS:
                    return AlgFilePath + @"\vls.alg";
                case AlgSet.OneLookLL:
                    return AlgFilePath + @"\oneLookLL.alg";
            }
            return null;
        }

        // makes list from set of ranges or set names
        public static List<int> MakeList(string posRange, int max)
        {
            List<int> nums = new List<int>();
            posRange = posRange.Trim();
            string[] ranges = posRange.Split(',');
            foreach (string range in ranges)
            {
                List<int> values = RangeToList(range.Trim(), max);
                foreach (var val in values)
                    nums.Add(val);
            }

            return nums;
        }

        // make list from single range
        public static List<int> RangeToList(string range, int max)
        {
            List<int> nums = new List<int>();
            string range1 = range.Trim();
            string[] ends = range1.Split('-');
            if (ends.Length == 1)
            {
                int num = 0;
                bool success = int.TryParse(ends[0], out num);
                if (!success || num < 0 || num >= max)
                    throw new ArgumentException("invalid range: " + range1);
                nums.Add(num);
            }
            else if (ends.Length == 2)
            {
                int low = 0;
                int high = 0;
                bool success = int.TryParse(ends[0], out low) && int.TryParse(ends[1], out high);
                if (!success || high <= low || low < 0 || high > max)
                    throw new ArgumentException("invalid range: " + range1);
                for (int k = low; k < high; k++)
                {
                    nums.Add(k);
                }
            }
            else
                throw new ArgumentException("invalid string " + range1);
            return nums;
        }
    }


}
