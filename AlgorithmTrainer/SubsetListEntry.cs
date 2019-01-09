using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cubing;

namespace AlgorithmTrainer
{
    public partial class SubsetListEntry : UserControl
    {
        CustomSubset CustomSubset;
        CustomSubsetFile File;
        Dictionary<string, List<int>> NameMap;

        public SubsetListEntry(CustomSubset customSubset, CustomSubsetFile file, Dictionary<string, List<int>> nameMap)
        {
            InitializeComponent();
            CustomSubset = customSubset;
            File = file;
            NameMap = nameMap;
            SubsetNameLabel.Text = CustomSubset.Name;
            RangeListBox.Text = customSubset.RangeStr;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var nameMap = SubsetTools.GetXmlSubsetFile().GetNameMap(CustomSubset.AlgSet);
                var rangesWithSubsets = RangeListBox.Text;
                SubsetTools.ValidateAlgListInput(rangesWithSubsets, nameMap, Info.GetNumPositionsInSet(CustomSubset.AlgSet));
                CustomSubset.RangeStr = rangesWithSubsets;
                File.SaveSubset(CustomSubset);
                MessageBox.Show("subset saved", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show($"Are you sure you want to delete subset {CustomSubset.Name}?", "confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (response == DialogResult.No)
                return;
            try
            {
                File.DeleteSubset(CustomSubset);
                this.Visible = false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            var screen = new SetInfoScreen(CustomSubset.AlgSet, CustomSubset.RangeStr, SubsetTools.GetXmlSubsetFile().GetNameMap(CustomSubset.AlgSet), setName: CustomSubset.Name);
            screen.Show();
            this.ParentForm.Close();
        }


    }
}
