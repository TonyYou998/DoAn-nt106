using Client.Modal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Player_Choose : Form
    {

        private NguoiChoi p;

        private Socket ClientSocket;
        
        private Connection _connect = new Connection();
        public Player_Choose(Socket ClientSocket , NguoiChoi nguoiChoi)
        {

            InitializeComponent();
            
            p = nguoiChoi;
            this.ClientSocket = ClientSocket;
            PlayerName.Text = p.userName;

            //FORM GIAO DIEN
            this.Size = new Size(1286, 751);
            this.BackgroundImage = Properties.Resources.Client__1_;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //BTN_CREATE_ROOM GIAO DIEN
            btn_Create_Room.Size = new Size(150, 75);
            btn_Create_Room.BackgroundImage = Properties.Resources.CREATE;
            btn_Create_Room.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Create_Room.Location = new Point(430, 435);
            btn_Create_Room.BackColor = Color.Transparent;
            //BTN_JOIN_ROOM GIAO DIEN
            btn_Join_Room.Size = new Size(150, 75);
            btn_Join_Room.BackgroundImage = Properties.Resources.JOIN;
            btn_Join_Room.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Join_Room.Location = new Point(685, 435);
            btn_Join_Room.BackColor = Color.Transparent;
            //Giao dien khac

            lbName.Size = new Size(157, 41);
            lbName.Location = new Point(394, 194);
            PlayerName.Size = new Size(325, 38);
            PlayerName.Font = new Font("Arial", 22, FontStyle.Bold);
            PlayerName.Location = new Point(580, 197);

            lbRoomName.Size = new Size(157, 41);
            lbRoomName.Location = new Point(370, 312);
            RoomName.Size = new Size(325, 38);
            RoomName.Font = new Font("Arial", 22, FontStyle.Bold);
            RoomName.Location = new Point(595, 315);
        }


        private void btn_Create_Room_Click(object sender, EventArgs e)
        {
            Room r = new Room();
           Point p1 = new Point(150,80);
            Point p2 = new Point(240, 85);
            Point p3 = new Point(150, 170);
            Point p4 = new Point(240, 170);
            Horse h1 = new Horse(p1, "Red", 1,p.userName);
            Horse h2 = new Horse(p2, "Red", 2,p.userName);
            Horse h3 = new Horse(p3, "Red", 3,p.userName);
            Horse h4 = new Horse(p4, "Red", 4,p.userName);
            List<Horse> listHorse=new List<Horse>();
            listHorse.Add(h1);
            listHorse.Add(h2);
            listHorse.Add(h3);
            listHorse.Add(h4);
            if (r.setRoomName(RoomName))
            {
                if(ClientSocket.Connected)
                {   
                    try
                    {
                        _connect.Sendmsg(ClientSocket,"CreateRoom", $"{r.getRoomName()}:{p.userName}",listHorse);
                    }
                    catch (SocketException)
                    {
                        MessageBox.Show("Lỗi : Không thể connect tới server !");
                    }
                }

                byte[] bytes = new byte[1024];
                ClientSocket.Receive(bytes);
                string MSG = Encoding.UTF8.GetString(bytes);
                var Jsonmsg = JsonConvert.DeserializeObject<ManagePacket>(MSG);
                if (Jsonmsg != null)
                {
                    Player_Create create = new Player_Create(p, ClientSocket);
                    create.Disposed += delegate {
                        this.Dispose();
                    };
                    create.Show();
                    this.Hide();
                }
            }
            else
                MessageBox.Show("chưa nhập tên phòng");
            
        }
       
        private void btn_Join_Room_Click(object sender, EventArgs e)
        {
           // ClientSocket.Connect(p.serverIP, p.port);
            _connect.Sendmsg(ClientSocket, "ListRoom", "null");
            byte[] bytes = new byte[1024];

            ClientSocket.Receive(bytes);
            string listRoom = Encoding.UTF8.GetString(bytes);
            var Jsonmsg = JsonConvert.DeserializeObject<ManagePacket>(listRoom);
           

            this.Hide();
            int ID_select = 0;
            ListRoom ls = new ListRoom(Jsonmsg.msgRoom,ClientSocket,p);
            ls.Show();
            ls.Disposed += delegate
            {
                ID_select = ls.ID_select;
                this.Dispose();
            };
            
        }

        private void PlayerName_Click(object sender, EventArgs e)
        {
           
        }
    }
}