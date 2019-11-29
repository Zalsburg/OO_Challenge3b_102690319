using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models {
    public class Computer {
        public int Number { get; set; }
        public int AssembledYear { get; set; }
        public string Building { get; set; }
        public int RoomNo { get; set; }

        public Computer () {
        }

        public Computer (int number, int assembledyear, string building, int roomno) {
            Number = number;
            AssembledYear = assembledyear;
            Building = building;
            RoomNo = roomno;
        }
    }
}
