using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Cubing;


namespace ZbllDemo
{
    /// <summary>
    /// Stores default subset definitions
    /// </summary>
    public class XmlSubsetFile
    {
        public string Name;

        public XmlSubsetFile(string name)
        {
            Name = name;
        }

        //public List<Subset> GetSubsetsForAlgSet(AlgSet set)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(@"subsets.xml");
        //    string xPath = "subsets/" + set.ToString();
        //    var node = doc.SelectSingleNode(xPath);
        //    var subsetNodes = node.SelectNodes("subset");
        //    var subsets = new List<Subset>();
        //    for(int k = 0; k < subsetNodes.Count; k++)
        //    {
        //        var subsetNode = subsetNodes[k];
        //        var subset = new Subset { Name = subsetNode.Attributes["name"].Value, SubsetList = subsetNode.InnerText };
        //        subsets.Add(subset);
        //    }
        //    return subsets;
        //}

        /// <summary>
        /// Gets all subset groups and subsets for the given alg set
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public List<SubsetGroup> GetSubsetGroupsForAlgSet(AlgSet set)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Name);
            string xPath = "subsets/" + set.ToString();
            var node = doc.SelectSingleNode(xPath);
            var groupNodes = node.SelectNodes("group");
            var groups = new List<SubsetGroup>();
            for (int k = 0; k < groupNodes.Count; k++)
            {
                var groupNode = groupNodes[k];
                var groupName = groupNode.Attributes["name"].Value;
                var subsets = new List<Subset>();
                var subsetNodes = groupNodes[k].SelectNodes(".//subset");
                for (int i = 0; i < subsetNodes.Count; i++)
                {
                    var subsetNode = subsetNodes[i];
                    var subset = new Subset { Name = subsetNode.Attributes["name"].Value, SubsetList = subsetNode.InnerText };
                    // check if subset is in a subgroup
                    var parent = subsetNode.SelectSingleNode("..");
                    if (parent.Name.Equals("subgroup"))
                        subset.Subgroup = parent.Attributes["name"].Value;
                    subsets.Add(subset);
                }
                var subgroupNames = new List<string>();
                var subgroupNodes = groupNode.SelectNodes("subgroup");
                for(var i = 0; i < subgroupNodes.Count; i++)
                {
                    subgroupNames.Add(subgroupNodes[i].Attributes["name"].Value);
                }

                var group = new SubsetGroup { Name = groupName, Subsets = subsets, SubgroupNames = subgroupNames };
                groups.Add(group);
            } 
            return groups;
        }

        /// <summary>
        /// Given a subset group, find the names of all subgroups in the group
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public List<string>GetSubsetSubgroupsForGroup(SubsetGroup group)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Name);
            string xPath = $"subsets/{group.AlgSet.ToString()}/group[@name='{group.Name}']/subgroup";
            var groupNames = new List<string>();
            var nodes = doc.SelectNodes(xPath);
            for(var k = 0; k < nodes.Count; k++)
            {
                groupNames.Add(nodes[k].Attributes["name"].Value);
            }
            return groupNames;
        }


        /// <summary>
        /// Gets a mapping of subset names to number lists for an alg set
        /// </summary>
        /// <param name="set"></param>
        public Dictionary<string, List<int>> GetNameMap(AlgSet set)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Name);
            string xPath = "subsets/" + set.ToString();
            var node = doc.SelectSingleNode(xPath);
            var subsetNodes = node.SelectNodes(".//subset");
            Dictionary<string, List<int>> names = new Dictionary<string, List<int>>();
            for(int k = 0; k < subsetNodes.Count; k++)
            {
                var subsetNode = subsetNodes[k];
                var key = subsetNode.Attributes["name"].Value;
                var rangeRext = subsetNode.InnerText;
                List<int> posNums = SubsetTools.GetListFromRanges(rangeRext, Info.GetNumPositionsInSet(set));
                names.Add(subsetNode.Attributes["name"].Value, posNums);
            }
            return names;
        }

    }
}
