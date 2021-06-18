using Client.Modal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Connection
    {
        public void Sendmsg(Socket s,  string type,string content )
        {
            var MSG = new ManagePacket(type, content);
            string json = JsonConvert.SerializeObject(MSG);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            s.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        public void SendRoll(Socket s, string type, string content,int rollnumber, int roomID, HorseList HL)
        {
            var MSG = new ManagePacket { msgtype = type, rollNumber = rollnumber, msgcontent = content, roomID =  roomID, HL = HL  };
            string json = JsonConvert.SerializeObject(MSG);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            s.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        public void sendDisconnect(Socket s, string username, int roomid)
        {
            var MSG = new ManagePacket { msgtype = "User", msgcontent = $"disconnect:{username}", roomID = roomid};
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

        public void Sendmsg(Socket s,string type ,string content,int RoomID,  HorseList HL)
        {
            var MSG = new ManagePacket { msgtype=type, msgcontent=$"{content}", roomID = RoomID,  HL = HL };
            string json = JsonConvert.SerializeObject(MSG);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            s.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

    }
}
