using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write a line ");
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            for (bool exit = false; exit == false;)
            {
                Console.WriteLine(sb.ToString());
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1 - Turn the word order around");
                Console.WriteLine("2 - Find hex numbers in it");
                Console.WriteLine("3 - Replace letters after vowels");
                Console.WriteLine("4 - Exit");
                int x = Console.Read() - 48;
                switch (x)
                {
                    case 1: Turnaround(sb); break;
                    case 2: Hex(sb); break;
                    case 3: Replace(sb); break;
                    case 4: exit = true; break;
                    default: Console.WriteLine("Well, that was a wrong choice"); break;
                }
                Console.In.ReadLine();
            }
        }

//------------------------------------------------------------------------------------------------------------------

        static void Turnaround(StringBuilder start)
        {
            StringBuilder second = new StringBuilder();
            int lastSpace = -1;
            for (int i = 0; i < start.Length; i++)
                if (start[i] == ' ')
                {
                    second.Insert(0, start.ToString(lastSpace + 1, i - lastSpace - 1));
                    second.Insert(0, " ");
                    lastSpace = i;
                }
            second.Insert(0, start.ToString(lastSpace + 1, start.Length - lastSpace - 1));
            Console.WriteLine(second);
        }

        static void Hex(StringBuilder line)
        {
            char[] hexNumbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F', ' ' };
            byte counting = 1;
            int lastSpace = -1;
            int a = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (counting == 1)
                {
                    for (int h = 0; h < hexNumbers.Length; h++)
                    {
                        if (line[i] == hexNumbers[h])
                        {
                            counting = 1;
                            h = hexNumbers.Length;
                        }
                        else
                        {
                            counting = 0;
                        }
                    }
                }
                if (line[i] == ' ')
                {
                    if (counting == 1)
                    {
                        a = 0;
                        for (int j = i - 1; j > lastSpace; j--)
                        {
                            if (line[j] < 58)
                            {
                                a = a + ((int)line[j] - 48) * (int)Math.Pow(16, (i - j - 1));
                            }
                            else
                            {
                                if (line[j] < 91)
                                {
                                    a = a + ((int)line[j] - 55) * (int)Math.Pow(16, (i - j - 1));
                                }
                                else
                                {
                                    a = a + ((int)line[j] - 87) * (int)Math.Pow(16, (i - j - 1));
                                }
                            }
                        }
                        line.Remove(lastSpace + 1, i - lastSpace - 1);
                        Console.WriteLine(line);
                        line.Insert(lastSpace + 1, a.ToString());
                        Console.WriteLine(line);
                        counting = 0;
                    }
                    else
                        counting = 1;
                    lastSpace = i;
                }
                if (i == line.Length - 1)
                {
                    if (counting == 1)
                    {
                        for (int j = i; j > lastSpace; j--)
                        {
                            if (line[j] < 58)
                                a = a + ((int)line[j] - 48) * (int)Math.Pow(16, (i - j));
                            else
                                if (line[j] < 91)
                                a = a + ((int)line[j] - 55) * (int)Math.Pow(16, (i - j));
                            else
                                a = a + ((int)line[j] - 87) * (int)Math.Pow(16, (i - j));
                        }
                        line.Remove(lastSpace + 1, i - lastSpace);
                        Console.WriteLine(line);
                        line.Insert(lastSpace + 1, a.ToString());
                        Console.WriteLine(line);
                        counting = 0;
                    }
                }
            }
            Console.WriteLine(line);
        }


        static void Replace(StringBuilder what)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };
            for (int i = 0; i < what.Length - 1; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (what[i] == vowels[j])
                    {
                        if (what[i + 1] != ' ')
                        {
                            what[i + 1] = (char)(((what[i + 1] == 'z') || (what[i + 1] == 'Z')) ? what[i + 1] - 25 : what[i + 1] + 1);
                        }
                    }
                }
            }
            Console.WriteLine(what);
        }
    }
}
