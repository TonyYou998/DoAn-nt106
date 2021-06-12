using Client.Modal;
using System.Collections.Generic;

namespace Client
{
    class ManagePacket
    {
        public string msgtype { get; set; }// user room action 
        public string msgcontent { get; set; }
        public string msgPlayer { get; set; }
        public List<RoomModel> msgRoom { get; set; }
        public List<Horse> msgHorse { get; set; }
        public HorseControl HC { get; set; }
        public ManagePacket(HorseControl HC)
        {
            this.HC = HC;
        }
        public ManagePacket()
        {
            msgcontent = "";
            msgtype = "";
            msgRoom = null;
        }
        public ManagePacket(string type,string msgRoom,List<Horse> listHorse)
        {
            this.msgtype = type;
            this.msgHorse = listHorse;
            this.msgcontent = msgRoom;
        }
        public ManagePacket(string type, string msg)
        {
            this.msgtype = type;
            this.msgcontent = msg;
        }

        public ManagePacket(List<RoomModel> Arr)
        {
            this.msgtype = "Room";
            this.msgcontent = null;
            this.msgRoom = Arr;
        }
    }
}
