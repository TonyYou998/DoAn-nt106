using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cờ_cá_ngựa
{
    class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RoomID { get; set; }

        public string FullInfo
        {
            get{
                return $"{ID} {Name} {RoomID}";
            }
        }
    }
}
