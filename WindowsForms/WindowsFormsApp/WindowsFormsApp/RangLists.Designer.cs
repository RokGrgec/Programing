namespace WindowsFormsApp
{
    partial class RangLists
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
            this.dvg_PlayersInfo = new System.Windows.Forms.DataGridView();
            this.CPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Favourite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Goals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvg_matchInfo = new System.Windows.Forms.DataGridView();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visitors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AwayTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_playersInfo = new System.Windows.Forms.Label();
            this.lbl_matchInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_PlayersInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_matchInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dvg_PlayersInfo
            // 
            this.dvg_PlayersInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_PlayersInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CPT,
            this.Favourite,
            this.Cards,
            this.Goals});
            this.dvg_PlayersInfo.Location = new System.Drawing.Point(170, 52);
            this.dvg_PlayersInfo.Name = "dvg_PlayersInfo";
            this.dvg_PlayersInfo.Size = new System.Drawing.Size(444, 146);
            this.dvg_PlayersInfo.TabIndex = 0;
            this.dvg_PlayersInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // CPT
            // 
            this.CPT.HeaderText = "CPT";
            this.CPT.Name = "CPT";
            // 
            // Favourite
            // 
            this.Favourite.HeaderText = "Favourite";
            this.Favourite.Name = "Favourite";
            // 
            // Cards
            // 
            this.Cards.HeaderText = "Cards";
            this.Cards.Name = "Cards";
            // 
            // Goals
            // 
            this.Goals.HeaderText = "Golas";
            this.Goals.Name = "Goals";
            // 
            // dvg_matchInfo
            // 
            this.dvg_matchInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_matchInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Location,
            this.Visitors,
            this.HomeTeam,
            this.AwayTeam});
            this.dvg_matchInfo.Location = new System.Drawing.Point(170, 249);
            this.dvg_matchInfo.Name = "dvg_matchInfo";
            this.dvg_matchInfo.Size = new System.Drawing.Size(444, 116);
            this.dvg_matchInfo.TabIndex = 2;
            this.dvg_matchInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            // 
            // Visitors
            // 
            this.Visitors.HeaderText = "Visitors";
            this.Visitors.Name = "Visitors";
            // 
            // HomeTeam
            // 
            this.HomeTeam.HeaderText = "Home Team";
            this.HomeTeam.Name = "HomeTeam";
            // 
            // AwayTeam
            // 
            this.AwayTeam.HeaderText = "Away Team";
            this.AwayTeam.Name = "AwayTeam";
            // 
            // lbl_playersInfo
            // 
            this.lbl_playersInfo.AutoSize = true;
            this.lbl_playersInfo.Location = new System.Drawing.Point(370, 9);
            this.lbl_playersInfo.Name = "lbl_playersInfo";
            this.lbl_playersInfo.Size = new System.Drawing.Size(64, 13);
            this.lbl_playersInfo.TabIndex = 3;
            this.lbl_playersInfo.Text = "Player\'s Info";
            // 
            // lbl_matchInfo
            // 
            this.lbl_matchInfo.AutoSize = true;
            this.lbl_matchInfo.Location = new System.Drawing.Point(370, 218);
            this.lbl_matchInfo.Name = "lbl_matchInfo";
            this.lbl_matchInfo.Size = new System.Drawing.Size(58, 13);
            this.lbl_matchInfo.TabIndex = 4;
            this.lbl_matchInfo.Text = "Match Info";
            // 
            // RangLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_matchInfo);
            this.Controls.Add(this.lbl_playersInfo);
            this.Controls.Add(this.dvg_matchInfo);
            this.Controls.Add(this.dvg_PlayersInfo);
            this.Name = "RangLists";
            this.Text = "RangLists";
            this.Load += new System.EventHandler(this.RangLists_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvg_PlayersInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_matchInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dvg_PlayersInfo;
        public System.Windows.Forms.DataGridView dvg_matchInfo;
        public System.Windows.Forms.DataGridViewTextBoxColumn CPT;
        public System.Windows.Forms.DataGridViewTextBoxColumn Favourite;
        public System.Windows.Forms.DataGridViewTextBoxColumn Cards;
        public System.Windows.Forms.DataGridViewTextBoxColumn Goals;
        public System.Windows.Forms.DataGridViewTextBoxColumn Location;
        public System.Windows.Forms.DataGridViewTextBoxColumn Visitors;
        public System.Windows.Forms.DataGridViewTextBoxColumn HomeTeam;
        public System.Windows.Forms.DataGridViewTextBoxColumn AwayTeam;
        public System.Windows.Forms.Label lbl_playersInfo;
        public System.Windows.Forms.Label lbl_matchInfo;
    }
}