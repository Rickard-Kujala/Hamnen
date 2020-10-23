using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen
{
    class Berth
    {
        public  Boat[] Lot { get; set; } = new Boat[2];
        public  bool IsEmpty { get; set; } = true;
        public static void Moor(List<Boat>boats, Berth[]docks)
        {
            foreach (var boat in boats)
            {
                if (boat is RowingBoat  )
                {
                    RowingBoat.FindBerth(docks, boat);
                }
            }
        }
        public static void GenerateBoats(int numberOfBoats, List<Boat>boats)
        {
            for (int i = 0; i < numberOfBoats; i++)
            {
                int TypeOfBoat = Boat.GetRandomValue(1, 1);
                switch (TypeOfBoat)
                {
                    case 1:
                        Boat r=RowingBoat.Generate();
                        boats.Add(r);
                        break;
                }
            }
        }
    }
}
