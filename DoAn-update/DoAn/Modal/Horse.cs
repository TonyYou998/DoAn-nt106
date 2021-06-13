using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Modal
{
  public  class Horse
    {
        public Point location { get; set; }
        public String color { get; set; }
        public int id { get; set; }
        public string owner { get; set; }
        public Horse(Point location,String color,int id,string owner)
        {
            this.location = location;
            this.color = color;
            this.id = id;
            this.owner = owner;
            
        }
    }
}
