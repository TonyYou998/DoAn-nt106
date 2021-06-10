﻿using Client.Modal;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Client
{
    public partial class Info_Player : Form
    {
        public Socket ClientSocket;
        public NguoiChoi p = new NguoiChoi();
        private Connection _connect = new Connection();
        private Thread clientThread;
        private int toggleForm=0;

        public void setToggle()
        {
            this.toggleForm = 1;
        }
        public Info_Player()
        {
            InitializeComponent();
            //FORM GIAO DIEN
            this.Size = new Size(1286, 751);
            this.BackgroundImage = Properties.Resources.Client__1_;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //BTN_CONNECT GIAO DIEN
            btn_Connect.Size = new Size(150, 75);
            btn_Connect.BackgroundImage = Properties.Resources.CONNECT;
            btn_Connect.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Connect.Location = new Point(550, 470);
            btn_Connect.BackColor = Color.Transparent;
            //Gio dien khac
            lbName.Size = new Size(157, 41);
            lbName.Location = new Point(385, 194);
            UserName.Size = new Size(325, 38);
            UserName.Font = new Font("Arial", 22, FontStyle.Bold);
            UserName.Location = new Point(578, 197);

            lbIP.Size = new Size(157, 41);
            lbIP.Location = new Point(394, 298);
            IpServer.Size = new Size(325, 38);
            IpServer.Font = new Font("Arial", 22, FontStyle.Bold);
            IpServer.Location = new Point(578, 301);

            this.Disposed += delegate
            {
                if (ClientSocket.Connected)
                    _connect.Sendmsg(ClientSocket, "User", $"disconnect:{p.userName}");
            };
        }


        private void connect(string userName, int port, IPAddress ip)
        {

        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {

            bool loop = true;
            while (loop)
            {
                if (p.nhapThongTin(UserName, IpServer))
                {

                    ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    while (!ClientSocket.Connected)
                    {
                        try
                        {
                            ClientSocket.Connect(p.serverIP, p.port);
                            _connect.Sendmsg(ClientSocket, "User", $"connect:{p.userName}");
                            Thread A = new Thread(ReceiveResponse);
                            A.Start();

                            loop = false;
                            break;

                        }
                        catch (SocketException)
                        {
                            MessageBox.Show("Lỗi : Không thể connect tới server !");
                            return;
                        }
                    }
                }
            }
            byte[] bytes = new byte[2048];

            ClientSocket.Receive(bytes);
            string acceptedUser = Encoding.UTF8.GetString(bytes);
            var msg = JsonConvert.DeserializeObject<ManagePacket>(acceptedUser);
            if (msg.msgtype == "User" && msg.msgcontent == "Success")
            {
                // Player_Choose choose = new Player_Choose(ClientSocket, p);
                //choose.Show();
                Player_Choose PY = new Player_Choose(ClientSocket,p);
                PY.Show();
                Hide();
            }







        }

        public void ReceiveResponse()
        {
            bool loop = false;
            try
            {
                while (!loop)
                {
                    var buffer = new byte[2048];
                    int received = ClientSocket.Receive(buffer, SocketFlags.None);
                    if (received == 0) return;
                    var data = new byte[received];
                    Array.Copy(buffer, data, received);
                    string text = Encoding.UTF8.GetString(data);
                    var msg = JsonConvert.DeserializeObject<ManagePacket>(text);

                    if (msg.msgtype == "User" && msg.msgcontent == "Exist")
                    {
                        MessageBox.Show("Tên đã tồn tại, vui lòng đặt tên khác");
                        return;
                    }
                    else if (msg.msgtype == "User" && msg.msgcontent == "Success")
                    {
                        // Player_Choose choose = new Player_Choose(ClientSocket, p);
                        //choose.Show();
                        setToggle();
                        loop = true;
                    }

                }
            }
            catch (Exception)
            {
                ClientSocket.Close();
            }
        }

        private delegate void SafeCallDelegate(string text);

        private void UpdateEventQC(string text)
        {
            //if (Chatbox.InvokeRequired)
            //{
            //    var d = new SafeCallDelegate(UpdateEventQC);
            //    Chatbox.Invoke(d, new object[] { text });
            //}
            //else
            //{
            //    Chatbox.Text += text;
            //}
        }


        private void IpServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void Info_Player_Load(object sender, EventArgs e)
        {

        }
    }
}