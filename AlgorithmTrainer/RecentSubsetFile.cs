using Cubing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AlgorithmTrainer
{
    public class RecentSubsetFile
    {
        public string Name;

        const int NumSubsetsPerSet = 10;

        public RecentSubsetFile(string name)
        {
            Name = name;
        }

        public List<string> GetSubsets(AlgSet set)
        {
            var doc = new XmlDocument();
            doc.Load(Name);
            var xpath = $"subsets/{set.ToString()}/subset";
            var nodes = doc.SelectNodes(xpath);
            List<string> subsetStrings = new List<string>();
            for(var k = 0; k < nodes.Count; k++)
            {
                var node = nodes[k];
                subsetStrings.Add(node.Attributes["value"].Value);
            }
            return subsetStrings;
        }

        public void AddSet(string setText, AlgSet set)
        {
            var doc = new XmlDocument();
            doc.Load(Name);
            var parentNode = doc.SelectSingleNode($"subsets/{set.ToString()}"); 
            var node = parentNode.SelectSingleNode($"subset[@value = '{setText}']");
            var place = int.MaxValue;
            if(node != null)
            {
                place = int.Parse(node.Attributes["order"].Value);
                parentNode.RemoveChild(node);
            }
            var newNode = doc.CreateNode(XmlNodeType.Element, "subset", null);
            var orderAttribute = doc.CreateAttribute("order");
            orderAttribute.Value = "1";
            var valueAttribute = doc.CreateAttribute("value");
            valueAttribute.Value = setText;
            newNode.Attributes.Append(orderAttribute);
            newNode.Attributes.Append(valueAttribute);
            parentNode.InsertBefore(newNode, parentNode.FirstChild);
            var refNode = newNode.NextSibling;
            while(refNode != null)
            {
                int order = int.Parse(refNode.Attributes["order"].Value);
                if (order >= place)
                    break;
                if(order >= NumSubsetsPerSet)
                {
                    parentNode.RemoveChild(refNode);
                    break;
                }
                refNode.Attributes["order"].Value = (order + 1).ToString();
                refNode = refNode.NextSibling;
            }
            doc.Save(Name);
        }
    }
}
