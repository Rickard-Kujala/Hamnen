using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hamnen
{
    class Program
    {
        const string fileName = "Berth.txt";

        static void Main(string[] args)
        {
            Berth[] Docks = new Berth[64];
            List<Boat> boats = new List<Boat>();

            while (true)
            {
                CountDown(Docks);
                Berth.Departure(Docks);
                Berth.GenerateBoats(5, boats, Docks);
                Load(Docks);
                Berth.Moor(boats, Docks);
                Berth.Print(Docks);
                Save(Docks);
                Console.ReadLine();
            }
        }
        static void CountDown(Berth[] docks)
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
            }
        }
        static void Save(Berth[] docks)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                foreach (var item in docks)
                {
                    if (item.Lot[0] != null)
                    {
                        sw.WriteLine($"{item.Lot[0].ID};{item.Lot[0].Weight};{item.Lot[0].Speed};{item.Lot[0].DaysLeftInTheDock};{item.Lot[0].DockNumber};{item.Lot[0].Type};{item.Lot[0].Size};{Berth.ReturnUnicueProperty(item.Lot[0])}");
                        // id,  weight,  speed,  daysleftinthedock, docknumber, type, size
                    }
                    if (item.Lot[1] != null)
                    {
                        sw.WriteLine($"{item.Lot[1].ID};{item.Lot[1].Weight};{item.Lot[1].Speed};{item.Lot[1].DaysLeftInTheDock};{item.Lot[1].DockNumber};{item.Lot[1].Type};{item.Lot[1].Size};{Berth.ReturnUnicueProperty(item.Lot[1])}");
                    }
                }
            }
        }
        static void Load(Berth[] docks)
        {
            foreach (var boat in File.ReadLines(fileName, System.Text.Encoding.UTF8))
            {
                string[] boatdata = boat.Split(';');
                for (int i = 0; i < boatdata.Length; i++)
                {
                    switch (boatdata[0].First())
                    {
                        case 'R':
                            RowingBoat r = new RowingBoat(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                            docks[int.Parse(boatdata[6]) ].Lot[0] = r;
                            break;
                        case 'M':
                            MotorBoat m = new MotorBoat(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                            docks[int.Parse(boatdata[6])].Lot[0] = m;
                            break;
                        case 'S':
                            SailBoat s = new SailBoat(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                            docks[int.Parse(boatdata[6])].Lot[0] = s;
                            break;
                        case 'L':
                            CargoShip c = new CargoShip(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                            docks[int.Parse(boatdata[6])].Lot[0] = c;
                            break;
                    }
                }

            }
        }

    }
}
