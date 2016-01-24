namespace VoteCDJ_Admin
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.candidateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.candidatePercentVotesLabel = new System.Windows.Forms.Label();
            this.candidateNumVotesLabel = new System.Windows.Forms.Label();
            this.candidateLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.déconnexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addCandidatesButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.voteTimeLeftLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.startVoteButton = new System.Windows.Forms.Button();
            this.voteTimeButton = new System.Windows.Forms.NumericUpDown();
            this.endVoteButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.voteHourLabel = new System.Windows.Forms.Label();
            this.totalVotesLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.popOutButton = new System.Windows.Forms.Button();
            this.comboBoxPost = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.histoChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.piChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connexionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouvelleConnexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voteTimer = new System.Windows.Forms.Timer(this.components);
            this.UIUpdater = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.candidateChart)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voteTimeButton)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histoChart)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piChart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.treeView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 537);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.candidateChart);
            this.panel2.Controls.Add(this.candidatePercentVotesLabel);
            this.panel2.Controls.Add(this.candidateNumVotesLabel);
            this.panel2.Controls.Add(this.candidateLabel);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 268);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 269);
            this.panel2.TabIndex = 2;
            // 
            // candidateChart
            // 
            chartArea7.CursorX.LineWidth = 3;
            chartArea7.Name = "ChartArea1";
            this.candidateChart.ChartAreas.Add(chartArea7);
            this.candidateChart.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.candidateChart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.candidateChart.Location = new System.Drawing.Point(0, 91);
            this.candidateChart.Name = "candidateChart";
            this.candidateChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.candidateChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Crimson};
            series7.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.Red;
            series7.IsVisibleInLegend = false;
            series7.MarkerBorderColor = System.Drawing.Color.Turquoise;
            series7.Name = "Series1";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series7.YValuesPerPoint = 2;
            series7.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.candidateChart.Series.Add(series7);
            this.candidateChart.Size = new System.Drawing.Size(492, 156);
            this.candidateChart.TabIndex = 4;
            this.candidateChart.Text = "chart1";
            // 
            // candidatePercentVotesLabel
            // 
            this.candidatePercentVotesLabel.AutoSize = true;
            this.candidatePercentVotesLabel.Location = new System.Drawing.Point(13, 72);
            this.candidatePercentVotesLabel.Name = "candidatePercentVotesLabel";
            this.candidatePercentVotesLabel.Size = new System.Drawing.Size(70, 13);
            this.candidatePercentVotesLabel.TabIndex = 3;
            this.candidatePercentVotesLabel.Text = "?% des votes";
            // 
            // candidateNumVotesLabel
            // 
            this.candidateNumVotesLabel.AutoSize = true;
            this.candidateNumVotesLabel.Location = new System.Drawing.Point(13, 49);
            this.candidateNumVotesLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.candidateNumVotesLabel.Name = "candidateNumVotesLabel";
            this.candidateNumVotesLabel.Size = new System.Drawing.Size(60, 13);
            this.candidateNumVotesLabel.TabIndex = 2;
            this.candidateNumVotesLabel.Text = "Votes: N/A";
            // 
            // candidateLabel
            // 
            this.candidateLabel.AutoSize = true;
            this.candidateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.candidateLabel.Location = new System.Drawing.Point(9, 0);
            this.candidateLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.candidateLabel.Name = "candidateLabel";
            this.candidateLabel.Size = new System.Drawing.Size(74, 39);
            this.candidateLabel.TabIndex = 1;
            this.candidateLabel.Text = "N/A";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText,
            this.connectionOptions});
            this.statusStrip1.Location = new System.Drawing.Point(0, 247);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(492, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // statusText
            // 
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(0, 17);
            // 
            // connectionOptions
            // 
            this.connectionOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.connectionOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.déconnexionToolStripMenuItem});
            this.connectionOptions.Image = ((System.Drawing.Image)(resources.GetObject("connectionOptions.Image")));
            this.connectionOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectionOptions.Name = "connectionOptions";
            this.connectionOptions.Size = new System.Drawing.Size(29, 20);
            this.connectionOptions.Text = "Déconnexion";
            this.connectionOptions.Visible = false;
            // 
            // déconnexionToolStripMenuItem
            // 
            this.déconnexionToolStripMenuItem.Name = "déconnexionToolStripMenuItem";
            this.déconnexionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.déconnexionToolStripMenuItem.Text = "Déconnexion";
            this.déconnexionToolStripMenuItem.Click += new System.EventHandler(this.déconnexionToolStripMenuItem_Click);
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(9, 9);
            this.treeView.Margin = new System.Windows.Forms.Padding(9);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(474, 250);
            this.treeView.TabIndex = 4;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.31276F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.68724F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(495, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(486, 262);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.addCandidatesButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(89, 262);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // addCandidatesButton
            // 
            this.addCandidatesButton.Location = new System.Drawing.Point(3, 3);
            this.addCandidatesButton.Name = "addCandidatesButton";
            this.addCandidatesButton.Size = new System.Drawing.Size(83, 23);
            this.addCandidatesButton.TabIndex = 0;
            this.addCandidatesButton.Text = "Modifier";
            this.addCandidatesButton.UseVisualStyleBackColor = true;
            this.addCandidatesButton.Click += new System.EventHandler(this.addCandidatesButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.voteTimeLeftLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel3, 0, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(92, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(391, 256);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // voteTimeLeftLabel
            // 
            this.voteTimeLeftLabel.AutoSize = true;
            this.voteTimeLeftLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.voteTimeLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voteTimeLeftLabel.ForeColor = System.Drawing.Color.Red;
            this.voteTimeLeftLabel.Location = new System.Drawing.Point(3, 28);
            this.voteTimeLeftLabel.Margin = new System.Windows.Forms.Padding(3);
            this.voteTimeLeftLabel.Name = "voteTimeLeftLabel";
            this.voteTimeLeftLabel.Size = new System.Drawing.Size(385, 70);
            this.voteTimeLeftLabel.TabIndex = 0;
            this.voteTimeLeftLabel.Text = "00:00";
            this.voteTimeLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(385, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Temps restant:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.startVoteButton);
            this.flowLayoutPanel2.Controls.Add(this.voteTimeButton);
            this.flowLayoutPanel2.Controls.Add(this.endVoteButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(51, 124);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(288, 29);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // startVoteButton
            // 
            this.startVoteButton.Location = new System.Drawing.Point(3, 3);
            this.startVoteButton.Name = "startVoteButton";
            this.startVoteButton.Size = new System.Drawing.Size(75, 23);
            this.startVoteButton.TabIndex = 0;
            this.startVoteButton.Text = "Start";
            this.startVoteButton.UseVisualStyleBackColor = true;
            this.startVoteButton.Click += new System.EventHandler(this.startVoteButton_Click);
            // 
            // voteTimeButton
            // 
            this.voteTimeButton.DecimalPlaces = 3;
            this.voteTimeButton.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.voteTimeButton.Location = new System.Drawing.Point(84, 3);
            this.voteTimeButton.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.voteTimeButton.Name = "voteTimeButton";
            this.voteTimeButton.Size = new System.Drawing.Size(120, 20);
            this.voteTimeButton.TabIndex = 1;
            // 
            // endVoteButton
            // 
            this.endVoteButton.Enabled = false;
            this.endVoteButton.Location = new System.Drawing.Point(210, 3);
            this.endVoteButton.Name = "endVoteButton";
            this.endVoteButton.Size = new System.Drawing.Size(75, 23);
            this.endVoteButton.TabIndex = 2;
            this.endVoteButton.Text = "End";
            this.endVoteButton.UseVisualStyleBackColor = true;
            this.endVoteButton.Click += new System.EventHandler(this.endVoteButton_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.voteHourLabel);
            this.flowLayoutPanel3.Controls.Add(this.totalVotesLabel);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(57, 185);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(276, 62);
            this.flowLayoutPanel3.TabIndex = 3;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // voteHourLabel
            // 
            this.voteHourLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.voteHourLabel.AutoSize = true;
            this.voteHourLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voteHourLabel.ForeColor = System.Drawing.Color.Green;
            this.voteHourLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.voteHourLabel.Location = new System.Drawing.Point(3, 3);
            this.voteHourLabel.Margin = new System.Windows.Forms.Padding(3);
            this.voteHourLabel.Name = "voteHourLabel";
            this.voteHourLabel.Size = new System.Drawing.Size(270, 25);
            this.voteHourLabel.TabIndex = 6;
            this.voteHourLabel.Text = "- votes dans la dernière heure";
            // 
            // totalVotesLabel
            // 
            this.totalVotesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.totalVotesLabel.AutoSize = true;
            this.totalVotesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalVotesLabel.ForeColor = System.Drawing.Color.Green;
            this.totalVotesLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.totalVotesLabel.Location = new System.Drawing.Point(68, 34);
            this.totalVotesLabel.Margin = new System.Windows.Forms.Padding(3);
            this.totalVotesLabel.Name = "totalVotesLabel";
            this.totalVotesLabel.Size = new System.Drawing.Size(139, 25);
            this.totalVotesLabel.TabIndex = 5;
            this.totalVotesLabel.Text = "- votes au total";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.popOutButton);
            this.panel1.Controls.Add(this.comboBoxPost);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(495, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 263);
            this.panel1.TabIndex = 6;
            // 
            // popOutButton
            // 
            this.popOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.popOutButton.Image = ((System.Drawing.Image)(resources.GetObject("popOutButton.Image")));
            this.popOutButton.Location = new System.Drawing.Point(460, 244);
            this.popOutButton.Name = "popOutButton";
            this.popOutButton.Size = new System.Drawing.Size(20, 20);
            this.popOutButton.TabIndex = 4;
            this.popOutButton.UseVisualStyleBackColor = true;
            this.popOutButton.Click += new System.EventHandler(this.popOutButton_Click);
            // 
            // comboBoxPost
            // 
            this.comboBoxPost.FormattingEnabled = true;
            this.comboBoxPost.Location = new System.Drawing.Point(3, 3);
            this.comboBoxPost.Name = "comboBoxPost";
            this.comboBoxPost.Size = new System.Drawing.Size(159, 21);
            this.comboBoxPost.TabIndex = 3;
            this.comboBoxPost.SelectedIndexChanged += new System.EventHandler(this.comboBoxPost_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 25);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(480, 219);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.histoChart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(472, 193);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Histogramme";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // histoChart
            // 
            chartArea8.Area3DStyle.Inclination = 20;
            chartArea8.Area3DStyle.Rotation = 5;
            chartArea8.Name = "ChartArea1";
            this.histoChart.ChartAreas.Add(chartArea8);
            this.histoChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.histoChart.Location = new System.Drawing.Point(3, 3);
            this.histoChart.Name = "histoChart";
            series8.ChartArea = "ChartArea1";
            series8.Name = "John";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series8.YValuesPerPoint = 6;
            this.histoChart.Series.Add(series8);
            this.histoChart.Size = new System.Drawing.Size(466, 194);
            this.histoChart.TabIndex = 0;
            this.histoChart.Text = "chart2";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.piChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(472, 193);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Camembert";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // piChart
            // 
            chartArea9.Area3DStyle.Inclination = 35;
            chartArea9.Area3DStyle.IsRightAngleAxes = false;
            chartArea9.Area3DStyle.PointDepth = 250;
            chartArea9.Area3DStyle.Rotation = 0;
            chartArea9.Name = "ChartArea1";
            this.piChart.ChartAreas.Add(chartArea9);
            this.piChart.Dock = System.Windows.Forms.DockStyle.Top;
            legend3.Name = "Legend1";
            this.piChart.Legends.Add(legend3);
            this.piChart.Location = new System.Drawing.Point(3, 3);
            this.piChart.Name = "piChart";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series9.CustomProperties = "PieLabelStyle=Disabled";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.piChart.Series.Add(series9);
            this.piChart.Size = new System.Drawing.Size(466, 194);
            this.piChart.TabIndex = 0;
            this.piChart.Text = "chart2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.connexionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportResultsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fileToolStripMenuItem.Text = "Fichier";
            // 
            // exportResultsToolStripMenuItem
            // 
            this.exportResultsToolStripMenuItem.Enabled = false;
            this.exportResultsToolStripMenuItem.Name = "exportResultsToolStripMenuItem";
            this.exportResultsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.exportResultsToolStripMenuItem.Text = "Exporter les resultats";
            this.exportResultsToolStripMenuItem.Click += new System.EventHandler(this.exportResultsToolStripMenuItem_Click_1);
            // 
            // connexionsToolStripMenuItem
            // 
            this.connexionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouvelleConnexionToolStripMenuItem,
            this.importPassToolStripMenuItem});
            this.connexionsToolStripMenuItem.Name = "connexionsToolStripMenuItem";
            this.connexionsToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.connexionsToolStripMenuItem.Text = "Base de données";
            // 
            // nouvelleConnexionToolStripMenuItem
            // 
            this.nouvelleConnexionToolStripMenuItem.Name = "nouvelleConnexionToolStripMenuItem";
            this.nouvelleConnexionToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.nouvelleConnexionToolStripMenuItem.Text = "Nouvelle Connexion";
            this.nouvelleConnexionToolStripMenuItem.Click += new System.EventHandler(this.nouvelleConnexionToolStripMenuItem_Click);
            // 
            // importPassToolStripMenuItem
            // 
            this.importPassToolStripMenuItem.Enabled = false;
            this.importPassToolStripMenuItem.Name = "importPassToolStripMenuItem";
            this.importPassToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.importPassToolStripMenuItem.Text = "Modifier les utilisateurs";
            this.importPassToolStripMenuItem.Click += new System.EventHandler(this.importPassToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.helpToolStripMenuItem.Text = "Aide";
            // 
            // voteTimer
            // 
            this.voteTimer.Interval = 60000;
            this.voteTimer.Tick += new System.EventHandler(this.voteTimer_Tick);
            // 
            // UIUpdater
            // 
            this.UIUpdater.Interval = 1000;
            this.UIUpdater.Tick += new System.EventHandler(this.UIUpdater_Tick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.OverwritePrompt = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainWindow";
            this.Text = "VoteCDJ Admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.candidateChart)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.voteTimeButton)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.histoChart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.piChart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Label voteTimeLeftLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button startVoteButton;
        private System.Windows.Forms.NumericUpDown voteTimeButton;
        private System.Windows.Forms.Button endVoteButton;
        private System.Windows.Forms.ToolStripMenuItem connexionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nouvelleConnexionToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.ToolStripDropDownButton connectionOptions;
        private System.Windows.Forms.ToolStripMenuItem déconnexionToolStripMenuItem;
        private System.Windows.Forms.Label candidateLabel;
        private System.Windows.Forms.Label candidateNumVotesLabel;
        private System.Windows.Forms.Label candidatePercentVotesLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart candidateChart;
        private System.Windows.Forms.Timer voteTimer;
        public System.Windows.Forms.Timer UIUpdater;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxPost;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart histoChart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button popOutButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart piChart;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label voteHourLabel;
        private System.Windows.Forms.Label totalVotesLabel;
        private System.Windows.Forms.ToolStripMenuItem importPassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportResultsToolStripMenuItem;
        private System.Windows.Forms.Button addCandidatesButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

    }
}

