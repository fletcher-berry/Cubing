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
using ZbllDemo.SetParsing;

namespace ZbllDemo
{
    public partial class MainScreen : Form
    {
        AlgSet Set;     // the current algorithm set 
        ICube Cube;     // the current cube on teh screen
        int PosNum;     // the current position number on the screen
        SubsetFile SubsetFile;  
        XmlSubsetFile XmlSubsetFile;
        CustomSubsetFile CustomSubsetFile;
        RecentSubsetFile RecentSubsetFile;




        const string subsetFilePath = @"keys.txt";

        public const double CubeSize = .9;
        public const double PreviewCubeSize = 0.6;

        public MainScreen()
        {
            SubsetFile = new SubsetFile(subsetFilePath);
            XmlSubsetFile = new XmlSubsetFile("subsets.xml");
            CustomSubsetFile = new CustomSubsetFile("customSubsets.xml");
            RecentSubsetFile = new RecentSubsetFile("recentSubsets.xml");
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
            Cube = Info.GetCube(Set);
            PosNum = -1;
        }

        // paint the current cube
        private void SampleCubeView_Paint(object sender, PaintEventArgs e)
        {
            Cube.Paint(e, PreviewCubeSize);
            Update();
        }

        // set up the position given from PostitionBox
        public void SetUpPosition()
        {
            int num = 0;
            string text = PositionBox.Text;
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

                // get and display the algorithm
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

        // run an alg runner with a RandomAlgGenerator from the inputted subset
        private void RunRandomButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> algs = GetListFromAlgSet(Set, RangeBox.Text);
                algs = algs.Distinct().ToList();
                var screen = new DefaultRunnerScreen(new AlgRunner(Info.GetCube(Set), new RandomAlgGenerator(algs), new AlgsFromFileStored(Info.GetAlgFileName(Set))), RunnerScreenCallback);
                screen.KeyPreview = true;
                screen.Show();
                this.Hide();
                RecentSubsetFile.AddSet(RangeBox.Text.Trim(), Set);
                UpdateRecentSubsetSelector();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "invalid range", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // run an alg runner with a RandomFixedGenerator from the inputted subset
        private void RunFixedButton_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(RunFixedBox.Text, out int numCases))
            {
                MessageBox.Show("Number of cases is not an integer.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<int> algs = GetListFromAlgSet(Set, RangeBox.Text);
            algs = algs.Distinct().ToList();
            var screen = new DefaultRunnerScreen(new AlgRunner(Info.GetCube(Set), new RandomFixedGenerator(algs, numCases), new AlgsFromFileStored(Info.GetAlgFileName(Set))), RunnerScreenCallback);
            screen.KeyPreview = true;
            screen.Show();
            this.Hide();
            RecentSubsetFile.AddSet(RangeBox.Text.Trim(), Set);
        }

        // run an alg runner that runs through each case once from the inputted subset
        private void SingleCycleButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> algs = GetListFromAlgSet(Set, RangeBox.Text);
                algs = algs.Distinct().ToList();
                //var screen = new RunnerScreen(new AlgRunner(new ZbllCube(CubeSize), new SingleCycleGenerator(algs), new AlgsFromFile(new AlgFile("zbll.alg", AlgFileMode.Open, AlgFileAccess.Read))));
                var screen = new DefaultRunnerScreen(new AlgRunner(Info.GetCube(Set), new SingleCycleGenerator(algs), new AlgsFromFileStored(Info.GetAlgFileName(Set))), RunnerScreenCallback);
                screen.KeyPreview = true;
                screen.Show();
                this.Hide();
                RecentSubsetFile.AddSet(RangeBox.Text.Trim(), Set);
                UpdateRecentSubsetSelector();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("no cases selected");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "invalid range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.StackTrace);
            }
        }

