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
using Cubing.ConstructPosition;

namespace ZbllDemo
{
    public partial class MainScreen : Form, ISetUpPositionParent
    {
        AlgSet Set;
        ICube Cube;
        int PosNum;
        SubsetFile SubsetFile;

        const string subsetFilePath = @"keys.txt";

        public const double CubeSize = .9;
        public const double PreviewCubeSize = 0.6;

        public MainScreen()
        {
            SubsetFile = new SubsetFile(subsetFilePath);
            InitializeComponent();
            Info.MainForm = this;
            StartPosition = FormStartPosition.CenterScreen;
            Update();
            //cube = new ZbllCube(PreviewCubeSize);
            foreach (var set1 in Enum.GetValues(typeof(AlgSet)).Cast<AlgSet>())
            {
                if(set1 != AlgSet.All)
                    AlgSetSelector.Items.Add(set1);
            }
            AlgSetSelector.SelectedItem = AlgSet.ZBLL;
            Set = AlgSet.ZBLL;
            Cube = Info.GetScreenCube(Set);
            PosNum = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void SampleCubeView_Paint(object sender, PaintEventArgs e)
        {
            Cube.Paint(e, PreviewCubeSize);
            Update();
        }

        public void SetUpPosition()
        {
            int num = 0;
            string text = PositionBox.Text;
            //PositionBox.Clear();
            bool success = int.TryParse(text, out num);
            if (success == true && num >= 0 && num < Cube.GetNumPositions())
            {
                Cube.SetUpPosition(num);
                SampleCubeView.Refresh();
                PosNum = num;
                AlgLabel.Visible = true;
                AlgorithmBox.Visible = true;
                ChangeAlgorithmButton.Visible = true;
                AlgLabel.Text = num.ToString();

                AlgFile file = new AlgFile(Info.GetAlgFileName(Set), AlgFileMode.Open, AlgFileAccess.Read);
                Algorithm alg = file.Read(num);
                AlgorithmBox.Text = alg.ToString();
                file.Close();
            }
            else
                MessageBox.Show("Invalid input.  Input must be an integer between 0 and " + Cube.GetNumPositions() + ".", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void SetupPositionButton_Click(object sender, EventArgs e)
        {
            SetUpPosition();
        }

        private void RunRandomButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> algs = SubsetFile.MakeList(RangeBox.Text, Info.GetRunnerCube(Set).GetNumPositions());
                algs = algs.Distinct().ToList();
                var screen = new RunnerScreen(new AlgRunner(Info.GetRunnerCube(Set), new RandomAlgGenerator(algs), new AlgsFromFileStored(Info.GetAlgFileName(Set))));
                screen.KeyPreview = true;
                screen.Show();
                this.Hide();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "invalid range", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunFixedButton_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(RunFixedBox.Text, out int numCases))
            {
                MessageBox.Show("Number of cases is not an integer.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<int> algs = SubsetFile.MakeList(RangeBox.Text, Info.GetRunnerCube(Set).GetNumPositions());
            algs = algs.Distinct().ToList();
            var screen = new RunnerScreen(new AlgRunner(Info.GetRunnerCube(Set), new RandomFixedGenerator(algs, numCases), new AlgsFromFileStored(Info.GetAlgFileName(Set))));
            screen.KeyPreview = true;
            screen.Show();
            this.Hide();
        }

        public void Reset()
        {
            Cube = Info.GetScreenCube(Set);
            PositionBox.Clear();
            PosNum = -1;
            AlgLabel.Visible = false;
            AlgorithmBox.Visible = false;
            ChangeAlgorithmButton.Visible = false;
            
            //  RangeBox.Clear();
            Update();
        }

        private void SingleCycleButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> algs = SubsetFile.MakeList(RangeBox.Text, Info.GetRunnerCube(Set).GetNumPositions());
                algs = algs.Distinct().ToList();
                //var screen = new RunnerScreen(new AlgRunner(new ZbllCube(CubeSize), new SingleCycleGenerator(algs), new AlgsFromFile(new AlgFile("zbll.alg", AlgFileMode.Open, AlgFileAccess.Read))));
                var screen = new RunnerScreen(new AlgRunner(Info.GetRunnerCube(Set), new SingleCycleGenerator(algs), new AlgsFromFileStored(Info.GetAlgFileName(Set))));
                screen.KeyPreview = true;
                screen.Show();
                this.Hide();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "invalid range", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeAlgorithmButton_Click(object sender, EventArgs e)
        {
            Algorithm alg = null;
            try
            {
                alg = new Algorithm(AlgorithmBox.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Not a valid algorithm.", "invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var file = new AlgFile(Info.GetAlgFileName(Set), AlgFileMode.Open, AlgFileAccess.ReadWrite);
            file.Write(PosNum, alg);
            file.Close();
            MessageBox.Show("Algorithm changed.", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AlgSetSelector_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void AlgSetSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            Set = (AlgSet)AlgSetSelector.SelectedItem;
            Cube = Info.GetScreenCube(Set);
            Reset();
            Refresh();
        }

        private void AddSubsetButton_Click(object sender, EventArgs e)
        {
            var screen = new AddSubsetScreen();
            screen.Show();
        }

        private void ViewSubsetsButton_Click(object sender, EventArgs e)
        {
            var screen = new SubsetListScreen();
            screen.Show();
        }

        public void PosNumReceived(AlgSet set, int value)
        {
            Set = set;
            AlgSetSelector.SelectedItem = set;
            PosNum = value;
            PositionBox.Text = value.ToString();
            SetUpPosition();
        }

        private void ConstructPostionButton_Click(object sender, EventArgs e)
        {
            var form = new SetupForm(this);
            form.Show();
        }

        
    }
}
