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
        public void Sendmsg(Socket s, string type, string content, List<Horse> listHorse)
        {
            var MSG = new ManagePacket(type, content, listHorse);
            string json = JsonConvert.SerializeObject(MSG);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            s.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
    }
}
