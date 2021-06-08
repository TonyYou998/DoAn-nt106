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
    public partial class Player_Create : Form
    {
        public Player_Create()
        {
            InitializeComponent();
            //FORM GIAO DIEN
            this.Size = new Size(1286, 751);
            this.BackgroundImage = Properties.Resources.BANCO__1_3;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            //BTN_START GIAO DIEN
            btn_Start.Size = new Size(150, 75);
            btn_Start.BackgroundImage = Properties.Resources.START_2;
            btn_Start.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Start.Location = new Point(980, 380);
            btn_Start.BackColor = Color.Transparent;
            //BTN_ROLL GIAO DIEN
            btn_Roll.Size = new Size(150, 75);
            btn_Roll.BackgroundImage = Properties.Resources.roll;
            btn_Roll.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Roll.Location = new Point(980, 480);
            btn_Roll.BackColor = Color.Transparent;
            //BTN_EXIT GIAO DIEN
            btn_exit.Size = new Size(150, 75);
            btn_exit.BackgroundImage = Properties.Resources.exit;
            btn_exit.BackgroundImageLayout = ImageLayout.Zoom;
            btn_exit.Location = new Point(980, 580);
            btn_exit.BackColor = Color.Transparent;
            //ROLL_NUMBER GIAO DIEN
            Roll_number.Size = new Size(290,290);
            Roll_number.BackgroundImage = Properties.Resources.loading;
            Roll_number.BackgroundImageLayout = ImageLayout.Zoom;
            Roll_number.Location = new Point(910, 50);
            Roll_number.BackColor = Color.Transparent;
            //
            Point[] temp = new Point[]
            {
               new Point {X = 0, Y= 0}

            };
            
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        temp[0] = RedReady[i];
                        break;
                    case 1:
                        temp[0] = RedReady[i];
                        break;
                    case 2:
                        temp[0] = RedReady[i];
                        break;
                    case 3:
                        temp[0] = RedReady[i];
                        break;
                }
                var picture = new PictureBox
                {
                    Name = "Red" + i.ToString(),
                    Size = new Size(51, 74),
                    Location = temp[0],
                    Image = Properties.Resources.red,
                };
                picture.Click += new EventHandler(Moving);
                this.Controls.Add(picture);
                picture.BackColor = Color.Transparent;
            }
            
            red2._index = -1;
            red2._top = false;
            red3._index = -1;
            red3._top = false;
            red4._index = -1;
            red4._top = false;
            red1._index = -1;
            red1._top = false;

        }
        public Redsoldier red1,red2,red3,red4;
        Point[] Red = new Point[]
        {
 new Point {X = 330, Y = 25 },
 new Point {X = 330, Y = 55 },
 new Point {X = 330, Y = 90 },
 new Point {X = 330, Y = 120 },
 new Point {X = 330, Y = 150 },
 new Point {X = 330, Y = 185 },
 new Point {X = 330, Y = 235 },
 new Point {X = 290, Y = 235 },
 new Point {X = 250, Y = 235 },
 new Point {X = 215, Y = 235 },
 new Point {X = 180, Y = 235 },
 new Point {X = 145, Y = 235 },
 new Point {X = 105, Y = 235 },
 new Point {X = 105, Y = 280 },
 new Point {X = 105, Y = 330 },
 new Point {X = 145, Y = 330 },
 new Point {X = 180, Y = 330 },
 new Point {X = 215, Y = 330 },
 new Point {X = 250, Y = 330 },
 new Point {X = 290, Y = 330 },
 new Point {X = 330, Y = 330 },
 new Point {X = 330, Y = 370 },
 new Point {X = 330, Y = 400 },
 new Point {X = 330, Y = 430 },
 new Point {X = 330, Y = 465 },
 new Point {X = 330, Y = 495 },
 new Point {X = 330, Y = 530 },
 new Point {X = 380, Y = 530 },
 new Point {X = 430, Y = 530 },
 new Point {X = 430, Y = 495 },
 new Point {X = 430, Y = 465 },
 new Point {X = 430, Y = 430 },
 new Point {X = 430, Y = 400 },
 new Point {X = 430, Y = 370 },
 new Point {X = 430, Y = 330 },
 new Point {X = 475, Y = 330 },
 new Point {X = 510, Y = 330 },
 new Point {X = 545, Y = 330 },
 new Point {X = 585, Y = 330 },
 new Point {X = 620, Y = 330 },
 new Point {X = 655, Y = 330 },
 new Point {X = 655, Y = 285 },
 new Point {X = 650, Y = 235 },
 new Point {X = 615, Y = 235 },
 new Point {X = 580, Y = 235 },
 new Point {X = 545, Y = 235 },
 new Point {X = 510, Y = 235 },
 new Point {X = 475, Y = 235 },
 new Point {X = 440, Y = 235 },
 new Point {X = 435, Y = 185 },
 new Point {X = 435, Y = 150 },
 new Point {X = 435, Y = 120 },
 new Point {X = 435, Y = 90 },
 new Point {X = 435, Y = 55 },
 new Point {X = 435, Y = 25 },
 new Point {X = 385, Y = 25 }
        };
        Point[] RedReady = new Point[]
        {
            new Point { X = 150, Y = 85},
            new Point { X = 240, Y = 85},
            new Point { X = 150, Y = 170 },
            new Point { X = 240, Y = 170 }
        };
        Point[] RedTop = new Point[]
       {
            new Point { X = 385, Y = 55},
            new Point { X = 385, Y = 90},
            new Point { X = 385, Y = 120 },
            new Point { X = 385, Y = 150 },
            new Point { X = 385, Y = 185 },
            new Point { X = 385, Y = 225 }
       };
        public bool StartMoving (int roll, int temp)
        {
            if (temp == -1)
            {
                if (roll == 1 || roll == 6)
                {
                    return true;
                }
            }
            return false;
           
        }
        public int NormalMoving(int roll, int temp)
        {
            temp += roll;
            return temp;
        }
        public bool CheckLocation (int a, int b,int c, int d, int t)
        {
            if (a == b || a == c || a == d)
                return true;
            if (a < b||a<c||a<d) return false;
            if (a - b < t||a-c<t||a-d<t) return true;
            else return false;
        }
        public void Moving(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            PictureBox a = (PictureBox)sender;
            if (temp != -1)
            {
                if (a.Name == "Red0")
                {
                    if (red1._top == false)
                    {
                        if (red1._index == -1)
                        {
                            if (StartMoving(temp, red1._index) == true) 
                            {
                                red1._index =0;
                            }
                            temp = 0;
                        }
                        if (CheckLocation(temp + red1._index, red2._index, red3._index, red4._index, temp) == false && red1._index + temp <= 55 && temp!=0)
                        {
                            red1._index = NormalMoving(temp, red1._index);
                            temp = 0;
                        }
                        if (red1._index == 55)
                        {
                            red1._top = true;
                        }
                        if (red1._index != -1&&temp==0)
                        {
                            a.Location = Red[red1._index];
                        }
                    }
                    if (red1._top == true)
                    {
                        if (CheckLocation(temp + red1._index, red2._index, red3._index, red4._index, temp) == false)
                        {
                            int t = red1._index + temp - 56;
                            if (t <= 6)
                            {
                                NormalMoving(temp, red1._index);
                                a.Location = RedTop[t];
                            }
                        }
                    }
                }
                if (a.Name == "Red1")
                {
                    if (red2._top == false)
                    {
                        if (red2._index == -1)
                        {
                            if (StartMoving(temp, red2._index) == true)
                            {
                                red2._index = 0;
                            }
                            temp = 0;
                        }
                        if (CheckLocation(temp + red2._index, red1._index, red3._index, red4._index, temp) == false && red2._index + temp <= 55 && temp != 0)
                        {
                            red2._index = NormalMoving(temp, red2._index);
                            temp = 0;
                        }
                        if (red2._index == 55)
                        {
                            red2._top = true;
                        }
                        if (red2._index != -1 && temp == 0)
                        {
                            a.Location = Red[red2._index];
                        }
                    }
                    if (red2._top == true)
                    {
                        if (CheckLocation(temp + red2._index, red1._index, red3._index, red4._index, temp) == false)
                        {
                            int t = red2._index + temp - 56;
                            if (t <= 6)
                            {
                                NormalMoving(temp, red2._index);
                                a.Location = RedTop[t];
                            }
                        }
                    }
                }
                if (a.Name == "Red2")
                {
                    if (red3._top == false)
                    {
                        if (red3._index == -1)
                        {
                            if (StartMoving(temp, red3._index) == true)
                            {
                                red3._index = 0;
                            }
                            temp = 0;
                        }
                        if (CheckLocation(temp + red3._index, red1._index, red2._index, red4._index, temp) == false && red3._index + temp <= 55 && temp != 0)
                        {
                            red3._index = NormalMoving(temp, red3._index);
                            temp = 0;
                        }
                        if (red3._index == 55)
                        {
                            red3._top = true;
                        }
                        if (red3._index != -1 && temp == 0)
                        {
                            a.Location = Red[red3._index];
                        }
                    }
                    if (red3._top == true)
                    {
                        if (CheckLocation(temp + red3._index, red1._index, red2._index, red4._index, temp) == false)
                        {
                            int t = red3._index + temp - 56;
                            if (t <= 6)
                            {
                                NormalMoving(temp, red3._index);
                                a.Location = RedTop[t];
                            }
                        }
                    }
                }
                if (a.Name == "Red3")
                {
                    if (red4._top == false)
                    {
                        if (red4._index == -1)
                        {
                            if (StartMoving(temp, red4._index) == true)
                            {
                                red4._index = 0;
                            }
                            temp = 0;
                        }
                        if (CheckLocation(temp + red4._index, red1._index, red2._index, red3._index, temp) == false && red4._index + temp <= 55 && temp != 0)
                        {
                            red4._index = NormalMoving(temp, red4._index);
                            temp = 0;
                        }
                        if (red4._index == 55)
                        {
                            red4._top = true;
                        }
                        if (red4._index != -1 && temp == 0)
                        {
                            a.Location = Red[red4._index];
                        }
                    }
                    if (red4._top == true)
                    {
                        if (CheckLocation(temp + red4._index, red1._index, red2._index, red3._index, temp) == false)
                        {
                            int t = red4._index + temp - 56;
                            if (t <= 6)
                            {
                                NormalMoving(temp, red4._index);
                                a.Location = RedTop[t];
                            }
                        }
                    }
                }
            }
           
          
        }
        private int temp=-1;
        public struct Redsoldier
        {
           public int _index;
           public bool _top;
        };
        
        private void btn_roll_Click(object sender, EventArgs e)
        {
           
            if (temp == -1)
            {
                Random random = new Random();
                temp = random.Next(1, 6);
                switch (temp)
                {
                    case 1:
                        Roll_number.BackgroundImage = Properties.Resources._1;
                        break;
                    case 2:
                        Roll_number.BackgroundImage = Properties.Resources._2;
                        break;
                    case 3:
                        Roll_number.BackgroundImage = Properties.Resources._3;
                        break;
                    case 4:
                        Roll_number.BackgroundImage = Properties.Resources._4;
                        break;
                    case 5:
                        Roll_number.BackgroundImage = Properties.Resources._5;
                        break;
                    case 6:
                        Roll_number.BackgroundImage = Properties.Resources._6;
                        break;


                }
            }
            
           
        }
    }
}
