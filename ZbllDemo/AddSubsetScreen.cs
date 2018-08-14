using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cubing;

namespace ZbllDemo
{
    public partial class AddSubsetScreen : Form
    {
        public AlgSet Set;

        public AddSubsetScreen(AlgSet set, string text)
        {
            InitializeComponent();
            Set = set;
            AlgListBox.Text = text;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                var setName = NameBox.Text;
                // make sure set name is not same as a predefined set name
                var defaultFile = new XmlSubsetFile("subsets.xml");
                var nameMap = defaultFile.GetNameMap(Set);
                if(nameMap.ContainsKey(setName))
                {
                    throw new ArgumentException($"Subset name '{setName}' already exists");
                }
                CustomSubsetFile file = new CustomSubsetFile("customSubsets.xml");
                var rawText = AlgListBox.Text;
                var newSet = new CustomSubset(setName, rawText, Set);         
                SubsetTools.ValidateAlgListInput(rawText, nameMap, Info.GetNumPositionsInSet(Set));
                file.AddSubset(newSet);
                MessageBox.Show("subset added", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
