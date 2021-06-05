using System;
using System.Net;
using System.Windows.Forms;

namespace Client.Modal
{
    class NguoiChoi
    {
        public string userName { get; set; }
        public int port { get; set; }
        public IPAddress serverIP { get; set; }

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
                    MessageBox.Show("sai định dạng port Hoặc ip ");
                }

                if(this.userName=="" || this.port==-1 || this.serverIP==null)
                {
                    MessageBox.Show("nhập lại username và ip");
                    userName.Text = "";
                    
                    Ip.Text = "";

                    return false;

                }
               
            }
            return true;


        }
    }
}
