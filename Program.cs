using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;

namespace Hamnen
{
    class Program
    {
        const string fileName = "Berth.txt";
        const string fileName2 = "Berth2.txt";

        static void Main(string[] args)
        {

            Berth[] DockOne = new Berth[32];
            Berth[] DockTwo = new Berth[32];
            List<Boat> boats = new List<Boat>();
            LoadOrNo(DockOne, fileName, DockTwo, fileName2);
           
            bool isRunning = true;
            while (isRunning)
            {

                Activity(DockOne, DockTwo);
                Berth.GenerateBoats(5, boats, DockOne);

                CountDown(DockOne);
                CountDown(DockTwo);

                Berth.Departure(DockOne);
                Berth.Departure(DockTwo);
                Berth.Moor(boats, DockOne, DockTwo);

                ConsoleKey key = Console.ReadKey().Key;

                if (key==ConsoleKey.Q)
                {
                    saveOrNo(DockOne, fileName, DockTwo, fileName2);
                    isRunning = false;
                }

            }
        }
        static void Activity(Berth[]docks, Berth[]docksTwo)
        {
            Console.Clear();
            List<Boat> boatPopulationOne = new List<Boat>();
            boatPopulationOne = Print.ArrayToList(docks);

            List<Boat> boatPopulationTwo = new List<Boat>();
            boatPopulationTwo = Print.ArrayToList(docksTwo);

            Console.WriteLine("Första Kajen");
            Print.Docks(boatPopulationOne, docks);
            Console.WriteLine("Andra Kajen");

            Print.Docks(boatPopulationTwo, docksTwo);

            Console.WriteLine("\nKajplats nr:\t\t  Typ av båt\t\t  ID\t\t  Vikt Kg\t  Toppfart Km/h\t\t  Unik egenskap\n");
            Console.WriteLine("Norra kajen");

            Print.BoatInfo(boatPopulationOne);
            Console.WriteLine("Södra Kajen");
            Print.BoatInfo(boatPopulationTwo);


            foreach (var item in boatPopulationTwo)
            {
                boatPopulationOne.Add(item);
            }
            Print.DockInfo(boatPopulationOne);

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
        static void Save(Berth[] docks, string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename, false))
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
        static void saveOrNo(Berth[]dockOne, string fileName, Berth[] dockTwo, string fileName2)
        {
            int choice = Meny.Save(Meny.LoadOrNewSimulation());
            switch (choice)
            {
                case 0:
                    Save(dockOne, fileName);
                    Save(dockTwo, fileName2);

                    break;
                case 1:

                default:
                    break;
            }
        }
        static void Load(Berth[] docks, string fileName)
        {
            foreach (var boat in File.ReadLines(fileName, System.Text.Encoding.UTF8))
            {
                string[] boatdata = boat.Split(';');

                switch (boatdata[0].First())
                {
                    case 'R':
                        RowingBoat r = new RowingBoat(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                        docks[int.Parse(boatdata[4])-1].Lot[0] = r;
                        docks[int.Parse(boatdata[4])-1].IsEmpty = false;
                        break;
                    case 'M':
                        MotorBoat m = new MotorBoat(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                        docks[int.Parse(boatdata[4])-1].Lot[0] = m;
                        int j = int.Parse(boatdata[4])-1;
                        Berth.SetToFalse(m, docks, j);
                        //docks[int.Parse(boatdata[4])].IsEmpty = false;

                        break;
                    case 'S':
                        SailBoat s = new SailBoat(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                        docks[int.Parse(boatdata[4])-1].Lot[0] = s;
                        //docks[int.Parse(boatdata[4])].IsEmpty = false;
                        int k = int.Parse(boatdata[4])-1;
                        Berth.SetToFalse(s, docks, k);


                        break;
                    case 'L':
                        CargoShip c = new CargoShip(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                        docks[int.Parse(boatdata[4])-1].Lot[0] = c;
                        //docks[int.Parse(boatdata[4])].IsEmpty = false;
                        int l = int.Parse(boatdata[4])-1;
                        Berth.SetToFalse(c, docks, l);

                        break;
                    case 'K':
                        Catamaran kat = new Catamaran(boatdata[0], int.Parse(boatdata[1]), int.Parse(boatdata[2]), int.Parse(boatdata[3]), int.Parse(boatdata[4]), boatdata[5], int.Parse(boatdata[6]), int.Parse(boatdata[7]));
                        docks[int.Parse(boatdata[4]) - 1].Lot[0] = kat;
                        //docks[int.Parse(boatdata[4])].IsEmpty = false;
                        int n = int.Parse(boatdata[4]) - 1;
                        Berth.SetToFalse(kat, docks, n);
                        break;
                }

            }
           
        }
        static void LoadOrNo(Berth[]dockOne, string fileName, Berth[] dockTwo, string fileName2)
        {
            InitializeArray(dockOne, dockTwo);

            int choice = Meny.Load(Meny.LoadOrNewSimulation());
            switch (choice)
            {
                case 0:
                    try
                    {
                        Load(dockOne, fileName);
                        Load(dockTwo, fileName2);
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
        static void InitializeArray(Berth[] dockOne, Berth[] dockTwo)
        {
            for (int i = 0; i < dockOne.Length; i++)
            {
                if (dockOne[i] is null)
                    dockOne[i] = new Berth();
            }
            for (int i = 0; i < dockTwo.Length; i++)
            {
                if (dockTwo[i] is null)
                    dockTwo[i] = new Berth();
            }
        }
    }
}
