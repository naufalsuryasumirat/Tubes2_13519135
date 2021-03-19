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
        class ItemCombo
        {
            public ItemCombo() { }
            public string Value { set; get; }
            public string Text { set; get; }
            public override string ToString()
            {
                return Value;
            }
        }
        private Classes.Graph OG;
        private Microsoft.Msagl.Drawing.Graph GDraw;
        // private Microsoft.Msagl.Drawing.Graph GDrawBase; // the base for the file, to reset after each findings
        private string account;
        private string findAccount;
        private List<ItemCombo> accList;
        private List<ItemCombo> findList;
        private int mode; // 1 for BFS, 0 for DFS, -1 for not selected
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
        void EditNodePath(Microsoft.Msagl.Drawing.Graph graphs, string name)
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Yellow;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.DoubleCircle;
        }
        void EditNodeNormal(Microsoft.Msagl.Drawing.Graph graphs, string name)
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
        }
        void EditNodeAccount(Microsoft.Msagl.Drawing.Graph graphs, string name)
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Yellow;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
        }
        void EditNodeFind(Microsoft.Msagl.Drawing.Graph graphs, string name)
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
        }
        void Wait(int ms) // Timer untuk animasi
        {
            var timer = new System.Windows.Forms.Timer();
            if (ms <= 0) return;
            timer.Interval = ms;
            timer.Enabled = true;
            timer.Start();

            timer.Tick += (s, e) =>
            {
                timer.Enabled = false;
                timer.Stop();
            };

            while (timer.Enabled == true)
            {
                Application.DoEvents();
            }
        }
        // Pastikan terdapat path terlebih dahulu
        void DrawPath(Microsoft.Msagl.Drawing.Graph graphs, List<string> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                AddDirectedEdge(graphs, list[i], list[i + 1], "Blue");
                EditNodePath(graphs, list[i]);
                if (i == list.Count - 2)
                {
                    EditNodePath(graphs, list[i + 1]);
                }
            }
        }
        void AnimatePath(Microsoft.Msagl.Drawing.Graph graphs, List<string> list, Microsoft.Msagl.GraphViewerGdi.GViewer gdi)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                AddDirectedEdge(graphs, list[i], list[i + 1], "Blue");
                EditNodePath(graphs, list[i]);
                if (i == list.Count - 2)
                {
                    EditNodePath(graphs, list[i + 1]);
                }
                gdi.Graph = graphs;
                Wait(1250); // menunggu 2.5 detik
            }
        }
        void DrawGraph(Microsoft.Msagl.Drawing.Graph graphs, List<Tuple<string, string>> list)
        {
            foreach (var tuple in list)
            {
                AddUndirectedEdge(graphs, tuple.Item1, tuple.Item2, "Black");
                EditNodeNormal(graphs, tuple.Item1);
                EditNodeNormal(graphs, tuple.Item2);
            }
        }
        public Form1()
        {
            InitializeComponent();
            //this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.GDraw = null;
            this.OG = null;
            this.account = null;
            this.findAccount = null;
            this.mode = -1;
            cmb_Account.Visible = false;
            pnl_ExploreFriends.Visible = false;
            cmb_ExploreWith.Visible = false;
            pnl_ExploreFriends.Size = new Size(200, 181);
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
                this.GDraw = new Microsoft.Msagl.Drawing.Graph("graph");
                this.OG = new Classes.Graph(fileToOpen);
                DrawGraph(this.GDraw, OG.getDrawInfo());
                gViewer1.Graph = this.GDraw;
                this.account = null;
                this.findAccount = null;
                this.mode = -1;
                lbl_FileName.Text = "File Name: " + System.IO.Path.GetFileName(fileToOpen);

                // Initialize dropdown menu
                accList = new List<ItemCombo>();
                findList = new List<ItemCombo>();
                foreach (var name in OG.getNodeNames())
                {
                    accList.Add(new ItemCombo() { Text = name, Value = name });
                    findList.Add(new ItemCombo() { Text = name, Value = name });
                }
                cmb_Account.DataSource = accList;
                cmb_Account.DisplayMember = "Text";
                cmb_Account.ValueMember = "Value";

                cmb_ExploreWith.DataSource = findList;
                cmb_ExploreWith.DisplayMember = "Text";
                cmb_ExploreWith.ValueMember = "Value";
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmb_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (account != null)
            {
                EditNodeNormal(this.GDraw, this.account);
                gViewer1.Graph = GDraw;
            }
            this.account = cmb_Account.SelectedValue.ToString();
            EditNodeAccount(this.GDraw, this.account);
            gViewer1.Graph = GDraw;
        }

        private void btn_Account_Click(object sender, EventArgs e)
        {
            cmb_Account.Visible = !cmb_Account.Visible;
        }

        private void btn_ExploreFriends_Click(object sender, EventArgs e)
        {
            pnl_ExploreFriends.Visible = !pnl_ExploreFriends.Visible;
        }

        private void cmb_ExploreWith_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (findAccount != null)
            {
                EditNodeNormal(this.GDraw, this.findAccount);
                gViewer1.Graph = GDraw;
            }
            this.findAccount = cmb_ExploreWith.SelectedValue.ToString();
            EditNodeFind(this.GDraw, this.findAccount);
            gViewer1.Graph = GDraw;
        }

        private void btn_FriendAccount_Click(object sender, EventArgs e)
        {
            if (cmb_ExploreWith.Visible)
            {
                pnl_ExploreFriends.Size = new Size(200, 181);
            }
            else
            {
                pnl_ExploreFriends.Size = new Size(200, 202);
            }
            cmb_ExploreWith.Visible = !cmb_ExploreWith.Visible;
        }

        private void btn_BFS_Click(object sender, EventArgs e)
        {
            if (this.mode == 1) return;
            this.mode = 1;
            // Mengganti warna tombol BFS
            btn_BFS.ForeColor = Color.FromArgb(255, 40, 42, 54);
            btn_BFS.BackColor = Color.FromArgb(255, 255, 121, 198);
            // Mengganti warna tombol DFS
            btn_DFS.ForeColor = Color.FromArgb(255, 255, 121, 198);
            btn_DFS.BackColor = Color.FromArgb(255, 40, 42, 54);
        }

        private void btn_DFS_Click(object sender, EventArgs e)
        {
            if (this.mode == 0) return;
            this.mode = 0;
            // Mengganti warna tombol DFS
            btn_DFS.ForeColor = Color.FromArgb(255, 40, 42, 54);
            btn_DFS.BackColor = Color.FromArgb(255, 255, 121, 198);
            // Mengganti warna tombol BFS
            btn_BFS.ForeColor = Color.FromArgb(255, 255, 121, 198);
            btn_BFS.BackColor = Color.FromArgb(255, 40, 42, 54);
        }

        private void btn_Explore_Click(object sender, EventArgs e)
        {
            if (this.mode == -1) return;
            if (this.account == null) return;
            if (this.findAccount == null) return;
            if (this.account == this.findAccount) return;
            if (this.mode == 1)
            {
                var BFSpath = OG.BFS(this.account, this.findAccount);
                AnimatePath(this.GDraw, BFSpath, this.gViewer1);
                lbl_Content.Text = "Penelusuran dengan Breadth-First Search\n" + OG.getPrintAll(BFSpath);
                return;
            }
            if (this.mode == 0)
            {
                var DFSpath = OG.DFS(this.account, this.findAccount);
                AnimatePath(this.GDraw, DFSpath, this.gViewer1);
                lbl_Content.Text = "Penelusuran dengan Depth-First Search\n" + OG.getPrintAll(DFSpath);
                return;
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            this.GDraw = new Microsoft.Msagl.Drawing.Graph("graph");
            DrawGraph(this.GDraw, OG.getDrawInfo());
            gViewer1.Graph = this.GDraw;
            this.account = null;
            this.findAccount = null;
            this.mode = -1;
            lbl_Content.Text = "";
        }

        private void btn_Mutual_Click(object sender, EventArgs e)
        {
            if (this.account == null) return;
            var mutualList = OG.getMutuals(this.account);
            if (mutualList.Count == 0) return;
            foreach (var mutual in mutualList)
            {
                EditNodeAccount(this.GDraw, mutual.Item1);
            }
            gViewer1.Graph = this.GDraw;
            lbl_Content.Text = OG.getPrintMutuals(this.account);
        }
    }
}
