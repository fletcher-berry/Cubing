using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZbllDemo.SetParsing
{
    public class SetParser
    {
        public static List<int> Parse(string setStr, Dictionary<string, List<int>> nameMap, List<CustomSubset> customSubsets, int max)
        {
            if (setStr.Trim().Length == 0)
                throw new SetParseException("No input provided.  Please enter a subset in the 'Algs' box");
            var currStr = setStr.Trim();
            List<int> algNumbers = new List<int>();
            Operator lastOperator = Operator.Union;
            var expectedToken = TokenType.Value;
            Stack<ParsingContext> stack = new Stack<ParsingContext>();

            while (currStr.Length != 0)
            {
                if (expectedToken == TokenType.Value)
                {
                    if (currStr[0].Equals('('))
                    {
                        var context = new ParsingContext(algNumbers, lastOperator);
                        stack.Push(context);
                        currStr = currStr.Substring(1);
                    }
                    else if (char.IsDigit(currStr[0]))
                    {
                        var endIdx = 1;
                        while (endIdx < currStr.Length)
                        {
                            if (!char.IsDigit(currStr[endIdx]) && currStr[endIdx] != '-')
                                break;
                            endIdx++;
                        }
                        try
                        {
                            List<int> fromRange = SubsetTools.GetListFromRange(currStr.Substring(0, endIdx), max);
                            algNumbers = Combine(algNumbers, fromRange, lastOperator);
                            expectedToken = TokenType.Operator;
                            currStr = currStr.Substring(endIdx);
                        }
                        catch (ArgumentException)
                        {
                            throw new SetParseException($"Invalid token: {currStr.Substring(0, endIdx)}");
                        }
                    }
                    else if (char.IsLetter(currStr[0]))
                    {
                        var endIdx = 1;
                        while (endIdx < currStr.Length)
                        {
                            if (!char.IsLetter(currStr[endIdx]) && !char.IsDigit(currStr[endIdx]) && currStr[endIdx] != ' ' && currStr[endIdx] != '-')
                                break;
                            endIdx++;
                        }
                        try
                        {
                            //MessageBox.Show("currStr");
                            var setName = currStr.Substring(0, endIdx).Trim(); 
                            if (nameMap.ContainsKey(setName))  //predefined subset name
                            {
                                List<int> fromRange = nameMap[setName];
                                algNumbers = Combine(algNumbers, fromRange, lastOperator);
                                expectedToken = TokenType.Operator;
                                currStr = currStr.Substring(endIdx);
                            }
                            else        // custom subset name
                            {
                                //MessageBox.Show("custom");
                                var subset = customSubsets.First(x => x.Name.Equals(setName));
                                currStr = currStr.Replace(setName, $"({subset.RangeStr})");
                            }
                        }
                        catch (Exception)
                        {
                            throw new SetParseException($"Invalid set name: {currStr.Substring(0, endIdx)}");
                        }
                    }
                    else
                        throw new SetParseException($"Unexpected character: {currStr[0]}");
                }
                else
                {
                    if(currStr[0] == ',' || currStr[0] == '+' || currStr[0] == '|')
                    {
                        lastOperator = Operator.Union;
                        currStr = currStr.Substring(1);
                        expectedToken = TokenType.Value;
                    }
                    else if(currStr[0] == '*' || currStr[0] == '&')
                    {
                        lastOperator = Operator.Intersection;
                        currStr = currStr.Substring(1);
                        expectedToken = TokenType.Value;
                    }
                    else if(currStr[0] == ')')
                    {
                        if (stack.Count == 0)
                            throw new SetParseException("Unexpected ')'");
                        var lastContext = stack.Pop();
                        lastOperator = lastContext.prevOperator;
                        algNumbers = Combine(algNumbers, lastContext.PrevValue, lastOperator);
                        currStr = currStr.Substring(1);
                    }
                    else
                    {
                        if(char.IsDigit(currStr[0]))
                        {
                            var endIdx = 1;
                            while (endIdx < currStr.Length && endIdx < 9)
                            {
                                if (!char.IsDigit(currStr[endIdx]))
                                    break;
                                endIdx++;
                            }
                            throw new SetParseException($"unexpected number: {int.Parse(currStr.Substring(0, endIdx))}");
                        }
                        else if(char.IsLetter(currStr[0]))
                        {
                            var endIdx = 1;
                            while (endIdx < currStr.Length)
                            {
                                if (!char.IsDigit(currStr[endIdx]))
                                    break;
                                endIdx++;
                            }
                            throw new SetParseException($"unexpected value: {currStr.Substring(0, endIdx)}");
                        }
                        else
                        {
                            throw new SetParseException($"unexpected character: {currStr[0]}");
                        }
                    }

                }
                currStr = currStr.TrimStart();
            }
            if (expectedToken == TokenType.Value)
                throw new SetParseException("Missing value at end of expression");
            if (stack.Count != 0)
                throw new SetParseException("unexpected end of input.  Are you missing a ')'?");
            return algNumbers;
        }

        private static List<int> Combine(List<int> first, List<int> second, Operator op)
        {
            if (op == Operator.Union)
                return first.Union(second).ToList();
            else
                return first.Intersect(second).ToList();
        }


    }
}
