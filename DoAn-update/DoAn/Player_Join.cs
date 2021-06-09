using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class Player_Join : Form
    {
        public Player_Join()
        {
            InitializeComponent();
            //FORM GIAO DIEN
            this.Size = new Size(1286, 751);
            this.BackgroundImage = Properties.Resources.BANCO__1_3;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            //BTN_ROLL GIAO DIEN
            btn_Roll.Size = new Size(150, 75);
            btn_Roll.BackgroundImage = Properties.Resources.roll;
            btn_Roll.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Roll.Location = new Point(980, 380);
            btn_Roll.BackColor = Color.Transparent;
            //BTN_EXIT GIAO DIEN
            btn_exit.Size = new Size(150, 75);
            btn_exit.BackgroundImage = Properties.Resources.exit;
            btn_exit.BackgroundImageLayout = ImageLayout.Zoom;
            btn_exit.Location = new Point(980, 480);
            btn_exit.BackColor = Color.Transparent;
            //ROLL_NUMBER GIAO DIEN
            Roll_number.Size = new Size(290, 290);
            Roll_number.BackgroundImage = Properties.Resources._1;
            Roll_number.BackgroundImageLayout = ImageLayout.Zoom;
            Roll_number.Location = new Point(910, 50);
            Roll_number.BackColor = Color.Transparent;
        }
       
        Point[] Green = new Point[]
        {
        new Point {X = 650, Y = 235 },
        new Point {X = 615, Y = 235 },
        new Point {X = 580, Y = 235 },
        new Point {X = 545, Y = 235 },
        new Point {X = 510, Y = 235 },
        new Point {X = 475, Y = 235 },
        new Point {X = 440, Y = 235 },
        new Point {X = 435, Y = 185 },
        new Point {X = 435, Y = 150 },
        new Point {X = 435, Y = 120 },
        new Point {X = 435, Y = 90 },
        new Point {X = 435, Y = 55 },
        new Point {X = 435, Y = 25 },
        new Point {X = 385, Y = 25 },
        new Point {X = 330, Y = 25 },
        new Point {X = 330, Y = 55 },
        new Point {X = 330, Y = 90 },
        new Point {X = 330, Y = 120 },
        new Point {X = 330, Y = 150 },
        new Point {X = 330, Y = 185 },
        new Point {X = 330, Y = 235 },
        new Point {X = 290, Y = 235 },
        new Point {X = 250, Y = 235 },
        new Point {X = 215, Y = 235 },
        new Point {X = 180, Y = 235 },
        new Point {X = 145, Y = 235 },
        new Point {X = 105, Y = 235 },
        new Point {X = 105, Y = 280 },
        new Point {X = 105, Y = 330 },
        new Point {X = 145, Y = 330 },
        new Point {X = 180, Y = 330 },
        new Point {X = 215, Y = 330 },
        new Point {X = 250, Y = 330 },
        new Point {X = 290, Y = 330 },
        new Point {X = 330, Y = 330 },
        new Point {X = 330, Y = 370 },
        new Point {X = 330, Y = 400 },
        new Point {X = 330, Y = 430 },
        new Point {X = 330, Y = 465 },
        new Point {X = 330, Y = 495 },
        new Point {X = 330, Y = 530 },
        new Point {X = 380, Y = 530 },
        new Point {X = 430, Y = 530 },
        new Point {X = 430, Y = 495 },
        new Point {X = 430, Y = 465 },
        new Point {X = 430, Y = 430 },
        new Point {X = 430, Y = 400 },
        new Point {X = 430, Y = 370 },
        new Point {X = 430, Y = 330 },
        new Point {X = 475, Y = 330 },
        new Point {X = 510, Y = 330 },
        new Point {X = 545, Y = 330 },
        new Point {X = 585, Y = 330 },
        new Point {X = 620, Y = 330 },
        new Point {X = 655, Y = 330 },
        new Point {X = 655, Y = 285 },
        };
        Point[] GreenReady = new Point[]
        {
            new Point { X = 515, Y = 85},
            new Point { X = 600, Y = 85},
            new Point { X = 515, Y = 170 },
            new Point { X = 600, Y = 170 }
        };

        private int temp, g1=-1, g2 = -1, g3 = -1, g4 = -1;

        private void Player_Join_Load(object sender, EventArgs e)
        {

        }

        private void btn_roll_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            temp = random.Next(1, 6);
        }
        public void Moving(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            PictureBox a = (PictureBox)sender;
            if (a.Name == "Green0")
            {
                a.Location = Green[g1 + temp];
                g1 += temp;
            }
            if (a.Name == "Green1")
            {
                a.Location = Green[g2 + temp];
                g2 += temp;
            }
            if (a.Name == "Green2")
            {
                a.Location = Green[g2 + temp];
                g3 += temp;
            }
            if (a.Name == "Green3")
            {
                a.Location = Green[g3 + temp];
                g4 += temp;
            }

        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            Point[] temp = new Point[]
            {
               new Point {X = 0, Y= 0}

            };
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        temp[0] = GreenReady[i];
                        break;
                    case 1:
                        temp[0] = GreenReady[i];
                        break;
                    case 2:
                        temp[0] = GreenReady[i];
                        break;
                    case 3:
                        temp[0] = GreenReady[i];
                        break;
                }
                var picture = new PictureBox
                {
                    Name = "Green" + i.ToString(),
                    Size = new Size(51, 74),
                    Location = temp[0],
                    Image = Properties.Resources.green,
                };
                picture.Click += new EventHandler(Moving);
                this.Controls.Add(picture);
                picture.BackColor = Color.Transparent;
            }
            
        }
    }
}
