namespace Client
{
    class ManagePacket
    {
        public string msgtype { get; set; }// user room action 
        public string msgcontent { get; set; }
        public string msgtime { get; set; }

        public ManagePacket() {
            msgcontent = "";
            msgtype = "";
            msgtime = "";
        }
        public ManagePacket(string type,string msg,string time)
        {
            this.msgtype = type;
            this.msgcontent = msg;
            this.msgtime = time;
        }
    }
}
