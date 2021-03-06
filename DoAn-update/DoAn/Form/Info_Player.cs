using Client.Modal;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace Client
{
    public partial class Info_Player : Form
    {
        public Socket ClientSocket;
        public NguoiChoi p = new NguoiChoi();
        private Connection _connect = new Connection();

        public Info_Player()
        {
            InitializeComponent();
            //FORM GIAO DIEN
            this.Size = new Size(1286, 751);
            this.BackgroundImage = Properties.Resources.Client__1_;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //BTN_CONNECT GIAO DIEN
            btn_Connect.Size = new Size(150, 75);
            btn_Connect.BackgroundImage = Properties.Resources.CONNECT;
            btn_Connect.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Connect.Location = new Point(550, 470);
            btn_Connect.BackColor = Color.Transparent;
            //Gio dien khac
            lbName.Size = new Size(157, 41);
            lbName.Location = new Point(385, 194);
            UserName.Size = new Size(325, 38);
            UserName.Font = new Font("Arial", 22, FontStyle.Bold);
            UserName.Location = new Point(578, 197);

            lbIP.Size = new Size(157, 41);
            lbIP.Location = new Point(394, 298);
            IpServer.Size = new Size(325, 38);
            IpServer.Font = new Font("Arial", 22, FontStyle.Bold);
            IpServer.Location = new Point(578, 301);
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (p.CheckValid(UserName.Text, IpServer.Text))
            {

                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    ClientSocket.Connect(p.serverIP, p.port);
                    _connect.Sendmsg(ClientSocket, "User", $"connect:{p.userName}");
                }
                catch (SocketException)
                {
                    MessageBox.Show("Lỗi : Không thể connect tới server !");
                    return;
                }
            }

            byte[] bytes = new byte[2048];
            ClientSocket.Receive(bytes);
            string acceptedUser = Encoding.UTF8.GetString(bytes);
            var msg = JsonConvert.DeserializeObject<ManagePacket>(acceptedUser);

            if (msg.msgtype == "User" && msg.msgcontent == "Success")
            {
                
                Player_Choose PY = new Player_Choose(ClientSocket, p);
                PY.Show();
                Hide();
                PY.Disposed += delegate {
                    this.Dispose();
                };
            }
            else if (msg.msgtype == "User" && msg.msgcontent == "Exist")
            {
                MessageBox.Show("Tên đã tồn tại, vui lòng đặt tên khác");
                return;
            }
        }

     

    

      


        private void IpServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void Info_Player_Load(object sender, EventArgs e)
        {

        }
    }
}