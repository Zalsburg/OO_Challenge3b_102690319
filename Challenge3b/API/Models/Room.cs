using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models {
    public class Room {
        public string Building { get; set; }
        public int RoomNo { get; set; }
        public int Capacity { get; set; }

        public Room () {
        }
        public Room (string building, int roomno, int capacity) {
            Building = building;
            RoomNo = roomno;
            Capacity = capacity;
        }
    }
}
