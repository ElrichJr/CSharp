using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Room[] a = null;
            for (bool stay=true; stay; )
            {
                Console.WriteLine("The blueprint has " + n + " rooms");
                Console.WriteLine("|---------MENU---------|");
                Console.WriteLine("|1.Create new room     |");
                Console.WriteLine("|2.Check room          |");
                Console.WriteLine("|3.Modify room         |");
                Console.WriteLine("|4.Delete room         |");
                Console.WriteLine("|5.Create an apartament|");
                Console.WriteLine("|6.Quit                |");
                Console.WriteLine("|----------------------|");
                int choice;
                choice = Int32.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1: CreateRoom(ref a, ref n); break;
                    case 2: CheckRoom(a); break;
                    case 3: ModifyRoom(ref a); break;
                    case 4: DeleteRoom(ref a, ref n); break;
                    case 5: CreateApartament(a); break;
                    case 6: stay = false; break;
                    default: Console.WriteLine("Wrong input"); break;
                }
            }
        }

        //---------------------------------------------------------------------------------

        static void CreateRoom(ref Room[] a, ref int n)
        {
            n++;
            Room[] newRoom = new Room[n];
            for (int i = 0; i < n - 1; i++)
            {
                newRoom[i] = a[i];
                Console.WriteLine(newRoom[i].id);
            }
            for (bool stay = true; stay;)
            {
                Console.WriteLine("|---------TYPE---------|");
                Console.WriteLine("|1.Kitchen             |");
                Console.WriteLine("|2.Bedroom             |");
                Console.WriteLine("|3.Generic             |");
                Console.WriteLine("|----------------------|");
                int choice;
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: newRoom[n - 1] = new Kitchen(); stay = false; break;
                    case 2: newRoom[n - 1] = new Bedroom(); stay = false; break;
                    case 3: newRoom[n - 1] = new Room(); stay = false; break;
                    default: Console.WriteLine("Wrong input"); break;
                }
            }
            a = newRoom;
            Console.WriteLine("Success");
        }

        static void CheckRoom(Room[] a)
        {
            Console.WriteLine("Which room to check?");
            int n = 0;
            for (bool success = false; !success;)
            {
                success = Int32.TryParse(Console.ReadLine(), out n);
                if (success)
                {
                    if ((n < 0) || (a.Length <= n))
                    {
                        success = false;
                    }
                }
                if (!success)
                {
                    Console.WriteLine("Wrong input");
                }
            }
            Console.WriteLine("This is a " + a[n].GetType());
            Console.WriteLine("Room id - " + a[n].id);
            Console.WriteLine("Room area - " + a[n].area);
            Console.WriteLine("Furniture - " + a[n].Contents());
        }

        static void ModifyRoom(ref Room[] a)
        {
            Console.WriteLine("Which room to modify?");
            int n=0;
            for (bool success = false; !success; )
            {
                success = Int32.TryParse(Console.ReadLine(), out n);
                if(success)
                {
                    if ((n < 0) || (a.Length <= n))
                    {
                        success = false;
                    }
                }
                if(!success)
                {
                    Console.WriteLine("Wrong input");
                }
            }
            Console.WriteLine("This is a " + a[n].GetType());
            Console.WriteLine("Room id - " + a[n].id);
            Console.WriteLine("Room area - " + a[n].area);
            Console.WriteLine("Furniture - " + a[n].Contents());
            Console.WriteLine();
            Console.WriteLine("|--------ACTION--------|");
            Console.WriteLine("|1.Change area         |");
            Console.WriteLine("|2.Change ID           |");
            Console.WriteLine("|3.Change furniture    |");
            Console.WriteLine("|4.Change location     |");
            Console.WriteLine("|----------------------|");
            int choice = 0;
            for (bool success = false; !success;)
            {
                success = Int32.TryParse(Console.ReadLine(), out choice);
                if (success)
                {
                    if ((choice < 1) || (4 < choice))
                    {
                        success = false;
                    }
                }
                if (!success)
                {
                    Console.WriteLine("Wrong input");
                }
            }
            if(choice == 1)
            {
                for (bool success = false; !success;)
                {
                    success = UInt32.TryParse(Console.ReadLine(), out uint newArea);
                    if (success)
                    {
                        a[n].area = newArea;
                    }
                    if (!success)
                    {
                        Console.WriteLine("Wrong input");
                    }
                }
            }
            if(choice == 2)
            {
                for (bool success = false; !success;)
                {
                    success = Int32.TryParse(Console.ReadLine(), out int newId);
                    if (success)
                    {
                        a[n].id = newId;
                    }
                    if (!success)
                    {
                        Console.WriteLine("Wrong input");
                    }
                }
            }
            if(choice == 3)
            {
                Console.WriteLine("1 - Put a bed in");
                Console.WriteLine("2 - Put chairs in");
                Console.WriteLine("3 - Put a table in");
                Console.WriteLine("4 - Put an oven in");
                Console.WriteLine("5 - Put a fridge in");
                Console.WriteLine("6 - Remove the bed");
                Console.WriteLine("7 - Remove the chairs");
                Console.WriteLine("8 - Remove the table");
                Console.WriteLine("9 - Remove the oven");
                Console.WriteLine("0 - Remove the fridge");
                for (bool success = false; !success;)
                {
                    success = Int32.TryParse(Console.ReadLine(), out int action);
                    if (success)
                    {
                        switch(action)
                        {
                            case 1: a[n].AddFurniture(Furniture.Bed); break;
                            case 2: a[n].AddFurniture(Furniture.Chair); break;
                            case 3: a[n].AddFurniture(Furniture.Table); break;
                            case 4: a[n].AddFurniture(Furniture.Oven); break;
                            case 5: a[n].AddFurniture(Furniture.Fridge); break;
                            case 6: a[n].RemoveFurniture(Furniture.Bed); break;
                            case 7: a[n].RemoveFurniture(Furniture.Chair); break;
                            case 8: a[n].RemoveFurniture(Furniture.Table); break;
                            case 9: a[n].RemoveFurniture(Furniture.Oven); break;
                            case 0: a[n].RemoveFurniture(Furniture.Fridge); break;
                            default: success = false; break;
                        }
                    }
                    if (!success)
                    {
                        Console.WriteLine("Wrong input");
                    }
                }
            }
            if(choice == 4)
            {
                Console.WriteLine("|New location:");
                Console.WriteLine("|1.Minsk");
                Console.WriteLine("|2.Moscow");
                Console.WriteLine("|3.London");
                int newLoc = 0;
                for (bool success = false; !success;)
                {
                    success = Int32.TryParse(Console.ReadLine(), out newLoc);
                    if (success)
                    {
                        if ((newLoc < 1) || (3 < newLoc))
                        {
                            success = false;
                        }
                    }
                    if (!success)
                    {
                        Console.WriteLine("Wrong input");
                    }
                }
                switch(newLoc)
                {
                    case 1: a[n].location = Location.Minsk; break;
                    case 2: a[n].location = Location.Moscow; break;
                    case 3: a[n].location = Location.London; break;
                }
            }
        }

        static void DeleteRoom(ref Room[] a, ref int n)
        {
            if (n == 0)
            {
                return;
            }
            n--;
            Console.WriteLine("Which room to delete?");
            int deletion = 0;
            for (bool success = false; !success; )
            {
                success = Int32.TryParse(Console.ReadLine(), out deletion);
                if (success)
                {
                    if ((deletion < 0) || (a.Length <= deletion))
                    {
                        success = false;
                    }
                }
                if (!success)
                {
                    Console.WriteLine("Wrong input");
                }
            }
            Room[] newRoom = new Room[n];
            for (int i = 0; i < n; i++)
            {
                if (i >= deletion)
                {
                    newRoom[i] = a[i + 1];
                }
                else
                {
                    newRoom[i] = a[i];
                }
            }
            a = newRoom;
            Console.WriteLine("Success");
        }

        static void CreateApartament(Room[] a)
        {
            int rooms = 0, bedrooms = 0;
            for(int i = 0; i<a.Length; i++)
            {
                if(a[i].GetType()==typeof(Room))
                {
                    rooms++;
                }
                if(a[i].GetType() == typeof(Bedroom))
                {
                    bedrooms++;
                }
            }
            Apartament ap = new Apartament(bedrooms, rooms);
            for (int i = 0, kitchens = 0; i < a.Length; i++)
            {
                if (a[i].GetType() == typeof(Room))
                {
                    rooms--;
                    ap.room[rooms] = a[i];
                }
                if (a[i].GetType() == typeof(Bedroom))
                {
                    bedrooms--;
                    ap.bedroom[bedrooms] = (Bedroom)a[i];
                }
                if (a[i].GetType() == typeof(Kitchen))
                {
                    kitchens++;
                    if (kitchens < 2)
                    {
                        ap.kitchen = (Kitchen)a[i];
                    }
                    else
                    {
                        Console.WriteLine("Numerous Kitchens detected, only the first will be used");
                    }
                }
            }
            Console.WriteLine("Apartament overview:");
            Console.WriteLine("This is a " + ap.kitchen.GetType());
            Console.WriteLine("Room id - " + ap.kitchen.id);
            Console.WriteLine("Room area - " + ap.kitchen.area);
            Console.WriteLine("Furniture - " + ap.kitchen.Contents());
            for (int i = 0; i < ap.room.Length; i++)
            {
                Console.WriteLine("This is a " + ap.room[i].GetType());
                Console.WriteLine("Room id - " + ap.room[i].id);
                Console.WriteLine("Room area - " + ap.room[i].area);
                Console.WriteLine("Furniture - " + ap.room[i].Contents());
            }
            for (int i = 0; i < ap.bedroom.Length; i++)
            {
                Console.WriteLine("This is a " + ap.bedroom[i].GetType());
                Console.WriteLine("Room id - " + ap.bedroom[i].id);
                Console.WriteLine("Room area - " + ap.bedroom[i].area);
                Console.WriteLine("Furniture - " + ap.bedroom[i].Contents());
            }

            ap.ApartamentNormalized += delegate (Location x)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i].location = x;
                }
            };

            try
            {
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i].location != a[i - 1].location)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                ap.NormalizeApartament();
            }
        }
    }
}
