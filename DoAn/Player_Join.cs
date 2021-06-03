using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Player_Join : Form
    {
        public Player_Join()
        {
            InitializeComponent();
        }

        private int[] a = {650,615,580,580,545,510,475,440,435,435,435,435,435,435,385,330,330,330,330,
                            330,330,330,290,250,215,180,145,105,105,105,145,180,215,250,290,330,330,330,
                            330,330,330,330,380,430,430,430,430,430,430,430,475,510,545,585,620,655,655 };
        private int[] b = { 235,235,235,235,235,235,235,235,185,150,120,90,55,25,25,25,55,90,120,150,185,235,235,
                            235,235,235,235,235,280,330,330,330,330,330,330,330,370,400,430,465,495,530,530,530,
                            495,465,430,400,370,330,330,330,330,330,330,330,285};
        private int t=-1;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int temp = Int32.Parse(richTextBox1.Text);
            if (temp <= 6 && temp >= 1)
            {
                t += temp ;
                pictureBox1.Location = new Point(a[t], b[t]);
            }
        }

        private void richTextBox1_Validated(object sender, EventArgs e)
        {
           


        }

        private void Player_Join_Load(object sender, EventArgs e)
        {

        }
    }
}
