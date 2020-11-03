using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Hamnen
{
    class RowingBoat : Boat
    {
        public int MaxPAssengers { get; set; }
        public RowingBoat(string id, int weight, int speed, int daysleftinthedock, int docknumber, string type, int size, int maxpassengers)
            : base  ( id,  weight,  speed,  daysleftinthedock, docknumber, type, size)
        {
            MaxPAssengers = maxpassengers;
        }
        public static Boat Generate()
        {
            string ID = Boat.GetID("R");
            int weight = Boat.GetRandomValue(100, 300);
            int speed = Boat.GetRandomValue(1, 3);
            speed = Boat.ConvertToKmPerHour(speed);
            int passengers = Boat.GetRandomValue(1, 6);
            RowingBoat R = new RowingBoat(ID, weight, speed, 1, 1,"Roddbåt ", 1, passengers);
            return R;
        }
        public static bool FindBerth(Berth[]docks, Boat b)
        {
            bool rejected = true;
            for (int i = 0; i < docks.Length; i++)
            {
                if (docks[i].IsEmpty==true && docks[i].Lot[0]==null )
                {
                    docks[i].Lot[0] = b;
                    docks[i].IsEmpty =false;
                    b.DockNumber = i + 1;
                    rejected = false;
                    break;
                }
                else if (docks[i].IsEmpty==false && docks[i].Lot[0] is RowingBoat && docks[i].Lot[1]==null)
                {
                    docks[i].Lot[1] = b;
                    docks[i].IsEmpty = false;
                    b.DockNumber = i + 1;
                    rejected = false;
                    break;
                }
            }
            if (rejected)
            {
                //Berth.RejectedBoats++;
            }
            return rejected;
        }
        public static void Depart()
        {
            
            
        }


    }
}
