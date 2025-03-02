using MyGraphProjectCSS.AnalyticalProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGraphProjectCSS
{
    public partial class MainForm : Form
    {
        int elipseDiameter = GuiPreferences.ElipseDiameter;
        int outlineDiameter = GuiPreferences.OutlineDiameter;
        Color defaultNodeColor = GuiPreferences.DefaultNodeColor;
        double defaultNodeChance = GuiPreferences.DefaultNodeChance;
        Graphics graphics;
        Graph graph;
        Node currentNode;
        Node prevNode = null;

        NodeRatingForm nodeRatingForm;

        public MainForm()
        {
            InitializeComponent();
            graphics = MainPB.CreateGraphics();
            graph = new Graph(this);
        }

        void DrawNode(int x, int y, int elipseDiameter, int outlineDiameter, Color color)
        {
            Brush brush;
            Pen pen = new Pen(Color.Black, outlineDiameter);
            int innerElipseDiameter = elipseDiameter - outlineDiameter;
            int outerElipseDiameter = elipseDiameter;

            // shifted coords're used for drawing elipses with center in the right place
            int shiftedX = x - outerElipseDiameter / 2;
            int shiftedY = y - outerElipseDiameter / 2;
            graphics.DrawEllipse(pen, shiftedX, shiftedY, outerElipseDiameter, outerElipseDiameter); //outer elipse

            brush = new SolidBrush(color);
            shiftedX = x - innerElipseDiameter / 2;
            shiftedY = y - innerElipseDiameter / 2;
            graphics.FillEllipse(brush, shiftedX, shiftedY, innerElipseDiameter, innerElipseDiameter); //inner elipse
        }
        void DrawNode(Node node)
        {
            Brush brush;
            Pen pen = new Pen(Color.Black, outlineDiameter);
            int innerElipseDiameter = elipseDiameter - outlineDiameter;
            int outerElipseDiameter = elipseDiameter;

            int x = node.X;
            int y = node.Y;
            Color color = node.Color;
            // shifted coords're used for drawing elipses with center in the right place
            int shiftedX = x - outerElipseDiameter / 2;
            int shiftedY = y - outerElipseDiameter / 2;
            graphics.DrawEllipse(pen, shiftedX, shiftedY, outerElipseDiameter, outerElipseDiameter); //outer elipse

            brush = new SolidBrush(color);
            shiftedX = x - innerElipseDiameter / 2;
            shiftedY = y - innerElipseDiameter / 2;
            graphics.FillEllipse(brush, shiftedX, shiftedY, innerElipseDiameter, innerElipseDiameter); //inner elipse
        }

        private string GenerateNodeName(int nodeIndex)
        {
            return new StringBuilder().Append((char) (nodeIndex + 0x41)).ToString();
        }

        //List<Node> NodeList = new List<Node>();
        void CreateNode(int x, int y)
        {
            if (FindNode(x, y) == null)
            {
                DrawNode(x, y, elipseDiameter, outlineDiameter, defaultNodeColor);
                string name = GenerateNodeName(graph.GetNodes().Count);
                Node node = new Node(x, y, elipseDiameter, defaultNodeColor, defaultNodeChance, false, false, name);
                graph.Add(node);
            }
        }


        void ShowNodeInfo(Node node)
        {
            double chance = node.Chance;
            chanceTB.Text = chance.ToString();
            int x = node.X;
            int y = node.Y;
            int index = graph.IndexOf(node);
            bool isStart = node.IsStart;
            bool isEnd = node.IsEnd;
            string text = String.Format("X: {0}  Y: {1}  GraphIndex: {2}  IsStart: {3}  IsEnd: {4}", x, y, index, isStart, isEnd);
            coordsLabel.Text = text;
        }
        void HideNodeInfo()
        {
            chanceTB.Text = "";
            string text = String.Format("X:  Y: ");
            coordsLabel.Text = text;
        }
        void DrawEdge(Node start, Node end)
        {
            Pen pen = new Pen(Color.Black);
            pen.Width = 10;
            int startX = start.X;
            int startY = start.Y;
            int endX = end.X;
            int endY = end.Y;

            Point p1 = new Point(startX, startY);
            Point p2 = new Point(endX, endY);

            graphics.DrawLine(pen, p1, p2);
            DrawNode(startX, startY, elipseDiameter, outlineDiameter, start.Color);
            DrawNode(endX, endY, elipseDiameter, outlineDiameter, end.Color);
        }

        void CreateEdge(Node start, Node end)
        {
            graph.Connect(start, end);
            DrawEdge(start, end);
        }
        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouseEvent = (MouseEventArgs)e;
            int mouseX = mouseEvent.X;
            int mouseY = mouseEvent.Y;
            MouseButtons button = mouseEvent.Button;

            if(button == MouseButtons.Left)
            {
                CreateNode(mouseX, mouseY);
            }


        }
        void OutlinePicBox()
        {
            int sizeX = MainPB.Size.Width;
            int sizeY = MainPB.Size.Height;
            // 4 corner points for outline
            Point p1 = new Point(0, 0);
            Point p2 = new Point(sizeX, 0);
            Point p3 = new Point(0, sizeY);
            Point p4 = new Point(sizeX, sizeY);

            Pen pen = new Pen(Color.Black);
            pen.Width = 2;
            graphics.DrawLine(pen, p1, p2);
            graphics.DrawLine(pen, p2, p4);
            graphics.DrawLine(pen, p4, p3);
            graphics.DrawLine(pen, p3, p1);
        }
        Node FindNode(int mouseX, int mouseY)
        {
            int count = graph.Count();
            for (int i = 0; i < count; i++)
            {
                //int nodeX = graph.ElementAt(i).x;
                int nodeX = graph.ElementAt(i).X;
                int nodeY = graph.ElementAt(i).Y;
                int nodeRadius = graph.ElementAt(i).diameter / 2;
                int nodeRadius_sqr = nodeRadius * nodeRadius;
                int dX = mouseX - nodeX;
                int dY = mouseY - nodeY;

                if ((nodeRadius_sqr >= dX * dX + dY * dY))
                {
                    return graph.ElementAt(i);
                }

            }
            return null;
        }

        void DrawGraph()
        {
            List<Node> NodeList = graph.GetNodes();
            List<Node> ConnectionList;

            Node node;
            for (int i = 0; i < NodeList.Count; i++)
            {
                node = NodeList.ElementAt(i);
                int x = node.X;
                int y = node.Y;
                DrawNode(x, y, elipseDiameter, outlineDiameter, node.Color);
                ConnectionList = node.Connections;
                for (int j = 0; j < ConnectionList.Count; j++)
                {
                    DrawEdge(node, ConnectionList.ElementAt(j));
                }

            }
            DrawStart();
            DrawEnd();
        }
        void ClearPicBox()
        {
            graphics.Clear(Color.White);
        }
        void RedrawAll()
        {
            ClearPicBox();
            DrawGraph();

            foreach(var node in graph.GetNodes())
            {
                DrawNodeInfo(node);
            }

            OutlinePicBox();
        }
        public void ResetNodeColor(Node node, Color color)
        {
            if (node != null)
            {
                DrawNode(node.X, node.Y, elipseDiameter, outlineDiameter, color);
                node.Color = color;
                DrawNodeInfo(node);
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            OutlinePicBox();
            MouseEventArgs mouseEvent = (MouseEventArgs)e;
            int mouseX = mouseEvent.X;
            int mouseY = mouseEvent.Y;
            MouseButtons button = mouseEvent.Button;
            if (currentNode != null)
            {
                ResetNodeColor(prevNode, defaultNodeColor);
                prevNode = currentNode;
            }
            currentNode = FindNode(mouseX, mouseY);
            if (currentNode != null)
            {
                if (button == MouseButtons.Right)
                {
                    if ((prevNode != null))
                    {
                        int indexOf1 = prevNode.Connections.IndexOf(currentNode);
                        int indexOf2 = currentNode.Connections.IndexOf(prevNode);
                        if ((indexOf1 == -1) & (indexOf2 == -1))
                        {
                            CreateEdge(prevNode, currentNode);
                            ResetNodeColor(prevNode, defaultNodeColor);
                            ResetNodeColor(currentNode, defaultNodeColor);
                            if (!AltConnectingCB.Checked)
                            {
                                currentNode = null;
                                prevNode = null;
                            }
                        }
                        else
                        {
                            DeleteEdge(currentNode, prevNode);
                        }
                    }
                }
                else if (button == MouseButtons.Left)
                {
                    ShowNodeInfo(currentNode);
                }
                ResetNodeColor(prevNode, Color.LightGray);
                ResetNodeColor(currentNode, Color.LightBlue);
            }
            else //if (!anyNodeClicked && (currentNode != null) && (i == NodeList.Count - 1))
            {
                //drawNode(currentNode.x, currentNode.y, elipseDiameter, outlineDiameter, Color.LightGray);
                ResetNodeColor(prevNode, Color.LightGray);
                ResetNodeColor(currentNode, Color.LightGray);
                currentNode = null;
                prevNode = null;
                HideNodeInfo();
                DrawPoint(graph.StartNode, Color.Green);
                DrawPoint(graph.EndNode, Color.Red);
            }
            DrawStart();
            DrawEnd();
        }

        void DrawNodeInfo(Node node)
        {
            StringBuilder builder = new StringBuilder();
            string nodeName = node.Name;
            string nodeChance = node.Chance.ToString(CultureInfo.InvariantCulture);
            builder.Append(nodeName).Append("\n").Append(nodeChance);            
            int fontSize = 10;
            int shiftedX = node.X;
            int shiftedY = node.Y;

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font("Consolas", fontSize);
            graphics.DrawString(builder.ToString(), font, brush, shiftedX, shiftedY, format);

            if (nodeRatingForm != null)
            {
                double rating = nodeRatingForm.GetNodeRating(node);
                string ratingStr = rating.ToString("0.0");
                StringBuilder ratingStringBuilder = new StringBuilder();
                ratingStringBuilder.Append("\nR: ").Append(ratingStr);

                format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;

                brush = new SolidBrush(Color.Red);
                font = new Font("Consolas", fontSize, FontStyle.Bold);
                graphics.DrawString(ratingStringBuilder.ToString(), font, brush, shiftedX, shiftedY - GuiPreferences.ElipseDiameter, format);
            }
        }
        private void SaveButt_Click(object sender, EventArgs e)
        {
            if(currentNode != null)
            {
                string chanceS = chanceTB.Text;
                double chance;
                CultureInfo customCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
                customCulture.NumberFormat.NumberDecimalSeparator = ".";
                double.TryParse(chanceS, NumberStyles.Any, customCulture, out chance);
                currentNode.Chance = chance;
                DrawNode(currentNode.X, currentNode.Y, GuiPreferences.ElipseDiameter, GuiPreferences.OutlineDiameter, GuiPreferences.DefaultNodeColor);
                DrawNodeInfo(currentNode);
            }
        }

        private void DeleteButt_Click(object sender, EventArgs e)
        {
            if(currentNode != null)
            {
                DeleteNode(currentNode, graph);
                RedrawAll();
            }
        }

        public void DeleteNode(Node delNode, Graph sender)
        {
            List<Node> nodeList = sender.GetNodes();
            nodeList.Remove(delNode);
            List<Node> connections = delNode.Connections;

            // Removing all mentions about delNode
            for (int i = 0; i < connections.Count; i++)
            {
                Node connectedNode = connections.ElementAt(i);
                connectedNode.Connections.Remove(delNode);
            }
            currentNode = null;
            DrawGraph();
        }

        void DeleteEdge(Node node1, Node node2)
        {
            graph.DeleteEdge(node1, node2);
            RedrawAll();
        }

        private void RedrawButt_Click(object sender, EventArgs e)
        {
            RedrawAll();
        }

        void DrawPoint(Node node, Color color)
        {
            if (node != null)
            {
                Brush brush = new SolidBrush(color);
                int x = node.X;
                int y = node.Y;

                int ElipseDiameter = 15;

                // shifted coords're used for drawing elipses with center in the right place
                int shiftedX = x - ElipseDiameter / 2;
                int shiftedY = y - ElipseDiameter / 2;
                graphics.FillEllipse(brush, shiftedX, shiftedY, ElipseDiameter, ElipseDiameter); //outer elipse
            }
        }
        void DrawStart()
        {
            DrawPoint(graph.StartNode, Color.Green);
        }
        void DrawEnd()
        {
            DrawPoint(graph.EndNode, Color.Red);
        }
        void SetStart(Node node)
        {
            if (graph.StartNode != null)
            {
                graph.StartNode.IsStart = false;
                DrawNode(graph.StartNode);
            }
            node.IsStart = true;
            DrawPoint(node, Color.Green);
            graph.StartNode = node;
            DrawNodeInfo(node);
        }
        void SetEnd(Node node)
        {
            if (graph.EndNode != null)
            {
                graph.EndNode.IsEnd = false;
                DrawNode(graph.EndNode);
            }
            node.IsEnd = true;
            DrawPoint(node, Color.Red);
            graph.EndNode = node;
            DrawNodeInfo(node);
        }

        private void SetStartButt_Click(object sender, EventArgs e)
        {
            if (currentNode != null)
            {
                SetStart(currentNode);
            }
        }
        private void SetEndButt_Click(object sender, EventArgs e)
        {
            if(currentNode != null)
            {
                SetEnd(currentNode);
            }
        }



        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            OutlinePicBox();
        }

        private void FindButt_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            PathSearcher.FindAllPaths(graph);
            int pathNumber = graph.GetPaths().Count;
            if (PathSearcher.PathExictanceCheck(graph))
            {
                MessageBox.Show($"At least one path was found. ({pathNumber})");
            }
            else
            {
                MessageBox.Show("There is no path between Start and End!");
            }
            PathSearcher.FindAllPaths(graph);
            List<Path> paths = graph.GetPaths();
            pathsTB.Clear();
            for (int i = 0; i < paths.Count(); i++)
            {
                Path currentPath = paths.ElementAt(i);
                stringBuilder.Append(String.Format("{0}) ", i + 1));
                for (int j = 0; j < currentPath.Count(); j++)
                {
                    Node currentNode = currentPath.ElementAt(j);

                    stringBuilder.Append(String.Format("{0}; ", graph.IndexOf(currentNode)));
                }
                stringBuilder.Append("\n");
                stringBuilder.Append("\n");
            }
            pathsTB.Text = stringBuilder.ToString();
        }

        private void StartExpButt_Click(object sender, EventArgs e)
        {
            if (graph.StartNode == null || graph.EndNode == null)
            {
                return;
            }
            int expAmount = 0;
            string expAmountStr = expAmountTB.Text;
            int.TryParse(expAmountStr, out expAmount);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double result = Experimentor.Experiment(expAmount, graph);
            sw.Stop();
            var duration = sw.Elapsed;
            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.Append("Experimental result: ").Append(result).Append('\n');
            messageBuilder.Append("Time: ").Append(duration);
            MessageBox.Show(messageBuilder.ToString());
        }

        private void CalculateButt_Click(object sender, EventArgs e)
        {
            if (graph.StartNode == null || graph.EndNode == null)
            {
                return;
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            PathSearcher.FindAllPaths(graph);
            double result = AnalyticalProcessor.Calculate(graph);
            sw.Stop();

            var duration = sw.Elapsed;

            StringBuilder messageBuilder  = new StringBuilder();
            messageBuilder.Append("Analytical result: ").Append(result).Append('\n');
            messageBuilder.Append("Time: ").Append(duration);
            MessageBox.Show(messageBuilder.ToString());
        }

        private void GetNodesRatingButt_Click(object sender, EventArgs e)
        {
            PathSearcher.FindAllPaths(graph);
            nodeRatingForm = new NodeRatingForm(graph);
            nodeRatingForm.Show();
            RedrawAll();
        }

        private void ExperimentPrecisionButton_Click(object sender, EventArgs e)
        {
            if (graph.StartNode == null || graph.EndNode == null)
            {
                return;
            }
            PathSearcher.FindAllPaths(graph);
            double result = AnalyticalProcessor.Calculate(graph);
            ExperimentPrecisionChartForm chartForm = new ExperimentPrecisionChartForm(graph, result);
            chartForm.ShowDialog();
        }
    }
}
