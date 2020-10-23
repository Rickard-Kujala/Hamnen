using System;
using System.Linq;
using System.Collections.Generic;

namespace Hamnen
{
    class Program
    {
        static void Main(string[] args)
        {
            Berth berth = new Berth();
            Berth[] Docks = new Berth[10];
            
            List<Boat> boats = new List<Boat>();
            while (true)
            {
                Berth.GenerateBoats(5,boats);
                Berth.Moor(boats, Docks);
                Console.ReadLine();
            }
            
        }

        //private static void printTheDock(Boat[,]dock/*, Boat b*/)
        //{
        //    int k = 1;
        //    int l = 1;
        //    for (int i = 0; i < 2; i++)
        //    {
        //        for (int j = 0; j < 10; j++)
        //        {
        //            if (dock[j, i] == null)
        //            {
        //                Console.Write("  tomt ");
        //            }
        //            else
        //            {
        //                Console.Write($" {b.ID} ");
        //            }
        //            k++;

        //        }
        //        Console.WriteLine();
        //        l ++;
        //    }
        //}
        private static void SearchForDockingspace(Boat[,] dock, Boat b)
        {
            int k = 0;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (dock[j,i]==null )
                    {
                        dock[j, i] = b;
                    }
                    
                    k++;
                }
                Console.WriteLine();
            }
        }
        //static void GenerateBoats(Boat[,] dock)
        //{
        //    int i=Boat.GetRandomValue(1, 1);
        //    switch (i)
        //    {
        //        case 1:
        //           Boat b=RowingBoat.GenerateBoat();
        //            SearchForDockingspace(dock, b);
        //            break;

        //    }
        //}
    }
}
