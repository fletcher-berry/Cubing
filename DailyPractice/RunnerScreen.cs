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

namespace DailyPractice
{
    public partial class RunnerScreen : Form
    {
        public AlgRunner Runner;
        public DateTime StartTime;
        public int TotalAlgs;

        private DateTime _spacePressed;
        private const int _MillisBetweenSpaces = 400;
        private Dictionary<AlgSet, List<int>> Algs;
        private AlgSet set;


        public RunnerScreen(AlgRunner runner, Dictionary<AlgSet, List<int>> algs = null)
        {
            TotalAlgs = 0;
            Runner = runner;
            StartTime = DateTime.Now;
            Runner.GetCube().SetUpPosition(Runner.GetCurrentPosNum());
            InitializeComponent();
            AlgLabel.Text = Runner.GetAlgClient().GetAlg(Runner.GetCurrentPosNum());
            NumberLabel.Text = Runner.GetCurrentPosNum().ToString();
            StartPosition = FormStartPosition.CenterScreen;
            if (algs != null)
            {
                set = AlgSet.ZBLL;
                Algs = algs;
                foreach (var set in Algs.Keys)
                {
                    TotalAlgs += Algs[set].Count;
                    //  MessageBox.Show(TotalAlgs.ToString());
                }
            }
            
                
            AlgLabel.Hide();
            NumberLabel.Hide();
        }


        private void CubePicture_Paint(object sender, PaintEventArgs e)
        {
            Runner.GetCube().Paint(e);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Info.MainForm.Reset();
            this.Close();
        }

        private void RunnerScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == ' ' && DateTime.Now - _spacePressed > new TimeSpan(0, 0, 0, 0, _MillisBetweenSpaces))
            {
                _spacePressed = DateTime.Now;
                Runner.NextPosition();
                int posNum = Runner.GetCurrentPosNum();
                if (posNum == -1)
                {
                    if(Algs != null)
                    {
                        NextAlgSet();
                        return;
                    }
                    // occurs when running only 1 alg set
                    DateTime end = DateTime.Now;
                    TimeSpan diff = end - Runner.GetStartTime();
                    TimeSpan perAlg = new TimeSpan();
                    try
                    {
                        perAlg = new TimeSpan(diff.Ticks / Runner.GetNumPositions());
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("there were no algs!", "results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
            else if (c == 'z')
            {
                AlgLabel.Visible = !AlgLabel.Visible;
                NumberLabel.Visible = !NumberLabel.Visible;
            }
        }

        private void NextAlgSet()
        {
            Runner.AlgClient.Terminate();
            NextAlgRunner();
            if(Runner == null)
            {
                // occurs when running all alg sets
                DateTime end = DateTime.Now;
                TimeSpan diff = end - StartTime;
                TimeSpan perAlg = new TimeSpan();
                try
                {
                    perAlg = new TimeSpan(diff.Ticks / TotalAlgs);
                }
                catch (DivideByZeroException)
                {
                    MessageBox.Show("there were no algs!", "results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                MessageBox.Show("Time: " + time + "\nAlgs: " + TotalAlgs + "\nTime per alg: " + timePerAlg,
                    "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Info.MainForm.Reset();
                this.Close();
            }
            else
            {
                int posNum = Runner.GetCurrentPosNum();
                if(posNum == -1)
                {
                    NextAlgSet();
                    return;
                }
                Runner.GetCube().SetUpPosition(posNum);
                AlgLabel.Text = Runner.GetAlgClient().GetAlg(Runner.GetCurrentPosNum());
                NumberLabel.Text = Runner.GetCurrentPosNum().ToString();
                Refresh();
            }
        }

        private void NextAlgRunner()
        {
            switch(set)
            {
                case AlgSet.ZBLL:
                    set = AlgSet.OLL;
                    break;
                case AlgSet.OLL:
                    set = AlgSet.OLLCP;
                    break;
                case AlgSet.OLLCP:
                    set = AlgSet.ELLCP;
                    break;
                case AlgSet.ELLCP:
                    set = AlgSet.VLS;
                    break;
                default:
                    set = AlgSet.All;
                    break;
            }
            if (set == AlgSet.All)
            {
                Runner = null;
                return;
            }
            else
            {
                Runner = new AlgRunner(Info.GetRunnerCube(set), new SingleCycleGenerator(Algs[set]), new AlgsFromFile(Info.GetAlgFileName(set)));
            }

        }

        private void RunnerScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Runner != null)
                Runner.AlgClient.Terminate();
            Info.MainForm.Show();

        }
    }
}

