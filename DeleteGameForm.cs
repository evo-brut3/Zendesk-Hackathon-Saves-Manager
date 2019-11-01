using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zendesk_Hackathon_Saves_Manager
{
    public partial class DeleteGameForm : Form
    {
        private bool remove = false;

        public DeleteGameForm()
        {
            InitializeComponent();
        }

        public bool CheckTheAnswer
        {
            get { return remove; }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            remove = true;
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            remove = false;
            this.Close();
        }
    }
}
