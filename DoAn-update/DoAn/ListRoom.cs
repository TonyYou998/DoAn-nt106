using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    public partial class ListRoom : Form
    {
        public int ID_select = 0;
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
        public ListRoom( List<RoomModel> ListRoom)
        {
            InitializeComponent();
            drawListRoom(ListRoom);

        }

        private void Double_click(object sender, MouseEventArgs e)
        {
            var id = listView1.SelectedItems[0].Text;
            ID_select = int.Parse(id);
            this.Dispose();
        }
    }
}
