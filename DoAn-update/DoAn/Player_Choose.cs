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
            //FORM GIAO DIEN
            this.Size = new Size(1286, 751);
            this.BackgroundImage = Properties.Resources.Client__1_;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            //BTN_CREATE_ROOM GIAO DIEN
            btn_Create_Room.Size = new Size(150, 75);
            btn_Create_Room.BackgroundImage = Properties.Resources.CREATE;
            btn_Create_Room.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Create_Room.Location = new Point(430, 435);
            btn_Create_Room.BackColor = Color.Transparent;
            //BTN_JOIN_ROOM GIAO DIEN
            btn_Join_Room.Size = new Size(150, 75);
            btn_Join_Room.BackgroundImage = Properties.Resources.JOIN;
            btn_Join_Room.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Join_Room.Location = new Point(685, 435);
            btn_Join_Room.BackColor = Color.Transparent;
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
