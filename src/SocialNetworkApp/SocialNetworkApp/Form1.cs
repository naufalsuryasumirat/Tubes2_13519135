using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace SocialNetworkApp
{
    public partial class Form1 : Form
    {
        void AddUndirectedEdge(Microsoft.Msagl.Drawing.Graph graphs, string source, string target, string color)
        {
            var Edge = graphs.AddEdge(source, target);
            Edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
            Edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
            if (color == "Black")
            {
                Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
            }
            else if (color == "Red")
            {
                Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
            }
            else
            {
                Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
            }
        }
        void AddDirectedEdge(Microsoft.Msagl.Drawing.Graph graphs, string source, string target, string color)
        {
            var Edge = graphs.AddEdge(source, target);
            Edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.Normal;
            Edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
            if (color == "Black")
            {
                Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
            }
            else if (color == "Red")
            {
                Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
            }
            else
            {
                Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
            }
        }
        void AddNode(Microsoft.Msagl.Drawing.Graph graphs, string name, string color, string shape)
        {
            graphs.AddNode(name);
            var Node = graphs.FindNode(name);
            if (color.ToLower() == "blue")
            {
                Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.SkyBlue;
            }
            else if (color.ToLower() == "yellow")
            {
                Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightYellow;
            }
            else if (color.ToLower() == "red")
            {
                Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
            }
            else
            {
                Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
            }
            if (shape.ToLower() == "diamond")
            {
                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            }
            else if (shape.ToLower() == "dcircle")
            {
                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.DoubleCircle;
            }
            else if (shape.ToLower() == "box")
            {
                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
            }
            else
            {
                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
            }
        }
        void EditNode(Microsoft.Msagl.Drawing.Graph graphs, string name, string color, string shape)
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Yellow;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.DoubleCircle;
        }
        // Pastikan terdapat path terlebih dahulu
        void DrawPath(Microsoft.Msagl.Drawing.Graph graphs, List<string> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                AddDirectedEdge(graphs, list[i], list[i + 1], "Blue");
                EditNode(graphs, list[i], "Yellow", "DCircle");
                if (i == list.Count - 2)
                {
                    EditNode(graphs, list[i + 1], "Yellow", "DCircle");
                }
            }
        }
        void DrawGraph(Microsoft.Msagl.Drawing.Graph graphs, List<Tuple<string, string>> list)
        {
            foreach (var tuple in list)
            {
                AddUndirectedEdge(graphs, tuple.Item1, tuple.Item2, "Black");
            }
        }
        public Form1()
        {
            InitializeComponent();
            //this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            Classes.Graph testImport = new Classes.Graph("../../test/test.txt");
            DrawGraph(graph, testImport.getDrawInfo());
            var listDFS = testImport.DFS("A", "H");
            var listBFS = testImport.BFS("A", "H");
            DrawPath(graph, listDFS);
            gViewer1.Graph = graph;
        }

        private void gViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            var result = new System.Windows.Forms.OpenFileDialog();
            if (result.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = result.FileName;
                Console.WriteLine(fileToOpen);
                Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
                Classes.Graph testImport = new Classes.Graph(fileToOpen);
                DrawGraph(graph, testImport.getDrawInfo());
                var listBFS = testImport.BFS("A", "H");
                DrawPath(graph, listBFS);
                gViewer1.Graph = graph;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
