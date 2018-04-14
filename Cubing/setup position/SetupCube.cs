using Cubing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cubing.ConstructPosition
{
    /*
     * This class is used so that a user can set up a position on a cube choosing what pieces are what colors.  If the colors of any piece can be determined
     * from colors that are already placed, they will be placed automatically.  User can undo actions.  From a fully or partially colored cube, a corresponding
     * ZBLL cube, ELLCP cube, 1LLL cube, OLLCP cube, or OLL cube can be generated with the same position.
     * To define orientation of the pieces, user clicks on a sticker to color it yellow.
     * To define permutation of the pieces, user clickes on a sticker, then uses the keyboard to choose a color for the sticker.
     * Corner permutation must be defined before edge permuatation.
     * 
     * Currently only supports creating a ZBLL cube.
     */
    public class SetupCube : OneLookLLCube
    {
        // The corners and edges are stored as circular linked lists.  The idea is that if all but one color is known, it can be determined.
        // The position of the unknown color can be arbitrary.
        // The colors of the corners are in clockwise order.
        // The colors of the edges are in a 2 element list.
        public CircularLinkedList<CubeColor> URFList;
        public CircularLinkedList<CubeColor> URBList;
        public CircularLinkedList<CubeColor> ULFList;
        public CircularLinkedList<CubeColor> ULBList;
        public CircularLinkedList<CubeColor> URList;
        public CircularLinkedList<CubeColor> ULList;
        public CircularLinkedList<CubeColor> UFList;
        public CircularLinkedList<CubeColor> UBList;



        private List<CircularLinkedList<CubeColor>> _edges;     // list of all edges
        private List<CircularLinkedList<CubeColor>> _corners;   // list of all corners


        private List<CubeColor> _leftCorners;
        // right corner values derived from left corner values.
        private List<CubeColor> _edgeColors;

        private Stack<Action> _actions;


        public int EODefined;
        public int CODefined;
        public int CPDefined;
        public int EPDefined;

        public int EdgesOriented;
        public int CONum;

        public SetupState State;

        public ListNode<CubeColor> SelectedNode;

        public double SizeRatio { get; }

        
        /// <summary>
        /// Creates a new instance of SetupCube in a solved state
        /// </summary>
        public SetupCube(double sizeRatio) : base()
        {
            URBList = new CircularLinkedList<CubeColor>(CubeColor.None, CubeColor.None, CubeColor.None);
            URFList = new CircularLinkedList<CubeColor>(CubeColor.None, CubeColor.None, CubeColor.None);
            ULFList = new CircularLinkedList<CubeColor>(CubeColor.None, CubeColor.None, CubeColor.None);
            ULBList = new CircularLinkedList<CubeColor>(CubeColor.None, CubeColor.None, CubeColor.None);
            URList = new CircularLinkedList<CubeColor>(CubeColor.None, CubeColor.None);
            ULList = new CircularLinkedList<CubeColor>(CubeColor.None, CubeColor.None);
            UFList = new CircularLinkedList<CubeColor>(CubeColor.None, CubeColor.None);
            UBList = new CircularLinkedList<CubeColor>(CubeColor.None, CubeColor.None);
            _edges = new List<CircularLinkedList<CubeColor>> { URList, UFList, ULList, UBList };
            _corners = new List<CircularLinkedList<CubeColor>> { URFList, URBList, ULFList, ULBList };
            _leftCorners = new List<CubeColor> { CubeColor.Red, CubeColor.Green, CubeColor.Orange, CubeColor.Blue };
            _edgeColors = new List<CubeColor> { CubeColor.Red, CubeColor.Green, CubeColor.Orange, CubeColor.Blue };
            _actions = new Stack<Action>();

            UF = FU = UB = BU = UR = RU = UL = LU = CubeColor.None;
            UpdatePieces();
            State = SetupState.Orienatation;

            SizeRatio = sizeRatio;

        }

        public override void Paint(PaintEventArgs e, double sizeRatio)
        {
            UpdatePieces();
            Paint2D(e.Graphics, SizeRatio, 0, 0, 18);
        }

        // During orientation phase, user clicks a sticker to color it yellow.  During permutation phase, user clicks a sticker to select it
        public void Click(MouseEventArgs e)
        {
            ListNode<CubeColor> node = GetClickedSticker(e.X, e.Y);
            if (node == null)
                return;
            switch(State)
            {
                case SetupState.Orienatation:           // place yellow on clicked piece if possible
                    Action action = new Action();
                    if (node.Right.Right == node)    // edge piece
                    {
                        if (node.Value == CubeColor.None && node.Right.Value == CubeColor.None)     // make sure piece is not colored
                        {
                            node.Value = CubeColor.Yellow;
                            action.Pieces.Add(node);
                        }
                        // if only one uncolored edge, its orientation can be determined.  An even number of edges must be correctly oriented
                        if (_edges.Count(edge => edge.Head.Value == CubeColor.None && edge.Head.Right.Value == CubeColor.None) == 1)
                        {
                            var unorientedEdge = _edges.First(edge => edge.Head.Value == CubeColor.None && edge.Head.Right.Value == CubeColor.None);
                            int numOriented = _edges.Count(edge => edge.Head.Value == CubeColor.Yellow);
                            if (numOriented % 2 == 0)
                            {
                                unorientedEdge.Head.Right.Value = CubeColor.Yellow;
                                action.Pieces.Add(unorientedEdge.Head.Right);
                            }
                            else
                            {
                                unorientedEdge.Head.Value = CubeColor.Yellow;
                                action.Pieces.Add(unorientedEdge.Head);
                            }
                            // if all corners have been colored, orientation step is complete
                            if(_corners.Count(corner => corner.Head.Value == CubeColor.None && corner.Head.Right.Value == CubeColor.None && corner.Head.Left.Value == CubeColor.None) == 0)
                            {
                                State = SetupState.CP;
                            }
                        }
                    }
                    else        // corner piece
                    {
                        if (node.Value == CubeColor.None && node.Right.Value == CubeColor.None && node.Left.Value == CubeColor.None)        // check to make sure corner has not veen colored
                        {
                            node.Value = CubeColor.Yellow;
                            action.Pieces.Add(node);
                        }
                        // if all but 1 corner have been colored, the orientation of the last corner can be determined
                        if (_corners.Count(corner => corner.Head.Value == CubeColor.None && corner.Head.Right.Value == CubeColor.None && corner.Head.Left.Value == CubeColor.None) == 1)
                        {
                            var unorientedCorner = _corners.First(corner => corner.Head.Value == CubeColor.None && corner.Head.Right.Value == CubeColor.None && corner.Head.Left.Value == CubeColor.None);
                            int orientationNum = _corners.Count(corner => corner.Head.Right.Value == CubeColor.Yellow)
                                - _corners.Count(corner => corner.Head.Left.Value == CubeColor.Yellow);
                            int num = orientationNum % 3;
                            // for corner orientation the difference in the number of clockwise twisted corners and counter-clockwise twisted corners must be a multiple of 3
                            if((orientationNum + 3) % 3 == 0)
                            {
                                unorientedCorner.Head.Value = CubeColor.Yellow;
                                action.Pieces.Add(unorientedCorner.Head);
                            }
                            else if((orientationNum + 3) % 3 == 1)
                            {
                                unorientedCorner.Head.Left.Value = CubeColor.Yellow;
                                action.Pieces.Add(unorientedCorner.Head.Left);
                            }
                            else
                            {
                                unorientedCorner.Head.Right.Value = CubeColor.Yellow;
                                action.Pieces.Add(unorientedCorner.Head.Right);
                            }
                            // if all edges have been colored, orientation step is complete
                            if (_edges.Count(edge => edge.Head.Value == CubeColor.None && edge.Head.Right.Value == CubeColor.None) == 0)
                            {
                                State = SetupState.CP;
                            }
                        }
                    }
                    if(action.Pieces.Count > 0)
                    {
                        _actions.Push(action);
                    }
                    break;
                case SetupState.CP:
                    if (node.Right.Right == node)        // edge
                        break;
                    if (node.Value != CubeColor.None)   // piece already colored
                        break;
                    SelectedNode = node;
                    break;
                case SetupState.EP:
                    if (node.Right.Right != node)       // corner
                        break;
                    if (node.Value != CubeColor.None)   // pieca already colored
                        break;
                    SelectedNode = node;
                    break;
            }
        }

        // during permutation phase, user uses keyboard to choose the color of the selected sticker
        public void KeyPress(KeyPressEventArgs e)
        {
            if (SelectedNode == null)
                return;
            Action action = new Action();
            switch (State)
            {
                case SetupState.CP:
                    List<CubeColor> available = GetAvailableColors();
                    CubeColor color = GetCubeColorFromChar(e.KeyChar);
                    // if selected color can be placed on the cubbe, place it
                    if(color != CubeColor.None && available.Contains(color))
                    {
                        SelectedNode.Value = color;
                        action.Pieces.Add(SelectedNode);
                        if(SelectedNode.Left.Value == CubeColor.Yellow)
                        {
                            SelectedNode.Right.Value = RecognitionTools.GetRelativeColor(color, ColorCompare.Left);
                            action.Pieces.Add(SelectedNode.Right);
                            _leftCorners.Remove(color);
                        }
                        else
                        {
                            SelectedNode.Left.Value = RecognitionTools.GetRelativeColor(color, ColorCompare.Right);
                            action.Pieces.Add(SelectedNode.Left);
                            _leftCorners.Remove(RecognitionTools.GetRelativeColor(color, ColorCompare.Right));
                        }
                        SelectedNode = null;
                    }
                    // if 3 corners have been colored, the other can be colored automatically, then corner permutation is complete
                    if(_corners.Count(corner => corner.Head.Value == CubeColor.None || corner.Head.Left.Value == CubeColor.None) == 1)
                    {
                        var list = _corners.First(corner => corner.Head.Value == CubeColor.None || corner.Head.Left.Value == CubeColor.None);
                        // find yellow sticker
                        var node = GetYellowNode(list);
                        node.Right.Value = _leftCorners[0];
                        action.Pieces.Add(node.Right);
                        node.Left.Value = RecognitionTools.GetRelativeColor(_leftCorners[0], ColorCompare.Left);
                        action.Pieces.Add(node.Left);
                        _leftCorners.Clear();
                        State = SetupState.EP;
                    }
                    if (action.Pieces.Count > 0)
                    {
                        _actions.Push(action);
                    }
                    return;
                case SetupState.EP:
                    List<CubeColor> availableEdges = GetAvailableColors();
                    CubeColor edgeColor = GetCubeColorFromChar(e.KeyChar);
                    if (edgeColor != CubeColor.None && availableEdges.Contains(edgeColor))
                    {
                        SelectedNode.Value = edgeColor;
                        action.Pieces.Add(SelectedNode);
                        _edgeColors.Remove(edgeColor);
                    }
                    // if 2 edges are colored, the other 2 can be determined because there must be an even number of piece swaps on the cube
                    if (_edges.Count(edge => edge.Head.Value == CubeColor.None || edge.Head.Right.Value == CubeColor.None) == 2)
                    {
                        bool cornerParity = IsParity(RecognitionTools.CompareColors(GetYellowNode(ULFList).Right.Value, CubeColor.Red),
                            RecognitionTools.CompareColors(GetYellowNode(URFList).Right.Value, CubeColor.Green),
                            RecognitionTools.CompareColors(GetYellowNode(URBList).Right.Value, CubeColor.Orange));
                        var uncoloredEdges = _edges.Where(edge => edge.Head.Value == CubeColor.None || edge.Head.Right.Value == CubeColor.None).ToArray();
                        GetYellowNode(uncoloredEdges[0]).Right.Value = _edgeColors[0];
                        GetYellowNode(uncoloredEdges[1]).Right.Value = _edgeColors[1];
                        bool edgeParity = IsParity(RecognitionTools.CompareColors(GetYellowNode(UFList).Right.Value, CubeColor.Red),
                            RecognitionTools.CompareColors(GetYellowNode(URList).Right.Value, CubeColor.Green),
                            RecognitionTools.CompareColors(GetYellowNode(UBList).Right.Value, CubeColor.Orange));
                        if(cornerParity != edgeParity)
                        {
                            GetYellowNode(uncoloredEdges[0]).Right.Value = _edgeColors[1];
                            GetYellowNode(uncoloredEdges[1]).Right.Value = _edgeColors[0];
                        }
                        action.Pieces.Add(GetYellowNode(uncoloredEdges[0]).Right);
                        action.Pieces.Add(GetYellowNode(uncoloredEdges[1]).Right);
                        _edgeColors.Clear();
                        State = SetupState.Compeleted;
                    }
                    if(action.Pieces.Count > 0)
                    {
                        _actions.Push(action);
                    }
                    return;
                default:
                    return;
            }

        }

        // undo an action
        public void Undo()
        {
            if (_actions.Count == 0)
                return;
            var pieces = _actions.Pop().Pieces;
            if(pieces[0].Value == CubeColor.Yellow)
            {
                State = SetupState.Orienatation;
            }
            else if(pieces[0].Right.Right == pieces[0])
            {
                State = SetupState.EP;
                for (int k = 0; k < pieces.Count; k++)
                {
                    _edgeColors.Add(pieces[k].Value);
                }
            }
            else
            {
                State = SetupState.CP;
                for (int k = 0; k < pieces.Count; k++)
                {
                    if (pieces[k].Left.Value == CubeColor.Yellow)
                        _leftCorners.Add(pieces[k].Value);
                }
            }
            for(int k = 0; k < pieces.Count; k++)
            {
                pieces[k].Value = CubeColor.None;
            }
        }

        // Get a list of colors that the selected node can take
        public List<CubeColor> GetAvailableColors()
        {
            if (SelectedNode == null || SelectedNode.Value != CubeColor.None)
                return new List<CubeColor>();
            switch(State)
            {
                case SetupState.CP:
                    if(SelectedNode.Left.Value == CubeColor.Yellow)
                    {
                        List<CubeColor> colors = new List<CubeColor>();
                        foreach (var color in _leftCorners)
                            colors.Add(color);
                        return colors;
                    }
                    else
                    {
                        List<CubeColor> colors = new List<CubeColor>();
                        foreach (var color in _leftCorners)
                            colors.Add(RecognitionTools.GetRelativeColor(color, ColorCompare.Left));
                        return colors;
                    }
                case SetupState.EP:
                    List<CubeColor> edgeColors = new List<CubeColor>();
                    foreach (var color in _edgeColors)
                        edgeColors.Add(color);
                    return edgeColors;
                default:
                    return new List<CubeColor>();
            }
        }

        /// <summary>
        /// Determines the node that was clicked based on the location of the click
        /// </summary>
        /// <param name="xCoord">The x coordinate of the location of the click</param>
        /// <param name="yCoord">The y coordinate of the location of the click</param>
        /// <returns></returns>
        public ListNode<CubeColor> GetClickedSticker(int xCoord, int yCoord)
        {
            int z = 20;

            Point p = Tools.ScalePoint(new Point(xCoord, yCoord), 1 / SizeRatio);
            int x = p.X;
            int y = (int)(p.Y + (50 / SizeRatio) + 50);
            if (x > 150 - z && x < 150)
            {
                if (y > 100 && y < 200)
                    return ULBList.Head.Right;
                else if (y > 200 && y < 300)
                    return ULList.Head.Right;
                else if (y > 300 && y < 400)
                    return ULFList.Head.Left;
            }
            else if (x > 150 && x < 250)
            {
                if (y > 100 - z && y < 100)
                    return ULBList.Head.Left;
                else if (y > 100 && y < 200)
                    return ULBList.Head;
                else if (y > 200 && y < 300)
                    return ULList.Head;
                else if (y > 300 && y < 400)
                    return ULFList.Head;
                else if (y > 400 && y < 400 + z)
                    return ULFList.Head.Right;
            }
            else if (x > 250 && x < 350)
            {
                if (y > 100 - z && y < 100)
                    return UBList.Head.Left;
                else if (y > 100 && y < 200)
                    return UBList.Head;
                else if (y > 300 && y < 400)
                    return UFList.Head;
                else if (y > 400 && y < 400 + z)
                    return UFList.Head.Right;
            }
            else if(x > 350 && x < 450)
            {
                if (y > 100 - z && y < 100)
                    return URBList.Head.Right;
                else if (y > 100 && y < 200)
                    return URBList.Head;
                else if (y > 200 && y < 300)
                    return URList.Head;
                else if (y > 300 && y < 400)
                    return URFList.Head;
                else if (y > 400 && y < 400 + z)
                    return URFList.Head.Left;
            }
            else if (x > 450 && x < 450 + z)
            {
                if (y > 100 && y < 200)
                    return URBList.Head.Left;
                else if (y > 200 && y < 300)
                    return URList.Head.Right;
                else if (y > 300 && y < 400)
                    return URFList.Head.Right;
            }
            return null;
        }

        /// <summary>
        /// From a character pressed on the keyboard, determine the corresponding cube color
        /// </summary>
        /// <param name="c">A charcter presses on the keyboard</param>
        /// <returns></returns>
        public CubeColor GetCubeColorFromChar(char c)
        {
            if (c == 'o' || c == 'O')
                return CubeColor.Orange;
            if (c == 'g' || c == 'G')
                return CubeColor.Green;
            if (c == 'b' || c == 'B')
                return CubeColor.Blue;
            if (c == 'r' || c == 'R')
                return CubeColor.Red;
            return CubeColor.None;
        }

        // Find the yellow node of a circular linked list representing a cubie
        public ListNode<CubeColor> GetYellowNode(CircularLinkedList<CubeColor> list)
        {
            ListNode<CubeColor> node = list.Head;
            do
            {
                if (node.Value == CubeColor.Yellow)
                    return node;
                node = node.Right;
            }
            while (node != list.Head);
            throw new InvalidOperationException("piece does not have yellow");
        }

        /// <summary>
        /// From 3 consecutive side colors, in counter-clockwise order, assuming white is on bottom, determine if there is an odd number of swaps.
        /// A normal color scheme is Red Green Orange Blue.  Works cor corners or edges.
        /// </summary>
        /// <returns></returns>
        public static bool IsParity(ColorCompare c1, ColorCompare c2, ColorCompare c3)
        {
            bool cornerParity;
            Dictionary<ColorCompare, int> colors = new Dictionary<ColorCompare, int>()
                        { { ColorCompare.Same, 0}, {ColorCompare.Opposite, 0 }, {ColorCompare.Left, 0}, {ColorCompare.Right, 0} };
            colors[c1]++;
            colors[c2]++;
            colors[c3]++;
            int numLR = colors[ColorCompare.Left] + colors[ColorCompare.Right];
            if (numLR == 0)
            {
                if (colors[ColorCompare.Opposite] == 3 || colors[ColorCompare.Same] == 3)
                    cornerParity = false;
                else
                    cornerParity = true;
            }
            else if (numLR == 1)
            {
                if (colors[ColorCompare.Same] == 1)
                    cornerParity = false;
                else
                    cornerParity = true;
            }
            else if (numLR == 2)
            {
                if (colors[ColorCompare.Left] == 1)
                    cornerParity = true;
                else
                    cornerParity = false;
            }
            else
            {
                if (colors[ColorCompare.Left] == 3 || colors[ColorCompare.Right] == 3)
                    cornerParity = true;
                else
                    cornerParity = false;
            }
            return cornerParity;
        }

        public bool IsZbll()
        {
            return EdgesAreOriented() && !CornersAreOriented();
        }

        public bool IsEllcp()
        {
            return CornersAreOriented() && !EdgesAreOriented();
        }

        public bool IsOll()
        {
            return !EdgesAreOriented() || !CornersAreOriented();
        }

        public bool IsOllcp()
        {
            return !EdgesAreOriented() || !CornersAreOriented();
        }

        public bool Is1lll()
        {
            return !EdgesAreOriented() || !CornersAreOriented();
        }

        private bool EdgesAreOriented()
        {
            return (UF == CubeColor.Yellow && UB == CubeColor.Yellow && UR == CubeColor.Yellow && UL == CubeColor.Yellow);
        }

        private bool CornersAreOriented()
        {
            return (URF == CubeColor.Yellow && ULF == CubeColor.Yellow && URB == CubeColor.Yellow && ULB == CubeColor.Yellow);
        }

        /// <summary>
        /// Set the colors of the encapsulated OneLookLL cube based on the circular linked list representation
        /// </summary>
        public void UpdatePieces()
        {
            URF = URFList.Head.Value;
            RUF = URFList.Head.Right.Value;
            FUR = URFList.Head.Left.Value;
            URB = URBList.Head.Value;
            BUR = URBList.Head.Right.Value;
            RUB = URBList.Head.Left.Value;
            ULB = ULBList.Head.Value;
            LUB = ULBList.Head.Right.Value;
            BUL = ULBList.Head.Left.Value;
            ULF = ULFList.Head.Value;
            FUL = ULFList.Head.Right.Value;
            LUF = ULFList.Head.Left.Value;

            UR = URList.Head.Value;
            RU = URList.Head.Right.Value;
            UL = ULList.Head.Value;
            LU = ULList.Head.Right.Value;
            UF = UFList.Head.Value;
            FU = UFList.Head.Right.Value;
            UB = UBList.Head.Value;
            BU = UBList.Head.Right.Value;
        }

        public override int GetNumPositions()
        {
            throw new NotImplementedException();
        }

        public override void SetUpPosition(int posNum)
        {
            throw new NotImplementedException();
        }

        
    }


}
