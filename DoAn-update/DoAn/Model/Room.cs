using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Modal
{
    class Room
    {
        private string roomName;
        private int numberOfPlayer;
        private NguoiChoi [] p = { };


        public bool setRoomName(RichTextBox roomName)
        {
            this.roomName = roomName.Text;
            if (this.roomName != "")
                return true;
            return false;
        }
        public string getRoomName()
        {
            return roomName;
        }



    }
}
