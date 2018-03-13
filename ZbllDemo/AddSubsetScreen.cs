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
        public AddSubsetScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                SubsetFile file = new SubsetFile(Tools.shortcutPath);
                file.MakeList(AlgListBox.Text, int.MaxValue);
                file.AddSubset(NameBox.Text, AlgListBox.Text);
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
