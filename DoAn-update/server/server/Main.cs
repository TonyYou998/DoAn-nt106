using Server;
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
        private readonly Dictionary<string, Socket> clientSockets = new Dictionary<string, Socket>();
        private readonly byte[] buffer = new byte[2048];
        private Socket serverSockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
       
        private IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        private int serverPort = 8000;

        Sqlite_control sql;
        int number_room = 0;

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

                                if (!clientSockets.ContainsValue(current))
                                {
                                    clientSockets.Add(data[1], current);
                                };
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

                            MSG = new ManagePacket("User", "Host Disconnect");
                            sendPacketToClient(current, MSG);

                        }
                    }

                    break;
                case "CreateRoom":
                 
                    string[] roomData = packet.msgcontent.Split(':');

                    sql.AddRoom(roomData[0]);
                    sql.SetHost(roomData[1], 1);
                    sql.SetRoomID(roomData[1], number_room + 1);

                    HC[number_room] = new HorseControl();
                    HC[number_room].listRedHorse = packet.msgHorse;
                    number_room++;
                    //roomID:username:lisHorse:
                    string  userName = roomData[1];
                 MSG = new ManagePacket(HC[number_room-1], userName, number_room);
                    sendPacketToClient(current, MSG);
                    break;


                case "ListRoom":
                    MSG = new ManagePacket(sql.ReadRoomData());
                    sendPacketToClient(current, MSG);
                    break;

                case "JoinRoom":
                    string[] Data = packet.msgcontent.Split(':');

                    string name = Data[0];
                    string RoomID = Data[1];
                    string Color = Data[2];

                    switch(Color)
                    {
                        case "Green":

                            HC[number_room-1].listGreenHorse = packet.msgHorse;
                            break;
                        case "Blue":
                            HC[number_room-1].listBlueHorse = packet.msgHorse;
                            break;
                        case "Yellow":
                            HC[number_room-1].listyellowHorse = packet.msgHorse;
                            break;
                    }

                    if (!sql.IsPlaying(RoomID))
                    {
                        MSG = new ManagePacket("JoinRoom", "Isplaying");
                        sendPacketToClient(current, MSG);
                        break;
                    }

                    sql.SetHost(Data[0],0);
                    sql.SetRoomID(Data[0], int.Parse(Data[1]));
                    MSG = new ManagePacket(HC[number_room - 1],name,number_room);
                    sendPacketToRoom(MSG, number_room);

                    break;

                case "Action":
                    data = packet.msgcontent.Split(':');
                    switch (data[0])
                    {
                        case "Start": // Room:1
                            sql.SetRoomStart(data[1], 1);
                            sendPacketToRoom(packet, int.Parse(data[1]));
                            break;
                        case "Roll":
                            int rollNuber = int.Parse(data[2]);
                            MSG = new ManagePacket(rollNuber);
                           sendPacketToRoom(MSG,int.Parse(data[1]));
                            break;
                        case "Moving":
                            sendPacketToRoom(packet, int.Parse(data[1]));
                            break;
                        case "Next":
                            sendPacketToRoom(packet, int.Parse(data[1]));
                            break;
                    }
                    break;
            }
                
        }

        private void sendPacketToRoom(ManagePacket MSG, int roomID)
        {
            List<string> user_in_room = sql.GetListUserInRoom(roomID);
            foreach(var u in user_in_room)
            {
                Socket temp;
                if(clientSockets.TryGetValue(u, out temp))
                {
                    sendPacketToClient(temp, MSG);
                }
            }
        }
        private void sendPacketToClient(Socket s, ManagePacket MSG ) 
        {
            string json = JsonConvert.SerializeObject(MSG);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            s.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private void CloseAllSockets()
        {
            foreach (var socket in clientSockets)
            {
                socket.Value.Shutdown(SocketShutdown.Both);
                socket.Value.Close();
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
