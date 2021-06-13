using System;
using System.Net;
using System.Windows.Forms;

namespace Client.Modal
{
    public class NguoiChoi
    {
        public string userName { get; set; }
        public int port { get; set; }
        public IPAddress serverIP { get; set; }

        public bool CheckValid(string u, string ip)
        {
            this.port = 8000;

            try
            {
                this.serverIP = IPAddress.Parse(ip);
                this.userName = u;
            }
            catch
            {
                MessageBox.Show("Sai định dạng IP, vui lòng nhập lại!");
                return false;
            }

            return true;
        }
    }
}
