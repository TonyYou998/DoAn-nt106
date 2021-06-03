using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.Modal
{
    class NguoiChoi
    {
        private string userName="";
        private int port=-1;
        private IPAddress serverIP=null;



       public String getUserName()
        {
            return userName;
        }
        public int getPort()
        {
            return port;

        }
        public IPAddress getIp()
        {
            return serverIP;
        }
        public bool nhapThongTin(RichTextBox userName,RichTextBox port,RichTextBox Ip)
        {
           

            while(this.userName=="" || this.port == -1 || this.serverIP==null  )
            {
                this.userName = userName.Text;
               
                try
                {
                    this.serverIP = IPAddress.Parse(Ip.Text);
                    this.port = Int32.Parse(port.Text);
                }
                catch
                {
                    MessageBox.Show("sai định dạng port Hoặc ip ");
                }

                if(this.userName=="" || this.port==-1 || this.serverIP==null)
                {
                    MessageBox.Show("nhập lại username và port");
                    userName.Text = "";
                    port.Text = "";
                    Ip.Text = "";

                    return false;

                }
               
            }
            return true;


        }
    }
}
