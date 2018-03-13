using Cubing;
using Cubing.ConstructPosition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyPractice
{
    public partial class MainScreen : SetUpPositionParent
    {
        public AlgSet Set;
        public ICube cube;

        int PosNum;

        public const double CubeSize = .9;
        public const double PreviewCubeSize = 0.75;

        public MainScreen()
        {
            InitializeComponent();
            Info.MainForm = this;
            StartPosition = FormStartPosition.CenterScreen;
            Update();
            foreach (var set1 in Enum.GetValues(typeof(AlgSet)).Cast<AlgSet>())
            {
                AlgSetSelector.Items.Add(set1);
            }
            AlgSetSelector.SelectedItem = AlgSet.All;
            Set = AlgSet.All;
            cube = Info.GetScreenCube(AlgSet.ZBLL);
            PosNum = -1;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SampleCubeView_Paint(object sender, PaintEventArgs e)
        {
            cube.Paint(e);
        }

        private void SetupPositionButton_Click(object sender, EventArgs e)
        {
            SetUpPosition();
        }

        public void SetUpPosition()
        {
            if (Set == AlgSet.All)
            {
                MessageBox.Show("You must select a single alg set", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int num = 0;
            string text = PositionBox.Text;
            bool success = int.TryParse(text, out num);
            if (success == true && num >= 0 && num < cube.GetNumPositions())
            {
                cube.SetUpPosition(num);
                PosNum = num;
                AlgLabel.Visible = true;
                AlgorithmBox.Visible = true;
                ChangeAlgorithmButton.Visible = true;
                AlgLabel.Text = num.ToString();
                AlgFile file = new AlgFile(Info.GetAlgFileName(Set), AlgFileMode.Open, AlgFileAccess.Read);
                Algorithm alg = file.Read(num);
                AlgorithmBox.Text = alg.ToString();
                file.Close();
                SampleCubeView.Refresh();
            }
            else
                MessageBox.Show("Invalid input.  Input must be an integer between 0 and " + cube.GetNumPositions() + ".", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddPositionButton_Click(object sender, EventArgs e)
        {
            if (Set == AlgSet.All)
            {
                MessageBox.Show("You must select a single alg set", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<int> days = new List<int>();
            int posNum = 0;
            try
            {
                days = Info.MakeList(DaysBox.Text, cube.GetNumPositions());
                posNum = int.Parse(PositionBox.Text);
                if (posNum >= cube.GetNumPositions())
                    throw new ArgumentException("Position number out of range: " + posNum);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show("No position number selected" + ex.Message + ex.StackTrace, "invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StreamWriter writer = new StreamWriter("forgottenAlgs.txt", true);
            DateTime today = DateTime.Now;
            writer.Write("{0} {1} {2} {3} {4} {5}", Set.ToString(), posNum, today.Year, today.Month, today.Day, "0 ");
            foreach(var day in days)
            {
                if(day != 0)
                    writer.Write(day + " ");
            }
            writer.WriteLine();
            writer.Close();
            PositionBox.Clear();
            DaysBox.Clear();
            MessageBox.Show("Position added", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Reset()
        {
            cube = new ZbllCube(PreviewCubeSize);
            PositionBox.Clear();
            PosNum = -1;
            AlgLabel.Visible = false;
            AlgorithmBox.Visible = false;
            ChangeAlgorithmButton.Visible = false;
            Update();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (Set != AlgSet.All)
                RunSingleSet();
            else
                RunAllSets();
        }

        private void RunSingleSet()
        {
            List<int> algs = new List<int>();
            StreamReader reader = new StreamReader("forgottenAlgs.txt");
            List<string> lines = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
            reader.Close();

            StreamWriter writer = new StreamWriter("forgottenAlgs.txt", false);
            foreach (string line1 in lines)
            {
                bool foundFuture = false;
                DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                string[] tokens = line1.Split(' ');
                AlgSet set1 = (AlgSet)Enum.Parse(typeof(AlgSet), tokens[0]);
                int alg = int.Parse(tokens[1]);
                int year = int.Parse(tokens[2]);
                int month = int.Parse(tokens[3]);
                int day = int.Parse(tokens[4]);
                DateTime entered = new DateTime(year, month, day);
                for (int k = 5; k < tokens.Length; k++)
                {
                    int value = 0;
                    if (!int.TryParse(tokens[k], out value))
                        continue;
                    DateTime d = entered + TimeSpan.FromDays(int.Parse(tokens[k]));
                    if (d.Equals(today) && Set == set1)
                    {
                        algs.Add(alg);
                        foundFuture = true;
                    }
                    if (d >= today)
                    {
                        foundFuture = true;
                    }
                }
                if (foundFuture)
                {
                    writer.WriteLine(line1);
                }
            }
            writer.Close();

            if (algs.Count == 0)
            {
                MessageBox.Show("Thre are no algs.", "No algs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            RunnerScreen screen;

            screen = new RunnerScreen(new AlgRunner(Info.GetRunnerCube(Set), new SingleCycleGenerator(algs), new AlgsFromFileStored(Info.GetAlgFileName(Set))));

            screen.KeyPreview = true;
            screen.Show();
            this.Hide();
        }

        public void RunAllSets()
        {
            Dictionary<AlgSet, List<int>> algs = new Dictionary<AlgSet, List<int>>()
            {
                {AlgSet.ZBLL, new List<int>() },
                {AlgSet.OLL, new List<int>() },
                {AlgSet.OLLCP, new List<int>() },
                {AlgSet.ELLCP, new List<int>() },
                {AlgSet.VLS, new List<int>() },
                {AlgSet.OneLookLL, new List<int>() }
            };
            
            StreamReader reader = new StreamReader("forgottenAlgs.txt");
            List<string> lines = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
            reader.Close();

            StreamWriter writer = new StreamWriter("forgottenAlgs.txt", false);
            foreach (string line1 in lines)
            {
                bool foundFuture = false;
                DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                string[] tokens = line1.Split(' ');
                AlgSet set1 = (AlgSet)Enum.Parse(typeof(AlgSet), tokens[0]);
                int alg = int.Parse(tokens[1]);
                int year = int.Parse(tokens[2]);
                int month = int.Parse(tokens[3]);
                int day = int.Parse(tokens[4]);
                DateTime entered = new DateTime(year, month, day);
                for (int k = 5; k < tokens.Length; k++)
                {
                    int value = 0;
                    if (!int.TryParse(tokens[k], out value))
                        continue;
                    DateTime d = entered + TimeSpan.FromDays(int.Parse(tokens[k]));
                    if (d.Equals(today))
                    {
                        algs[set1].Add(alg);
                        foundFuture = true;
                    }
                    if (d >= today)
                    {
                        foundFuture = true;
                    }
                }
                if (foundFuture)
                {
                    writer.WriteLine(line1);
                }
            }
            writer.Close();

            RunnerScreen screen;
            screen = new RunnerScreen(new AlgRunner(Info.GetRunnerCube(AlgSet.ZBLL), new SingleCycleGenerator(algs[AlgSet.ZBLL]), new AlgsFromFileStored(Info.GetAlgFileName(AlgSet.ZBLL))), algs);
            screen.KeyPreview = true;
            screen.Show();
            this.Hide();
        }

        public override void PosNumReceived(AlgSet set, int posNum)
        {
            Set = set;
            AlgSetSelector.SelectedItem = set;
            PosNum = posNum;
            PositionBox.Text = posNum.ToString();
            SetUpPosition();
        }

        private void AlgSetSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            Set = (AlgSet)AlgSetSelector.SelectedItem;
            if(Set != AlgSet.All)
                cube = Info.GetScreenCube(Set);
            //Reset();
            Refresh();
        }

        private void ConstructPositionButton_Click(object sender, EventArgs e)
        {
            var form = new SetupForm(this);
            form.Show();
        }
    }
}