        // run an alg runner each case once from the inputted subset in sequence
        private void RunSequentialButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> algs;
                // if only one number given, start at that number and don't end until the entire alg set is complete
                if (int.TryParse(RangeBox.Text, out int startNum))
                {
                    algs = SubsetTools.GetListFromRange($"{startNum}-{Info.GetCube(Set).GetNumPositions() - 1}", Info.GetNumPositionsInSet(Set));
                }
                else
                {
                    algs = GetListFromAlgSet(Set, RangeBox.Text);
                    algs = algs.Distinct().ToList();
                }
                
                //var screen = new RunnerScreen(new AlgRunner(new ZbllCube(CubeSize), new SingleCycleGenerator(algs), new AlgsFromFile(new AlgFile("zbll.alg", AlgFileMode.Open, AlgFileAccess.Read))));
                var screen = new DefaultRunnerScreen(new AlgRunner(Info.GetCube(Set), new SequentialGenerator(algs), new AlgsFromFileStored(Info.GetAlgFileName(Set))), RunnerScreenCallback);
                screen.KeyPreview = true;
                screen.Show();
                this.Hide();
                RecentSubsetFile.AddSet(RangeBox.Text.Trim(), Set);
                UpdateRecentSubsetSelector();
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("no cases selected");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "invalid range", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Reset()
        {
            Cube = Info.GetCube(Set);
            PositionBox.Clear();
            PosNum = -1;
            AlgLabel.Visible = false;
            AlgorithmBox.Visible = false;
            ChangeAlgorithmButton.Visible = false;
            Update();
        }

        // changes the algorithm for the current position
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

