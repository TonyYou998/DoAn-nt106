using Client.Modal;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Player_Create : Form
    {
        private HorseControl HC = new HorseControl();
        private  readonly NguoiChoi p;
        private readonly Socket ClientSocket;
        public Player_Create(NguoiChoi p, Socket S)
        {
            InitializeComponent();
            this.p = p;
            this.ClientSocket = S;
           
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

            Thread a = new Thread(Player_Join_Receive);
            a.Start();
        }
        //Các biến sử dụng
        public Soldier Red1, Red2, Red3, Red4, Green1, Green2, Green3, Green4, Yellow1, Yellow2, Yellow3, Yellow4, Blue1, Blue2, Blue3, Blue4;
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

        private void AddControlSafe(PictureBox picture)
        {
            this.Controls.Add(picture);
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

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => AddControlSafe(picture)));
            }
            else
            {
                AddControlSafe(picture);
            }

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
        Point[] RedTop = new Point[]
       {
            new Point { X = 385, Y = 55},
            new Point { X = 385, Y = 90},
            new Point { X = 385, Y = 120 },
            new Point { X = 385, Y = 150 },
            new Point { X = 385, Y = 185 },
            new Point { X = 385, Y = 225 }
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
                Red1.color = color;
                Red1.ID = 1;
                Red1.Location = RedReady[0];
                Red1.MySoldier = CheckMyHorse(p, UserNameTest);

                Red2.color = color;
                Red2.ID = 2;
                Red2.Location = RedReady[1];
                Red2.MySoldier = CheckMyHorse(p, UserNameTest);

                Red3.color = color;
                Red3.ID = 3;
                Red3.Location = RedReady[2];
                Red3.MySoldier = CheckMyHorse(p, UserNameTest);

                Red4.color = color;
                Red4.ID = 4;
                Red4.Location = RedReady[3];
                Red4.MySoldier = CheckMyHorse(p, UserNameTest);
            }
            if (color == "Blue" && ListCreatedHorse.BLUE != true)
            {
                for (int i = 0; i < 4; i++)
                {
                    CreateHorse(color, BlueReady[i], i + 1, CheckMyHorse(p, UserNameTest));
                }
                Blue1.color = color;
                Blue1.ID = 1;
                Blue1.Location = BlueReady[0];
                Blue1.MySoldier = CheckMyHorse(p, UserNameTest);

                Blue2.color = color;
                Blue2.ID = 2;
                Blue2.Location = BlueReady[1];
                Blue2.MySoldier = CheckMyHorse(p, UserNameTest);

                Blue3.color = color;
                Blue3.ID = 3;
                Blue3.Location = BlueReady[2];
                Blue3.MySoldier = CheckMyHorse(p, UserNameTest);

                Blue4.color = color;
                Blue4.ID = 4;
                Blue4.Location = BlueReady[3];
                Blue4.MySoldier = CheckMyHorse(p, UserNameTest);
            }
            if (color == "Yellow" && ListCreatedHorse.YELLOW != true)
            {
                for (int i = 0; i < 4; i++)
                {
                    CreateHorse(color, YellowReady[i], i + 1, CheckMyHorse(p, UserNameTest));
                }
                Yellow1.color = color;
                Yellow1.ID = 1;
                Yellow1.Location = YellowReady[0];
                Yellow1.MySoldier = CheckMyHorse(p, UserNameTest);

                Yellow2.color = color;
                Yellow2.ID = 2;
                Yellow2.Location = YellowReady[1];
                Yellow2.MySoldier = CheckMyHorse(p, UserNameTest);

                Yellow3.color = color;
                Yellow3.ID = 3;
                Yellow3.Location = YellowReady[2];
                Yellow3.MySoldier = CheckMyHorse(p, UserNameTest);

                Yellow4.color = color;
                Yellow4.ID = 4;
                Yellow4.Location = YellowReady[3];
                Yellow4.MySoldier = CheckMyHorse(p, UserNameTest);
            }
            if (color == "Green" && ListCreatedHorse.GREEN != true)
            {
                for (int i = 0; i < 4; i++)
                {
                    CreateHorse(color, GreenReady[i], i + 1, CheckMyHorse(p, UserNameTest));
                }
                Green1.color = color;
                Green1.ID = 1;
                Green1.Location = GreenReady[0];
                Green1.MySoldier = CheckMyHorse(p, UserNameTest);

                Green2.color = color;
                Green2.ID = 2;
                Green2.Location = GreenReady[1];
                Green2.MySoldier = CheckMyHorse(p, UserNameTest);

                Green3.color = color;
                Green3.ID = 3;
                Green3.Location = GreenReady[2];
                Green3.MySoldier = CheckMyHorse(p, UserNameTest);

                Green4.color = color;
                Green4.ID = 4;
                Green4.Location = GreenReady[3];
                Green4.MySoldier = CheckMyHorse(p, UserNameTest);
            }
        }
        public void updateLocation (Point a,Point b, Point c, Point d)
        {

        }
        public void Player_Join_Receive()
        {
            while (ClientSocket.Connected)
            {
                byte[] bytes = new byte[2048];
                ClientSocket.Receive(bytes);
                string MSG = Encoding.UTF8.GetString(bytes);
                var Jsonmsg = JsonConvert.DeserializeObject<ManagePacket>(MSG);

                if (Jsonmsg.HC != null)
                {
                    HC = Jsonmsg.HC;
                    if (HC.listyellowHorse.Count > 0)
                    {
                        checkForCreateHorse(HC.listyellowHorse[1].color, p.userName, HC.listyellowHorse[1].owner);
                    }
                    if (HC.listGreenHorse.Count > 0)
                    {
                        checkForCreateHorse(HC.listGreenHorse[1].color, p.userName, HC.listGreenHorse[1].owner);
                    }
                    if (HC.listBlueHorse.Count > 0)
                    {
                        checkForCreateHorse(HC.listBlueHorse[1].color, p.userName, HC.listBlueHorse[1].owner);
                    }
                    if (HC.listRedHorse.Count > 0)
                    {
                        checkForCreateHorse(HC.listRedHorse[1].color, p.userName, HC.listRedHorse[1].owner);
                    }
                }


            }

        }




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
