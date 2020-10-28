using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen
{
    class CargoShip : Boat
    {
        public int NmbOfContainers { get; set; }
        public CargoShip(string id, int weight, int speed, int daysleftinthedock, int docknumber, string type, int size, int nmbrOfContainers)
            : base(id, weight, speed, daysleftinthedock, docknumber, type, size)
        {
            NmbOfContainers = nmbrOfContainers;
        }
        public static Boat Generate()
        {
            string ID = Boat.GetID("L");
            int weight = Boat.GetRandomValue(3000, 20000);
            int speed = Boat.GetRandomValue(1, 20);
            speed = Boat.ConvertToKmPerHour(speed);
            int containers = Boat.GetRandomValue(0, 500);
            CargoShip L = new CargoShip(ID, weight, speed, 6, 1, "Lastfartyg ", 4, containers);
            return L;
        }
    }
}
