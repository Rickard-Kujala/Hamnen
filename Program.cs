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
            Load(Docks);
            bool isRunning = true;
            while (isRunning)
            {

                CountDown(Docks);
                Berth.Departure(Docks);
                Berth.GenerateBoats(5, boats, Docks);
                Berth.Moor(boats, Docks);
                Berth.Print(Docks);
                ConsoleKey key = Console.ReadKey().Key;
                if (key==ConsoleKey.Q)
                {
                    Save(Docks);
                    isRunning =false;

                }
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
            int choice=Meny.Save(Meny.yesOrNo());
            switch (choice)
            {
                case 0:
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
                    break;
                case 1:

                default:
                    break;
            }
            
        }
        static void Load(Berth[] docks)
        {
            for (int i = 0; i < docks.Length; i++)
            {
                if (docks[i] is null)
                    docks[i] = new Berth();
            }

            int choice = Meny.Load(Meny.yesOrNo());
            switch (choice)
            {
                case 0:
                    try
                    {

                        foreach (var boat in File.ReadLines(fileName, System.Text.Encoding.UTF8))
                        {
                            string[] boatdata = boat.Split(';');


                            switch (boatdata[0].First())
                            {
                                case 'R':
                                    RowingBoat r = new RowingBoat(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                                    docks[int.Parse(boatdata[4])].Lot[0] = r;
                                    docks[int.Parse(boatdata[4])].IsEmpty = false;
                                    break;
                                case 'M':
                                    MotorBoat m = new MotorBoat(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                                    docks[int.Parse(boatdata[4])].Lot[0] = m;
                                    int j = int.Parse(boatdata[4]);
                                    Berth.SetToFalse(m, docks, j);
                                    //docks[int.Parse(boatdata[4])].IsEmpty = false;

                                    break;
                                case 'S':
                                    SailBoat s = new SailBoat(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                                    docks[int.Parse(boatdata[4])].Lot[0] = s;
                                    //docks[int.Parse(boatdata[4])].IsEmpty = false;
                                    int k = int.Parse(boatdata[4]);
                                    Berth.SetToFalse(s, docks, k);


                                    break;
                                case 'L':
                                    CargoShip c = new CargoShip(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                                    docks[int.Parse(boatdata[4])].Lot[0] = c;
                                    //docks[int.Parse(boatdata[4])].IsEmpty = false;
                                    int l = int.Parse(boatdata[4]);
                                    Berth.SetToFalse(c,docks, l);

                                    break;
                            }

                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Filen är tom!");
                        Console.ReadLine();
                    }
                    break;
                case 1:
                    break;
            }
            
           
        }

    }
}
