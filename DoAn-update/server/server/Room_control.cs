using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cờ_cá_ngựa
{
    public partial class Room_control : Form
    {
        Sqlite_control Database_control = new Sqlite_control();
        public Room_control()
        {
            InitializeComponent();
            SetDataToListView();
        }
        private void SetDataToListView()
        {
            Box_listview.Items.Clear();
            List<RoomModel> L = Database_control.GetRoomData();
            int i = 0;
            while (i < L.Count)
            {
                string[] row = { L[i].RoomID.ToString(), L[i].Title, L[i].StartTime};
                var lvi = new ListViewItem(row);
                Box_listview.Items.Add(lvi);
                i++;
            }
        }
    }
}
