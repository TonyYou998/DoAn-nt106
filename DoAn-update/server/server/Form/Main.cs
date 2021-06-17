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
       
        //private IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        private int serverPort = 8000;

        Sqlite_control sql;
        int number_room = 0;

        HorseList [] HL = new HorseList[50];
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
                serverSockets.Bind(new IPEndPoint(IPAddress.Any, serverPort));
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
                            if (!sql.IsUserOnline(data[1])) 
                            {
                                MSG = new ManagePacket("User", "Success");
                                sendPacketToClient(current, MSG);
                                if(!sql.checkUserExist(data[1]))  sql.Adduser(data[1]);
                                sql.SetUserOnline(data[1], 1);

                                if (!clientSockets.ContainsKey(data[1]))
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
                    //nhận được listHorse từ cli thêm vào HorseControl
                    sql.AddRoom(roomData[0]);
                    sql.SetHost(roomData[1], 1);
                    sql.SetRoomID(roomData[1], number_room + 1);

                    HL[number_room] = new HorseList();
                    HL[number_room].listRedHorse = packet.msgHorse;
                    
                    //roomID:username:lisHorse:
                    string  userName = roomData[1];
                    MSG = new ManagePacket(HL[number_room], userName, number_room+1);
                    //phản hồi cho cli nếu đã tạo phòng thành công
                    sendPacketToClient(current, MSG);
                    number_room++;
                    break;


                case "ListRoom":
                    MSG = new ManagePacket(sql.ReadRoomData());
                    //trả về listRoom khi cli join vào
                    sendPacketToClient(current, MSG);
                    break;

                case "JoinRoom":
                    string[] Data = packet.msgcontent.Split(':');

                    string name = Data[0];
                    string RoomID = Data[1];
                    string Color = Data[2];
                    //add clie vào listRoom theo màu
                    switch(Color)
                    {
                        case "Green":

                            HL[int.Parse(RoomID)-1].listGreenHorse = packet.msgHorse;
                            break;
                        case "Blue":
                            HL[int.Parse(RoomID)-1].listBlueHorse = packet.msgHorse;
                            break;
                        case "Yellow":
                            HL[int.Parse(RoomID)-1].listyellowHorse = packet.msgHorse;
                            break;
                    }
                    //nếu đã start thì không join vào dc nữa
                    if (sql.IsPlaying(RoomID))
                    {
                        MSG = new ManagePacket("JoinRoom", "Isplaying");
                        sendPacketToClient(current, MSG);
                        break;
                    }


                    sql.SetHost(Data[0],0);
                    sql.SetRoomID(Data[0], int.Parse(Data[1]));
                    MSG = new ManagePacket
                    {
                        msgtype = "Join",
                        roomID = int.Parse(RoomID),
                        HL = HL[int.Parse(RoomID) - 1]
                    };
                    sendPacketToRoom(MSG);

                    break;
                case "checkNumber":
                    string roomIDToCheck = packet.msgcontent;

                    //Hàm sql kiểm tra số  player trong phòng kiểu int theo roomID

                    break;
                case "Action":
                    data = packet.msgcontent.Split(':');
                    packet.roomID = int.Parse(data[1]);
                    // data[1] = roomID, data[2] = rollnumber, data[3] = username;
                    switch (data[0])
                    {
                        case "Start": 
                            sql.SetRoomStart(data[1], 1);
                            sendPacketToRoom(packet);
                            break;
                        case "Roll":
                            string nextplayer = "";
                            if (int.Parse(data[2]) == 1 || int.Parse(data[2]) == 6)
                                nextplayer = data[3];
                            else
                                nextplayer = getNextPlayer(data[3], data[1]);

                            MSG = new ManagePacket
                            {
                                msgtype = "Action",
                                rollNumber = int.Parse(data[2]),
                                msgcontent = $"Roll:{nextplayer}",

                                    roomID = packet.roomID
                                };
                            sendPacketToRoom(MSG);
                            break;

                        case "Update":
                            sendPacketToRoom(packet);
                            break;
                    }
                    break;

                case "ProgressBar":
                    data = packet.msgcontent.Split(':');
                    MSG = new ManagePacket
                    {
                        msgtype = "ProgressBar",
                        roomID = int.Parse(data[0]),
                        msgcontent = data[1]
                    };
                    sendPacketToRoom(MSG);
                    break;
            }
                
        }

        private string getNextPlayer(string current_player, string roomID)
        {
            List<string> user_in_room = sql.GetListUserInRoom(int.Parse(roomID));

            int index = user_in_room.IndexOf(current_player);
            return user_in_room[(index + 1) % user_in_room.Count];
        }

        private void sendPacketToRoom(ManagePacket MSG)
        {
            List<string> user_in_room = sql.GetListUserInRoom(MSG.roomID);
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
       
    }
}
