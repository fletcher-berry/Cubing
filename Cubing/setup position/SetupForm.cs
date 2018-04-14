using Cubing;
using Cubing.ConstructPosition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cubing.ConstructPosition
{
    /// <summary>
    /// Provides a user interface to construct a position on a rubik's cube
    /// </summary>
    public partial class SetupForm : Form
    {
        public SetupCube Cube;

        const double SizeRatio = .8;

        /// <summary>
        /// The form which created an instance of this form
        /// </summary>
        ISetUpPositionParent Parent;

        /// <summary>
        /// Creates a new instance of SetupFrom
        /// </summary>
        /// <param name="screen">The form which created an instance of this form</param>
        public SetupForm(ISetUpPositionParent screen)
        {
            InitializeComponent();
            Cube = new SetupCube(SizeRatio);
            Parent = screen;
            InfoLabel.Text = GetInfoString(Cube.State);

            OrangeLabel.Visible = false;
            GreenLabel.Visible = false;
            BlueLabel.Visible = false;
            RedLabel.Visible = false;

            SetUpOllButton.Visible = false;
            SetUpOllcpButton.Visible = false;
            SetUp1lllButton.Visible = false;
            SetUpEllcpButton.Visible = false;
            SetUpZbllButton.Visible = false;

            KeyPreview = true;
        }

        private void CubeBox_Paint(object sender, PaintEventArgs e)
        {
            Cube.Paint(e, SizeRatio);
        }

        // gives a description of how to interact with the cube given its state
        public static string GetInfoString(SetupState state)
        {
            switch(state)
            {
                case SetupState.Orienatation:
                    return "Orientation: \nclick a piece to place yellow on that piece";
                case SetupState.CP:
                    return "Corner permutation \n click a corner piece to select it, then use the keyboard to select a color";
                case SetupState.EP:
                    return "Edge permutation \n click an edge piece to select it, then use the keyboard to select a color";
                default:
                    return "";
            }
        }

        private void CubeBox_Click(object sender, EventArgs e)
        {
            
        }

        private void CubeBox_MouseClick(object sender, MouseEventArgs e)
        {
            Cube.Click(e);
            InfoLabel.Text = GetInfoString(Cube.State);
            if (Cube.State == SetupState.CP)
                SetUpOllButton.Visible = true;
            List<CubeColor> available = Cube.GetAvailableColors();
            OrangeLabel.Visible = available.Contains(CubeColor.Orange);
            GreenLabel.Visible = available.Contains(CubeColor.Green);
            BlueLabel.Visible = available.Contains(CubeColor.Blue);
            RedLabel.Visible = available.Contains(CubeColor.Red);   
            Refresh();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cube.KeyPress(e);
            InfoLabel.Text = GetInfoString(Cube.State);
            if (Cube.State == SetupState.EP)
                SetUpOllcpButton.Visible = true;
            if(Cube.State == SetupState.Compeleted)
            {
                SetUpZbllButton.Visible = true;
                SetUpEllcpButton.Visible = true;
                SetUp1lllButton.Visible = true;
            }
            List<CubeColor> available = Cube.GetAvailableColors();
            OrangeLabel.Visible = available.Contains(CubeColor.Orange);
            GreenLabel.Visible = available.Contains(CubeColor.Green);
            BlueLabel.Visible = available.Contains(CubeColor.Blue);
            RedLabel.Visible = available.Contains(CubeColor.Red);
            Refresh();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            Cube.Undo();
            Cube.SelectedNode = null;
            InfoLabel.Text = GetInfoString(Cube.State);
            if(Cube.State == SetupState.EP)
            {
                SetUpZbllButton.Visible = false;
                SetUpEllcpButton.Visible = false;
                SetUp1lllButton.Visible = false;
            }
            if (Cube.State == SetupState.CP)
                SetUpOllcpButton.Visible = false;
            if (Cube.State == SetupState.Orienatation)
                SetUpOllButton.Visible = false;
            OrangeLabel.Visible = false;
            GreenLabel.Visible = false;
            BlueLabel.Visible = false;
            RedLabel.Visible = false;
            Refresh();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Sets up the constructed ZBLL position on the parent form
        private void SetUpZbllButton_Click(object sender, EventArgs e)
        {
            if(!Cube.IsZbll())
            {
                MessageBox.Show("Not a valid ZBLL position.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int posNum = Cube.GetPosNum();
            Parent.PosNumReceived(AlgSet.ZBLL, posNum);
            this.Close();
        }

        // still need to implement the buttons for the other algorithm sets
    }
}
