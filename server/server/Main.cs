using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Cờ_cá_ngựa
{
    public partial class Server : Form
    {
        private readonly List<Socket> clientSockets = new List<Socket>();
        private readonly byte[] buffer = new byte[2048];
        private Socket serverSockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        private int serverPort = 8000;
        public Server()
        {
            InitializeComponent();
            
        }
        
        private void UserFormClick(object sender, EventArgs e)
        {
            User_control gui = new User_control();
            gui.Show();
        }

        private void RoomFormClick(object sender, EventArgs e)
        {
            Room_control gui = new Room_control();
            gui.Show();
        }

        private void ListenButtonClick(object sender, EventArgs e)
        {
            if (ListenButton.Text == "LISTEN")
                start();
            else
                stop();
        }

        private void stop()
        {
            ListenButton.Text = "LISTEN"; 
            CloseAllSockets();
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
                System.Environment.Exit(1);
            }
            ListenButton.Text = "STOP";
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
            catch (SocketException)
            {
                current.Close();
                clientSockets.Remove(current);
                return;
            }

            byte[] recBuf = new byte[received]; // Cấp phát mảng động
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.UTF8.GetString(recBuf);

            var Packet = new ManagePacket();
            resolve(Packet,current);

            current.BeginReceive(buffer, 0, 2048, SocketFlags.None, ReceiveCallback, current);
        }

        private void resolve(ManagePacket packet, Socket current )
        {

            switch (packet.msgtype)
            {
                case "User":
                    string[] data = packet.msgcontent.Split(':');
                    string name = "";
                    if (data.Length == 2)
                    {
                        if(data[0] == "connect")
                        {
                            name = data[1];
                        } 
                    }

                    break;
                case "Room":

                    break;
                case "Action":
                    switch (packet.msgcontent)
                    {
                        case "Connect":

                            break;
                        case "Disconnect":

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
        private void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            serverSockets.Close();
        }
    }
}
