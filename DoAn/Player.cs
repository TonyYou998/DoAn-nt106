using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Info_Player info = new Info_Player();
            info.Show();
            this.Hide();
        }
    }
}
