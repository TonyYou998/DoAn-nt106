using Client.Modal;
using System.Collections.Generic;

namespace Client
{
    class ManagePacket
    {
        public string msgtype { get; set; }// user room action 
        public string msgcontent { get; set; }
        public List<Horse> msgHorse { get; set; }
        public HorseList HL { get; set; }
        public string Name { get; set; }
        public int rollNumber { get; set; }
        public int roomID { get; set; }
        public List<RoomModel> msgRoom { get; set; }

        public ManagePacket() { }
        public ManagePacket(HorseList HL,string name,int roomID)
        {
            this.HL = HL;
            this.Name = name;
            this.roomID = roomID;
        }
        public ManagePacket(int rollNumber)
        {
            this.roomID = rollNumber;
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
