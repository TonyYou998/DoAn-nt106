using Client.Modal;
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
        public HorseControl HC { get; set; }
        public NguoiChoi p { get; set; }
        public Player_Create(NguoiChoi p)
        {
            InitializeComponent();
            this.p = p;
            this.HC = HC;
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
            Roll_number.Location = new Point(910, 50);
            Roll_number.BackColor = Color.Transparent;
            //
            Roll_number.BackgroundImageLayout = ImageLayout.Stretch;
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
            updateListCreate(color);

           
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
        public string temp;
        public bool tempMyHorse;
        public bool CheckMyHorse(string p, string UserNameTest)
        {
            return (p == UserNameTest);
        }
        public void checkForCreateHorse(string color, string p, string UserNameTest)
        {
            if (color == "Red" && ListCreatedHorse.RED != true)
            {
                for (int i = 0; i < 4; i++)
                {
                    CreateHorse(color, RedReady[i], i + 1, CheckMyHorse(p, UserNameTest));
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

        private void Player_Create_Activated(object sender, EventArgs e)
        {
         
           
            if (HC.listyellowHorse.Count >0)
            {
                checkForCreateHorse(HC.listyellowHorse[1].color, p.userName, HC.listyellowHorse[1].owner);
            }
            if (HC.listGreenHorse.Count>0)
            {
                checkForCreateHorse(HC.listGreenHorse[1].color, p.userName, HC.listGreenHorse[1].owner);
            }
            if (HC.listBlueHorse.Count>0)
            {
                checkForCreateHorse(HC.listBlueHorse[1].color, p.userName, HC.listBlueHorse[1].owner);
            }
           
            byte[] bytes = new byte[2048];

                //ClientSocket.Receive(bytes);
                string ListHorseAvailable = Encoding.UTF8.GetString(bytes);
                //var Jsonmsg = JsonConvert.DeserializeObject<ManagePacket>(ListHorseAvailable);
               // return Jsonmsg.HC;
           
            

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
