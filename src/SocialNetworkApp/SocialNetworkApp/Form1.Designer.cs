
namespace SocialNetworkApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation6 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
            this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.pnl_SideMenu = new System.Windows.Forms.Panel();
            this.btn_Mutual = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.pnl_ExploreFriends = new System.Windows.Forms.Panel();
            this.btn_Explore = new System.Windows.Forms.Button();
            this.btn_DFS = new System.Windows.Forms.Button();
            this.btn_BFS = new System.Windows.Forms.Button();
            this.cmb_ExploreWith = new System.Windows.Forms.ComboBox();
            this.btn_FriendAccount = new System.Windows.Forms.Button();
            this.btn_ExploreFriends = new System.Windows.Forms.Button();
            this.cmb_Account = new System.Windows.Forms.ComboBox();
            this.btn_Account = new System.Windows.Forms.Button();
            this.btn_Minimize = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.pnl_Logo = new System.Windows.Forms.Panel();
            this.lbl_Logo = new System.Windows.Forms.Label();
            this.pnl_Bottom = new System.Windows.Forms.Panel();
            this.pnl_Main = new System.Windows.Forms.Panel();
            this.lbl_Content = new System.Windows.Forms.Label();
            this.pnl_Filename = new System.Windows.Forms.Panel();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.pnl_AddAccount = new System.Windows.Forms.Panel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.rtb_AccName = new System.Windows.Forms.RichTextBox();
            this.btn_AddAccount = new System.Windows.Forms.Button();
            this.btn_AddConnection = new System.Windows.Forms.Button();
            this.pnl_AddConnection = new System.Windows.Forms.Panel();
            this.btn_From = new System.Windows.Forms.Button();
            this.cmb_From = new System.Windows.Forms.ComboBox();
            this.btn_To = new System.Windows.Forms.Button();
            this.cmb_To = new System.Windows.Forms.ComboBox();
            this.btn_AddFromTo = new System.Windows.Forms.Button();
            this.pnl_SideMenu.SuspendLayout();
            this.pnl_ExploreFriends.SuspendLayout();
            this.pnl_Logo.SuspendLayout();
            this.pnl_Main.SuspendLayout();
            this.pnl_Filename.SuspendLayout();
            this.pnl_AddAccount.SuspendLayout();
            this.pnl_AddConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // gViewer1
            // 
            this.gViewer1.ArrowheadLength = 10D;
            this.gViewer1.AsyncLayout = false;
            this.gViewer1.AutoScroll = true;
            this.gViewer1.BackwardEnabled = false;
            this.gViewer1.BuildHitTree = true;
            this.gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.gViewer1.EdgeInsertButtonVisible = true;
            this.gViewer1.FileName = "";
            this.gViewer1.ForwardEnabled = false;
            this.gViewer1.Graph = null;
            this.gViewer1.InsertingEdge = false;
            this.gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer1.LayoutEditingEnabled = true;
            this.gViewer1.Location = new System.Drawing.Point(978, 66);
            this.gViewer1.LooseOffsetForRouting = 0.25D;
            this.gViewer1.MouseHitDistance = 0.05D;
            this.gViewer1.Name = "gViewer1";
            this.gViewer1.NavigationVisible = true;
            this.gViewer1.NeedToCalculateLayout = true;
            this.gViewer1.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer1.PaddingForEdgeRouting = 8D;
            this.gViewer1.PanButtonPressed = false;
            this.gViewer1.SaveAsImageEnabled = true;
            this.gViewer1.SaveAsMsaglEnabled = true;
            this.gViewer1.SaveButtonVisible = true;
            this.gViewer1.SaveGraphButtonVisible = true;
            this.gViewer1.SaveInVectorFormatEnabled = true;
            this.gViewer1.Size = new System.Drawing.Size(726, 909);
            this.gViewer1.TabIndex = 1;
            this.gViewer1.TightOffsetForRouting = 0.125D;
            this.gViewer1.ToolBarIsVisible = true;
            this.gViewer1.Transform = planeTransformation6;
            this.gViewer1.UndoRedoButtonsVisible = true;
            this.gViewer1.WindowZoomButtonPressed = false;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            this.gViewer1.Load += new System.EventHandler(this.gViewer1_Load);
            // 
            // pnl_SideMenu
            // 
            this.pnl_SideMenu.AutoScroll = true;
            this.pnl_SideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.pnl_SideMenu.Controls.Add(this.pnl_AddConnection);
            this.pnl_SideMenu.Controls.Add(this.btn_AddConnection);
            this.pnl_SideMenu.Controls.Add(this.pnl_AddAccount);
            this.pnl_SideMenu.Controls.Add(this.btn_AddAccount);
            this.pnl_SideMenu.Controls.Add(this.btn_Mutual);
            this.pnl_SideMenu.Controls.Add(this.btn_Reset);
            this.pnl_SideMenu.Controls.Add(this.pnl_ExploreFriends);
            this.pnl_SideMenu.Controls.Add(this.btn_ExploreFriends);
            this.pnl_SideMenu.Controls.Add(this.cmb_Account);
            this.pnl_SideMenu.Controls.Add(this.btn_Account);
            this.pnl_SideMenu.Controls.Add(this.btn_Minimize);
            this.pnl_SideMenu.Controls.Add(this.btn_exit);
            this.pnl_SideMenu.Controls.Add(this.btn_Browse);
            this.pnl_SideMenu.Controls.Add(this.pnl_Logo);
            this.pnl_SideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_SideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnl_SideMenu.Name = "pnl_SideMenu";
            this.pnl_SideMenu.Size = new System.Drawing.Size(200, 1041);
            this.pnl_SideMenu.TabIndex = 0;
            // 
            // btn_Mutual
            // 
            this.btn_Mutual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btn_Mutual.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Mutual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Mutual.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Mutual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btn_Mutual.Location = new System.Drawing.Point(0, 424);
            this.btn_Mutual.Name = "btn_Mutual";
            this.btn_Mutual.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_Mutual.Size = new System.Drawing.Size(200, 45);
            this.btn_Mutual.TabIndex = 10;
            this.btn_Mutual.Text = "Mutual Friends";
            this.btn_Mutual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Mutual.UseVisualStyleBackColor = false;
            this.btn_Mutual.Click += new System.EventHandler(this.btn_Mutual_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(140)))));
            this.btn_Reset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btn_Reset.Location = new System.Drawing.Point(0, 900);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(200, 40);
            this.btn_Reset.TabIndex = 9;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // pnl_ExploreFriends
            // 
            this.pnl_ExploreFriends.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.pnl_ExploreFriends.Controls.Add(this.btn_Explore);
            this.pnl_ExploreFriends.Controls.Add(this.btn_DFS);
            this.pnl_ExploreFriends.Controls.Add(this.btn_BFS);
            this.pnl_ExploreFriends.Controls.Add(this.cmb_ExploreWith);
            this.pnl_ExploreFriends.Controls.Add(this.btn_FriendAccount);
            this.pnl_ExploreFriends.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_ExploreFriends.Location = new System.Drawing.Point(0, 222);
            this.pnl_ExploreFriends.Name = "pnl_ExploreFriends";
            this.pnl_ExploreFriends.Size = new System.Drawing.Size(200, 202);
            this.pnl_ExploreFriends.TabIndex = 8;
            // 
            // btn_Explore
            // 
            this.btn_Explore.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Explore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Explore.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Explore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.btn_Explore.Location = new System.Drawing.Point(0, 156);
            this.btn_Explore.Name = "btn_Explore";
            this.btn_Explore.Size = new System.Drawing.Size(200, 45);
            this.btn_Explore.TabIndex = 8;
            this.btn_Explore.Text = "Explore";
            this.btn_Explore.UseVisualStyleBackColor = true;
            this.btn_Explore.Click += new System.EventHandler(this.btn_Explore_Click);
            // 
            // btn_DFS
            // 
            this.btn_DFS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_DFS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DFS.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DFS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.btn_DFS.Location = new System.Drawing.Point(0, 111);
            this.btn_DFS.Name = "btn_DFS";
            this.btn_DFS.Size = new System.Drawing.Size(200, 45);
            this.btn_DFS.TabIndex = 7;
            this.btn_DFS.Text = "DFS";
            this.btn_DFS.UseVisualStyleBackColor = true;
            this.btn_DFS.Click += new System.EventHandler(this.btn_DFS_Click);
            // 
            // btn_BFS
            // 
            this.btn_BFS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_BFS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BFS.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BFS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.btn_BFS.Location = new System.Drawing.Point(0, 66);
            this.btn_BFS.Name = "btn_BFS";
            this.btn_BFS.Size = new System.Drawing.Size(200, 45);
            this.btn_BFS.TabIndex = 6;
            this.btn_BFS.Text = "BFS";
            this.btn_BFS.UseVisualStyleBackColor = true;
            this.btn_BFS.Click += new System.EventHandler(this.btn_BFS_Click);
            // 
            // cmb_ExploreWith
            // 
            this.cmb_ExploreWith.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.cmb_ExploreWith.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmb_ExploreWith.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_ExploreWith.FormattingEnabled = true;
            this.cmb_ExploreWith.Location = new System.Drawing.Point(0, 45);
            this.cmb_ExploreWith.Name = "cmb_ExploreWith";
            this.cmb_ExploreWith.Size = new System.Drawing.Size(200, 21);
            this.cmb_ExploreWith.TabIndex = 5;
            this.cmb_ExploreWith.SelectedIndexChanged += new System.EventHandler(this.cmb_ExploreWith_SelectedIndexChanged);
            // 
            // btn_FriendAccount
            // 
            this.btn_FriendAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_FriendAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FriendAccount.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FriendAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.btn_FriendAccount.Location = new System.Drawing.Point(0, 0);
            this.btn_FriendAccount.Name = "btn_FriendAccount";
            this.btn_FriendAccount.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btn_FriendAccount.Size = new System.Drawing.Size(200, 45);
            this.btn_FriendAccount.TabIndex = 0;
            this.btn_FriendAccount.Text = "Explore With";
            this.btn_FriendAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FriendAccount.UseVisualStyleBackColor = true;
            this.btn_FriendAccount.Click += new System.EventHandler(this.btn_FriendAccount_Click);
            // 
            // btn_ExploreFriends
            // 
            this.btn_ExploreFriends.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btn_ExploreFriends.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_ExploreFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExploreFriends.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExploreFriends.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btn_ExploreFriends.Location = new System.Drawing.Point(0, 177);
            this.btn_ExploreFriends.Name = "btn_ExploreFriends";
            this.btn_ExploreFriends.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_ExploreFriends.Size = new System.Drawing.Size(200, 45);
            this.btn_ExploreFriends.TabIndex = 7;
            this.btn_ExploreFriends.Text = "Explore Friends";
            this.btn_ExploreFriends.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ExploreFriends.UseVisualStyleBackColor = false;
            this.btn_ExploreFriends.Click += new System.EventHandler(this.btn_ExploreFriends_Click);
            // 
            // cmb_Account
            // 
            this.cmb_Account.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.cmb_Account.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmb_Account.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Account.FormattingEnabled = true;
            this.cmb_Account.Location = new System.Drawing.Point(0, 156);
            this.cmb_Account.Name = "cmb_Account";
            this.cmb_Account.Size = new System.Drawing.Size(200, 21);
            this.cmb_Account.TabIndex = 4;
            this.cmb_Account.SelectedIndexChanged += new System.EventHandler(this.cmb_Account_SelectedIndexChanged);
            // 
            // btn_Account
            // 
            this.btn_Account.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btn_Account.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Account.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Account.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Account.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btn_Account.Location = new System.Drawing.Point(0, 111);
            this.btn_Account.Name = "btn_Account";
            this.btn_Account.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_Account.Size = new System.Drawing.Size(200, 45);
            this.btn_Account.TabIndex = 6;
            this.btn_Account.Text = "Your Account";
            this.btn_Account.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Account.UseVisualStyleBackColor = false;
            this.btn_Account.Click += new System.EventHandler(this.btn_Account_Click);
            // 
            // btn_Minimize
            // 
            this.btn_Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(250)))), ((int)(((byte)(123)))));
            this.btn_Minimize.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Minimize.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Minimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.btn_Minimize.Location = new System.Drawing.Point(0, 940);
            this.btn_Minimize.Name = "btn_Minimize";
            this.btn_Minimize.Size = new System.Drawing.Size(200, 35);
            this.btn_Minimize.TabIndex = 5;
            this.btn_Minimize.Text = "Minimize";
            this.btn_Minimize.UseVisualStyleBackColor = false;
            this.btn_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(140)))));
            this.btn_exit.Location = new System.Drawing.Point(0, 975);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(200, 66);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btn_Browse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Browse.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Browse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btn_Browse.Location = new System.Drawing.Point(0, 66);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_Browse.Size = new System.Drawing.Size(200, 45);
            this.btn_Browse.TabIndex = 2;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Browse.UseVisualStyleBackColor = false;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // pnl_Logo
            // 
            this.pnl_Logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.pnl_Logo.Controls.Add(this.lbl_Logo);
            this.pnl_Logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Logo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.pnl_Logo.Location = new System.Drawing.Point(0, 0);
            this.pnl_Logo.Name = "pnl_Logo";
            this.pnl_Logo.Size = new System.Drawing.Size(200, 66);
            this.pnl_Logo.TabIndex = 1;
            // 
            // lbl_Logo
            // 
            this.lbl_Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Logo.Font = new System.Drawing.Font("Bob Sponge", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Logo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.lbl_Logo.Location = new System.Drawing.Point(0, 0);
            this.lbl_Logo.Name = "lbl_Logo";
            this.lbl_Logo.Size = new System.Drawing.Size(200, 66);
            this.lbl_Logo.TabIndex = 0;
            this.lbl_Logo.Text = "YO space";
            this.lbl_Logo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Bottom
            // 
            this.pnl_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Bottom.Location = new System.Drawing.Point(200, 975);
            this.pnl_Bottom.Name = "pnl_Bottom";
            this.pnl_Bottom.Size = new System.Drawing.Size(1704, 66);
            this.pnl_Bottom.TabIndex = 2;
            // 
            // pnl_Main
            // 
            this.pnl_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.pnl_Main.Controls.Add(this.lbl_Content);
            this.pnl_Main.Controls.Add(this.gViewer1);
            this.pnl_Main.Controls.Add(this.pnl_Filename);
            this.pnl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Main.Location = new System.Drawing.Point(200, 0);
            this.pnl_Main.Name = "pnl_Main";
            this.pnl_Main.Size = new System.Drawing.Size(1704, 975);
            this.pnl_Main.TabIndex = 3;
            // 
            // lbl_Content
            // 
            this.lbl_Content.Font = new System.Drawing.Font("LEMON MILK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Content.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.lbl_Content.Location = new System.Drawing.Point(78, 133);
            this.lbl_Content.Name = "lbl_Content";
            this.lbl_Content.Size = new System.Drawing.Size(823, 752);
            this.lbl_Content.TabIndex = 2;
            // 
            // pnl_Filename
            // 
            this.pnl_Filename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.pnl_Filename.Controls.Add(this.lbl_FileName);
            this.pnl_Filename.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Filename.Location = new System.Drawing.Point(0, 0);
            this.pnl_Filename.Name = "pnl_Filename";
            this.pnl_Filename.Size = new System.Drawing.Size(1704, 66);
            this.pnl_Filename.TabIndex = 0;
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.Font = new System.Drawing.Font("LEMON MILK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.lbl_FileName.Location = new System.Drawing.Point(19, 9);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(992, 45);
            this.lbl_FileName.TabIndex = 0;
            this.lbl_FileName.Text = "File Name: ";
            this.lbl_FileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl_AddAccount
            // 
            this.pnl_AddAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.pnl_AddAccount.Controls.Add(this.btn_Add);
            this.pnl_AddAccount.Controls.Add(this.rtb_AccName);
            this.pnl_AddAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_AddAccount.Location = new System.Drawing.Point(0, 514);
            this.pnl_AddAccount.Name = "pnl_AddAccount";
            this.pnl_AddAccount.Size = new System.Drawing.Size(200, 83);
            this.pnl_AddAccount.TabIndex = 12;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.btn_Add.Location = new System.Drawing.Point(0, 37);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(200, 45);
            this.btn_Add.TabIndex = 12;
            this.btn_Add.Text = "ADD";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // rtb_AccName
            // 
            this.rtb_AccName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.rtb_AccName.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtb_AccName.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_AccName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(147)))), ((int)(((byte)(249)))));
            this.rtb_AccName.Location = new System.Drawing.Point(0, 0);
            this.rtb_AccName.Name = "rtb_AccName";
            this.rtb_AccName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtb_AccName.Size = new System.Drawing.Size(200, 37);
            this.rtb_AccName.TabIndex = 0;
            this.rtb_AccName.Text = "";
            // 
            // btn_AddAccount
            // 
            this.btn_AddAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btn_AddAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_AddAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddAccount.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btn_AddAccount.Location = new System.Drawing.Point(0, 469);
            this.btn_AddAccount.Name = "btn_AddAccount";
            this.btn_AddAccount.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_AddAccount.Size = new System.Drawing.Size(200, 45);
            this.btn_AddAccount.TabIndex = 11;
            this.btn_AddAccount.Text = "Add Account";
            this.btn_AddAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddAccount.UseVisualStyleBackColor = false;
            this.btn_AddAccount.Click += new System.EventHandler(this.btn_AddAccount_Click);
            // 
            // btn_AddConnection
            // 
            this.btn_AddConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btn_AddConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_AddConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddConnection.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btn_AddConnection.Location = new System.Drawing.Point(0, 597);
            this.btn_AddConnection.Name = "btn_AddConnection";
            this.btn_AddConnection.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_AddConnection.Size = new System.Drawing.Size(200, 45);
            this.btn_AddConnection.TabIndex = 13;
            this.btn_AddConnection.Text = "Add Connection";
            this.btn_AddConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddConnection.UseVisualStyleBackColor = false;
            this.btn_AddConnection.Click += new System.EventHandler(this.btn_AddConnection_Click);
            // 
            // pnl_AddConnection
            // 
            this.pnl_AddConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.pnl_AddConnection.Controls.Add(this.btn_AddFromTo);
            this.pnl_AddConnection.Controls.Add(this.cmb_To);
            this.pnl_AddConnection.Controls.Add(this.btn_To);
            this.pnl_AddConnection.Controls.Add(this.cmb_From);
            this.pnl_AddConnection.Controls.Add(this.btn_From);
            this.pnl_AddConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_AddConnection.Location = new System.Drawing.Point(0, 642);
            this.pnl_AddConnection.Name = "pnl_AddConnection";
            this.pnl_AddConnection.Size = new System.Drawing.Size(200, 178);
            this.pnl_AddConnection.TabIndex = 14;
            // 
            // btn_From
            // 
            this.btn_From.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.btn_From.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_From.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_From.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_From.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.btn_From.Location = new System.Drawing.Point(0, 0);
            this.btn_From.Name = "btn_From";
            this.btn_From.Size = new System.Drawing.Size(200, 45);
            this.btn_From.TabIndex = 13;
            this.btn_From.Text = "From";
            this.btn_From.UseVisualStyleBackColor = false;
            // 
            // cmb_From
            // 
            this.cmb_From.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.cmb_From.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmb_From.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_From.FormattingEnabled = true;
            this.cmb_From.Location = new System.Drawing.Point(0, 45);
            this.cmb_From.Name = "cmb_From";
            this.cmb_From.Size = new System.Drawing.Size(200, 21);
            this.cmb_From.TabIndex = 14;
            this.cmb_From.SelectedIndexChanged += new System.EventHandler(this.cmb_From_SelectedIndexChanged);
            // 
            // btn_To
            // 
            this.btn_To.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.btn_To.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_To.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_To.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_To.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.btn_To.Location = new System.Drawing.Point(0, 66);
            this.btn_To.Name = "btn_To";
            this.btn_To.Size = new System.Drawing.Size(200, 45);
            this.btn_To.TabIndex = 15;
            this.btn_To.Text = "To";
            this.btn_To.UseVisualStyleBackColor = false;
            // 
            // cmb_To
            // 
            this.cmb_To.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.cmb_To.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmb_To.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_To.FormattingEnabled = true;
            this.cmb_To.Location = new System.Drawing.Point(0, 111);
            this.cmb_To.Name = "cmb_To";
            this.cmb_To.Size = new System.Drawing.Size(200, 21);
            this.cmb_To.TabIndex = 16;
            this.cmb_To.SelectedIndexChanged += new System.EventHandler(this.cmb_To_SelectedIndexChanged);
            // 
            // btn_AddFromTo
            // 
            this.btn_AddFromTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.btn_AddFromTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_AddFromTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddFromTo.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddFromTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.btn_AddFromTo.Location = new System.Drawing.Point(0, 132);
            this.btn_AddFromTo.Name = "btn_AddFromTo";
            this.btn_AddFromTo.Size = new System.Drawing.Size(200, 45);
            this.btn_AddFromTo.TabIndex = 17;
            this.btn_AddFromTo.Text = "ADD";
            this.btn_AddFromTo.UseVisualStyleBackColor = false;
            this.btn_AddFromTo.Click += new System.EventHandler(this.btn_AddFromTo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pnl_Main);
            this.Controls.Add(this.pnl_Bottom);
            this.Controls.Add(this.pnl_SideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1080, 608);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnl_SideMenu.ResumeLayout(false);
            this.pnl_ExploreFriends.ResumeLayout(false);
            this.pnl_Logo.ResumeLayout(false);
            this.pnl_Main.ResumeLayout(false);
            this.pnl_Filename.ResumeLayout(false);
            this.pnl_AddAccount.ResumeLayout(false);
            this.pnl_AddConnection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
        private System.Windows.Forms.Panel pnl_SideMenu;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Panel pnl_Logo;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel pnl_Bottom;
        private System.Windows.Forms.Label lbl_Logo;
        private System.Windows.Forms.Panel pnl_Main;
        private System.Windows.Forms.Panel pnl_Filename;
        private System.Windows.Forms.ComboBox cmb_Account;
        private System.Windows.Forms.Button btn_Minimize;
        private System.Windows.Forms.Button btn_Account;
        private System.Windows.Forms.Button btn_ExploreFriends;
        private System.Windows.Forms.Panel pnl_ExploreFriends;
        private System.Windows.Forms.Button btn_FriendAccount;
        private System.Windows.Forms.ComboBox cmb_ExploreWith;
        private System.Windows.Forms.Button btn_DFS;
        private System.Windows.Forms.Button btn_BFS;
        private System.Windows.Forms.Button btn_Explore;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Mutual;
        private System.Windows.Forms.Label lbl_FileName;
        private System.Windows.Forms.Label lbl_Content;
        private System.Windows.Forms.Panel pnl_AddAccount;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.RichTextBox rtb_AccName;
        private System.Windows.Forms.Button btn_AddAccount;
        private System.Windows.Forms.Panel pnl_AddConnection;
        private System.Windows.Forms.Button btn_AddFromTo;
        private System.Windows.Forms.ComboBox cmb_To;
        private System.Windows.Forms.Button btn_To;
        private System.Windows.Forms.ComboBox cmb_From;
        private System.Windows.Forms.Button btn_From;
        private System.Windows.Forms.Button btn_AddConnection;
    }
}

