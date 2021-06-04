using Client.Modal;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace Client
{
    public partial class Info_Player : Form
    {
        private static readonly Socket ClientSocket = new Socket
           (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private Thread clientThread;
        public Info_Player()
        {
            InitializeComponent();
            //FORM GIAO DIEN
            this.Size = new Size(1286, 751);
            this.BackgroundImage = Properties.Resources.Client__1_;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            //BTN_CONNECT GIAO DIEN
            btn_Connect.Size = new Size(150, 75);
            btn_Connect.BackgroundImage = Properties.Resources.CONNECT;
            btn_Connect.BackgroundImageLayout = ImageLayout.Zoom;
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

            lbPort.Size = new Size(157, 41);
            lbPort.Location = new Point(394, 413);
            Port.Size = new Size(325, 38);
            Port.Font = new Font("Arial", 22, FontStyle.Bold);
            Port.Location = new Point(578, 410);


        }
        private void connect(string userName,int port,IPAddress ip)
        {

        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            

            Player_Choose choose = new Player_Choose();
            NguoiChoi p = new NguoiChoi();

            

            if (p.nhapThongTin(UserName, Port, IpServer))
            {
                this.Hide();
                while (!ClientSocket.Connected)
                {
                    try
                    {
                        ClientSocket.Connect(p.serverIP, p.port);
                    }
                    catch (SocketException)
                    {
                        MessageBox.Show("Lỗi : Không thể connect tới server !");
                    }
                }
                choose.Show();
            }

        }

        private void ReceiveResponse()
        {
            try
            {
                while (ClientSocket.Connected)
                {
                    var buffer = new byte[2048];
                    int received = ClientSocket.Receive(buffer, SocketFlags.None);
                    if (received == 0) return;
                    var data = new byte[received];
                    Array.Copy(buffer, data, received);
                    string text = Encoding.UTF8.GetString(data);
                    UpdateEventQC($"{text}\n");
                }
            }
            catch (Exception)
            {
                ClientSocket.Close();
            }
        }

        private delegate void SafeCallDelegate(string text);

        private void UpdateEventQC(string text)
        {
            //if (Chatbox.InvokeRequired)
            //{
            //    var d = new SafeCallDelegate(UpdateChatHistoryThreadSafe);
            //    Chatbox.Invoke(d, new object[] { text });
            //}
            //else
            //{
            //    Chatbox.Text += text;
            //}
        }


        private void IpServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void Info_Player_Load(object sender, EventArgs e)
        {

        }
    }
}
