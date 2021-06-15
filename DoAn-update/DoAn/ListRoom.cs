using Client.Modal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class ListRoom : Form
    {
        public int ID_select = 0;
        private Socket ClientSocket;
        private Connection _connect = new Connection();
        NguoiChoi p;

        public void drawListRoom(List<RoomModel> L)
        {
            int i = 0;
            while (i < L.Count)
            {
                string[] row = { L[i].RoomID.ToString(), L[i].RoomName, L[i].Members_num.ToString() };
                var lvi = new ListViewItem(row);
                listView1.Items.Add(lvi);
                i++;
            }
        }
        public ListRoom(List<RoomModel> ListRoom, Socket ClientSocket, NguoiChoi p)
        {
            InitializeComponent();
            drawListRoom(ListRoom);
            this.ClientSocket = ClientSocket;
            this.p = p;
        }

        private void Double_click(object sender, MouseEventArgs e)
        {
            var id = listView1.SelectedItems[0].Text;
            var numberOfPlayer = listView1.SelectedItems[0].SubItems[2].Text;

            ID_select = int.Parse(id);
            //  _connect.Sendmsg(ClientSocket, "JoinRoom", "null");
            if (realJoin(int.Parse(numberOfPlayer), ID_select))
            {
                HorseControl HC = acceptJoin();
                if (HC != null)
                {
                    Player_Join PJ = new Player_Join(HC, p, ClientSocket, int.Parse(id));
                    PJ.Disposed += delegate
                    {
                        this.Dispose();
                    };
                    PJ.Show();
                    this.Hide();
                }
            }
            
              
           
        }
        private bool realJoin(int numberOfPlayer, int roomID)
        {
            switch (numberOfPlayer)
            {
                case 1:
                    List<Horse> listGreenHorse = new List<Horse>();
                    createListHorse(listGreenHorse, 515, 600, 85, 170, "Green");

                    _connect.Sendmsg(ClientSocket, "JoinRoom", $"{p.userName}:{roomID}:Green",listGreenHorse);
                    return true;
                case 2:
                    List<Horse> listBlueHorse = new List<Horse>();
                    createListHorse(listBlueHorse, 150, 230, 440, 530, "Blue");

                    _connect.Sendmsg(ClientSocket, "JoinRoom", $"{p.userName}:{roomID}:Blue:{listBlueHorse}",listBlueHorse);
                    return true;
                case 3:
                    List<Horse> listYellowHorse = new List<Horse>();
                    createListHorse(listYellowHorse, 515, 600, 440, 530, "Yellow");

                    _connect.Sendmsg(ClientSocket, "JoinRoom", $"{p.userName}:{roomID}:Yellow:{listYellowHorse}",listYellowHorse);
                    return true;
                case 4:
                    MessageBox.Show("full player");
                    return false;
                    
                default:
                    MessageBox.Show("hack");
                    return false;
            }
        }
        public List<Horse> createListHorse(List<Horse> lstHorse, int x1, int x2, int y1, int y2, string color)
        {
            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);
            Point p3 = new Point(x1, y2);
            Point p4 = new Point(x2, y1);
            Horse h1 = new Horse(p1, color, 1,p.userName);
            Horse h2 = new Horse(p2, color, 2,p.userName);
            Horse h3 = new Horse(p3, color, 3,p.userName);
            Horse h4 = new Horse(p4, color, 4,p.userName);

            lstHorse.Add(h1);
            lstHorse.Add(h2);
            lstHorse.Add(h3);
            lstHorse.Add(h4);
            return lstHorse;
        }
        private HorseControl acceptJoin()
        {
            byte[] bytes = new byte[2048];

            ClientSocket.Receive(bytes);
            string ListHorseAvailable = Encoding.UTF8.GetString(bytes);
            var Jsonmsg = JsonConvert.DeserializeObject<ManagePacket>(ListHorseAvailable);
            return Jsonmsg.HC;
        }
        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}