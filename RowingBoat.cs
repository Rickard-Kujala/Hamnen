using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Hamnen
{
    class RowingBoat : Boat
    {
        public int MaxPAssengers { get; set; }
        public RowingBoat(string id, int weight, int speed, int daysleftinthedock, bool hasleftthedock, int docknumber, int maxpassengers)
            : base  ( id,  weight,  speed,  daysleftinthedock, hasleftthedock, docknumber)
        {
            MaxPAssengers = maxpassengers;
        }
        public static Boat Generate()
        {
            string ID = Boat.GetID("R");
            int weight = Boat.GetRandomValue(100, 300);
            int speed = Boat.GetRandomValue(1, 3);
            int passengers = Boat.GetRandomValue(1, 6);
            RowingBoat R = new RowingBoat(ID, weight, speed, 1, false, 1, passengers);
            return R;
        }
        public static void FindBerth(Berth[]docks, Boat b)
        {
            int i = 0;
            foreach (var berth in docks)
            {
                if (berth.Lot[0] == null)
                {
                    berth.Lot[0] = b;
                    break;
                }
            }
        }
        
    }
}
