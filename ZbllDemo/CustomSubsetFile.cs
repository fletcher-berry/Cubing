using Cubing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ZbllDemo
{
    /// <summary>
    /// Stores user defined subsets
    /// </summary>
    public class CustomSubsetFile
    {
        public string Name;


        public CustomSubsetFile(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets all subsets of an alg set
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public List<CustomSubset> GetSubsets(AlgSet set)
        {
            List<CustomSubset> sets = new List<CustomSubset>();
            var doc = new XmlDocument();
            doc.Load(Name);
            var xpath = $"subsets/{set.ToString()}/subset";
            var nodes = doc.SelectNodes(xpath);
            for(var k = 0; k < nodes.Count; k++)
            {
                var node = nodes[k];
                var name = node.Attributes["name"].Value.ToString();
                var subsetText = node.SelectSingleNode("rangeStr").InnerText;
                var customSet = new CustomSubset(name, subsetText, set);
                sets.Add(customSet);
            }
            return sets;
        }

        /// <summary>
        /// Adds a subset to the subset file
        /// </summary>
        /// <param name="newSet">The subset to add</param>
        /// <exception cref="ArgumentException">thrown if the subset name is a duplicate</exception>
        public void AddSubset(CustomSubset newSet)
        {
            var doc = new XmlDocument();
            doc.Load(Name);
            var xpath = $"subsets/{newSet.AlgSet.ToString()}";

            var parentNode = doc.SelectSingleNode(xpath);
            var checkDupXpath = $"/subset[@name='{newSet.Name}']";
            var matchingName = parentNode.SelectNodes(checkDupXpath);
            if (matchingName.Count > 0)
                throw new ArgumentException("Duplicate set name");

            for(var k = 0; k < newSet.Name.Length; k++)
            {
                if (!char.IsLetter(newSet.Name[k]) && !char.IsDigit(newSet.Name[k]) && newSet.Name[k] != ' ' && newSet.Name[k] != '-')
                    throw new ArgumentException($"invalid character in subset name: '{newSet.Name[k]}'");
            }
            if (!char.IsLetter(newSet.Name[0]))
                throw new ArgumentException("The first character of the subset name must be a letter.");
            if (newSet.Name[newSet.Name.Length - 1] == ' ')
                throw new ArgumentException("The last character of the subset name cannot ba a space");
            
            var newNode = doc.CreateNode(XmlNodeType.Element, "subset", null);
            var rangeStrNode = doc.CreateNode(XmlNodeType.Element, "rangeStr", null);
            rangeStrNode.InnerText = newSet.RangeStr;
            var nameAttribute = doc.CreateAttribute("name");
            nameAttribute.Value = newSet.Name;
            newNode.Attributes.Append(nameAttribute);
            newNode.AppendChild(rangeStrNode);
            parentNode.AppendChild(newNode);
            doc.Save(Name);
        }

        /// <summary>
        /// Updates an existing custom subset
        /// </summary>
        /// <param name="set">The subset ot update</param>
        /// <exception cref="ArgumentException"></exception>
        public void SaveSubset(CustomSubset set)
        {
            DeleteSubset(set);
            AddSubset(set);
        }

        /// <summary>
        /// deletes a custom subset from the file
        /// </summary>
        /// <param name="set">the subset to delete</param>
        /// <exception cref="ArgumentException">Thrown if the subset is not in the file or is a duplicate</exception>
        public void DeleteSubset(CustomSubset set)
        {
            var doc = new XmlDocument();
            doc.Load(Name);
            var xpath = $"subsets/{set.AlgSet.ToString()}";
            var parent = doc.SelectSingleNode(xpath);
            var toDelete = parent.SelectNodes($"subset[@name='{set.Name}']");
            if (toDelete.Count == 0)
                throw new ArgumentException("subset does not exist");
            if (toDelete.Count > 1)
                throw new ArgumentException("duplicate set names detected");
            var deletedNode = toDelete[0];
            parent.RemoveChild(deletedNode);
            doc.Save(Name);

        }


    }
}
