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
    public partial class Info_Player : Form
    {
        public Info_Player()
        {
            InitializeComponent();
            //FORM GIAO DIEN
            this.Size = new Size(1286, 751);
            this.BackgroundImage = Properties.Resources.Client__1_;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            //BTN_CONNECT GIAO DIEN
            btn_Connect.Size = new Size(150, 75);
            btn_Connect.BackgroundImage = Properties.Resources.CONNECT;
            btn_Connect.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Connect.Location = new Point(550, 470);
            btn_Connect.BackColor = Color.Transparent;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            this.Hide();
            Player_Choose choose = new Player_Choose();
            choose.Show();
        }
    }
}
