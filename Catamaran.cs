using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen
{
    class Catamaran : Boat
    {
        public int NmbrOfBeds { get; set; }

        public Catamaran(string id, int weight, int speed, int daysleftinthedock, int docknumber, string type, int size, int nmbrOfBeds)
           : base(id, weight, speed, daysleftinthedock, docknumber, type, size)
        {
            NmbrOfBeds = nmbrOfBeds;
        }
        public static Boat Generate()
        {
            string ID = Boat.GetID("K");
            int weight = Boat.GetRandomValue(1200, 8000);
            int speed = Boat.GetRandomValue(1, 12);
            speed = Boat.ConvertToKmPerHour(speed);
            int beds = Boat.GetRandomValue(1, 4);
            Catamaran K = new Catamaran(ID, weight, speed, 3, 1, "Katamaran", 3, beds);
            return K;
        }
    }
    //Katamaran, somupptar3 hamnplatser, och somligger kvar I hamnenI tredagar,◦Identitetsnummer
    //    (slumpmässigttrebokstävermed prefix “K-”, t ex K-ABC)◦Vikt(1200-8000 kg)◦
    //    //Maxhastighet(0-12 knop)◦Unikegenskap: Antal bäddplatser(1-4)
}
