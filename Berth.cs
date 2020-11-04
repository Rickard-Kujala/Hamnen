using System;
using System.Collections.Generic;
using System.Linq;

namespace Hamnen
{
    class Berth
    {
        public static int RejectedBoats = 0;
        public Boat[] Lot { get; set; } = new Boat[2];
        public bool IsEmpty { get; set; } = true;
        public static void Moor(List<Boat> boats, Berth[] docks, Berth[] docksTwo)
        {
            foreach (var boat in boats)
            {
                if (boat is RowingBoat)
                {
                    bool b=RowingBoat.FindBerth(docks, boat);
                    if (b && boats.Count() > 0)
                    {
                        if (RowingBoat.FindBerth(docksTwo, boat))
                        {
                            RejectedBoats++;
                        }
                    }
                }
                else
                {
                   
                    bool b=FindBerth(docks, boat);

                    if (b && boats.Count()>0)
                    {
                        if (  FindBerth(docksTwo,boat)     )
                        {
                            RejectedBoats++;
                        }

                    }
                }
            }
            boats.Clear();
        }
        public static void GenerateNumberOfRandomBoats(int numberOfBoats, List<Boat> boats, Berth[] docks)
        {
            for (int i = 0; i < numberOfBoats; i++)
            {
                int TypeOfBoat = Boat.GetRandomValue(1, 5);
                switch (TypeOfBoat)
                {
                    case 1:
                        Boat r = RowingBoat.Generate();
                        boats.Add(r);
                        break;
                    case 2:
                        Boat m = MotorBoat.Generate();
                        boats.Add(m);
                        break;
                    case 3:
                        Boat s = SailBoat.Generate();
                        boats.Add(s);
                        break;
                    case 4:
                        Boat l = CargoShip.Generate();
                        boats.Add(l);
                        break;
                    case 5:
                        Boat k = Catamaran.Generate();
                        boats.Add(k);
                        break;
                }
            }
        }
        public static void GenerateTypeOfBoat( List<Boat> boats, Berth[] docks)
        {
            int typeOfBoat= Meny.GenerateTypeOfBoat();
           
                switch (typeOfBoat)
                {
                    case 0:
                        Boat r = RowingBoat.Generate();
                        boats.Add(r);
                        break;
                    case 1:
                        Boat m = MotorBoat.Generate();
                        boats.Add(m);
                        break;
                    case 2:
                        Boat s = SailBoat.Generate();
                        boats.Add(s);
                        break;
                    case 3:
                        Boat l = CargoShip.Generate();
                        boats.Add(l);
                        break;
                    case 4:
                        Boat k = Catamaran.Generate();
                        boats.Add(k);
                        break;
                }
            
        }
        public static void Departure(Berth[] docks)
        {
            for (int i = 0; i < docks.Length; i++)
            {

                if (docks[i] != null && docks[i].Lot[0] != null && docks[i].IsEmpty == false && docks[i].Lot[0].DaysLeftInTheDock == 0)
                {
                    SetToTrue(docks[i].Lot[0], docks, i);
                    docks[i].Lot[0] = null;

                }
                if (docks[i] != null && docks[i].Lot[1] is RowingBoat && docks[i].Lot[1].DaysLeftInTheDock == 0)
                {
                    docks[i].Lot[1] = null;
                }
            }
        }

        private static void SetToTrue(Boat b, Berth[] docks, int numberOfElements)
        {
            for (int i = 0; i < b.Size; i++)
            {
                docks[numberOfElements].IsEmpty = true;
                numberOfElements++;
            }
        }

