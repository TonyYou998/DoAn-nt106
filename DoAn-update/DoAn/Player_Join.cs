using Client.Modal;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class Player_Join : Form
    {
        public HorseControl HC { get; set; }
        public NguoiChoi p { get; set; }
        public Player_Join(HorseControl HC,NguoiChoi p)
        {
            InitializeComponent();
            this.HC = HC;
            this.p = p;
            //FORM GIAO DIEN
            this.Size = new Size(1286, 751);
            this.BackgroundImage = Properties.Resources.BANCO__1_3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //BTN_ROLL GIAO DIEN
            btn_Roll.Size = new Size(150, 75);
            btn_Roll.BackgroundImage = Properties.Resources.roll;
            btn_Roll.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Roll.Location = new Point(980, 380);
            btn_Roll.BackColor = Color.Transparent;
            //BTN_EXIT GIAO DIEN
            btn_exit.Size = new Size(150, 75);
            btn_exit.BackgroundImage = Properties.Resources.exit;
            btn_exit.BackgroundImageLayout = ImageLayout.Stretch;
            btn_exit.Location = new Point(980, 480);
            btn_exit.BackColor = Color.Transparent;
            //ROLL_NUMBER GIAO DIEN
            Roll_number.Size = new Size(290, 290);
            Roll_number.BackgroundImage = Properties.Resources._1;
            Roll_number.BackgroundImageLayout = ImageLayout.Stretch;
            Roll_number.Location = new Point(910, 50);
            Roll_number.BackColor = Color.Transparent;
        }
        public Soldier Red1, Red2, Red3, Red4;
        public struct Soldier
        {
            public string color;
            public int ID;
            public bool MySoldier;
            public Point Location;
        }
        public struct listCreated
        {
            public bool RED;
            public bool GREEN;
            public bool YELLOW;
            public bool BLUE;
        }
        public listCreated ListCreatedHorse;
        public void updateListCreate(string color)
        {
            switch (color)
            {
                case "Red":
                    ListCreatedHorse.RED = true;
                    break;
                case "Green":
                    ListCreatedHorse.GREEN = true;
                    break;
                case "Blue":
                    ListCreatedHorse.BLUE = true;
                    break;
                case "Yellow":
                    ListCreatedHorse.YELLOW = true;
                    break;


            }
        }
        public void CreateHorse(string color, Point X, int ID, bool MyHorse)
        {
            var picture = new PictureBox
            {
                Name = color + ID.ToString(),
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
            updateListCreate(color);


        }
        public string temp, UsernameTest;

        public bool CheckMyHorse(string p, string UserNameTest)
        {
            if (p == UserNameTest)
                return true;
            else return false;
        }
        public void checkForCreateHorse(string color, string p, string UserNameTest)
        {
            if (color == "Red" && ListCreatedHorse.RED != true)
            {
                for (int i = 0; i < 4; i++)
                {
                    CreateHorse(color, RedReady[i], i + 1, CheckMyHorse(p,UserNameTest));
                }
            }
            if (color == "Blue" && ListCreatedHorse.BLUE != true)
            {
                for (int i = 0; i < 4; i++)
                {
                    CreateHorse(color, BlueReady[i], i + 1, CheckMyHorse(p, UserNameTest));
                }
            }
            if (color == "Yellow" && ListCreatedHorse.YELLOW != true)
            {
                for (int i = 0; i < 4; i++)
                {
                    CreateHorse(color, YellowReady[i], i + 1, CheckMyHorse(p, UserNameTest));
                }
            }
            if (color == "Green" && ListCreatedHorse.GREEN != true)
            {
                for (int i = 0; i < 4; i++)
                {
                    CreateHorse(color, GreenReady[i], i + 1, CheckMyHorse(p, UserNameTest));
                }
            }
        }
        //  checkForCreateHorse(temp);
        Point[] RedReady = new Point[]
        {
            new Point { X = 150, Y = 85},
            new Point { X = 240, Y = 85},
            new Point { X = 150, Y = 170 },
            new Point { X = 240, Y = 170 }
        };
        Point[] GreenReady = new Point[]
      {
            new Point { X = 515, Y = 85},
            new Point { X = 600, Y = 85},
            new Point { X = 515, Y = 170 },
            new Point { X = 600, Y = 170 }
      };
        Point[] BlueReady = new Point[]
      {
            new Point { X = 150, Y = 440},
            new Point { X = 230, Y = 440},
            new Point { X = 150, Y = 530 },
            new Point { X = 230, Y = 530 }
      };
        Point[] YellowReady = new Point[]
      {
            new Point { X = 515, Y = 440},
            new Point { X = 600, Y = 440},
            new Point { X = 515, Y = 530 },
            new Point { X = 600, Y = 530 }
      };

        private void Player_Join_Activated(object sender, EventArgs e)
        {
            // checkForCreateHorse(temp, p., UsernameTest);
            MessageBox.Show(p.userName);
        }

        private void Roll_number_Click(object sender, EventArgs e)
        {

        }

        private void btn_roll_Click(object sender, EventArgs e)
        {
            Random random = new Random();
           // temp = random.Next(1, 6);
        }
        public void Moving(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            PictureBox a = (PictureBox)sender;
        }

       
    }
}
