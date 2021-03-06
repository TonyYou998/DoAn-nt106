using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
            //FORM GIAO DIEN
            this.Size = new Size(1286, 751);
            this.BackgroundImage = Properties.Resources.MainMenu;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //BTN_START GIAO DIEN
            btn_Start.Size = new Size(150, 75);
            btn_Start.BackgroundImage = Properties.Resources.START;
            btn_Start.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Start.Location = new Point(550, 470);
            btn_Start.BackColor = Color.Transparent;
            //BTN_CONTACT

            btn_Contact.Size = new Size(150, 75);
            btn_Contact.BackgroundImage = Properties.Resources.contact;
            btn_Contact.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Contact.Location = new Point(390, 560);
            btn_Contact.BackColor = Color.Transparent;
            //BTN_EXIT
            btn_Exit.Size = new Size(150, 75);
            btn_Exit.BackgroundImage = Properties.Resources.exit;
            btn_Exit.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Exit.Location = new Point(705, 560);
            btn_Exit.BackColor = Color.Transparent;

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Info_Player info = new Info_Player();
            info.Show();
            info.Disposed += delegate
            {
                this.Dispose();
            };

            this.Hide();
            
        }
    }
}
