using System;
using System.Linq;
using System.Collections.Generic;

namespace Hamnen
{
    class Program
    {
        static void Main(string[] args)
        {
            Berth[] Docks = new Berth[64];
            List<Boat> boats = new List<Boat>();

            while (true)
            {
                Berth.Departure(Docks);
                Berth.GenerateBoats(5,boats);
                Berth.Moor(boats, Docks);
                Berth.Print(Docks);
                CountDown(Docks);
                Console.ReadLine();
            }
        }
        static void CountDown(Berth[]docks)
        {
            foreach (var boat in docks)
            {
                if (boat != null && boat.Lot[0] != null)
                {
                    boat.Lot[0].DaysLeftInTheDock--;
                }
                if (boat != null && boat.Lot[1] != null)
                {
                    boat.Lot[1].DaysLeftInTheDock--;

                }
                //if (boat != null && boat.Lot[0]!=null && boat.Lot[0].DaysLeftInTheDock==0)
                //{
                //    boat.Lot[0] = null;
                //    boat.IsEmpty=true;
                //}
                //if (boat != null && boat.Lot[1]!= null && boat.Lot[1].DaysLeftInTheDock == 0)
                //{
                //    boat.Lot[1] = null;
                //    boat.IsEmpty = true;
                //}
            }
        }
        static void CountDown()
        {
            
        }
    }
}
