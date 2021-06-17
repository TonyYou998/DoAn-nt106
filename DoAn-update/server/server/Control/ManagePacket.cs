using Server;
using System.Collections.Generic;

namespace Server
{
    class ManagePacket
    {
        public string msgtype { get; set; }// user room action 
        public string msgcontent { get; set; }
        public List<RoomModel> msgRoom { get; set; }
        public List<Horse> msgHorse { get; set; }
        public HorseControl HC = new HorseControl();
        public string Name { get; set; }
        public int roomID { get; set; }
        public int rollNumber { get; set; }
        public ManagePacket() {
            msgcontent = "";
            msgtype = "";
            msgRoom = null;
        }
        public ManagePacket(int rollNumber)
        {
            this.rollNumber= rollNumber;
        }
        public ManagePacket(HorseControl HC,string name,int roomID)
        {
            this.HC = HC;
            this.Name = name;
            this.roomID = roomID;
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
