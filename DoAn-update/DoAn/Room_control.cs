using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Room_control : Form
    {
        public Room_control(List<> ... )
        {
            InitializeComponent(); // Ok?
            SetDataToListView(List <);
        }
        private void SetDataToListView(List<>)
        {
            Box_listview.Items.Clear();
            List<RoomModel> L = List<>;// OK?
            int i = 0;
            while (i < L.Count)
            {
                string[] row = { L[i].RoomID.ToString(), L[i].RoomName, L[i].Members_num.ToString() } ;
                var lvi = new ListViewItem(row);
                Box_listview.Items.Add(lvi);
                i++;
            }
        }

        private void Box_listview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
