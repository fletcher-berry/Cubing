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

namespace ZbllDemo
{
    public partial class SubsetListScreen : Form
    {
        private TableLayoutPanel Panel;
        List<Subset> Subsets;
        SubsetFile File;

        const int HeightPerRow = 90;

        public SubsetListScreen()
        {
            InitializeComponent();

            Panel = new TableLayoutPanel();
            Panel = new TableLayoutPanel { Width = 500 };
            Panel.ColumnCount = 2;
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            Panel.TabIndex = 0;
            Panel.Location = new Point(50, 80);
            Panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            File = new SubsetFile(Tools.shortcutPath);
            Subsets = File.GetSubsets();
            Panel.RowCount = Subsets.Count;
            Panel.Height = Panel.RowCount * HeightPerRow;
            for(int k = 0; k < Subsets.Count; k++)
            {
                Panel.RowStyles.Add(new RowStyle(SizeType.Absolute, HeightPerRow));
                var set = Subsets[k];
                Panel.Controls.Add(new TextBox()
                {
                    Text = set.Name,
                    Font = new Font(FontFamily.GenericSansSerif, 12),
                    Width = 70
                },0, k);
                Panel.Controls.Add(new RichTextBox
                {
                    Text = set.SubsetList,
                    Font = new Font(FontFamily.GenericSansSerif, 12),
                    Width = 400
                }, 1, k);
            }
            


            Panel.Height = Panel.RowCount * HeightPerRow;
            this.Controls.Add(Panel);
            this.AutoScroll = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var newSubsets = new List<Subset>();
            for(int k = 0; k < Panel.RowCount; k++)
            {
                newSubsets.Add(new Subset { Name = Panel.GetControlFromPosition(0, k).Text, SubsetList = Panel.GetControlFromPosition(1, k).Text });
            }

            try
            {
                File.SaveSubsets(newSubsets);
                MessageBox.Show("Subsets saved", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(ArgumentException)
            {
                MessageBox.Show("A subset is not in correct form", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
