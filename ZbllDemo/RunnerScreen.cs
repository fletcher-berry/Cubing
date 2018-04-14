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
    public partial class RunnerScreen : Form
    {
        public AlgRunner Runner;

        private DateTime _spacePressed;
        private const int _MillisBetweenSpaces = 400;

        const double CubeSize = .9;


        public RunnerScreen(AlgRunner runner)
        {
            Runner = runner;
            Runner.GetCube().SetUpPosition(Runner.GetCurrentPosNum());
            InitializeComponent();
            AlgLabel.Text = Runner.GetAlgClient().GetAlg(Runner.GetCurrentPosNum());
            NumberLabel.Text = Runner.GetCurrentPosNum().ToString();
            StartPosition = FormStartPosition.CenterScreen;
            AlgLabel.Hide();
            NumberLabel.Hide();
            _spacePressed = DateTime.Now;
        }

        private void RunnerScreen_Load(object sender, EventArgs e)
        {

        }

        

        private void RunnerScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if(c == ' ' && DateTime.Now - _spacePressed > new TimeSpan(0, 0, 0, 0, _MillisBetweenSpaces))
            {
                _spacePressed = DateTime.Now;
                Runner.NextPosition();
                int posNum = Runner.GetCurrentPosNum();
                if (posNum == -1)
                {
                    DateTime end = DateTime.Now;
                    TimeSpan diff = end - Runner.GetStartTime();
                    TimeSpan perAlg = new TimeSpan(diff.Ticks / Runner.GetNumPositions());
                    string time = diff.ToString(@"hh\:mm\:ss\.ff");
                    while (!((time[0] > '0' && time[0] <= '9') || time[0] == '.'))
                    {
                        time = time.Substring(1);
                    }
                    string timePerAlg = perAlg.ToString(@"hh\:mm\:ss\.ff");
                    while (!((timePerAlg[0] > '0' && timePerAlg[0] <= '9') || timePerAlg[0] == '.'))
                    {
                        timePerAlg = timePerAlg.Substring(1);
                    }
                    MessageBox.Show("Time: " + time + "\nAlgs: " + Runner.GetNumPositions() + "\nTime per alg: " + timePerAlg,
                        "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Info.MainForm.Reset();
                    this.Close();
                }
                else
                {
                    Runner.GetCube().SetUpPosition(posNum);
                    AlgLabel.Text = Runner.GetAlgClient().GetAlg(Runner.GetCurrentPosNum());
                    NumberLabel.Text = Runner.GetCurrentPosNum().ToString();
                    Refresh();
                }
            }
            else if(c == 'z')
            {
                
                AlgLabel.Visible = !AlgLabel.Visible;
                
                NumberLabel.Visible = !NumberLabel.Visible;
            }
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Info.MainForm.Reset();
            this.Close();
        }

        private void RunnerScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                
        }

        private void CubePicture_Paint(object sender, PaintEventArgs e)
        {
            Runner.GetCube().Paint(e, CubeSize);
        }

        private void RunnerScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Runner.AlgClient.Terminate();
            Info.MainForm.Show();
        }
    }
}
