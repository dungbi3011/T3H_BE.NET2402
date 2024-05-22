using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public RoomType RoomType {get; set;}
        public string Description { get; set; }
        public long Cost { get; set; }
        public State State { get; set; }
    }
}
