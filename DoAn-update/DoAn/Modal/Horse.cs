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
        private Point location;
        private String color;
        private int id;
        public Horse(Point location,String color,int id)
        {
            this.location = location;
            this.color = color;
            this.id = id;
        }
    }
}
