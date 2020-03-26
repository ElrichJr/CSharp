using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            const int n = 36;
            const int theirmax = 16;
            Card[] a = new Card[n];
            byte[] val = { 6, 7, 8, 9, 10, 2, 3, 4, 11 };
            for (int i = 0; i < n; i++)
            {
                a[i].Rank = RankE.Six+(i / 4);
                a[i].Suit = (char)(3 + (i % 4));
                a[i].Value = val[i / 4];
                a[i].Owner = 0;
            }
            string you = "y", them = "y";
            int their = 0, your = 0;
            byte counter = 1;
            do
            {
                Random rnd = new Random();
                if ((you == "y")&&(counter>2))
                {
                    do
                    {
                        Console.Write("\nYour hand is\n");
                        for (int i = 0; i < n; i++)
                        {
                            if (a[i].Owner > 0)
                            {
                                Console.Write(a[i].Rank);
                                Console.Write(a[i].Suit);
                            }
                        }
                        Console.Write("\nTake another card? y/n");
                        you = Console.ReadLine();
			Console.Clear();
                        if ((you != "y") && (you != "n")) Console.Write("\nYou picked the wrong answer, fool!");
                    }
                    while ((you != "y") && (you != "n"));
                }
                if (you == "y")
                {
                    for (int ownership=1; ownership>0; ownership++)
                    {
                        int i = rnd.Next(n);
                        if (a[i].Owner == 0)
                        {
                            a[i].Owner = ownership;
                            your += a[i].Value;
                            Console.Write("\nYour new Card is ");
                            Console.Write(a[i].Rank);
                            Console.Write(a[i].Suit);
                            ownership = -1;
                        }
                    }
                }
                if (them == "y")
                {
                    for (int ownership = -1; ownership < 0; ownership--)
                    {
                        int i;
                        i = rnd.Next(n);
                        if (a[i].Owner == 0)
                        {
                            a[i].Owner = ownership;
                            their += a[i].Value;
                            ownership = 1;
                        }
                    }
                    if ((their >= theirmax) && (counter > 2)) them = "n";
                    counter++;
                }
            } while ((you == "y") || (them == "y"));
            Console.Write("\nCards open");
            Console.Write("\nYour hand is\n");
            for (int i = 0; i < n; i++)
            {
                if (a[i].Owner > 0)
                {
                    Console.Write(a[i].Rank);
                    Console.Write(a[i].Suit);
                }
            }
            Console.Write("\nTheir hand is\n");
            for (int i = 0; i < n; i++)
            {
                if (a[i].Owner < 0)
                {
                    Console.Write(a[i].Rank);
                    Console.Write(a[i].Suit);
                }
            }
            Console.Write("\nTheir final score ");
            Console.Write(their);
            Console.Write("\nYour final score ", your);
            Console.Write(your);
            if ((their == your) || ((their > 21) && (your > 21))) Console.Write("\nDraw");
            else
            {
                if ((their > your) || (your > 21))
                    if (their>21) Console.Write("\nYou win");
                    else Console.Write("\nYou lose");
                else
                if ((their < your) || (their > 21))
                    if (your > 21) Console.Write("\nYou lose");
                    else Console.Write("\nYou win");
            }
            Console.ReadKey();
        }
    }
}
