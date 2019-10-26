using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace Zendesk_Hackathon_Saves_Manager
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Input name of the game";
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                Description = "Select the save path directory of the game",
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                locationTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        public string GetNameAndLocation
        {
            get { return (nameTextBox.Text + ";" + locationTextBox.Text); }
        }
    }
}
