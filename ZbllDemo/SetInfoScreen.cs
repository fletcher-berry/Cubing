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
using ZbllDemo.SetParsing;

namespace ZbllDemo
{
    public partial class SetInfoScreen : Form
    {
        public AlgSet Set;
        public string SetName;
        List<ICube> Cubes;


        List<CubeRowControl> CubeRows;

        const int PixelsBetweenControls = 135;


        public SetInfoScreen(AlgSet set, string rangeList, Dictionary<string, List<int>> nameMap, List<CustomSubset> customSubsets = null, string setName = null)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            CubeRows = new List<CubeRowControl>();
            Set = set;
            RangeBox.Text = rangeList;
            if(setName != null)
            {
                NameLabel.Text = setName;
                NameLabel.Visible = true;
            }

            List<int> posNums = SetParser.Parse(rangeList, nameMap, customSubsets?? new List<CustomSubset>(), Info.GetNumPositionsInSet(set));
            Cubes = posNums.ConvertAll(num =>
            {
                var cube = Info.GetCube(set);
                cube.SetUpPosition(num);
                return cube;
            }).ToList();
            
            int startX = 40;
            int startY = 100;
            int currY = startY;
            List<ICube> currRowCubes = new List<ICube>();
            for (int k = 0; k < Cubes.Count; k++)
            {
                currRowCubes.Add(Cubes[k]);

                if(k % 6 == 5)
                {
                    CubeRows.Add(new CubeRowControl(currRowCubes){ Location = new Point(startX, currY)});
                    currY += PixelsBetweenControls;
                    currRowCubes.Clear();
                }
                else if(k == Cubes.Count - 1)
                {
                    while (currRowCubes.Count < 6)
                        currRowCubes.Add(null);
                    CubeRows.Add(new CubeRowControl(currRowCubes) { Location = new Point(startX, currY) });
                }

            }
            
            foreach (var control in CubeRows)
            {
                this.Controls.Add(control);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
