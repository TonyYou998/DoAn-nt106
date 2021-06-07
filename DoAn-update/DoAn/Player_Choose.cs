using Client.Modal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Player_Choose : Form
    {

        private NguoiChoi p;

        private Socket ClientSocket;
        private Thread clientThread;
        public Player_Choose(NguoiChoi nguoiChoi)
        {

            InitializeComponent();
             p = nguoiChoi;
            
            PlayerName.Text = nguoiChoi.getUserName();

            //FORM GIAO DIEN
            this.Size = new Size(1286, 751);
            this.BackgroundImage = Properties.Resources.Client__1_;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            //BTN_CREATE_ROOM GIAO DIEN
            btn_Create_Room.Size = new Size(150, 75);
            btn_Create_Room.BackgroundImage = Properties.Resources.CREATE;
            btn_Create_Room.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Create_Room.Location = new Point(430, 435);
            btn_Create_Room.BackColor = Color.Transparent;
            //BTN_JOIN_ROOM GIAO DIEN
            btn_Join_Room.Size = new Size(150, 75);
            btn_Join_Room.BackgroundImage = Properties.Resources.JOIN;
            btn_Join_Room.BackgroundImageLayout = ImageLayout.Zoom;
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

            if (r.setRoomName(RoomName))
            {
                Player_Create create = new Player_Create();
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                while (!ClientSocket.Connected)
                {
                    try
                    {
                        ClientSocket.Connect(p.serverIP, p.port);
                        Sendmsg("Room", $"room name:{r.getRoomName()}");
                        
                    }
                    catch (SocketException)
                    {
                        MessageBox.Show("Lỗi : Không thể connect tới server !");
                    }
                    clientThread = new Thread(ReceiveResponse);
                    clientThread.Start();
                }
                create.Show();
                this.Hide();
               
            }
            else
                MessageBox.Show("chưa nhập tên phòng");
            
        }

        private void Sendmsg(string type, string content)
        {
            var MSG = new ManagePacket(type, content);
            string json = JsonConvert.SerializeObject(MSG);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private void ReceiveResponse()
        {
            try
            {
                while (ClientSocket.Connected)
                {
                    var buffer = new byte[2048];
                    int received = ClientSocket.Receive(buffer, SocketFlags.None);
                    if (received == 0) return;
                    var data = new byte[received];
                    Array.Copy(buffer, data, received);
                    string text = Encoding.UTF8.GetString(data);
                    //UpdateEventQC($"{text}\n");
                }
            }
            catch (Exception)
            {
                ClientSocket.Close();
            }
        }

        private void btn_Join_Room_Click(object sender, EventArgs e)
        {
            this.Hide();
            Player_Join join = new Player_Join();

            join.Show();
        }

        private void PlayerName_Click(object sender, EventArgs e)
        {

        }
    }
}