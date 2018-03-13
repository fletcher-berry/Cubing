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
    public class SetupCube : OneLookLLCube
    {
        public CircularLinkedList<CubeColor> URFList;
        public CircularLinkedList<CubeColor> URBList;
        public CircularLinkedList<CubeColor> ULFList;
        public CircularLinkedList<CubeColor> ULBList;
        public CircularLinkedList<CubeColor> URList;
        public CircularLinkedList<CubeColor> ULList;
        public CircularLinkedList<CubeColor> UFList;
        public CircularLinkedList<CubeColor> UBList;

        private List<CircularLinkedList<CubeColor>> _edges;
        private List<CircularLinkedList<CubeColor>> _corners;

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

        

        public SetupCube(double sizeRatio) : base(sizeRatio)
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

        }

        public override void Paint(PaintEventArgs e)
        {
            UpdatePieces();

            int z = 18;

            e.Graphics.FillPolygon(Brushes.Black, Tools.ScalePointArray(new Point[] { new Point(148, 98), new Point(452, 98), new Point(452, 402), new Point(148, 402) }, SizeRatio));

            e.Graphics.FillPolygon(Tools.GetBrush(ULB), Tools.ScalePointArray(new Point[] { new Point(152, 102), new Point(248, 102), new Point(248, 198), new Point(152, 198) }, SizeRatio));  // ULB
            e.Graphics.FillPolygon(Tools.GetBrush(UB), Tools.ScalePointArray(new Point[] { new Point(252, 102), new Point(348, 102), new Point(348, 198), new Point(252, 198) }, SizeRatio));  // UB
            e.Graphics.FillPolygon(Tools.GetBrush(URB), Tools.ScalePointArray(new Point[] { new Point(352, 102), new Point(448, 102), new Point(448, 198), new Point(352, 198) }, SizeRatio));  // URB
            e.Graphics.FillPolygon(Tools.GetBrush(UL), Tools.ScalePointArray(new Point[] { new Point(152, 202), new Point(248, 202), new Point(248, 298), new Point(152, 298) }, SizeRatio));  // UL
            e.Graphics.FillPolygon(Tools.GetBrush(Ucenter), Tools.ScalePointArray(new Point[] { new Point(252, 202), new Point(348, 202), new Point(348, 298), new Point(252, 298) }, SizeRatio));  // UCenter
            e.Graphics.FillPolygon(Tools.GetBrush(UR), Tools.ScalePointArray(new Point[] { new Point(352, 202), new Point(448, 202), new Point(448, 298), new Point(352, 298) }, SizeRatio));  // UR
            e.Graphics.FillPolygon(Tools.GetBrush(ULF), Tools.ScalePointArray(new Point[] { new Point(152, 302), new Point(248, 302), new Point(248, 398), new Point(152, 398) }, SizeRatio));  // ULF
            e.Graphics.FillPolygon(Tools.GetBrush(UF), Tools.ScalePointArray(new Point[] { new Point(252, 302), new Point(348, 302), new Point(348, 398), new Point(252, 398) }, SizeRatio));  // UF
            e.Graphics.FillPolygon(Tools.GetBrush(URF), Tools.ScalePointArray(new Point[] { new Point(352, 302), new Point(448, 302), new Point(448, 398), new Point(352, 398) }, SizeRatio));  // URF

            e.Graphics.FillPolygon(Tools.GetBrush(BUL), Tools.ScalePointArray(new Point[] { new Point(152, 98), new Point(248, 98), new Point(248 - z, 98 - z), new Point(152 + z, 98 - z) }, SizeRatio));  // BUL
            e.Graphics.FillPolygon(Tools.GetBrush(BU), Tools.ScalePointArray(new Point[] { new Point(252, 98), new Point(348, 98), new Point(348 - z, 98 - z), new Point(252 + z, 98 - z) }, SizeRatio));  // BU
            e.Graphics.FillPolygon(Tools.GetBrush(BUR), Tools.ScalePointArray(new Point[] { new Point(352, 98), new Point(448, 98), new Point(448 - z, 98 - z), new Point(352 + z, 98 - z) }, SizeRatio));  // BUR

            e.Graphics.FillPolygon(Tools.GetBrush(FUL), Tools.ScalePointArray(new Point[] { new Point(152, 402), new Point(248, 402), new Point(248 - z, 402 + z), new Point(152 + z, 402 + z) }, SizeRatio));  // FUL
            e.Graphics.FillPolygon(Tools.GetBrush(FU), Tools.ScalePointArray(new Point[] { new Point(252, 402), new Point(348, 402), new Point(348 - z, 402 + z), new Point(252 + z, 402 + z) }, SizeRatio));  // FU
            e.Graphics.FillPolygon(Tools.GetBrush(FUR), Tools.ScalePointArray(new Point[] { new Point(352, 402), new Point(448, 402), new Point(448 - z, 402 + z), new Point(352 + z, 402 + z) }, SizeRatio));  // FUR

            e.Graphics.FillPolygon(Tools.GetBrush(LUB), Tools.ScalePointArray(new Point[] { new Point(148, 100), new Point(148, 200), new Point(148 - z, 200 - z), new Point(148 - z, 100 + z) }, SizeRatio));  // LUB
            e.Graphics.FillPolygon(Tools.GetBrush(LU), Tools.ScalePointArray(new Point[] { new Point(148, 200), new Point(148, 300), new Point(148 - z, 300 - z), new Point(148 - z, 200 + z) }, SizeRatio));  // LU
            e.Graphics.FillPolygon(Tools.GetBrush(LUF), Tools.ScalePointArray(new Point[] { new Point(148, 300), new Point(148, 400), new Point(148 - z, 400 - z), new Point(148 - z, 300 + z) }, SizeRatio));  // LUF

            e.Graphics.FillPolygon(Tools.GetBrush(RUB), Tools.ScalePointArray(new Point[] { new Point(452, 100), new Point(452, 200), new Point(452 + z, 200 - z), new Point(452 + z, 100 + z) }, SizeRatio));  // RUB
            e.Graphics.FillPolygon(Tools.GetBrush(RU), Tools.ScalePointArray(new Point[] { new Point(452, 200), new Point(452, 300), new Point(452 + z, 300 - z), new Point(452 + z, 200 + z) }, SizeRatio));  // RU
            e.Graphics.FillPolygon(Tools.GetBrush(RUF), Tools.ScalePointArray(new Point[] { new Point(452, 300), new Point(452, 400), new Point(452 + z, 400 - z), new Point(452 + z, 300 + z) }, SizeRatio));  // RUF
        }

        public void Click(MouseEventArgs e)
        {
            ListNode<CubeColor> node = GetClickedSticker(e.X, e.Y);
            if (node == null)
                return;
            switch(State)
            {
                case SetupState.Orienatation:
                    Action action = new Action();
                    if (node.Right.Right == node)    // edge piece
                    {
                        if (node.Value == CubeColor.None && node.Right.Value == CubeColor.None)
                        {
                            node.Value = CubeColor.Yellow;
                            action.Pieces.Add(node);
                        }
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
                            if(_corners.Count(corner => corner.Head.Value == CubeColor.None && corner.Head.Right.Value == CubeColor.None && corner.Head.Left.Value == CubeColor.None) == 0)
                            {
                                State = SetupState.CP;
                            }
                        }
                    }
                    else        // corner piece
                    {
                        if (node.Value == CubeColor.None && node.Right.Value == CubeColor.None && node.Left.Value == CubeColor.None)
                        {
                            node.Value = CubeColor.Yellow;
                            action.Pieces.Add(node);
                        }
                        if (_corners.Count(corner => corner.Head.Value == CubeColor.None && corner.Head.Right.Value == CubeColor.None && corner.Head.Left.Value == CubeColor.None) == 1)
                        {
                            var unorientedCorner = _corners.First(corner => corner.Head.Value == CubeColor.None && corner.Head.Right.Value == CubeColor.None && corner.Head.Left.Value == CubeColor.None);
                            int orientationNum = _corners.Count(corner => corner.Head.Right.Value == CubeColor.Yellow)
                                - _corners.Count(corner => corner.Head.Left.Value == CubeColor.Yellow);
                            int num = orientationNum % 3;
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
                    if (node.Value != CubeColor.None)
                        break;
                    SelectedNode = node;
                    break;
                case SetupState.EP:
                    if (node.Right.Right != node)
                        break;
                    if (node.Value != CubeColor.None)
                        break;
                    SelectedNode = node;
                    break;
            }
        }

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
                    SelectedNode.Value = edgeColor;
                    action.Pieces.Add(SelectedNode);
                    _edgeColors.Remove(edgeColor);
                    if (_edges.Count(edge => edge.Head.Value == CubeColor.None || edge.Head.Right.Value == CubeColor.None) == 2)
                    {
                        bool cornerParity = isParity(RecognitionTools.CompareColors(GetYellowNode(ULFList).Right.Value, CubeColor.Red),
                            RecognitionTools.CompareColors(GetYellowNode(URFList).Right.Value, CubeColor.Green),
                            RecognitionTools.CompareColors(GetYellowNode(URBList).Right.Value, CubeColor.Orange));
                        var uncoloredEdges = _edges.Where(edge => edge.Head.Value == CubeColor.None || edge.Head.Right.Value == CubeColor.None).ToArray();
                        GetYellowNode(uncoloredEdges[0]).Right.Value = _edgeColors[0];
                        GetYellowNode(uncoloredEdges[1]).Right.Value = _edgeColors[1];
                        bool edgeParity = isParity(RecognitionTools.CompareColors(GetYellowNode(UFList).Right.Value, CubeColor.Red),
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

        public ListNode<CubeColor> GetClickedSticker(int xCoord, int yCoord)
        {
            int z = 20;

            Point p = Tools.ScalePoint(new Point(xCoord, yCoord), 1 / SizeRatio);
            int x = p.X;
            int y = (int)(p.Y + (50 / SizeRatio) + 50);
            //MessageBox.Show(x + "  " + y);
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

        public static bool isParity(ColorCompare c1, ColorCompare c2, ColorCompare c3)
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
