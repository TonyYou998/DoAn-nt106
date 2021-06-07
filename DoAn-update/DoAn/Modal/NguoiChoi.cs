using System;
using System.Net;
using System.Windows.Forms;

namespace Client.Modal
{
    public class NguoiChoi
    {
        public string userName {
            get;
       set;
        }

        public String getUserName()
        {
            return userName;
        }
        public int port { get; set; }
        public int getPort()
        {
            return this.port;
        }
        public IPAddress serverIP { get; set; }
        public IPAddress getIP()
        {
            return this.serverIP;
        }

        public bool nhapThongTin(RichTextBox userName,RichTextBox Ip)
        {
            this.port = 8000;

            while(this.userName=="" || this.serverIP==null  )
            {
                this.userName = userName.Text;
               
                try
                {
                    this.serverIP = IPAddress.Parse(Ip.Text);
                    
                }
                catch
                {
                    MessageBox.Show("sai định dạng ip\nmởi nhập lại ");
                  
                    userName.Text = "";

                    Ip.Text = "";

                    return false;
                }

              
               
            }

            return true;


        }
    }
}
