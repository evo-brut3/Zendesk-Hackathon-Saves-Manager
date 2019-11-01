namespace Zendesk_Hackathon_Saves_Manager
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.deleteprofile = new System.Windows.Forms.Button();
            this.deletegame = new System.Windows.Forms.Button();
            this.addgame = new System.Windows.Forms.Button();
            this.addprofile = new System.Windows.Forms.Button();
            this.gameListView = new System.Windows.Forms.ListBox();
            this.profileListView = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // deleteprofile
            // 
            this.deleteprofile.Location = new System.Drawing.Point(640, 495);
            this.deleteprofile.Margin = new System.Windows.Forms.Padding(4);
            this.deleteprofile.Name = "deleteprofile";
            this.deleteprofile.Size = new System.Drawing.Size(133, 68);
            this.deleteprofile.TabIndex = 14;
            this.deleteprofile.Text = "Delete Profile";
            this.deleteprofile.UseVisualStyleBackColor = true;
            // 
            // deletegame
            // 
            this.deletegame.Location = new System.Drawing.Point(216, 495);
            this.deletegame.Margin = new System.Windows.Forms.Padding(4);
            this.deletegame.Name = "deletegame";
            this.deletegame.Size = new System.Drawing.Size(133, 68);
            this.deletegame.TabIndex = 13;
            this.deletegame.Text = "Delete Game";
            this.deletegame.UseVisualStyleBackColor = true;
            // 
            // addgame
            // 
            this.addgame.Location = new System.Drawing.Point(16, 495);
            this.addgame.Margin = new System.Windows.Forms.Padding(4);
            this.addgame.Name = "addgame";
            this.addgame.Size = new System.Drawing.Size(133, 68);
            this.addgame.TabIndex = 9;
            this.addgame.Text = "Add Game";
            this.addgame.UseVisualStyleBackColor = true;
            this.addgame.Click += new System.EventHandler(this.Addgame_Click);
            // 
            // addprofile
            // 
            this.addprofile.Location = new System.Drawing.Point(440, 495);
            this.addprofile.Margin = new System.Windows.Forms.Padding(4);
            this.addprofile.Name = "addprofile";
            this.addprofile.Size = new System.Drawing.Size(133, 68);
            this.addprofile.TabIndex = 8;
            this.addprofile.Text = "Add Profile";
            this.addprofile.UseVisualStyleBackColor = true;
            this.addprofile.Click += new System.EventHandler(this.Addprofile_Click);
            // 
            // gameListView
            // 
            this.gameListView.FormattingEnabled = true;
            this.gameListView.ItemHeight = 16;
            this.gameListView.Location = new System.Drawing.Point(17, 20);
            this.gameListView.Name = "gameListView";
            this.gameListView.Size = new System.Drawing.Size(332, 452);
            this.gameListView.TabIndex = 17;
            this.gameListView.SelectedIndexChanged += new System.EventHandler(this.GameListView_SelectedIndexChanged);
            // 
            // profileListView
            // 
            this.profileListView.FormattingEnabled = true;
            this.profileListView.ItemHeight = 16;
            this.profileListView.Location = new System.Drawing.Point(440, 20);
            this.profileListView.Name = "profileListView";
            this.profileListView.Size = new System.Drawing.Size(332, 452);
            this.profileListView.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 577);
            this.Controls.Add(this.profileListView);
            this.Controls.Add(this.gameListView);
            this.Controls.Add(this.deleteprofile);
            this.Controls.Add(this.deletegame);
            this.Controls.Add(this.addgame);
            this.Controls.Add(this.addprofile);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Saves Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deleteprofile;
        private System.Windows.Forms.Button deletegame;
        private System.Windows.Forms.Button addgame;
        private System.Windows.Forms.Button addprofile;
        private System.Windows.Forms.ListBox gameListView;
        private System.Windows.Forms.ListBox profileListView;
    }
}

