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
        private int roomID;
        public Player_Join(HorseControl HC,NguoiChoi p, Socket S, int roomID)
        {
            InitializeComponent();
            this.HC = HC;
            this.p = p;
            this.roomID = roomID;
            this.ClientSocket = S;
            this.Text = p.userName;
            InitBC();
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
        public struct listCreated
        {
            public bool RED;
            public bool GREEN;
            public bool YELLOW;
            public bool BLUE;
        }
        public listCreated ListCreatedHorse;
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

        public bool Started = false, Rolled = true, MyTurn = true;

        private void timeout()
        {
            for (int i = 0; i < 20; i++)
            {
                if (progressBar1.Value == 0) break;
                progressBar1.BeginInvoke((Action)(() => {
                    progressBar1.Value = progressBar1.Value + 5;
                }));
                _connect.Sendmsg(ClientSocket, "ProgressBar", progressBar1.Value.ToString());
                Thread.Sleep(1000);
            }
            progressBar1.BeginInvoke((Action)(() => {
                progressBar1.Value = 0;
            }));
            // Client không làm j cả sẽ gởi lượt đi tiếp theo đến đối thủ
            _connect.Sendmsg(ClientSocket, "Next", roomID.ToString(), HC);
        }

        public void InitBC()
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
                        if (Jsonmsg.msgcontent == p.userName) // Nếu lượt đi bằng với tên người chơi 
                        {
                            MyTurn = true;
                            Rolled = false;
                            //Thread t = new Thread(timeout);
                            //t.Start();
                        }
                        else
                        {
                            MyTurn = false;
                            Rolled = false;
                        }

                        alert.BeginInvoke((Action)(() => {
                            alert.Text = $"Lượt chơi của {Jsonmsg.msgcontent}";
                        }));

                    }

                    else if (s[0] == "Update")
                    {
                        HC = Jsonmsg.HC;
                        updateBC();
                    }

                    continue;
                }


                if (Jsonmsg.msgtype == "Join" && Jsonmsg.HC != null)
                {
                    HC = Jsonmsg.HC;
                    InitBC();
                    continue;
                }

                if (Jsonmsg.msgtype == "Update" && Jsonmsg.HC != null)
                {
                    HC = Jsonmsg.HC;
                    updateBC();
                    continue;
                }

                //if (Jsonmsg.msgtype == "ProgressBar")
                //{
                //    progressBar1.BeginInvoke((Action)(() => {
                //        progressBar1.Value = int.Parse(Jsonmsg.msgcontent);
                //    }));
                //}

            }
        }

        public bool Is_in_readyArea(Point A)
        {
            foreach (var i in Ready)
            {
                if (A == i) return true;
            }
            return false;
        }

        public int ConvertLocationToIndex(Point a, Point[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (a == b[i])
                    return i;
            }
            return -1;
        }

        private void UpdateHorseLocation(PictureBox myHorse, Point LocationToUpdate)
        {
            string name = myHorse.Name;
            string color = name.Substring(0, name.Length - 1);
            int id = int.Parse(name.Substring(name.Length - 1, 1));
            id = id - 1;
            id = id % 4;

            myHorse.Location = LocationToUpdate;
            if (color == "Red") HC.listRedHorse[id].location = LocationToUpdate;
            else if (color == "Green") HC.listGreenHorse[id].location = LocationToUpdate;
            else if (color == "Blue") HC.listBlueHorse[id].location = LocationToUpdate;
            else if (color == "Yellow") HC.listyellowHorse[id].location = LocationToUpdate;
        }
        private void kickAssHorse(int competitor_index, PictureBox myHorse)
        //competitor_index == index của quân cờ sẽ bị đá trên map
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
            _connect.Sendmsg(ClientSocket, "Update", roomID.ToString(), HC);
        }
        public void Moving(object sender, EventArgs e)
        {
            PictureBox Horse = (PictureBox)sender;
            string name = Horse.Name.ToString();
            string color = name.Substring(0, name.Length - 1);

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

                    for (var i = 1; i < RollNumber; i++)
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
                            alert.Text = "Không thể đá chính quân của mình";
                        }
                        else
                        {
                            int DoLechDiDoi = 0;

                            if (color == "Green") DoLechDiDoi = 42;
                            else if (color == "Blue") DoLechDiDoi = 14;
                            else if (color == "Yellow") DoLechDiDoi = 28;

                            int calc = ((DoLechDiDoi - pos) % 56) + RollNumber;

                            if (calc > 55) alert.Text = "Không đi được";

                            else if (calc == 55)
                            {
                                UpdateHorseLocation(Horse, Map[(pos + RollNumber) % 56]);
                                alert.Text = "Win";
                            }
                            else
                            {
                                UpdateHorseLocation(Horse, Map[(pos + RollNumber) % 56]);
                            }
                        }
                    }

                    else alert.Text = "Không đi được";

                }
                else // Đang trong chuồng
                {
                    if (RollNumber == 1 || RollNumber == 6) // quay được 1 hoặc 6
                    {
                        int DoLechDiDoi = 0;

                        if (color == "Green") DoLechDiDoi = 42;
                        else if (color == "Blue") DoLechDiDoi = 14;
                        else if (color == "Yellow") DoLechDiDoi = 28;

                        if (GetColorHorse(DoLechDiDoi) == "") UpdateHorseLocation(Horse, Map[DoLechDiDoi]);
                        // Có quân nào tồn tại ở ngay chỗ xuất quân hay không?
                        else if (GetColorHorse(DoLechDiDoi) != color) kickAssHorse(DoLechDiDoi, Horse);
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
                 
                _connect.Sendmsg(ClientSocket, "Update", roomID.ToString(), HC);
                
            }
        }

        private bool AcceptMoving(int _index)
        {
            if (_index > 55) _index = _index % 56;
            foreach (var j in HC.listRedHorse)
            {
                if (Map[_index] == j.location) return false;
            }
            foreach (var j in HC.listGreenHorse)
            {
                if (Map[_index] == j.location) return false;
            }
            foreach (var j in HC.listBlueHorse)
            {
                if (Map[_index] == j.location) return false;
            }
            foreach (var j in HC.listyellowHorse)
            {
                if (Map[_index] == j.location) return false;
            }
            return true;
        }

        private string GetColorHorse(int _index)
        {
            if (_index > 55) _index = _index % 56;
            foreach (var j in HC.listRedHorse)
            {
                if (Map[_index] == j.location) return j.color;
            }
            foreach (var j in HC.listGreenHorse)
            {
                if (Map[_index] == j.location) return j.color;
            }
            foreach (var j in HC.listBlueHorse)
            {
                if (Map[_index] == j.location) return j.color;
            }
            foreach (var j in HC.listyellowHorse)
            {
                if (Map[_index] == j.location) return j.color;
            }
            return "";
        }
        public int RollNumber = 6;

        public void updateBC()
        {
            if (HC != null)
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
                                    { Controls[i].Location = HC.listRedHorse[id - 1].location; }
                                    ));
                                }
                                else
                                {
                                    Controls[i].Location = HC.listRedHorse[id - 1].location;
                                }

                                break;
                            case "Green":
                                int _id = int.Parse(name.Substring(name.Length - 1, 1));
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new MethodInvoker(() =>
                                    { Controls[i].Location = HC.listGreenHorse[(_id - 1) % 4].location; }
                                    ));
                                }
                                else
                                {
                                    Controls[i].Location = HC.listGreenHorse[(_id - 1) % 4].location;
                                }
                                break;
                            case "Blue":
                                int __id = int.Parse(name.Substring(name.Length - 1, 1));
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new MethodInvoker(() =>
                                    { Controls[i].Location = HC.listBlueHorse[(__id - 1) % 4].location; }
                                    ));
                                }
                                else
                                {
                                    Controls[i].Location = HC.listBlueHorse[(__id - 1) % 4].location;
                                }
                                break;
                            case "Yellow":
                                int ___id = int.Parse(name.Substring(name.Length - 1, 1));
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new MethodInvoker(() =>
                                    { Controls[i].Location = HC.listyellowHorse[(___id - 1) % 4].location; }
                                    ));
                                }
                                else
                                {
                                    Controls[i].Location = HC.listyellowHorse[(___id - 1) % 4].location;
                                }
                                break;
                        }
                    }
                }
            }
        }

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
