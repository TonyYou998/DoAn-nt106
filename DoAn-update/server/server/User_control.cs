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
    public partial class User_control : Form
    {
        Sqlite_control Database_control = new Sqlite_control();

        public User_control()
        {
            InitializeComponent();
            SetDataToListView();
        }
        private void SetDataToListView()
        {
            Box_listview.Items.Clear();
            List<UserModel> L = Database_control.GetUserData();
            int i = 0;
            while(i < L.Count)
            {
                string [] row = { L[i].ID.ToString(), L[i].Name, L[i].RoomID.ToString() };
                var lvi = new ListViewItem(row);
                Box_listview.Items.Add(lvi);
                i++;
            }
        }
        private void WireUp()
        {
            //Box_listview.Items.Add(Users);
        }
    }
}
