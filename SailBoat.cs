using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen
{
    class SailBoat : Boat
    {
        public int Length { get; set; }
        public SailBoat(string id, int weight, int speed, int daysleftinthedock, int docknumber, string type, int size, int length)
            : base(id, weight, speed, daysleftinthedock, docknumber, type, size)

        {
            Length = length;
        }
        public static Boat Generate()
        {
            string ID = Boat.GetID("S");
            int weight = Boat.GetRandomValue(800, 6000);
            int speed = Boat.GetRandomValue(1, 12);
            speed=Boat.ConvertToKmPerHour(speed);
            int length = Boat.GetRandomValue(10, 60);
            SailBoat S = new SailBoat(ID, weight, speed, 4, 1, "Segelbåt", 2, length);
            return S;
        }
    }
}
