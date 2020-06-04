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
            ApartamentNormalized = x => Console.WriteLine("Locations are now uniform");
        }
        public delegate void MyDelegate(Location input);
        public event MyDelegate ApartamentNormalized;
        public void NormalizeApartament()
        {
            Console.WriteLine("Rooms are in different countries, which one is it, really?");
            Console.WriteLine("|1.Minsk");
            Console.WriteLine("|2.Moscow");
            Console.WriteLine("|3.London");
            int newLoc;
            for (bool success = false; !success;)
            {
                success = Int32.TryParse(Console.ReadLine(), out newLoc);
                switch (newLoc)
                {
                    case 1: kitchen.location = Location.Minsk; break;
                    case 2: kitchen.location = Location.Moscow; break;
                    case 3: kitchen.location = Location.London; break;
                    default: success = false; break;
                }
                if (!success)
                {
                    Console.WriteLine("Wrong input");
                }
            }

            for (int i = 0; i < bedroom.Length; i++)
            {
                bedroom[i].location = kitchen.location;
            }
            for (int i = 0; i < room.Length; i++)
            {
                room[i].location = kitchen.location;
            }

            ApartamentNormalized(kitchen.location);
        }
    }
}
