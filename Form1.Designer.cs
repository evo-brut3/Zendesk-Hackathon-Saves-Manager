namespace Zendesk_Hackathon_Saves_Manager
{
    partial class Form1
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
            this.deleteprofile.Location = new System.Drawing.Point(480, 402);
            this.deleteprofile.Name = "deleteprofile";
            this.deleteprofile.Size = new System.Drawing.Size(100, 55);
            this.deleteprofile.TabIndex = 14;
            this.deleteprofile.Text = "Delete Profile";
            this.deleteprofile.UseVisualStyleBackColor = true;
            // 
            // deletegame
            // 
            this.deletegame.Location = new System.Drawing.Point(162, 402);
            this.deletegame.Name = "deletegame";
            this.deletegame.Size = new System.Drawing.Size(100, 55);
            this.deletegame.TabIndex = 13;
            this.deletegame.Text = "Delete Game";
            this.deletegame.UseVisualStyleBackColor = true;
            // 
            // addgame
            // 
            this.addgame.Location = new System.Drawing.Point(12, 402);
            this.addgame.Name = "addgame";
            this.addgame.Size = new System.Drawing.Size(100, 55);
            this.addgame.TabIndex = 9;
            this.addgame.Text = "Add Game";
            this.addgame.UseVisualStyleBackColor = true;
            this.addgame.Click += new System.EventHandler(this.Addgame_Click);
            // 
            // addprofile
            // 
            this.addprofile.Location = new System.Drawing.Point(330, 402);
            this.addprofile.Name = "addprofile";
            this.addprofile.Size = new System.Drawing.Size(100, 55);
            this.addprofile.TabIndex = 8;
            this.addprofile.Text = "Add Profile";
            this.addprofile.UseVisualStyleBackColor = true;
            // 
            // gameListView
            // 
            this.gameListView.FormattingEnabled = true;
            this.gameListView.Location = new System.Drawing.Point(12, 16);
            this.gameListView.Name = "gameListView";
            this.gameListView.Size = new System.Drawing.Size(250, 368);
            this.gameListView.TabIndex = 15;
            // 
            // profileListView
            // 
            this.profileListView.FormattingEnabled = true;
            this.profileListView.Location = new System.Drawing.Point(330, 16);
            this.profileListView.Name = "profileListView";
            this.profileListView.Size = new System.Drawing.Size(250, 368);
            this.profileListView.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 469);
            this.Controls.Add(this.profileListView);
            this.Controls.Add(this.gameListView);
            this.Controls.Add(this.deleteprofile);
            this.Controls.Add(this.deletegame);
            this.Controls.Add(this.addgame);
            this.Controls.Add(this.addprofile);
            this.Name = "Form1";
            this.Text = "Form1";
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

