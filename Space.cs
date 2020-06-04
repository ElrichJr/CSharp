using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    abstract class Space<T>
    {
        public uint area { get; set; }
        abstract public T Contents();
    }

    [Flags]
    public enum Furniture { Bed=1, Chair=2, Table=4, Oven=8, Fridge=16}

    class Room : Space<Furniture>
    {
        private static int idStart = 0;
        protected Furniture furniture;
        public int id;
        protected string roomtype;

        public Room()
        {
            area = 1;
            id = idStart;
            idStart++;
            furniture = 0;
            roomtype = "room";
        }

        public override Furniture Contents() => furniture;
        public virtual void AddFurniture(Furniture a) => furniture |= a;
        public void RemoveFurniture(Furniture a) => furniture = furniture ^ (furniture & a);
        public string RoomType() => roomtype;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value < idStart)
                {
                    Console.WriteLine("Are you sure? This id might have already been used y/n");
                    string x = Console.ReadLine();
                    if (x == "y")
                    {
                        id = value;
                    }
                    else
                    {
                        Console.WriteLine("Id input cancelled");
                    }
                    Console.In.ReadLine();
                }
            }
        }
    }

    class Kitchen : Room
    {
        public Kitchen() : base()
        {
            roomtype = "kitchen";
        }

        public override void AddFurniture(Furniture a)
        {
            if((a & Furniture.Bed) != 0)
            {
                Console.WriteLine("Sleeping two steps from the fridge might be convenient, but yikes, man");
            }
            else
            {
                base.AddFurniture(a);
            }
        }
    }

    class Bedroom : Room
    {
        public Bedroom() : base()
        {
            roomtype = "bedroom";
        }
        
        public override void AddFurniture(Furniture a)
        {
            if ((a & (Furniture.Fridge | Furniture.Oven)) != 0)
            {
                Console.WriteLine("Sleeping two steps from the fridge might be convenient, but yikes, man");
            }
            else
            {
                base.AddFurniture(a);
            }
        }
    }
}
