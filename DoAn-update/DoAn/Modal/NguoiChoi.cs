using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.Modal
{
    class NguoiChoi
    {
        private string userName="";
        private int port=-1;


        public bool nhapThongTin(RichTextBox userName,RichTextBox port)
        {
           

            while(this.userName=="" || this.port == -1)
            {
                this.userName = userName.Text;
                
                try
                {
                    this.port = Int32.Parse(port.Text);
                }
                catch
                {
                    MessageBox.Show("sai định dạng port");
                }

                if(this.userName=="" || this.port==-1)
                {
                    MessageBox.Show("nhập lại username và port");
                    userName.Text = "";
                    port.Text = "";


                    return false;

                }
               
            }
            return true;


        }
    }
}
