using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models {
    public class RoomClass {
        public string Building { get; set; }
        public int RoomNo { get; set; }
        public ClassinRoom Class { get; set; }

        public RoomClass() {
        }
        public RoomClass(string building, int roomno, ClassinRoom @class) {
            Building = building;
            RoomNo = roomno;
            Class = @class;
        }
    }
}
