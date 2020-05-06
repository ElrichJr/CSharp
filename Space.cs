using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Space
    {
        public uint area { get; set; }
    }

    [Flags]
    public enum Furniture { Bed=1, Chair=2, Table=4, Oven=8, Fridge=16}

    class Room : Space
    {
        private static int idStart = 0;
        protected Furniture furniture;
        public int id;

        public Room()
        {
            SetId(this);
            furniture = 0;
        }
        public Furniture SeeFurniture => furniture;
        public void AddFurniture(Furniture a) => furniture |= a;
        public void RemoveFurniture(Furniture a) => furniture = furniture ^ (furniture & a);
        public static void SetId(Room a)
        {
            a.id = idStart;
            idStart++;
        }
    }
}
