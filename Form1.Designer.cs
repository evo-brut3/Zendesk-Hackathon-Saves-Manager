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
            this.listView1 = new System.Windows.Forms.ListView();
            this.addgame = new System.Windows.Forms.Button();
            this.addprofile = new System.Windows.Forms.Button();
            this.profile = new System.Windows.Forms.ListView();
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
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(440, 15);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(332, 457);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
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
            // 
            // profile
            // 
            this.profile.HideSelection = false;
            this.profile.Location = new System.Drawing.Point(16, 15);
            this.profile.Margin = new System.Windows.Forms.Padding(4);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(332, 457);
            this.profile.TabIndex = 12;
            this.profile.UseCompatibleStateImageBehavior = false;
            this.profile.SelectedIndexChanged += new System.EventHandler(this.Profile_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 577);
            this.Controls.Add(this.deleteprofile);
            this.Controls.Add(this.deletegame);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.addgame);
            this.Controls.Add(this.addprofile);
            this.Controls.Add(this.profile);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deleteprofile;
        private System.Windows.Forms.Button deletegame;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button addgame;
        private System.Windows.Forms.Button addprofile;
        private System.Windows.Forms.ListView profile;
    }
}

