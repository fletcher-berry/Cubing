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
    /// <summary>
    /// Runner screen that iterates through cobe positions and can show algotithms for those positions.
    /// This Form is designed to be easily used by client applications.
    /// </summary>
    public partial class DefaultRunnerScreen : Form
    {

        private static readonly string[] helpLabels = new string[]
        {
            "Press Spacebar to move to the next position. \nPress 'z' to show algorithm.",
            "Press Spacebar to move to the next position. \nPress 'z' to hide algorithm."
        };

        public AlgRunner Runner;

        private DateTime _spacePressed;
        
        /// <summary>
        /// the amount of time that must occur between space presses to go to the next position.  Used to avoid mistakes from accidental double space presses.
        /// </summary>
        private const int _MillisBetweenSpaces = 400;   

        const double CubeSize = .9;

        /// <summary>
        /// The action to be executed when the form is closed.
        /// </summary>
        private Action _callback;


        public DefaultRunnerScreen(AlgRunner runner, Action callback = null)
        {
            Runner = runner;
            Runner.GetCube().SetUpPosition(Runner.GetCurrentPosNum());
            InitializeComponent();
            AlgLabel.Text = Runner.GetAlgClient().GetAlg(Runner.GetCurrentPosNum());
            NumberLabel.Text = Runner.GetCurrentPosNum().ToString();
            StartPosition = FormStartPosition.CenterScreen;
            AlgLabel.Hide();
            NumberLabel.Hide();
            HelpLabel.Text = helpLabels[0];
            _spacePressed = DateTime.Now;
            _callback = callback;
        }

   

        private void RunnerScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if(c == ' ' && DateTime.Now - _spacePressed > new TimeSpan(0, 0, 0, 0, _MillisBetweenSpaces))
            {
                // go to the next position
                _spacePressed = DateTime.Now;
                Runner.NextPosition();
                int posNum = Runner.GetCurrentPosNum();
                if (posNum == -1)
                {
                    // show stats on the session
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
            else if(c == 'z' || c == 'Z')
            {
                // toggle showing the algorithm
                AlgLabel.Visible = !AlgLabel.Visible;
                NumberLabel.Visible = !NumberLabel.Visible;
                HelpLabel.Text = AlgLabel.Visible ? helpLabels[1] : helpLabels[0];
            }
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CubePicture_Paint(object sender, PaintEventArgs e)
        {
            Runner.GetCube().Paint(e, CubeSize);
        }

        private void RunnerScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Runner.AlgClient.Terminate();
            _callback?.Invoke();
        }
    }
}
