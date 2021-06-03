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
    public partial class Player_Choose : Form
    {
        public Player_Choose()
        {
            InitializeComponent();
        }

        private void btn_Create_Room_Click(object sender, EventArgs e)
        {
            this.Hide();
            Player_Create create = new Player_Create();
            create.Show();
        }

        private void btn_Join_Room_Click(object sender, EventArgs e)
        {
            this.Hide();
            Player_Join join = new Player_Join();
            join.Show();
        }
    }
}
