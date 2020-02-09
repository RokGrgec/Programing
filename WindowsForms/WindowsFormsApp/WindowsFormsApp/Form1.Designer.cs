using System;

namespace WindowsFormsApp
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_ranglist = new System.Windows.Forms.Button();
            this.pnl_allplayers = new System.Windows.Forms.Panel();
            this.dgv_allplayers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_favplayers = new System.Windows.Forms.Panel();
            this.pb_loading = new System.Windows.Forms.PictureBox();
            this.dgv_favplayers = new System.Windows.Forms.DataGridView();
            this.favPlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerIsCaptain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_languages = new System.Windows.Forms.Button();
            this.pnl_allplayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_allplayers)).BeginInit();
            this.pnl_favplayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_loading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_favplayers)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(351, 203);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chose Your Team";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Confirm Choice";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_ranglist
            // 
            this.btn_ranglist.Location = new System.Drawing.Point(280, 401);
            this.btn_ranglist.Name = "btn_ranglist";
            this.btn_ranglist.Size = new System.Drawing.Size(75, 23);
            this.btn_ranglist.TabIndex = 5;
            this.btn_ranglist.Text = "Rang Lists";
            this.btn_ranglist.UseVisualStyleBackColor = true;
            this.btn_ranglist.Click += new System.EventHandler(this.btn_ranglist_Click);
            // 
            // pnl_allplayers
            // 
            this.pnl_allplayers.Controls.Add(this.dgv_allplayers);
            this.pnl_allplayers.Location = new System.Drawing.Point(370, 34);
            this.pnl_allplayers.Name = "pnl_allplayers";
            this.pnl_allplayers.Size = new System.Drawing.Size(315, 341);
            this.pnl_allplayers.TabIndex = 4;
            // 
            // dgv_allplayers
            // 
            this.dgv_allplayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_allplayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgv_allplayers.Location = new System.Drawing.Point(3, 6);
            this.dgv_allplayers.Name = "dgv_allplayers";
            this.dgv_allplayers.Size = new System.Drawing.Size(309, 338);
            this.dgv_allplayers.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Number";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Position";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "CPT";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // pnl_favplayers
            // 
            this.pnl_favplayers.Controls.Add(this.pb_loading);
            this.pnl_favplayers.Controls.Add(this.dgv_favplayers);
            this.pnl_favplayers.Location = new System.Drawing.Point(28, 34);
            this.pnl_favplayers.Name = "pnl_favplayers";
            this.pnl_favplayers.Size = new System.Drawing.Size(327, 341);
            this.pnl_favplayers.TabIndex = 3;
            // 
            // pb_loading
            // 
            this.pb_loading.BackgroundImage = global::WindowsFormsApp.Properties.Resources.loading;
            this.pb_loading.Location = new System.Drawing.Point(22, 6);
            this.pb_loading.Name = "pb_loading";
            this.pb_loading.Size = new System.Drawing.Size(621, 358);
            this.pb_loading.TabIndex = 7;
            this.pb_loading.TabStop = false;
            this.pb_loading.Click += new System.EventHandler(this.pb_loading_Click);
            // 
            // dgv_favplayers
            // 
            this.dgv_favplayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_favplayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.favPlayerName,
            this.playerNumber,
            this.playerPosition,
            this.playerIsCaptain});
            this.dgv_favplayers.Location = new System.Drawing.Point(1, 0);
            this.dgv_favplayers.Name = "dgv_favplayers";
            this.dgv_favplayers.Size = new System.Drawing.Size(323, 338);
            this.dgv_favplayers.TabIndex = 0;
            // 
            // favPlayerName
            // 
            this.favPlayerName.HeaderText = "Name";
            this.favPlayerName.Name = "favPlayerName";
            // 
            // playerNumber
            // 
            this.playerNumber.HeaderText = "Number";
            this.playerNumber.Name = "playerNumber";
            // 
            // playerPosition
            // 
            this.playerPosition.HeaderText = "Position";
            this.playerPosition.Name = "playerPosition";
            // 
            // playerIsCaptain
            // 
            this.playerIsCaptain.HeaderText = "CPT";
            this.playerIsCaptain.Name = "playerIsCaptain";
            // 
            // btn_languages
            // 
            this.btn_languages.Location = new System.Drawing.Point(373, 400);
            this.btn_languages.Name = "btn_languages";
            this.btn_languages.Size = new System.Drawing.Size(75, 23);
            this.btn_languages.TabIndex = 6;
            this.btn_languages.Text = "Settings";
            this.btn_languages.UseVisualStyleBackColor = true;
            this.btn_languages.Click += new System.EventHandler(this.btn_languages_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 535);
            this.Controls.Add(this.btn_languages);
            this.Controls.Add(this.btn_ranglist);
            this.Controls.Add(this.pnl_allplayers);
            this.Controls.Add(this.pnl_favplayers);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnl_allplayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_allplayers)).EndInit();
            this.pnl_favplayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_loading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_favplayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btn_ranglist;
        public System.Windows.Forms.Panel pnl_allplayers;
        public System.Windows.Forms.DataGridView dgv_allplayers;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        public System.Windows.Forms.Panel pnl_favplayers;
        public System.Windows.Forms.DataGridView dgv_favplayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn favPlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerIsCaptain;
        public System.Windows.Forms.Button btn_languages;
        private System.Windows.Forms.PictureBox pb_loading;
    }
}

