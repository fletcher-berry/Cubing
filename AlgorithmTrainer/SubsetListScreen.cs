using Cubing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmTrainer
{
    public partial class SubsetListScreen : Form
    {
        CustomSubsetFile File;
        AlgSet Set;

        const int HeightPerRow = 110;

        public SubsetListScreen(AlgSet set)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            Set = set;
            int startX = 50;
            int startY = 80;
            int currY = startY;


            File = new CustomSubsetFile("customSubsets.xml");
            var subsets = File.GetSubsets(Set);

            var originalFile = SubsetTools.GetXmlSubsetFile();
            var nameMap = originalFile.GetNameMap(Set);

            for(int k = 0; k < subsets.Count; k++)
            {
                var control = new SubsetListEntry(subsets[k], File, nameMap) { Location = new Point(startX, currY) };
                currY += HeightPerRow;
                this.Controls.Add(control);
            }
            this.AutoScroll = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
