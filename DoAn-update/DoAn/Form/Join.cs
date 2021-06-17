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
    public partial class Join : Form
    {
        private Socket ClientSocket;
        private HorseList HL;
        private NguoiChoi p;
        private Connection _connect = new Connection();
        private int roomID, RollNumber = -1;
        public bool Started = false, Rolled = true, MyTurn = true;

        Point[] Ready = new MapTable().Ready;
        Point[] OnTop = new MapTable().OnTop;
        Point[] Map = new MapTable().Map;

        public Join(HorseList HL,NguoiChoi p, Socket S, int roomID)
        {
            InitializeComponent();
            this.HL = HL;
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
            _connect.Sendmsg(ClientSocket, "Next", roomID.ToString(), HL);
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
        private void UpdateBC()
        {
            if (HL != null)
            {
                for (int i = 0; i < Controls.Count; i++)
                {
                    if (Controls[i].GetType().Name == "PictureBox")
                    {
                        string name = Controls[i].Name;
                        string color = name.Substring(0, name.Length - 1);
                        int id = int.Parse(name.Substring(name.Length - 1, 1));
                        id = (id - 1) % 4;


                        if (this.InvokeRequired)
                        {
                            this.Invoke(new MethodInvoker(() =>
                            {
                                switch (color)
                                {
                                    case "Red":
                                        Controls[i].Location = HL.listRedHorse[id].location;
                                        break;
                                    case "Green":
                                        Controls[i].Location = HL.listGreenHorse[id].location;
                                        break;
                                    case "Blue":
                                        Controls[i].Location = HL.listBlueHorse[id].location;
                                        break;
                                    case "Yellow":
                                        Controls[i].Location = HL.listyellowHorse[id].location;
                                        break;
                                }
                            }
                            ));
                        }
                        else
                        {
                            switch (color)
                            {
                                case "Red":
                                    Controls[i].Location = HL.listRedHorse[id].location;
                                    break;
                                case "Green":
                                    Controls[i].Location = HL.listGreenHorse[id].location;
                                    break;
                                case "Blue":
                                    Controls[i].Location = HL.listBlueHorse[id].location;
                                    break;
                                case "Yellow":
                                    Controls[i].Location = HL.listyellowHorse[id].location;
                                    break;
                            }
                        }
                    }
                }
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
                        HL = Jsonmsg.HL;
                        UpdateBC();
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
                    UpdateBC();
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
            if (color == "Red") HL.listRedHorse[id].location = LocationToUpdate;
            else if (color == "Green") HL.listGreenHorse[id].location = LocationToUpdate;
            else if (color == "Blue") HL.listBlueHorse[id].location = LocationToUpdate;
            else if (color == "Yellow") HL.listyellowHorse[id].location = LocationToUpdate;
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
            _connect.Sendmsg(ClientSocket, "Update", roomID.ToString(), HL);
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

            int DoLechDiDoi = 0, Pos_to_on_top = 0;

            if (color == "Green")
            {
                DoLechDiDoi = 14;
                Pos_to_on_top = 41;
            }
            else if (color == "Blue")
            {
                DoLechDiDoi = 42;
                Pos_to_on_top = 13;
            }
            else if (color == "Yellow")
            {
                DoLechDiDoi = 28;
                Pos_to_on_top = 27;
            }

            int pos = ConvertLocationToIndex(Horse.Location, Map);
            int isOnTop = ConvertLocationToIndex(Horse.Location, OnTop);



            if (true)
            {

                if (Pos_to_on_top == pos || isOnTop != -1)  
                    // Kiểm tra trường hợp ontop đầu tiên
                    // Pos == -1 nghĩa là ko ở trên top
                    alert.Text = "Win"; 

                else if (!Is_in_readyArea(Horse.Location)) // Nếu không có trong chuồng
                {
                    bool move = true;

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

                            int calc = (Math.Abs((DoLechDiDoi + pos) % 56)) + RollNumber;

                            if (calc > 55) alert.Text = "Không đi được";

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
                        int PosXuatquan = 0;

                        if (color == "Green") PosXuatquan = 42;
                        else if (color == "Blue") PosXuatquan = 14;
                        else if (color == "Yellow") PosXuatquan = 28;

                        if (GetColorHorse(DoLechDiDoi) == "") UpdateHorseLocation(Horse, Map[PosXuatquan]);
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
                 
                _connect.Sendmsg(ClientSocket, "Update", roomID.ToString(), HL);
                
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
