using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class Connection
    {
        bool Running = true;
        private void Sendmsg(Socket s,  string type, string content)
        {
            var MSG = new ManagePacket(type, content);
            string json = JsonConvert.SerializeObject(MSG);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            s.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private void ReceiveResponse(Socket s, string mode = "")
        {
            try
            {
                while (s.Connected)
                {
                    var buffer = new byte[2048];
                    int received = s.Receive(buffer, SocketFlags.None);
                    if (received == 0) return;
                    var data = new byte[received];
                    Array.Copy(buffer, data, received);
                    string text = Encoding.UTF8.GetString(data);
                    var msg = JsonConvert.DeserializeObject<ManagePacket>(text);

                    if(mode == "Connect")
                    {
                        if(msg.msgtype == "User" && msg.msgcontent == "Exist")
                        {
                            MessageBox.Show("Tên đã tồn tại, vui lòng đặt tên khác");
                            return;
                        }
                        if (msg.msgtype == "User" && msg.msgcontent == "Success")
                        {
                            MessageBox.Show("Đã kết nối thành công đến server");
                            return;
                        }
                    }
                    else if(mode == "CreateRoom")
                    {
                        if(msg.msgtype == "Room" && msg.msgcontent == "Exist")
                        {
                            MessageBox.Show("Phòng đã tồn tại, vui lòng đặt tên khác");
                            return;
                        }
                    }
                    else if(mode == "JoinRoom")
                    {

                    }
                    else if(mode == "")
                    {

                    }

                    //UpdateEventQC($"{text}\n");
                }
            }
            catch (Exception)
            {
                s.Close();
            }
        }
    }
}
