using Client.Modal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    class Connection
    {
        bool Running = true;
      
        public void Sendmsg(Socket s,  string type,string content )
        {
            var MSG = new ManagePacket(type, content);
            string json = JsonConvert.SerializeObject(MSG);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            s.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
        public void Sendmsg(Socket s, string type, string content, List<Horse> listHorse)
        {
            var MSG = new ManagePacket(type, content, listHorse);
            string json = JsonConvert.SerializeObject(MSG);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            s.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
        public void ReceiveResponse(Socket s, NguoiChoi p)
        {
            try
            {
                while (!s.Connected)
                {
                    var buffer = new byte[2048];
                    int received = s.Receive(buffer, SocketFlags.None);
                    if (received == 0) return;
                    var data = new byte[received];
                    Array.Copy(buffer, data, received);
                    string text = Encoding.UTF8.GetString(data);
                    var msg = JsonConvert.DeserializeObject<ManagePacket>(text);

                    if (msg.msgtype == "Room" && msg.msgcontent == "Create:Exist")
                    {
                        MessageBox.Show("Phòng đã tồn tại, vui lòng đặt tên khác");
                        return;
                    }
                    else if (msg.msgtype == "Room" && msg.msgcontent == "Create:Success")
                    {
                        Player_Choose choose = new Player_Choose(s, p);
                        choose.Show();
                        return;
                    }

                }
            }
            catch (Exception)
            {
                s.Close();
            }
        }

    }
}
