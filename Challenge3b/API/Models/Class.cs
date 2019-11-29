using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models {
    public class Class {
        public string ClassCode { get; set; }
        public string Name { get; set; }
        public string Building { get; set; }
        public int RoomNo { get; set; }

        public Class () {
        }

        public Class (string classcode, string name, string building, int roomno) {
            ClassCode = classcode;
            Name = name;
            Building = building;
            RoomNo = roomno;
        }
    }
}
