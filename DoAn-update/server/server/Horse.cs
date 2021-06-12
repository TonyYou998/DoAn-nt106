using System.Drawing;

namespace Server
{
    class Horse
    {
        public Point location { get; set; }
        public string color { get; set; }

        public int id { get; set; }

        public Horse(Point p,string color,int id)
        {
            this.location = p;
            
            this.color = color;
            this.id = id;
        }
    }
}
