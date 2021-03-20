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
        class ItemCombo // Kelas untuk form pilihan akun/find friend
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
        private string account; // Akun yang dipilih saat ini
        private string findAccount; // Akun yang dituju explore friends
        private List<ItemCombo> accList; // List akun untuk pilihan Akun saat ini
        private List<ItemCombo> findList; // List akun untuk pilihan Find Friend
        private List<ItemCombo> fromList; // List akun untuk pilihan From Connection
        private List<ItemCombo> toList; // List akun untuk pilihan To Connection
        private int mode; // 1 for BFS, 0 for DFS, -1 for not selected
        private string from; // Akun from (penambahan koneksi)
        private string to; // Akun to (penambahan koneksi)
        void AddUndirectedEdge(Microsoft.Msagl.Drawing.Graph graphs, string source, string target, string color) // Menambah dan Menggambarkan jalur / edge tidak berarah
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
        void AddDirectedEdge(Microsoft.Msagl.Drawing.Graph graphs, string source, string target, string color) // Menggambarkan jalur / edge berarah, diperlukan untuk explore friends
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
        void AddNode(Microsoft.Msagl.Drawing.Graph graphs, string name, string color, string shape) // Menambahkan Node baru pada Graph MSAGL jika belum terdapat
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
        void EditNodePath(Microsoft.Msagl.Drawing.Graph graphs, string name) // Mengubah atribut sebuah simpul untuk menunjukkan jalur
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Yellow;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.DoubleCircle;
        }
        void EditNodeNormal(Microsoft.Msagl.Drawing.Graph graphs, string name) // Mengubah atribut sebuah simpul untuk menjadi simpul normal
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
        }
        void EditNodeAccount(Microsoft.Msagl.Drawing.Graph graphs, string name) // Mengubah atribut sebuah simpul untuk menunjukkan akun saat ini
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Yellow;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
        }
        void EditNodeFind(Microsoft.Msagl.Drawing.Graph graphs, string name) // Mengubah atribut sebuah simpul untuk menunjukkan simpul tujuan
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
        }
        void EditNodeConnection(Microsoft.Msagl.Drawing.Graph graphs, string name) // Mengubah atribut sebuah simpul untuk menunjukkan menambahkan koneksi
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightGreen;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
        }
        void Wait(int ms) // Timer / Wait untuk animasi jalur pencarian teman (explore friends) // Pastikan terdapat path terlebih dahulu untuk parameter
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
        void DrawPath(Microsoft.Msagl.Drawing.Graph graphs, List<string> list) // Menggambar jalur pencarian teman (explore friends) // Pastikan terdapat path terlebih dahulu untuk parameter
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
        void AnimatePath(Microsoft.Msagl.Drawing.Graph graphs, List<string> list, Microsoft.Msagl.GraphViewerGdi.GViewer gdi) // Menganimasikan jalur pencarian teman / Explore friends
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
                Wait(1500); // menunggu 1.5 detik
            }
        }
        void DrawGraph(Microsoft.Msagl.Drawing.Graph graphs, List<Tuple<string, string>> list) // Menggambar Graph (MSAGL) sesuai dengan kelas Graph yang dibuat (Classes.Graph)
        {
            foreach (var tuple in list)
            {
                if (tuple.Item2 == null) { AddNode(graphs, tuple.Item1, "white", "circle"); continue; }
                AddUndirectedEdge(graphs, tuple.Item1, tuple.Item2, "Black");
                EditNodeNormal(graphs, tuple.Item1);
                EditNodeNormal(graphs, tuple.Item2);
            }
        }
        void InitializeComboItems(List<ItemCombo> list1, List<ItemCombo> list2, List<ItemCombo> list3, List<ItemCombo> list4, Classes.Graph graph)
        {
            foreach (var name in graph.getNodeNames())
            {
                list1.Add(new ItemCombo() { Text = name, Value = name });
                list2.Add(new ItemCombo() { Text = name, Value = name });
                list3.Add(new ItemCombo() { Text = name, Value = name });
                list4.Add(new ItemCombo() { Text = name, Value = name });
            }
            cmb_Account.DataSource = list1;
            cmb_Account.DisplayMember = "Text";
            cmb_Account.ValueMember = "Value";

            cmb_ExploreWith.DataSource = list2;
            cmb_ExploreWith.DisplayMember = "Text";
            cmb_ExploreWith.ValueMember = "Value";

            cmb_From.DataSource = list3;
            cmb_From.DisplayMember = "Text";
            cmb_From.ValueMember = "Value";

            cmb_To.DataSource = list4;
            cmb_To.DisplayMember = "Text";
            cmb_To.ValueMember = "Value";
        }
        public Form1() // Konstruktor form (Menginisialisasikan tiap atribut dengan null, dan beberapa komponen tidak dapat dilihat terlebih dahulu pada form)
        {
            InitializeComponent();
            //this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.GDraw = null;
            this.OG = null;
            this.account = null;
            this.findAccount = null;
            this.mode = -1;
            this.from = null;
            this.to = null;
            cmb_Account.Visible = false;
            pnl_ExploreFriends.Visible = false;
            cmb_ExploreWith.Visible = false;
            pnl_ExploreFriends.Size = new Size(200, 181);
            pnl_AddAccount.Visible = false;
            pnl_AddConnection.Visible = false;
        }

        private void gViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Browse_Click(object sender, EventArgs e) // Event btn_Browse di klik (Browse files) dan menggambarkan graph setelah berhasil di load file
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
                fromList = new List<ItemCombo>();
                toList = new List<ItemCombo>();
                InitializeComboItems(accList, findList, fromList, toList, OG);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e) // Event btn_exit di klik (Exit) dan menghentikan program
        {
            this.Close();
        }

        private void btn_Minimize_Click(object sender, EventArgs e) // Event btn_Minimize di klik dan me-minimize window program
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmb_Account_SelectedIndexChanged(object sender, EventArgs e) // Event memilih pada pilihan Akun (memilih akun pengguna)
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

        private void btn_Account_Click(object sender, EventArgs e) // Event btn_Account di klik, memperlihatkan/menutup pilihan akun
        {
            cmb_Account.Visible = !cmb_Account.Visible;
        }

        private void btn_ExploreFriends_Click(object sender, EventArgs e) // Event btn_ExploreFriends di klik, memperlihatkan/menutup panel Explore Friends
        {
            pnl_ExploreFriends.Visible = !pnl_ExploreFriends.Visible;
        }

        private void cmb_ExploreWith_SelectedIndexChanged(object sender, EventArgs e) // Event memilih pada pilihan Akun yang dituju (memilih akun yang dicari)
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

        private void btn_FriendAccount_Click(object sender, EventArgs e) // Event btn_FriendAccount di klik, memperlihatkan pilihan akun ExploreWith dan mengganti size panel
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

        private void btn_BFS_Click(object sender, EventArgs e) // Event btn_BFS di klik, mengganti mode pencarian menggunakan BFS
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

        private void btn_DFS_Click(object sender, EventArgs e) // Event btn_DFS di klik, mengganti mode pencarian menggunakan DFS
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

        private void btn_Explore_Click(object sender, EventArgs e) // Event btn_Explore di klik, menjalankan proses pencarian jalur dari akun saat ini ke akun yang dipilih
        {
            string noConnection = "Tidak terdapat jalur koneksi dari " + this.account + " menuju " + this.findAccount + " yang tersedia." + "\nAnda harus memulai koneksi baru tersebut sendiri.";
            if (this.mode == -1) return;
            if (this.account == null) return;
            if (this.findAccount == null) return;
            if (this.account == this.findAccount) return;
            if (this.mode == 1)
            {
                var BFSpath = OG.BFS(this.account, this.findAccount);
                if (BFSpath == null) { lbl_Content.Text = noConnection; return; }
                AnimatePath(this.GDraw, BFSpath, this.gViewer1);
                lbl_Content.Text = "Penelusuran dengan Breadth-First Search\n" + OG.getPrintAll(BFSpath);
                return;
            }
            if (this.mode == 0)
            {
                var DFSpath = OG.DFS(this.account, this.findAccount);
                if (DFSpath == null) { lbl_Content.Text = noConnection; return; }
                AnimatePath(this.GDraw, DFSpath, this.gViewer1);
                lbl_Content.Text = "Penelusuran dengan Depth-First Search\n" + OG.getPrintAll(DFSpath);
                return;
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e) // Reset graph untuk menghilangkan path sebelumnya (mengembalikan ke state awal di load)
        {
            if (this.OG == null || this.GDraw == null) return;
            this.GDraw = new Microsoft.Msagl.Drawing.Graph("graph");
            DrawGraph(this.GDraw, OG.getDrawInfo());
            gViewer1.Graph = this.GDraw;
            this.account = null;
            this.findAccount = null;
            this.mode = -1;
            this.from = null;
            this.to = null;
            lbl_Content.Text = "";
        }

        private void btn_Mutual_Click(object sender, EventArgs e) // Event btn_Mutual di klik, memperlihatkan mutual friends untuk akun
        {
            if (this.account == null) return;
            var mutualList = OG.getMutuals(this.account);
            if (mutualList.Count == 0) { lbl_Content.Text = OG.getPrintMutuals(this.account); return; }
            foreach (var mutual in mutualList)
            {
                EditNodeAccount(this.GDraw, mutual.Item1);
            }
            gViewer1.Graph = this.GDraw;
            lbl_Content.Text = OG.getPrintMutuals(this.account);
        }

        private void btn_AddAccount_Click(object sender, EventArgs e)
        {
            pnl_AddAccount.Visible = !pnl_AddAccount.Visible;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (rtb_AccName.Text.Length == 0) return;
            if (this.OG == null || this.GDraw == null) return;
            var toAdd = rtb_AccName.Text;
            if (this.OG.findNode(toAdd) != null) { lbl_Content.Text = "Akun dengan nama " + toAdd + " sudah terdapat pada Graph."; return; }
            
            OG.addNode(new Node(toAdd));
            this.GDraw = new Microsoft.Msagl.Drawing.Graph("graph");
            DrawGraph(this.GDraw, OG.getDrawInfo());
            gViewer1.Graph = this.GDraw;

            // Re-initialize dropdown menu
            accList = new List<ItemCombo>();
            findList = new List<ItemCombo>();
            fromList = new List<ItemCombo>();
            toList = new List<ItemCombo>();
            InitializeComboItems(accList, findList, fromList, toList, OG);
            lbl_Content.Text = "Akun dengan nama " + toAdd + " berhasil ditambahkan.";
        }

        private void cmb_From_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.from != null)
            {
                EditNodeNormal(this.GDraw, this.from);
            }
            this.from = cmb_From.SelectedValue.ToString();
            EditNodeConnection(this.GDraw, this.from);
            gViewer1.Graph = this.GDraw;
        }

        private void cmb_To_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.to != null)
            {
                EditNodeNormal(this.GDraw, this.to);
            }
            this.to = cmb_To.SelectedValue.ToString();
            EditNodeConnection(this.GDraw, this.to);
            gViewer1.Graph = this.GDraw;
        }

        private void btn_AddFromTo_Click(object sender, EventArgs e)
        {
            if (this.from == null || this.to == null) return;
            if (this.from == this.to) { lbl_Content.Text = "Tidak dapat menambahkan koneksi ke diri sendiri"; return; }
            if (this.OG.findNode(this.from).IsConnected(this.to)) { lbl_Content.Text = "Akun " + from + " dan Akun " + to + " sudah terhubung."; return; }
            OG.addConnection(this.from, this.to);
            this.GDraw = new Microsoft.Msagl.Drawing.Graph("graph");
            DrawGraph(this.GDraw, OG.getDrawInfo());
            gViewer1.Graph = this.GDraw;
        }

        private void btn_AddConnection_Click(object sender, EventArgs e)
        {
            pnl_AddConnection.Visible = !pnl_AddConnection.Visible;
        }
    }
}