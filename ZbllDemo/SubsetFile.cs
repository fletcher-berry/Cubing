using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class SubsetFile
    {
        public string Name;

        public SubsetFile(string name)
        {
            Name = name;
        }

        public void AddSubset(string setName, string posList)
        {
            StreamWriter writer = new StreamWriter(Name, true);
            writer.Write(setName + " ");
            writer.WriteLine(posList);
            writer.Close();
        }

        public List<Subset> GetSubsets()
        {
            List<Subset> subsets = new List<Subset>();
            StreamReader reader = new StreamReader(Name);
            string line;
            while((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                int spaceIdx = line.IndexOf(' ');
                string setName = line.Substring(0, spaceIdx);
                string setList = line.Substring(spaceIdx + 1);
                subsets.Add(new Subset() { Name = setName, SubsetList = setList });
            }
            reader.Close();
            return subsets;
        }

        public void SaveSubsets(List<Subset> subsets)
        {
            StreamWriter writer = new StreamWriter(Name, false);

            // this will throw an exception if a subset is not valid
            foreach (var set in subsets)
            {
                MakeList(set.SubsetList, int.MaxValue);
            }

            foreach(var set in subsets)
            {
                writer.Write(set.Name + " ");
                writer.WriteLine(set.SubsetList);
            }
            writer.Close();
        }

        // makes list from set of ranges or set names
        public List<int> MakeList(string posRange, int max)
        {
            List<int> nums = new List<int>();
            posRange = posRange.Trim();
            string[] ranges = posRange.Split(',');
            foreach (string range in ranges)
            {
                List<int> values = GetAlgs(range.Trim(), max);
                foreach (var val in values)
                    nums.Add(val);
            }

            return nums;
        }

        // makes list from range or set name
        public List<int> GetAlgs(string token, int max)
        {
            List<int> algs = new List<int>();
            if (token.ToUpper().Equals("ALL"))
            {
                for (int k = 0; k < max; k++)
                    algs.Add(k);
                return algs;
            }
            StreamReader reader = new StreamReader(Name);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Equals(string.Empty))
                    continue;
                string[] ranges = line.Split(' ');
                if (!ranges[0].Equals(token))
                    continue;
                for (int k = 1; k < ranges.Length; k++)
                {
                    if (ranges[k].EndsWith(","))
                        ranges[k] = ranges[k].Substring(0, ranges[k].Length - 1);
                    List<int> result = RangeToList(ranges[k], max);
                    foreach (var alg in result)
                    {
                        algs.Add(alg);
                    }
                }
                reader.Close();
                return algs;
            }
            reader.Close();
            return RangeToList(token, max);
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

        public void AddSetName(string name, string posList)
        {
            MakeList(posList, int.MaxValue);        //exception will be thrown if posList is invalid
            StreamWriter writer = new StreamWriter(Name, true);
            writer.Write(name + " ");
            writer.WriteLine(posList);
            writer.Close();

        }

    }
}
