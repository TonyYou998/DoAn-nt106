using System.Drawing;

namespace Client
{
    public class MapTable
    {

        public Point[] Ready = new Point[]
        {
            //--------- RED Pos -----------
            new Point { X = 150, Y = 85},
            new Point { X = 240, Y = 85},
            new Point { X = 150, Y = 170 },
            new Point { X = 240, Y = 170 },
            //--------- Green Pos ----------
            new Point { X = 515, Y = 85},
            new Point { X = 600, Y = 85},
            new Point { X = 515, Y = 170 },
            new Point { X = 600, Y = 170 },
            //--------- Blue Pos ----------
            new Point { X = 150, Y = 440},
            new Point { X = 230, Y = 440},
            new Point { X = 150, Y = 530 },
            new Point { X = 230, Y = 530 },
            //--------- Yellow Pos ----------
            new Point { X = 515, Y = 440},
            new Point { X = 600, Y = 440},
            new Point { X = 515, Y = 530 },
            new Point { X = 600, Y = 530 }
        };

        public Point[] OnTop = new Point[]
        {
            //--------- RED Pos -----------
            new Point { X = 385, Y = 55},
            new Point { X = 385, Y = 90},
            new Point { X = 385, Y = 120},
            new Point { X = 385, Y = 150},
            new Point { X = 385, Y = 185},
            new Point { X = 385, Y = 225}, 
            
            //--------- Green Pos ----------
            new Point { X = 615, Y = 285},
            new Point { X = 580, Y = 285},
            new Point { X = 545, Y = 285},
            new Point { X = 510, Y = 285},
            new Point { X = 475, Y = 285},
            new Point { X = 435, Y = 285},

            //--------- Blue Pos ----------
            new Point { X = 145, Y = 280},
            new Point { X = 180, Y = 280},
            new Point { X = 215, Y = 280},
            new Point { X = 250, Y = 280},
            new Point { X = 290, Y = 280},
            new Point { X = 330, Y = 280},

            //--------- Yellow Pos ----------
            new Point { X = 380, Y = 495},
            new Point { X = 380, Y = 465},
            new Point { X = 380, Y = 430},
            new Point { X = 380, Y = 400},
            new Point { X = 380, Y = 370},
            new Point { X = 380, Y = 330}
        };

        public Point[] Map = new Point[]
        {
            new Point {X = 330, Y = 25 }, new Point {X = 330, Y = 55 }, new Point {X = 330, Y = 90 }, new Point {X = 330, Y = 120 },
            new Point {X = 330, Y = 150 }, new Point {X = 330, Y = 185 }, new Point {X = 330, Y = 235 }, new Point {X = 290, Y = 235 },
            new Point {X = 250, Y = 235 }, new Point {X = 215, Y = 235 }, new Point {X = 180, Y = 235 }, new Point {X = 145, Y = 235 },
            new Point {X = 105, Y = 235 }, new Point {X = 105, Y = 280 }, new Point {X = 105, Y = 330 }, new Point {X = 145, Y = 330 },
            new Point {X = 180, Y = 330 }, new Point {X = 215, Y = 330 }, new Point {X = 250, Y = 330 }, new Point {X = 290, Y = 330 },
            new Point {X = 330, Y = 330 }, new Point {X = 330, Y = 370 }, new Point {X = 330, Y = 400 }, new Point {X = 330, Y = 430 },
            new Point {X = 330, Y = 465 }, new Point {X = 330, Y = 495 }, new Point {X = 330, Y = 530 }, new Point {X = 380, Y = 530 },
            new Point {X = 430, Y = 530 }, new Point {X = 430, Y = 495 }, new Point {X = 430, Y = 465 }, new Point {X = 430, Y = 430 },
            new Point {X = 430, Y = 400 }, new Point {X = 430, Y = 370 }, new Point {X = 430, Y = 330 }, new Point {X = 475, Y = 330 },
            new Point {X = 510, Y = 330 }, new Point {X = 545, Y = 330 }, new Point {X = 585, Y = 330 }, new Point {X = 620, Y = 330 },
            new Point {X = 655, Y = 330 }, new Point {X = 655, Y = 285 }, new Point {X = 650, Y = 235 }, new Point {X = 615, Y = 235 },
            new Point {X = 580, Y = 235 }, new Point {X = 545, Y = 235 }, new Point {X = 510, Y = 235 }, new Point {X = 475, Y = 235 },
            new Point {X = 440, Y = 235 }, new Point {X = 435, Y = 185 }, new Point {X = 435, Y = 150 }, new Point {X = 435, Y = 120 },
            new Point {X = 435, Y = 90 }, new Point {X = 435, Y = 55 }, new Point {X = 435, Y = 25 }, new Point {X = 385, Y = 25 }
        };

    }
}
