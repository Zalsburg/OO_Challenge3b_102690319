using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models {
    public class ClassinRoom {
        public string ClassCode { get; set; }
        public string Name { get; set; }

        public ClassinRoom() {
        }

        public ClassinRoom(string classcode, string name) {
            ClassCode = classcode;
            Name = name;
        }
    }
}
