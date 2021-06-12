using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Player_Create : Form
    {
        public Player_Create()
        {
            InitializeComponent();
            //FORM GIAO DIEN
            this.Size = new Size(1286, 751);
            this.BackgroundImage = Properties.Resources.BANCO__1_3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //BTN_START GIAO DIEN
            btn_Start.Size = new Size(150, 75);
            btn_Start.BackgroundImage = Properties.Resources.START_2;
            btn_Start.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Start.Location = new Point(980, 380);
            btn_Start.BackColor = Color.Transparent;
            //BTN_ROLL GIAO DIEN
            btn_Roll.Size = new Size(150, 75);
            btn_Roll.BackgroundImage = Properties.Resources.roll;
            btn_Roll.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Roll.Location = new Point(980, 480);
            btn_Roll.BackColor = Color.Transparent;
            //BTN_EXIT GIAO DIEN
            btn_exit.Size = new Size(150, 75);
            btn_exit.BackgroundImage = Properties.Resources.exit;
            btn_exit.BackgroundImageLayout = ImageLayout.Stretch;
            btn_exit.Location = new Point(980, 580);
            btn_exit.BackColor = Color.Transparent;
            //ROLL_NUMBER GIAO DIEN
            Roll_number.Size = new Size(290,290);
            Roll_number.BackgroundImage = Properties.Resources.loading;
            Roll_number.BackgroundImageLayout = ImageLayout.Stretch;
            Roll_number.Location = new Point(910, 50);
            Roll_number.BackColor = Color.Transparent;
            //
            for(int i = 0; i < 4; i++)
            {
                CreateHorse("Red", RedReady[i], i + 1, true);
            }
            Red1.color = "Red";
            Red1.ID = 1;
            Red1.Location = RedReady[0];
            Red1.MySoldier = true;

            Red2.color = "Red";
            Red2.ID = 2;
            Red2.Location = RedReady[1];
            Red2.MySoldier = true;

            Red3.color = "Red";
            Red3.ID = 3;
            Red3.Location = RedReady[2];
            Red3.MySoldier = true;

            Red4.color = "Red";
            Red4.ID = 4;
            Red4.Location = RedReady[3];
            Red4.MySoldier = true;


        }
        //Các biến sử dụng
        public Soldier Red1, Red2, Red3, Red4;
        public struct Soldier
        {
            public string color;
            public int ID;
            public bool MySoldier;
            public Point Location;
        }
        public void CreateHorse(string color, Point X, int ID, bool MyHorse)
        {
            var picture = new PictureBox
            {
                Name =color + ID.ToString(),
                Size = new Size(51, 74),
                Location = X,
                BackColor = Color.Transparent
            };
            this.Controls.Add(picture);
            switch (color) 
            {
                case "Red":
                    picture.Image = Properties.Resources.red;
                    break;
                case "Green":
                    picture.Image = Properties.Resources.green;
                    break;
                case "Yellow":
                    picture.Image = Properties.Resources.yellow;
                    break;
                case "Blue":
                    picture.Image = Properties.Resources.blue;
                    break;
            }
            if (MyHorse == true)
            {
                picture.Click += new EventHandler(Moving);
            }
           
        }
        Point[] Red = new Point[]
        {
            new Point {X = 330, Y = 25 }, new Point {X = 330, Y = 55 }, new Point {X = 330, Y = 90 }, new Point {X = 330, Y = 120 },
            new Point {X = 330, Y = 150 }, new Point {X = 330, Y = 185 }, new Point {X = 330, Y = 235 }, new Point {X = 290, Y = 235 },
            new Point {X = 250, Y = 235 }, new Point {X = 215, Y = 235 }, new Point {X = 180, Y = 235 }, new Point {X = 145, Y = 235 },
            new Point {X = 105, Y = 235 }, new Point {X = 105, Y = 280 }, new Point {X = 105, Y = 330 }, new Point {X = 145, Y = 330 },
            new Point {X = 180, Y = 330 }, new Point {X = 215, Y = 330 }, new Point {X = 250, Y = 330 }, new Point {X = 290, Y = 330 },
            new Point {X = 330, Y = 330 }, new Point {X = 330, Y = 370 }, new Point {X = 330, Y = 400 }, new Point {X = 330, Y = 430 },
            new Point {X = 330, Y = 465 }, new Point {X = 330, Y = 495 }, new Point {X = 330, Y = 530 }, new Point {X = 380, Y = 530 },
            new Point {X = 430, Y = 530 }, new Point {X = 430, Y = 495 }, new Point {X = 430, Y = 465 }, new Point {X = 430, Y = 430 },
            new Point {X = 430, Y = 400 }, new Point {X = 430, Y = 370 }, new Point {X = 430, Y = 330 }, new Point {X = 475, Y = 330 },
            new Point {X = 510, Y = 330 }, new Point {X = 545, Y = 330 }, new Point {X = 585, Y = 330 }, new Point {X = 620, Y = 330 },
            new Point {X = 655, Y = 330 }, new Point {X = 655, Y = 285 }, new Point {X = 650, Y = 235 }, new Point {X = 615, Y = 235 },
            new Point {X = 580, Y = 235 }, new Point {X = 545, Y = 235 }, new Point {X = 510, Y = 235 }, new Point {X = 475, Y = 235 },
            new Point {X = 440, Y = 235 }, new Point {X = 435, Y = 185 }, new Point {X = 435, Y = 150 }, new Point {X = 435, Y = 120 },
            new Point {X = 435, Y = 90 }, new Point {X = 435, Y = 55 }, new Point {X = 435, Y = 25 }, new Point {X = 385, Y = 25 }
        };
        Point[] RedReady = new Point[]
        {
            new Point { X = 150, Y = 85},
            new Point { X = 240, Y = 85},
            new Point { X = 150, Y = 170 },
            new Point { X = 240, Y = 170 }
        };

        private void Player_Create_Activated(object sender, EventArgs e)
        {
            MessageBox.Show("Active");
        }

        private void Player_Create_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Load");
        }

        Point[] RedTop = new Point[]
       {
            new Point { X = 385, Y = 55},
            new Point { X = 385, Y = 90},
            new Point { X = 385, Y = 120 },
            new Point { X = 385, Y = 150 },
            new Point { X = 385, Y = 185 },
            new Point { X = 385, Y = 225 }
       };

 
   
        
        public void Moving(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;
            MessageBox.Show(a.Name);
        }

        
        private void btn_roll_Click(object sender, EventArgs e)
        {
           
        }
    }
}
