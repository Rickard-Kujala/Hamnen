using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen
{
    class Meny
    {
        public static int Load(List<string> meyChoices)
        {
            int scroll = 0;
            bool done = false;
            while (!done)
            {
                Console.Clear();
                List<string> menyChoice = new List<string>();
                menyChoice = LoadOrNewSimulation();
                Console.WriteLine("Do you want to Load previous simulation?\n");
                int counter = 0;
                foreach (var item in menyChoice)
                {
                    if (counter == scroll)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(item);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                    counter++;
                }
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Z && scroll == menyChoice.Count - 1)
                {
                    scroll = menyChoice.Count - 1;

                }
                else if (key == ConsoleKey.A && scroll == 0)
                {
                    scroll = 0;

                }

                else if (key == ConsoleKey.Z)
                {
                    scroll++;

                }
                else if (key == ConsoleKey.A)
                {
                    scroll--;

                }
                else if (key == ConsoleKey.Enter)
                {
                    done = true;
                }

            }

            return scroll;
        }
        public static List<string> LoadOrNewSimulation()
        {
            List<string> choices1 = new List<string>();
            string s1 = "|   Load simulation    |\n" +
                        "|----------------------|";
            string s2 = "|   New simulation     |\n" +
                        "|----------------------|";
            choices1.Add(s1);
            choices1.Add(s2);
            return choices1;
        }
        public static List<string> SaveOrNot()
        {
            List<string> choices1 = new List<string>();
            string s1 = "|   Save simulation    |\n" +
                        "|----------------------|";
            string s2 = "|   Don´t save         |\n" +
                        "|----------------------|";
            choices1.Add(s1);
            choices1.Add(s2);
            return choices1;
        }
        public static List<string> TypeOfBoatMeny()
        {
            List<string> choices1 = new List<string>();
            string s1 = "   Rowingboat  ";
            string s2 = "   Motorboat   ";
            string s3 = "   Sailboat    ";
            string s4 = "   Cargoship   ";
            string s5 = "   Catamaran   ";
            choices1.Add(s1);
            choices1.Add(s2);
            choices1.Add(s3);
            choices1.Add(s4);
            choices1.Add(s5);

            return choices1;
        }
        public static int GenerateTypeOfBoat()
        {
            int scroll = 0;
            bool done = false;
            while (!done)
            {
                Console.Clear();
                List<string> menyChoice = new List<string>();
                menyChoice = TypeOfBoatMeny();
                Console.WriteLine("Chose type of boat\n");
                int counter = 0;
                foreach (var item in menyChoice)
                {
                    if (counter == scroll)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(item);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                    counter++;
                }
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Z && scroll == menyChoice.Count - 1)
                {
                    scroll = menyChoice.Count - 1;

                }
                else if (key == ConsoleKey.A && scroll == 0)
                {
                    scroll = 0;

                }

                else if (key == ConsoleKey.Z)
                {
                    scroll++;

                }
                else if (key == ConsoleKey.A)
                {
                    scroll--;

                }
                else if (key == ConsoleKey.Enter)
                {
                    done = true;
                }

            }

            return scroll;
        }

        public static int Save(List<string> meyChoices)
        {
            int scroll = 0;
            bool done = false;
            while (!done)
            {
                Console.Clear();
                Console.WriteLine("Do you want to save previous simulation?\n");
                List<string> menyChoice = new List<string>();
                menyChoice= SaveOrNot();

                int counter = 0;
                foreach (var item in menyChoice)
                {
                    if (counter == scroll)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(item);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                    counter++;
                }
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Z && scroll == menyChoice.Count - 1)
                {
                    scroll = menyChoice.Count - 1;

                }
                else if (key == ConsoleKey.A && scroll == 0)
                {
                    scroll = 0;
                }

                else if (key == ConsoleKey.Z)
                {
                    scroll++;
                }
                else if (key == ConsoleKey.A)
                {
                    scroll--;
                }
                else if (key == ConsoleKey.Enter)
                {
                    done = true;
                }

            }

            return scroll;
        }
       
    }
}