        public static void Print(Berth[] docks)
        {
            //Console.Clear();
            BoatInfo(docks);

        }
        private static void BoatInfo(Berth[] docks)
        {
            List<Boat> boatPopulation = new List<Boat>();

            for (int i = 0; i < docks.Length; i++)
            {
                if (docks[i].IsEmpty == false && docks[i].Lot[0] != null)
                {
                    boatPopulation.Add(docks[i].Lot[0]);
                }
                if (docks[i].IsEmpty == false && docks[i].Lot[1] != null)
                {
                    boatPopulation.Add(docks[i].Lot[1]);

                }
                if (docks[i].IsEmpty == false && docks[i].Lot[0] == null)
                {
                    boatPopulation.Add(new EmptyBerth("", 0, 0, 0, i + 1, "Upptaget", 0));

                }
                if (docks[i].IsEmpty  && docks[i].Lot[0] == null)
                {
                    boatPopulation.Add(new EmptyBerth("", 0, 0, 0, i + 1, "Tomt", 0));

                }
            }
            Docks(boatPopulation, docks);
            Console.WriteLine("\nKajplats\t\t  Typ av båt\t\t  ID\t\t  Vikt Kg\t  Toppfart Km/h\t\t  Unik egenskap\n");

            var q = boatPopulation
                .Where(b => b.Type != "Tomt" && b.Type != "Upptaget")
                .OrderBy(b => b.DockNumber);
            foreach (var Boat in q)
            {
                if (Boat.Size >1)
                {
                    Console.WriteLine($"{Boat.DockNumber}-{Boat.DockNumber + Boat.Size-1}\t\t\t| {Boat.Type}\t\t| {Boat.ID}\t\t| {Boat.Weight}\t\t| {Boat.Speed}\t\t\t| {PrintUnicueProperty(Boat)}");

                }
                else
                {
                    Console.WriteLine($"{Boat.DockNumber}\t\t\t| {Boat.Type}\t\t| {Boat.ID}\t\t| {Boat.Weight}\t\t| {Boat.Speed}\t\t\t| {PrintUnicueProperty(Boat)}");

                }

            }
            var q2 = boatPopulation
                .Select(b => b.Weight)
                .Sum();
            var q3 = boatPopulation
                .Where(b=> b.ID != "")
                .Select(b => b.Speed)
                .Average();
            var q4 = boatPopulation
                .Where(b => b.Type == "Tomt")
                .GroupBy(b => b.Type);
            var q5 = boatPopulation
                .Where(b => b.Type != "Tomt" && b.Type != "Upptaget" )
                .GroupBy(b => b.Type)
                .OrderByDescending(b=> b.Key);
            Console.WriteLine("");
           
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n" +
                             "----------------------------------------" +
                "\nNuvarande båtbestånd:\n");
            foreach (var item in q5)
            {
                Console.WriteLine($"{item.Key} {item.Count()}");
               
            }
            Console.WriteLine("---------------------------------------" +
                "\nHamndata:\n");
            foreach (var boat in q4)
            {
                Console.WriteLine($"Tomma plater i hamnen: {boat.Count()}");
            }
            Console.WriteLine($"Totalvikt i Hamnen: {q2} Kg");
            Console.WriteLine($"Medelhastighet: {Math.Round(q3)} Km/h.");
            Console.WriteLine($"Antal avvisade båtar: {RejectedBoats}\n" +
                            $"---------------------------------------");
            Console.ResetColor();
        }
        private static void Docks(List<Boat> boatPopulation, Berth[] docks)
        {
            Console.Write("|");
            for (int i = 0; i < docks.Length; i++)
            {
                if (i + 1 < 10)
                {
                    Console.Write($"{i + 1} |");

                }
                else
                {
                    Console.Write($"{i + 1}|");

                }

            }
            Console.WriteLine("|");

            for (int i = 0; i < boatPopulation.Count; i++)
            {
                if (boatPopulation[i] is RowingBoat)
                {
                    if (boatPopulation[i] is RowingBoat && boatPopulation[i + 1] is RowingBoat/*i !=0 && boatPopulation[i-1] is RowingBoat*/)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|RR");
                        Console.ForegroundColor = ConsoleColor.White;
                        i++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|R ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                if (boatPopulation[i] is SailBoat)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write("|S ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                if (boatPopulation[i] is MotorBoat)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("|M ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                if (boatPopulation[i] is CargoShip)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("|L ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (boatPopulation[i] is EmptyBerth && boatPopulation[i].Type == "Tomt")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("|  ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                if (boatPopulation[i] is EmptyBerth && boatPopulation[i].Type == "Upptaget")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("|  ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
            Console.WriteLine("|");

        }
        public static bool FindBerth(Berth[] docks, Boat b)
        {
            bool rejected = true;
            for (int i = 0; i < docks.Length; i++)
            {
                ///     Om det finns en lucka..     ///
                if (

                    i + 3 < docks.Length
                    && Multiply(b, docks, i)
                    && docks[i + 3].IsEmpty == false)

                {
                    docks[i].Lot[0] = b;
                    SetToFalse(b, docks, i);
                    b.DockNumber = i + 1;
                    rejected = false;
                    break;

                }
                ///     Om det finns en lucka och den sista platsen är den sista i arrayen..     ///
                else if (
                    i + b.Size == docks.Length
                    && Multiply(b, docks, i)
                    )
                {
                    docks[i].Lot[0] = b;
                    SetToFalse(b, docks, i);
                    b.DockNumber = i + 1;
                    rejected = false;
                    break;
                }
                else if (
                    i + b.Size < docks.Length && Multiply(b, docks, i)

                    )
                {
                    docks[i].Lot[0] = b;

                    SetToFalse(b, docks, i);
                    b.DockNumber = i + 1;//Ändra till string $"{i}-{i+boat.size}"
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
        public static bool Multiply(Boat b, Berth[] docks, int j)
        {
            int count = 0;
            bool found = false;
            for (int i = 0; i < b.Size; i++)
            {
                if (docks[j].IsEmpty)
                {
                    count++;
                }
                j++;
            }
            if (count == b.Size)
            {
                found = true;
            }
            return found;
        }
        public static void SetToFalse(Boat b, Berth[] docks, int j)
        {
            for (int i = 0; i < b.Size; i++)
            {
                docks[j].IsEmpty = false;
                j++;
            }
        }
        public static string PrintUnicueProperty(Boat b)
        {
            string s = "";
            if (b is RowingBoat)
            {
                s = $"Rymmer {((RowingBoat)b).MaxPAssengers} Passagarare.";
            }
            if (b is SailBoat)
            {
                s = $"Är {((SailBoat)b).Length} fot lång.";
            }
            if (b is MotorBoat)
            {
                s = $"Har {((MotorBoat)b).HP} Hästkrafter.";
            }
            if (b is CargoShip)
            {
                s = $"Har {((CargoShip)b).NmbOfContainers} containers.";
            }
            if (b is Catamaran)
            {
                s = $"Har {((Catamaran)b).NmbrOfBeds} Bäddplatser..";
            }
            return s;
        }
        public static int ReturnUnicueProperty(Boat b)
        {
            int i = 0;
            if (b is RowingBoat)
            {
                i = ((RowingBoat)b).MaxPAssengers;
            }
            if (b is SailBoat)
            {
                i = ((SailBoat)b).Length;
            }
            if (b is MotorBoat)
            {
                i = ((MotorBoat)b).HP;

            }
            if (b is CargoShip)
            {
                i = ((CargoShip)b).NmbOfContainers;

            }
            return i;

        }








    }
}


