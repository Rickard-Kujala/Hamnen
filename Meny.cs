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
                Console.WriteLine("Do you want to Load previous simulation?");
                int counter = 0;
                foreach (var item in meyChoices)
                {
                    if (counter == scroll)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(item);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else
                    {
                        Console.WriteLine(item);

                    }
                    counter++;
                }
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.A && scroll == meyChoices.Count - 1)
                {
                    scroll = meyChoices.Count - 1;

                }
                else if (key == ConsoleKey.Z && scroll == 0)
                {
                    scroll = 0;

                }

                else if (key == ConsoleKey.A)
                {
                    scroll++;

                }
                else if (key == ConsoleKey.Z)
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
        public static List<string> yesOrNo()
        {
            List<string> choices1 = new List<string>();
            string s1 = "YES";
            string s2 = "NO";
            choices1.Add(s1);
            choices1.Add(s2);



            return choices1;
        }
        public static int Save(List<string> meyChoices)
        {
            int scroll = 0;
            bool done = false;
            while (!done)
            {
                Console.Clear();
                Console.WriteLine("Do you want to save previous simulation?");


                int counter = 0;
                foreach (var item in meyChoices)
                {
                    if (counter == scroll)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(item);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else
                    {
                        Console.WriteLine(item);

                    }
                    counter++;
                }
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.A && scroll == meyChoices.Count - 1)
                {
                    scroll = meyChoices.Count - 1;

                }
                else if (key == ConsoleKey.Z && scroll == 0)
                {
                    scroll = 0;

                }

                else if (key == ConsoleKey.A)
                {
                    scroll++;

                }
                else if (key == ConsoleKey.Z)
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
