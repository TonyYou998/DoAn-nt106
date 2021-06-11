using System.Drawing;

namespace Server
{
    class Horse
    {
        private Point location;
        private string color { get; set; }

        private int id { get; set; }

        public Horse(Point p,string color,int id)
        {
            this.location.X = p.X;
            this.location.Y = p.Y;
            this.color = color;
            this.id = id;
        }
    }
}
