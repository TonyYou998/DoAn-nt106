﻿using Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        private readonly List<Socket> clientSockets = new List<Socket>();
        private readonly byte[] buffer = new byte[2048];
        private Socket serverSockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
       
        private IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        private int serverPort = 8000;

        Sqlite_control sql;
        int id = 0;

        HorseControl [] HC = new HorseControl[50];
        public Server()
        {
            InitializeComponent();
            if (File.Exists("Database.db"))
            {
                File.Delete("Database.db");
            }
            sql = new Sqlite_control();
        }
        
        private void start()
        {
            
            var msg = "Server đang khởi động ...";
            logs.Text = msg + "\n";
            try
            {
                serverSockets.Bind(new IPEndPoint(serverIP, serverPort));
            }
            catch
            {
                MessageBox.Show("PORT " + serverPort + " đang được sử dụng!!!", "Lỗi");
                return;
            }
            listenbtn.Enabled = false;
            serverSockets.Listen(50);
            serverSockets.BeginAccept(AcceptCallBack, null);
            logs.Text += "Server đang chạy ở cổng " + serverPort + "\n";
        }

        private void AcceptCallBack(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = serverSockets.EndAccept(AR);
            }
            catch (ObjectDisposedException)
            {
                return;// Tắt socket
            }
            clientSockets.Add(socket); //Thêm Client
            socket.BeginReceive(buffer, 0, 2048, SocketFlags.None, ReceiveCallback, socket);
            serverSockets.BeginAccept(AcceptCallBack, null);
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            Socket current = (Socket)AR.AsyncState;
            int received;

            try
            {
                received = current.EndReceive(AR);
            }
            catch
            {
                current.Close();
                clientSockets.Remove(current);
                return;
            }

            byte[] recBuf = new byte[received]; // Cấp phát mảng động
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.UTF8.GetString(recBuf);
            var Jsonmsg = JsonConvert.DeserializeObject<ManagePacket>(text);

            resolve(Jsonmsg, current);

            current.BeginReceive(buffer, 0, 2048, SocketFlags.None, ReceiveCallback, current);
        }

        private void resolve(ManagePacket packet, Socket current )
        {
            ManagePacket MSG;

            switch (packet.msgtype)
            {
                case "User":
                    string[] data = packet.msgcontent.Split(':'); // VD: connect:Duy
                    if (data.Length == 2)
                    {
                        if(data[0] == "connect")
                        {
                            if (!sql.checkUserExist(data[1]) || !sql.IsUserOnline(data[1])) 
                            {
                                MSG = new ManagePacket("User", "Success");
                                sendPacketToClient(current, MSG);
                                sql.Adduser(data[1]);
                                sql.SetUserOnline(data[1], 1);

                                //sendPacketToClient(current, MSG);
                                logs.BeginInvoke((Action)(() =>
                                { logs.AppendText($"\r\nĐã kết nối với {data[1]}"); }));
                            }
                            else
                            {
                                MSG =  new ManagePacket("User","Exist");
                               sendPacketToClient(current, MSG);
                            }

                        }
                        else if(data[0] == "disconnect")
                        {
                            sql.SetUserOnline(data[1], 0);
                            logs.BeginInvoke((Action)(() =>
                            { logs.AppendText($"\r\nĐã ngắt kết nối với {data[1]}"); }));
                        }
                    }

                    break;
                case "CreateRoom":
                 
                    string[] roomData = packet.msgcontent.Split(':');
                    id++;
                    sql.AddRoom(roomID.ToString(), roomData[1]);
                    HC[id].listRedHorse = packet.msgHorse;

                    break;


                case "JoinRoom":
                     MSG = new ManagePacket(sql.ReadRoomData());
                   
                    sendPacketToClient(current, MSG);
                    break;

                case "Action":
                    switch (packet.msgcontent)
                    {
                        case "Connect":

                            break;
               
                    }
                    break;
            }
                
        }
        //private void deliverymsg(Socket current, string text)
        //{
        //    var sk1 = current.RemoteEndPoint.ToString();
        //    var portA = sk1.Split(':')[1];

        //    foreach (var A in Users)
        //    {
        //        if (A.Port == portA)
        //        {
        //            foreach (var B in Users)
        //            {
        //                if (B.Name == A.Friend)
        //                {
        //                    // Tìm socket để gởi msg tới B
        //                    foreach (Socket socket in clientSockets)
        //                    {
        //                        var sk2 = socket.RemoteEndPoint.ToString();
        //                        var portB = sk2.Split(':')[1];
        //                        if (portB == B.Port)
        //                        {
        //                            byte[] msg = Encoding.UTF8.GetBytes(text);
        //                            socket.Send(msg);
        //                        }
        //                    }
        //                }
        //            }

        //        }
        //    }

        //}

        private void sendPacketToClient(Socket current, ManagePacket MSG ) 
        {
            string json = JsonConvert.SerializeObject(MSG);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            current.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            serverSockets.Close();
        }

        private void logs_TextChanged(object sender, EventArgs e)
        {

        }

        private void listenbtn_Click(object sender, EventArgs e)
        {
            start();
        }

        private void listroombtn_Click(object sender, EventArgs e)
        {
            Room_control gui = new Room_control(sql.ReadRoomData());
            gui.Show();
        }

        private void listuserbtn_Click(object sender, EventArgs e)
        {
            User_control gui = new User_control(sql.ReadUserData());
            gui.Show();
        }

        private void contactbtn_Click(object sender, EventArgs e)
        {

        }
       /* private void createListHorse(List<Horse> listHorse)
        {
            Point p1 = new Point(150,85); ;
            Point p2 = new Point(240, 85);
            Point p3 = new Point(150, 170);
            Point p4 = new Point(240, 170);
            Horse h1 = new Horse(p1, "red", 1);
            Horse h2 = new Horse(p2, "red", 2);
            Horse h3 = new Horse(p3, "red", 3);
            Horse h4 = new Horse(p4, "red", 4);
            listHorse.Add(h1);
            listHorse.Add(h2);
            listHorse.Add(h3);
            listHorse.Add(h4);

        }*/
    }
}
