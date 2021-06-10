using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Server
{
    public partial class User_control : Form
    {
        public User_control(List<UserModel> L)
        {
            InitializeComponent();
            SetDataToListView(L);
        }
        private void SetDataToListView(List<UserModel> L)
        {
            Box_listview.Items.Clear();
            int i = 0;
            while(i < L.Count)
            {
                string [] row = { L[i].ID.ToString(), L[i].Name, L[i].RoomID.ToString() };
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
