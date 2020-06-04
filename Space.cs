using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    abstract class Space<T> : IPriceable
    {
        public uint area { get; set; }
        public Location location { get; set; }
        abstract public T Contents();
        public double Price()
        {
            return area * (uint)location;
        }
    }

    [Flags]
    public enum Furniture { Bed=1, Chair=2, Table=4, Oven=8, Fridge=16}
    public enum Location { Minsk=1, Moscow=10, London=80}

    class Room : Space<Furniture>
    {
        private static int idStart = 0;
        protected Furniture furniture;
        public int id;

        public Room() : base()
        {
            id = idStart;
            idStart++;
            furniture = 0;
        }

        public override Furniture Contents() => furniture;
        public virtual void AddFurniture(Furniture a) => furniture |= a;
        public void RemoveFurniture(Furniture a) => furniture = furniture ^ (furniture & a);
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
