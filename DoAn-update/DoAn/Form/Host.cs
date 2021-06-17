﻿using Client.Modal;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Host : Form
    {
        private HorseList HL = new HorseList();
        private readonly NguoiChoi p;
        private readonly Socket ClientSocket;
        private Connection _connect = new Connection();
        private int roomID { get; set; }
        public Host(NguoiChoi p, Socket S,int roomID, HorseList HL)
        {
            InitializeComponent();
            //nhận thông tin user,clientsocket và room id từ form choose
            this.p = p;
            this.ClientSocket = S;
            this.roomID = roomID;
            this.HL = HL;
            this.Text = p.userName;
            InitBC();
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
            Roll_number.Size = new Size(290, 290);
            Roll_number.BackgroundImage = Properties.Resources.loading;
            Roll_number.Location = new Point(910, 50);
            Roll_number.BackColor = Color.Transparent;
            //LABLE
            alert.Text = ""; //59, 25
            alert.Location = new Point(59,25);
            alert.BackColor = Color.Transparent;

            Roll_number.BackgroundImageLayout = ImageLayout.Stretch;

            updateBC();
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

        Point[] Map = new Point[]
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

        Point[] RedTop = new Point[]
       {
            new Point { X = 385, Y = 55},
            new Point { X = 385, Y = 90},
            new Point { X = 385, Y = 120 },
            new Point { X = 385, Y = 150 },
            new Point { X = 385, Y = 185 },
            new Point { X = 385, Y = 225 }
        };

        Point[] Ready = new Point[]
        {
            new Point { X = 150, Y = 80},
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


        public bool Started = false, Rolled = true, MyTurn = true;
       
        public bool CheckMyHorse(string p, string UserNameTest)
        {
            return (p == UserNameTest);
        }
        public void checkForCreateHorse(string color, string p, string UserNameTest)
        {
            int _start = 0, end = 0, i;

            if (color == "Red" && ListCreatedHorse.RED != true)
            { _start = 0; end = 4; }

            if (color == "Green" && ListCreatedHorse.GREEN != true)
            { _start = 4; end = 8; }

            if (color == "Blue" && ListCreatedHorse.BLUE != true)
            { _start = 8; end = 12; }

            if (color == "Yellow" && ListCreatedHorse.YELLOW != true)
            { _start = 12; end = 16; }

            for (i = _start; i < end; i++)
            {
                CreateHorse(color, Ready[i], i + 1, CheckMyHorse(p, UserNameTest));
            }
        }

        public void InitBC()
        {
            if (HL.listyellowHorse.Count > 0)
            {
                checkForCreateHorse(HL.listyellowHorse[1].color, p.userName, HL.listyellowHorse[1].owner);
            }
            if (HL.listGreenHorse.Count > 0)
            {
                checkForCreateHorse(HL.listGreenHorse[1].color, p.userName, HL.listGreenHorse[1].owner);
            }
            if (HL.listBlueHorse.Count > 0)
            {
                checkForCreateHorse(HL.listBlueHorse[1].color, p.userName, HL.listBlueHorse[1].owner);
            }
            if (HL.listRedHorse.Count > 0)
            {
                checkForCreateHorse(HL.listRedHorse[1].color, p.userName, HL.listRedHorse[1].owner);
            }
        }
        private void timeout()
        {
            for(int i =0; i < 20; i++)
            {
                progressBar1.BeginInvoke((Action)(() => { 
                    progressBar1.Value = progressBar1.Value + 5; 
                }));

                if (progressBar1.Value == 0) break;
                Thread.Sleep(1000);
            }
            progressBar1.BeginInvoke((Action)(() => {
                progressBar1.Value = 0;
            }));
            // Client không làm j cả sẽ gởi lượt đi tiếp theo đến đối thủ
            _connect.Sendmsg(ClientSocket,"Update",roomID.ToString(),HL);
        }
        public void Player_Join_Receive()
        {
            while (ClientSocket.Connected)
            {
                byte[] bytes = new byte[2048];
                ClientSocket.Receive(bytes);
                string MSG = Encoding.UTF8.GetString(bytes);
                var Jsonmsg = JsonConvert.DeserializeObject<ManagePacket>(MSG);

                if (Jsonmsg.msgtype == "Action")
                {
                    string[] s = Jsonmsg.msgcontent.Split(':');
                    if (s[0] == "Start")
                    {
                        alert.BeginInvoke((Action)(() => { 
                            alert.Text = $"Trận đấu bắt đầu, lượt chơi của {s[2]}"; 
                        }));

                        MyTurn = true;
                        Rolled = false;
                        //Thread t = new Thread(timeout);
                        //t.Start();  
                    }

                    else if (s[0] == "Roll")
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

                        RollNumber = Jsonmsg.rollNumber;
                        if (s[1] == p.userName) // Nếu lượt đi bằng với tên người chơi 
                        {
                            MyTurn = true;
                            //Thread t = new Thread(timeout);
                            //t.Start();
                        }
                        else
                        {
                            MyTurn = false;
                            Rolled = false;
                        }

                        alert.BeginInvoke((Action)(() => {
                            alert.Text = $"Lượt chơi của {s[1]}";
                        }));

                    }

                    else if(s[0] == "Update")
                    {
                        HL = Jsonmsg.HL;
                        updateBC();
                    }
                    continue;
                }
                

                if (Jsonmsg.msgtype == "Join" && Jsonmsg.HL != null)
                {
                    HL = Jsonmsg.HL;
                    InitBC();
                    continue;
                }

                if (Jsonmsg.msgtype == "Update" && Jsonmsg.HL != null)
                {
                    HL = Jsonmsg.HL;
                    updateBC();
                    continue;
                }

                //if(Jsonmsg.msgtype == "ProgressBar")
                //{
                //    progressBar1.BeginInvoke((Action)(() => {
                //        progressBar1.Value = int.Parse(Jsonmsg.msgcontent);
                //    }));
                //}

            }
        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (Started == false)
            {
                //send gói bắt đầu để nhận gọi next
                //nhận về gói có listHorse, Username được đi

                _connect.Sendmsg(ClientSocket, "Action", $"Start:{roomID}:{p.userName}");
                Started = true;
                btn_Start.Dispose();
            }
        }
        public void updateBC()
        {
            if (HL != null)
            {
                for (int i = 0; i < Controls.Count; i++)
                {
                    if (Controls[i].GetType().Name == "PictureBox")
                    {
                        string name = Controls[i].Name;
                        string color = name.Substring(0, name.Length - 1);
                        switch (color)
                        {
                            case "Red":
                                int id = int.Parse(name.Substring(name.Length - 1, 1));

                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new MethodInvoker(() =>
                                    { Controls[i].Location = HL.listRedHorse[id - 1].location; }
                                    ));
                                }
                                else
                                {
                                    Controls[i].Location = HL.listRedHorse[id - 1].location;
                                }

                                break;
                            case "Green":
                                int _id = int.Parse(name.Substring(name.Length - 1, 1));
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new MethodInvoker(() =>
                                    { Controls[i].Location = HL.listGreenHorse[(_id - 1) % 4].location; }
                                    ));
                                }
                                else
                                {
                                    Controls[i].Location = HL.listGreenHorse[(_id - 1) % 4].location;
                                }
                                break;
                            case "Blue":
                                int __id = int.Parse(name.Substring(name.Length - 1, 1));
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new MethodInvoker(() =>
                                    { Controls[i].Location = HL.listBlueHorse[(__id - 1) % 4].location; }
                                    ));
                                }
                                else
                                {
                                    Controls[i].Location = HL.listBlueHorse[(__id - 1) % 4].location;
                                }
                                break;
                            case "Yellow":
                                int ___id = int.Parse(name.Substring(name.Length - 1, 1));
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new MethodInvoker(() =>
                                    { Controls[i].Location = HL.listyellowHorse[(___id - 1) % 4].location; }
                                    ));
                                }
                                else
                                {
                                    Controls[i].Location = HL.listyellowHorse[(___id - 1) % 4].location;
                                }
                                break;
                        }
                    }
                }
            }
        }
        public void updateHorse (HorseList HL, Point a, int t, string color)
        {
            switch (color)
            {
                case "Red":
                    HL.listRedHorse[t].location = a;
                    break;
                case "Green":
                    HL.listGreenHorse[t].location = a;
                    break;
                case "Yellow":
                    HL.listyellowHorse[t].location = a;
                    break;
                case "Blue":
                    HL.listBlueHorse[t].location = a;
                    break;
            }
        }

        public int ConvertLocationToIndex (Point a,Point[] b)
        {
            for(int i = 0; i < b.Length; i++)
            {
                if (a == b[i])
                    return i;
            }
            return -1;
        }

        public bool checkBehindThisHorese(Point a, HorseList HL, int temp)
        {
            for (int j = 1; j <= temp; j++)
            {
                Point k = Map[ConvertLocationToIndex(a, Map)+j];
                for (int i = 0; i < 4; i++)
                {
                    if (HL.listBlueHorse.Count > 0)
                    {
                        if (HL.listBlueHorse[i].location == k)
                        {
                            return true;
                        }
                    }
                    if (HL.listGreenHorse.Count > 0)
                    {
                        if (HL.listGreenHorse[i].location == k)
                        {
                            return true;
                        }
                    }
                    if (HL.listRedHorse.Count > 0)
                    {
                        if (HL.listRedHorse[i].location == k)
                        {
                            return true;
                        }
                    }
                    if (HL.listyellowHorse.Count > 0)
                    {
                        if (HL.listyellowHorse[i].location == k)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public int checkActionMoving;
        public bool Not_On_Top (string color, Point[] t, Point a)
        {
            for(int i= 0; i < 6; i++)
            {
                if (a == t[i]) 
                {
                    return false;
                }
            }
            return true;
        }
        public bool Is_in_readyArea (Point A)
        {
            for (int i =0; i < 4; i++)
            {
                if (A == Ready[i]) return true;
            }
            return false;
        }
        public void Moving(object sender, EventArgs e)
        {
            PictureBox Horse = (PictureBox)sender;
            string name = Horse.Name.ToString();
            string color = name.Substring(0, name.Length - 1 );

            Random random = new Random();
            int RollNumber = random.Next(1, 6);

            alert.Text = $"Bạn xoay ra quân {RollNumber}";
            //_connect.Sendmsg(ClientSocket, "Action", $"Roll:{roomID}:{RollNumber}:{p.userName}");

            if (true)
            {
                if (!Is_in_readyArea(Horse.Location)) // Nếu không có trong chuồng
                {
                    bool move = true;
                    int pos = ConvertLocationToIndex(Horse.Location, Map);

                    for (var i = 1; i < RollNumber; i++) // kiểm tra dọc đường có quân nào cản đường hay không
                    {
                        int _index = (i + pos) > 55 ? (i + pos) % 56 : (i + pos);
                        if (!AcceptMoving(_index)) move = false;
                    }


                    if (move)
                    {
                        if (GetColorHorse(RollNumber + pos) != color && GetColorHorse(RollNumber + pos) != "")
                        {
                            kickAssHorse(RollNumber + pos, Horse);
                        }
                        else if (GetColorHorse(RollNumber + pos) == color)
                        {
                            alert.Text = "Không đi được";
                        }
                        else
                        {
                            int calc = pos + RollNumber;
                            if (calc > 55) alert.Text = "Không đi được";
                            else if (calc == 55)
                            {
                                UpdateHorseLocation(Horse, Map[calc]);
                                MessageBox.Show("WIN");
                            }
                            else
                            {
                                UpdateHorseLocation(Horse, Map[calc]);
                            }
                        }
                    }

                    else alert.Text = "Không đi được";

                }
                else // Đang trong chuồng
                {
                    if (RollNumber == 1 || RollNumber == 6) // quay được 1 hoặc 6
                    {
                        if (GetColorHorse(0) == "") UpdateHorseLocation(Horse, Map[0]);
                        // Có quân nào tồn tại ở ngay chỗ xuất quân hay không?
                        else if (GetColorHorse(0) != color) kickAssHorse(0, Horse);
                        // Màu của quân đó có phải quân địch hay không
                        else
                        {
                            alert.Text = "Không đi được";
                        }

                    }

                    else
                    {
                        alert.Text = "Phải xoay ra mặt 1 hoặc 6 thì mới xuất quân được";
                    }
                }
       
            }
            
            _connect.Sendmsg(ClientSocket, "Update", roomID.ToString(), HL);
        }

        private bool AcceptMoving(int _index)
        {
            if (_index > 55) _index = _index % 56;
            foreach (var j in HL.listRedHorse)
            {
                if (Map[_index] == j.location) return false;
            }
            foreach (var j in HL.listGreenHorse)
            {
                if (Map[_index] == j.location) return false;
            }
            foreach (var j in HL.listBlueHorse)
            {
                if (Map[_index] == j.location) return false;
            }
            foreach (var j in HL.listyellowHorse)
            {
                if (Map[_index] == j.location) return false;
            }
            return true;
        }

        private string GetColorHorse(int _index)
        {
            if (_index > 55) _index = _index % 56;
            foreach (var j in HL.listRedHorse)
            {
                if (Map[_index] == j.location) return j.color;
            }
            foreach (var j in HL.listGreenHorse)
            {
                if (Map[_index] == j.location) return j.color;
            }
            foreach (var j in HL.listBlueHorse)
            {
                if (Map[_index] == j.location) return j.color;
            }
            foreach (var j in HL.listyellowHorse)
            {
                if (Map[_index] == j.location) return j.color;
            }
            return "";
        }

        private void UpdateHorseLocation(PictureBox myHorse, Point LocationToUpdate)
        {
            string name = myHorse.Name;
            string color = name.Substring(0, name.Length - 1);
            int id = int.Parse(name.Substring(name.Length - 1, 1));
            id = id - 1;
            id = id % 4;

            myHorse.Location = LocationToUpdate;
            if (color == "Red") HL.listRedHorse[id].location = LocationToUpdate;
            else if (color == "Green") HL.listGreenHorse[id].location = LocationToUpdate;
            else if (color == "Blue") HL.listBlueHorse[id].location = LocationToUpdate;
            else if (color == "Yellow") HL.listyellowHorse[id].location = LocationToUpdate;
        }
        private void kickAssHorse(int competitor_index, PictureBox myHorse)
        {
            if (competitor_index > 55) competitor_index = competitor_index % 56;
            for (var i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].Location == Map[competitor_index])
                {
                    string name = Controls[i].Name; // Tên của quân cờ sẽ bị đá
                    string color = name.Substring(0, name.Length - 1); // Màu của quân cờ sẽ bị đá
                    int id = int.Parse(name.Substring(name.Length - 1, 1)); // Id của quân cờ sẽ bị đá
                    id = id - 1;

                    UpdateHorseLocation((PictureBox)Controls[i], Ready[id]);
                    UpdateHorseLocation(myHorse, Map[competitor_index]);
                    break;
                }
            }
            _connect.Sendmsg(ClientSocket, "Update", roomID.ToString(), HL);
        }

        public int RollNumber=6;
        private void btn_roll_Click(object sender, EventArgs e)
        {
            if (!Rolled && MyTurn)
            {
                Rolled = true;
                Random random = new Random();
                RollNumber = random.Next(1, 6);
                _connect.Sendmsg(ClientSocket, "Action", $"Roll:{roomID}:{RollNumber}:{p.userName}");
            }
        }
    }
}