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
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(330, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(250, 372);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // addgame
            // 
            this.addgame.Location = new System.Drawing.Point(12, 402);
            this.addgame.Name = "addgame";
            this.addgame.Size = new System.Drawing.Size(100, 55);
            this.addgame.TabIndex = 9;
            this.addgame.Text = "Add Game";
            this.addgame.UseVisualStyleBackColor = true;
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
            // profile
            // 
            this.profile.HideSelection = false;
            this.profile.Location = new System.Drawing.Point(12, 12);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(250, 372);
            this.profile.TabIndex = 12;
            this.profile.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 469);
            this.Controls.Add(this.deleteprofile);
            this.Controls.Add(this.deletegame);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.addgame);
            this.Controls.Add(this.addprofile);
            this.Controls.Add(this.profile);
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

