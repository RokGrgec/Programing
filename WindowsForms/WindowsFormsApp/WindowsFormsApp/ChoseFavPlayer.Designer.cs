namespace WindowsFormsApp
{
    partial class ChoseFavPlayer
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
            this.lbl_choseFavPlayer = new System.Windows.Forms.Label();
            this.btn_choseFavPlayer = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lbl_choseFavPlayer
            // 
            this.lbl_choseFavPlayer.AutoSize = true;
            this.lbl_choseFavPlayer.Location = new System.Drawing.Point(296, 22);
            this.lbl_choseFavPlayer.Name = "lbl_choseFavPlayer";
            this.lbl_choseFavPlayer.Size = new System.Drawing.Size(149, 13);
            this.lbl_choseFavPlayer.TabIndex = 1;
            this.lbl_choseFavPlayer.Text = "Chose your 3 favourite players";
            // 
            // btn_choseFavPlayer
            // 
            this.btn_choseFavPlayer.Location = new System.Drawing.Point(329, 486);
            this.btn_choseFavPlayer.Name = "btn_choseFavPlayer";
            this.btn_choseFavPlayer.Size = new System.Drawing.Size(75, 23);
            this.btn_choseFavPlayer.TabIndex = 2;
            this.btn_choseFavPlayer.Text = "Confirm";
            this.btn_choseFavPlayer.UseVisualStyleBackColor = true;
            this.btn_choseFavPlayer.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(266, 60);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(236, 394);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // ChoseFavPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 567);
            this.Controls.Add(this.btn_choseFavPlayer);
            this.Controls.Add(this.lbl_choseFavPlayer);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "ChoseFavPlayer";
            this.Text = "ChoseFavPlayer";
            this.Load += new System.EventHandler(this.ChoseFavPlayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lbl_choseFavPlayer;
        public System.Windows.Forms.Button btn_choseFavPlayer;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}