        private void AlgSetSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            Set = (AlgSet)AlgSetSelector.SelectedItem;
            Cube = Info.GetCube(Set);
            UpdateGroupSelector();
            UpdateCustomSubsetSelector();
            UpdateRecentSubsetSelector();
            RangeBox.Text = "";
            Reset();
            Refresh();
        }

        // When the alg set changes, show the groups of the new alg set
        private void UpdateGroupSelector()
        {
            GroupSelector.Items.Clear();
            var groups = XmlSubsetFile.GetSubsetGroupsForAlgSet(Set);
            foreach (var group in groups)
            {
                GroupSelector.Items.Add(group);
            }
            SubgroupSelector.Items.Clear();
            SubsetSelector.Items.Clear();
            GroupSelector.SelectedIndex = -1;
            SubgroupSelector.SelectedIndex = -1;
            SubsetSelector.SelectedIndex = -1;
        }

        private void UpdateCustomSubsetSelector()
        {
            CustomSubsetSelector.Items.Clear();
            var subsets = CustomSubsetFile.GetSubsets(Set);
            foreach (var subset in subsets)
            {
                CustomSubsetSelector.Items.Add(subset);
            }
        }

        private void UpdateRecentSubsetSelector()
        {
            RecentSubsetSelector.Items.Clear();
            var subsets = RecentSubsetFile.GetSubsets(Set);
            foreach (var subset in subsets)
            {
                RecentSubsetSelector.Items.Add(subset);
            }
        }

        // show the subsets of the new group
        private void GroupSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            if (GroupSelector.SelectedItem == null)
                return;
            var selectedGroup = (SubsetGroup)GroupSelector.SelectedItem;
            SubsetSelector.Items.Clear();
            SubgroupSelector.Items.Clear();
            foreach (var subset in selectedGroup.Subsets)
            {
                SubsetSelector.Items.Add(subset);
            }
            foreach(var subgroup in selectedGroup.SubgroupNames)
            {
                SubgroupSelector.Items.Add(subgroup);
            }
        }

        // update the subset seletor to only show subsets in the new subgroup
        private void SubgroupSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SubgroupSelector.SelectedItem == null)
                return;
            SubsetSelector.Items.Clear();
            foreach (var subset in ((SubsetGroup)GroupSelector.SelectedItem).Subsets)
            {
                if(subset.Subgroup.Equals(SubgroupSelector.SelectedItem.ToString()))
                    SubsetSelector.Items.Add(subset);
            }
        }

        // adds the selected subset to the input box
        private void ToRangeButton_Click(object sender, EventArgs e)
        {
            string setText;
            bool append;
            if(SubsetSelector.SelectedItem != null)
            {
                Subset selectedSubset = (Subset)SubsetSelector.SelectedItem;
                setText = selectedSubset.Name;
                append = true;
            }
            else if(CustomSubsetSelector.SelectedItem != null)
            {
                var selectedSubset = (CustomSubset)CustomSubsetSelector.SelectedItem;
                setText = selectedSubset.Name;
                append = true;
            }
            else
            {
                if (RecentSubsetSelector.SelectedItem == null)
                    return;
                setText = (string)RecentSubsetSelector.SelectedItem;
                append = false;
            }
            if(append)
            {
                bool addComma = true;
                if (RangeBox.Text.Trim().Equals(""))
                    addComma = false;
                var operators = new List<string> { ",", "+", "*", "|", "&", "(" };
                foreach (var str in operators)
                {
                    if (RangeBox.Text.Trim().EndsWith(str))
                        addComma = false;
                }
                if (addComma)
                    RangeBox.Text += ", ";
                RangeBox.Text += setText;
            }
            else
            {
                RangeBox.Text = setText.Trim();
            }

        }

        private void SubsetSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SubsetSelector.SelectedItem != null)
            {
                CustomSubsetSelector.SelectedItem = null;
                RecentSubsetSelector.SelectedItem = null;
            }
        }

        private void CustomSubsetSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CustomSubsetSelector.SelectedItem != null)
            {
                SubsetSelector.SelectedItem = null;
                RecentSubsetSelector.SelectedItem = null;
            }
        }

        private void RecentSubsetSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            if (RecentSubsetSelector.SelectedItem != null)
            {
                SubsetSelector.SelectedItem = null;
                CustomSubsetSelector.SelectedItem = null;
            }
        }

        /// <summary>
        /// Gets a list of alg numbers from the given input text for the given alg set
        /// </summary>
        /// <param name="set">The current alg set</param>
        /// <param name="fromTextBox">The list of ranges or subsets entered by the user</param>
        /// <returns></returns>
        public List<int> GetListFromAlgSet(AlgSet set, string fromTextBox)
        {
            Dictionary<string, List<int>> subsets = XmlSubsetFile.GetNameMap(set);
            return SetParser.Parse(fromTextBox, subsets, CustomSubsetFile.GetSubsets(Set), Info.GetNumPositionsInSet(set));
        }



        private void UpdateSubsetSelector()
        {
            //GroupSelector.Items.Clear();
            //var groups = XmlSubsetFile.GetSubsetGroupsForAlgSet(Set);
            //foreach (var group in groups)
            //{
            //    GroupSelector.Items.Add(group);
            //}
        }

        private void AddSubsetButton_Click(object sender, EventArgs e)
        {
            var screen = new AddSubsetScreen(Set, RangeBox.Text);
            screen.Show();
        }

        private void ViewSubsetsButton_Click(object sender, EventArgs e)
        {
            var screen = new SubsetListScreen(Set);
            screen.Show();
        }

        // When a postition is constructed by the user, show it on the screen
        void PosNumReceived(AlgSet set, int value)
        {
            Set = set;
            AlgSetSelector.SelectedItem = set;
            PosNum = value;
            PositionBox.Text = value.ToString();
            SetUpPosition();
        }

        private void ConstructPostionButton_Click(object sender, EventArgs e)
        {
            var form = new SetupForm(PosNumReceived);
            form.Show();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            RangeBox.Text = "";
        }

        private void ViewSelectedButton_Click(object sender, EventArgs e)
        {
            var nameMap = XmlSubsetFile.GetNameMap(Set);
            try
            {
                SubsetTools.ValidateAlgListInput(RangeBox.Text, nameMap, Info.GetNumPositionsInSet(Set), CustomSubsetFile.GetSubsets(Set));

                // translate custom subset names into their alg lists

                var screen = new SetInfoScreen(Set, RangeBox.Text, nameMap, CustomSubsetFile.GetSubsets(Set));
                screen.Show();
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunnerScreenCallback()
        {
            this.Show();
        }
    }
}
