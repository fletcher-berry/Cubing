using Cubing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ZbllDemo.SetParsing;

namespace ZbllDemo
{
    public class SubsetTools
    {
        /// <summary>
        /// Gets a list of alg numbers given a string representation of a single range.  Does not allow subset names.
        /// </summary>
        /// <param name="range"></param>
        /// <param name="max"></param>
        /// <exception cref="ArgumentException">thrown if the input cannot be parsed as a range, or if the range contains a value larger than max.</exception>
        /// <returns></returns>
        public static List<int> GetListFromRange(string range, int max)
        {
            var nums = new List<int>();
            string[] ends = range.Split('-');
            if (ends.Length == 1)       // single number
            {
                int num = 0;
                bool success = int.TryParse(ends[0], out num);
                if (!success || num < 0 || num >= max)
                    throw new ArgumentException("invalid alg number: " + range);
                nums.Add(num);
            }
            else if (ends.Length == 2)  // range of numbers
            {
                int low = 0;
                int high = 0;
                bool success = int.TryParse(ends[0], out low) && int.TryParse(ends[1], out high);
                if (!success || high <= low || low < 0 || high > max)
                    throw new ArgumentException("invalid range: " + range);
                for (int k = low; k < high; k++)
                {
                    nums.Add(k);
                }
            }
            else
                throw new ArgumentException("invalid string " + range);
            return nums;

        }

        /// <summary>
        /// Gets a list of alg numbers given input text.  Does not allow subset names.
        /// </summary>
        /// <param name="listText">the input to convert to a list of alg numbers</param>
        /// <param name="max">The maximum number allowed in the range</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">thrown if a range is invalid</exception>
        public static List<int> GetListFromRanges(string ranges, int max)
        {
            List<int> nums = new List<int>();
            ranges = ranges.Trim();
            string[] ranges1 = ranges.Split(',');
            foreach (string range in ranges1)
            {
                var trimmedRange = range.Trim();
                if (trimmedRange.Equals(""))
                    continue;
                List<int> newNums = GetListFromRange(trimmedRange, max);
                nums.AddRange(newNums);
            }
            return nums;
        }


        /// <summary>
        /// Gets a list of alg numbers given input text and a mapping from subset names to ranges
        /// </summary>
        /// <param name="listText">the input to convert to a list of alg numbers</param>
        /// <param name="nameMap">Mapping between subset names and set ranges</param>
        /// <param name="max">the highest number allowed in a range</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">thrown if a subset name does not exist in the name map</exception>
        public static List<int> MakeAlgNumList(string listText, Dictionary<string, string> nameMap, int max)
        {
            List<int> nums = new List<int>();
            listText = listText.Trim();
            string[] ranges = listText.Split(',');
            foreach (string range in ranges)
            {
                var trimmedRange = range.Trim();
                if (trimmedRange.Equals(""))
                    continue;
                List<int> newNums = new List<int>();
                if (char.IsDigit(trimmedRange[0]))  // range
                {
                    newNums = GetListFromRange(trimmedRange, max);
                }
                else    // name of alg set
                {
                    try
                    {
                        newNums = MakeAlgNumList(nameMap[trimmedRange], null, max);
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("Invalid set: " + listText);
                    }
                }
                nums = nums.Union(newNums).ToList();
            }
            return nums;
        }

        /// <summary>
        /// converts a string with subset names into one with the corresponding number ranges and returns the result
        /// </summary>
        /// <param name="listText">the input to convert to a list of alg numbers</param>
        /// <param name="nameMap">Mapping between subset names and set ranges</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">thrown if a subset name does not exist in the name map</exception>
        public static string ConvertSetNames(string listText, Dictionary<string, string> nameMap)
        {
            var returned = "";
            listText = listText.Trim();
            string[] ranges = listText.Split(',');
            foreach (string range in ranges)
            {
                var trimmedRange = range.Trim();
                if (trimmedRange.Equals(""))
                    continue;
                if (char.IsDigit(trimmedRange[0]))  // range
                {
                    if (!returned.Equals(""))
                        returned += ", ";
                    returned += trimmedRange;
                }
                else    // name of alg set
                {
                    try
                    {
                        if (!returned.Equals(""))
                            returned += ", ";
                        returned += nameMap[trimmedRange];
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("Invalid set: " + listText);
                    }
                }
            }
            return returned;
        }

        /// <summary>
        /// Asserts that a position set string is valid
        /// </summary>
        /// <param name="rangeText"></param>
        /// <param name="max"></param>
        /// <exception cref="ArgumentException">Thrown if input is invalid</exception>
        public static void ValidateAlgListInput(string rangeText, int max)
        {
            rangeText = rangeText.Trim();
            string[] ranges = rangeText.Split(',');
            foreach (string range in ranges)
            {
                var trimmedRange = range.Trim();
                if (trimmedRange.Equals(""))
                    continue;

                GetListFromRange(trimmedRange, max);
            }
        }

        /// <summary>
        /// Asserts that a position set string is valid
        /// </summary>
        /// <param name="rangeText"></param>
        /// <exception cref="SetParseException">Thrown if input is invalid</exception>
        public static void ValidateAlgListInput(string rangeText, Dictionary<string, List<int>> nameMap, int max, List<CustomSubset> customSubsets= null)
        {
            if (customSubsets == null)
                customSubsets = new List<CustomSubset>();
            SetParser.Parse(rangeText, nameMap, customSubsets, max);
        }

        public static XmlSubsetFile GetXmlSubsetFile()
        {
            return new XmlSubsetFile("subsets.xml");
        }

        public static CustomSubsetFile GetCustomSubsetFile()
        {
            return new CustomSubsetFile("customSubsets.xml");
        }

    }
}
