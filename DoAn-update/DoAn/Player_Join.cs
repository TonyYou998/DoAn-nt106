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
    public partial class Player_Join : Form
    {
        private Socket ClientSocket;
        private HorseControl HC;
        private NguoiChoi p;
        private Connection _connect = new Connection();
        public Player_Join(HorseControl HC,NguoiChoi p, Socket S)
        {
            InitializeComponent();
            this.HC = HC;
            this.p = p;
            this.ClientSocket = S;
            UPDATE_BANCO();
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
            Roll_number.BackgroundImage = Properties.Resources.loading;
            Roll_number.BackgroundImageLayout = ImageLayout.Stretch;
            Roll_number.Location = new Point(910, 50);
            Roll_number.BackColor = Color.Transparent;

            //LABLE
            alert.Text = ""; //59, 25
            alert.Location = new Point(59, 25);
            alert.BackColor = Color.Transparent;

            Thread a = new Thread(Player_Join_Receive);
            a.Start();
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
        public string temp, UsernameTest;

        public bool CheckMyHorse(string p, string UserNameTest)
        {
            return (p == UserNameTest);
        }
        public void checkForCreateHorse(string color, string p, string UserNameTest)
        {
            int _start = 0, end= 0,i;

            if (color == "Red" && ListCreatedHorse.RED != true)
            { _start = 0; end = 4; }

            if (color == "Green" && ListCreatedHorse.BLUE != true)
            { _start = 4; end = 8; }

            if (color == "Blue" && ListCreatedHorse.YELLOW != true)
            { _start = 8; end = 12; }

            if (color == "Yellow" && ListCreatedHorse.GREEN != true)
            { _start = 12; end = 16; }

            for (i = _start; i < end; i++)
            {
                CreateHorse(color, Ready[i], i + 1, CheckMyHorse(p, UserNameTest));
            }
        }
        //  checkForCreateHorse(temp);
        Point[] Ready = new Point[]
        {
            new Point { X = 150, Y = 85},
            new Point { X = 240, Y = 85},
            new Point { X = 150, Y = 170 },
            new Point { X = 240, Y = 170 },
            new Point { X = 515, Y = 85},
            new Point { X = 600, Y = 85},
            new Point { X = 515, Y = 170 },
            new Point { X = 600, Y = 170 },
            new Point { X = 150, Y = 440},
            new Point { X = 230, Y = 440},
            new Point { X = 150, Y = 530 },
            new Point { X = 230, Y = 530 },
            new Point { X = 515, Y = 440},
            new Point { X = 600, Y = 440},
            new Point { X = 515, Y = 530 },
            new Point { X = 600, Y = 530 }
        };

 

        private void timeout()
        {
            for (int i = 0; i < 20; i++)
            {
                progressBar1.BeginInvoke((Action)(() => {
                    progressBar1.Value = progressBar1.Value + 5;
                }));
                Thread.Sleep(1000);
            }
            _connect.Sendmsg(ClientSocket, HC);
        }

        private void Player_Join_Receive()
        {
            while (ClientSocket.Connected)
            {
                byte[] bytes = new byte[1024];
                ClientSocket.Receive(bytes);
                string MSG = Encoding.UTF8.GetString(bytes);
                var Jsonmsg = JsonConvert.DeserializeObject<ManagePacket>(MSG);
                if (Jsonmsg.msgtype=="Roll")
                {
                    switch (Jsonmsg.rollNumber)
                    {
                        case 1:
                            Roll_number.BackgroundImage = Properties.Resources._1;
                            break;
                        case 2:
                            Roll_number.BackgroundImage = Properties.Resources._2;
                            break;
                        case 3:
                            Roll_number.BackgroundImage = Properties.Resources._3;
                            break;
                        case 4:
                            Roll_number.BackgroundImage = Properties.Resources._4;
                            break;
                        case 5:
                            Roll_number.BackgroundImage = Properties.Resources._5;
                            break;
                        case 6:
                            Roll_number.BackgroundImage = Properties.Resources._6;
                            break;
                    }
                }
                    

                if (Jsonmsg.HC != null)
                {
                    HC = Jsonmsg.HC;
                    UPDATE_BANCO();
                }

            }
           
        }

        private void Player_Join_Load(object sender, EventArgs e)
        {

        }

        private void UPDATE_BANCO()
        {
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
        private void Roll_number_Click(object sender, EventArgs e)
        {

        }

        private void btn_roll_Click(object sender, EventArgs e)
        {
           
        }
        public void Moving(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            PictureBox a = (PictureBox)sender;
            MessageBox.Show(a.Name);
        }

       
    }
}
