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
    public partial class CubeRowControl : UserControl
    {
        
        public ICube Cube1;
        public ICube Cube2;
        public ICube Cube3;
        public ICube Cube4;
        public ICube Cube5;
        public ICube Cube6;

        private List<PictureBox> pictureBoxes;

        const double SizeRatio = 0.3;
        const int OffsetX = -30;
        const int OffsetY = -13;
        const int StickerSize = 14;

        public CubeRowControl(List<ICube> cubes)
        {
            InitializeComponent();
            Cube1 = cubes[0];
            Cube2 = cubes[1];
            Cube3 = cubes[2];
            Cube4 = cubes[3];
            Cube5 = cubes[4];
            Cube6 = cubes[5];

            cubes = new List<ICube> { Cube1, Cube2, Cube3, Cube4, Cube5, Cube6 };
            pictureBoxes = new List<PictureBox> { CubeBox1, CubeBox2, CubeBox3, CubeBox4, CubeBox5, CubeBox6 };
            for(int k = 0; k < cubes.Count; k++)
            {
                pictureBoxes[k].Paint += delegate (object sender, PaintEventArgs e)
                {
                    int idx = 0;
                    for(int i = 0; i < pictureBoxes.Count; i++)
                    {
                        if(sender == pictureBoxes[i])
                        {
                            idx = i;
                            //MessageBox.Show(cubes[idx].ToString());
                            break;
                        }
                    }
                    if(cubes[idx] != null)
                    {
                        cubes[idx].Paint2D(e.Graphics, SizeRatio, OffsetX, OffsetY, StickerSize);
                    }
                };
            }
        }
    }
}
