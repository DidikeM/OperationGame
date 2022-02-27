using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Forms
{
    public partial class LaunchForm : Form
    {
        public LaunchForm()
        {
            InitializeComponent();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            using (GameForm gameForm = new GameForm(0))
            {
                this.Hide();
                gameForm.ShowDialog();
                this.Show();
            }
        }

        private void btnAdvenced_Click(object sender, EventArgs e)
        {
            using (GameForm gameForm = new GameForm(1))
            {
                this.Hide();
                gameForm.ShowDialog();
                this.Show();
            }
        }
    }
}
