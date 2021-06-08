using System.Collections.Generic;

namespace Server
{
    class ManagePacket
    {
        public string msgtype { get; set; }// user room action 
        public string msgcontent { get; set; }
        public List<RoomModel> msgRoom { get; set; }

        public ManagePacket() {
            msgcontent = "";
            msgtype = "";
            msgRoom = null;
        }
        public ManagePacket(string type,string msg)
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
