using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    struct Apartament
    {
        public Kitchen kitchen;
        public Bedroom[] bedroom;
        public Room[] room;
        public Apartament(int bedroomNumber, int roomNumber)
        {
            kitchen = new Kitchen();
            bedroom = new Bedroom[bedroomNumber];
            room = new Room[roomNumber];
        }
    }
}
