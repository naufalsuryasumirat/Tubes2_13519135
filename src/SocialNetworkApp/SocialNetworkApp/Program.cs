using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace SocialNetworkApp
{
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Form myform = new Form1();
            // myform.FormBorderStyle = FormBorderStyle.None;
            // myform.WindowState = FormWindowState.Maximized;
            Application.Run(myform);
        }
    }
    
    //static class ViewerSample
    //{
    //    public static void Main()
    //    {
    //        void AddUndirectedEdge(Microsoft.Msagl.Drawing.Graph graphs, string source, string target, string color)
    //        {
    //            var Edge = graphs.AddEdge(source, target);
    //            Edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
    //            Edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
    //            if (color == "Black")
    //            {
    //                Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
    //            }
    //            else if (color == "Red")
    //            {
    //                Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
    //            }
    //            else
    //            {
    //                Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
    //            }
    //        }
    //        void AddDirectedEdge(Microsoft.Msagl.Drawing.Graph graphs, string source, string target, string color)
    //        {
    //            var Edge = graphs.AddEdge(source, target);
    //            Edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.Normal;
    //            Edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
    //            if (color == "Black")
    //            {
    //                Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
    //            }
    //            else if (color == "Red")
    //            {
    //                Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
    //            }
    //            else
    //            {
    //                Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
    //            }
    //        }
    //        void AddNode(Microsoft.Msagl.Drawing.Graph graphs, string name, string color, string shape)
    //        {
    //            graphs.AddNode(name);
    //            var Node = graphs.FindNode(name);
    //            if (color.ToLower() == "blue")
    //            {
    //                Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.SkyBlue;
    //            }
    //            else if (color.ToLower() == "yellow")
    //            {
    //                Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightYellow;
    //            }
    //            else if (color.ToLower() == "red")
    //            {
    //                Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
    //            }
    //            else
    //            {
    //                Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
    //            }
    //            if (shape.ToLower() == "diamond")
    //            {
    //                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
    //            }
    //            else if (shape.ToLower() == "dcircle")
    //            {
    //                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.DoubleCircle;
    //            }
    //            else if (shape.ToLower() == "box")
    //            {
    //                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
    //            }
    //            else
    //            {
    //                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
    //            }
    //        }
    //        void EditNode(Microsoft.Msagl.Drawing.Graph graphs, string name, string color, string shape)
    //        {
    //            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
    //            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Yellow;
    //            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.DoubleCircle;
    //        }
    //        // Pastikan terdapat path terlebih dahulu
    //        void DrawPath(Microsoft.Msagl.Drawing.Graph graphs, List<string> list)
    //        {
    //            for (int i = 0; i < list.Count - 1; i++)
    //            {
    //                AddDirectedEdge(graphs, list[i], list[i + 1], "Blue");
    //                EditNode(graphs, list[i], "Yellow", "DCircle");
    //                if (i == list.Count - 2)
    //                {
    //                    EditNode(graphs, list[i + 1], "Yellow", "DCircle");
    //                }
    //            }
    //        }
    //        void DrawGraph(Microsoft.Msagl.Drawing.Graph graphs, List<Tuple<string, string>> list)
    //        {
    //            foreach (var tuple in list)
    //            {
    //                AddUndirectedEdge(graphs, tuple.Item1, tuple.Item2, "Black");
    //            }
    //        }
    //        //create a form 
    //        System.Windows.Forms.Form form = new System.Windows.Forms.Form();
    //        //create a viewer object 
    //        Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
    //        //create a graph object 
    //        Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
    //        //create the graph content 
    //        /*
    //        graph.AddEdge("A", "B");
    //        graph.AddEdge("B", "A");
    //        graph.AddEdge("B", "C");
    //        */

    //        /* TEST
    //        AddUndirectedEdge(graph, "A", "B", "Black");
    //        AddUndirectedEdge(graph, "B", "C", "Black");
    //        AddUndirectedEdge(graph, "A", "C", "Red");
    //        TEST */

    //        /*
    //        graph.AddNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
    //        graph.AddNode("a");
    //        */

    //        /* TEST
    //        AddNode(graph, "A", "Red", "Circle");
    //        AddNode(graph, "B", "Yellow", "Box");
    //        AddNode(graph, "C", "White", "DCircle");
    //        TEST */

    //        /*
    //        // graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
    //        graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
    //        Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
    //        c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
    //        c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
    //        */
    //        Graph testImport = new Graph("test.txt");

    //        /*
    //        testImport.WriteMutuals("A");
    //        testImport.WritePathBFS("A", "H");
    //        testImport.WritePathDFS("A", "H");
    //        */

    //        DrawGraph(graph, testImport.getDrawInfo());
    //        /* TEST
    //        // Draw BFS Path
    //        for (int i = 0; i < testImport.BFS("A", "H").Count - 1; i++)
    //        {
    //            AddUndirectedEdge(graph, testImport.BFS("A", "H")[i], testImport.BFS("A", "H")[i + 1], "Red");
    //            EditNode(graph, testImport.BFS("A", "H")[i], "Yellow", "DCircle");
    //            if (i == testImport.BFS("A", "H").Count - 1)
    //            {
    //                EditNode(graph, testImport.BFS("A", "H")[i + 1], "Yellow", "DCircle");
    //            }
    //        }
    //        TEST */
    //        /*
    //        // Draw DFS Path
    //        for (int i = 0; i < testImport.DFS("A", "H").Count - 1; i++)
    //        {
    //            AddUndirectedEdge(graph, testImport.DFS("A", "H")[i], testImport.DFS("A", "H")[i + 1], "Blue");
    //            EditNode(graph, testImport.DFS("A", "H")[i], "Yellow", "DCircle");
    //            if (i == testImport.DFS("A", "H").Count - 1)
    //            {
    //                EditNode(graph, testImport.DFS("A", "H")[i + 1], "Yellow", "DCircle");
    //            }
    //        }
    //        */
    //        var listDFS = testImport.DFS("A", "H");
    //        var listBFS = testImport.BFS("A", "H");
    //        DrawPath(graph, listDFS);


    //        /*
    //        // NOTES
    //        This sample shows how to render an image by using class Microsoft.Msagl.GraphViewerGDI.GraphRenderer.

    //        Microsoft.Msagl.Drawing.Graph graph = new
    //        Microsoft.Msagl.Drawing.Graph("");
    //        graph.AddEdge("A", "B"); 
    //        graph.AddEdge("A", "B"); 
    //        graph.FindNode("A").Attr.Fillcolor = 
    //        Microsoft.Msagl.Drawing.Color.Red; 
    //        graph.FindNode("B").Attr.Fillcolor = 
    //        Microsoft.Msagl.Drawing.Color.Blue; 
    //        Microsoft.Msagl.GraphViewerGdi.GraphRenderer renderer
    //        = new Microsoft.Msagl.GraphViewerGdi.GraphRenderer
    //        (graph);
    //        renderer.CalculateLayout();
    //        int width = 50;
    //        Bitmap bitmap = new Bitmap(width, (int)(graph.Height * (width / graph.Width)), PixelFormat.Format32bppPArgb);
    //        renderer.Render(bitmap); 
    //        bitmap.Save("test.png");
    //        Alternatively, if you have a System.Drawing.Graphics object available, you can draw by using method 
    //        public void Render(Graphics graphics, Rectangle rect) taking a System.Drawing.Graphics object as an argument.

    //        */


    //        //bind the graph to the viewer 
    //        viewer.Graph = graph;
    //        //associate the viewer with the form 
    //        form.SuspendLayout();
    //        viewer.Dock = System.Windows.Forms.DockStyle.Fill;
    //        form.Controls.Add(viewer);
    //        form.ResumeLayout();
    //        //show the form 
    //        form.ShowDialog();
    //    }
    //}
}

// Notes
/*
    Install-Package AutomaticGraphLayout -Version 1.1.11
    Install-Package AutomaticGraphLayout.Drawing -Version 1.1.11
    Install-Package AutomaticGraphLayout.WpfGraphControl -Version 1.1.11
    Install-Package AutomaticGraphLayout.GraphViewerGDI -Version 1.1.11

    Install 1.3 packages using NuGet Package Manager

    Palette				Hex					RGB					HSL
    Background			#282a36				40 42 54			231° 15% 18%
    Current Line		#44475a				68 71 90			232° 14% 31%
    Selection			#44475a				68 71 90			232° 14% 31%
    Foreground			#f8f8f2				248 248 242			60° 30% 96%
    Comment				#6272a4				98 114 164			225° 27% 51%
    Cyan				#8be9fd				139 233 253			191° 97% 77%
    Green				#50fa7b				80 250 123			135° 94% 65%
    Orange				#ffb86c				255 184 108			31° 100% 71%
    Pink				#ff79c6				255 121 198			326° 100% 74%
    Purple				#bd93f9				189 147 249			265° 89% 78%
    Red					#ff5555				255 85 85			0° 100% 67%
    Yellow				#f1fa8c				241 250 140			65° 92% 76%
*/