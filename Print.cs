using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hamnen
{
    class Print
    {
       
        
       public static void Docks(List<Boat> boatPopulation, Berth[] docks)//Skriv ut Arrayen
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
                    if (boatPopulation[i] is RowingBoat && i + 1 < boatPopulation.Count && boatPopulation[i+1] is RowingBoat)
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
                if (boatPopulation[i] is Catamaran)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("|K ");
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
        public static List<Boat> ArrayToList(Berth[] docks)

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
                if (docks[i].IsEmpty && docks[i].Lot[0] == null)
                {
                    boatPopulation.Add(new EmptyBerth("", 0, 0, 0, i + 1, "Tomt", 0));

                }
            }
            
            return boatPopulation;
        }
        public static void BoatInfo(List<Boat>ListofAllBoats)
        {

            var q = ListofAllBoats
                .Where(b => b.Type != "Tomt" && b.Type != "Upptaget")
                .OrderBy(b => b.DockNumber);
            foreach (var Boat in q)
            {
                
                if (Boat.Size > 1)
                {
                    Console.WriteLine($"{Boat.DockNumber}-{Boat.DockNumber + Boat.Size - 1}\t\t\t| {Boat.Type}\t\t| {Boat.ID}\t\t| {Boat.Weight}\t\t| {Boat.Speed}\t\t\t| {Berth.PrintUnicueProperty(Boat)}");

                }
                else
                {
                    Console.WriteLine($"{Boat.DockNumber}\t\t\t| {Boat.Type}\t\t| {Boat.ID}\t\t| {Boat.Weight}\t\t| {Boat.Speed}\t\t\t| {Berth.PrintUnicueProperty(Boat)}");

                }

            }
        }
        public static void DockInfo(List<Boat>listOfAllBoats)
        {
            var q2 = listOfAllBoats
                .Select(b => b.Weight)
                .Sum();
           
            
            var q4 = listOfAllBoats
               .Where(b => b.Type == "Tomt")
               .GroupBy(b => b.Type);
            var q5 = listOfAllBoats
               .Where(b => b.Type != "Tomt" && b.Type != "Upptaget")
               .GroupBy(b => b.Type)
               .OrderByDescending(b => b.Count());
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("");
            Console.WriteLine("\n" +
                             "----------------------------------------" +
                "\nNuvarande båtbestånd i hamnen:\n");
            foreach (var item in q5)
            {
                Console.WriteLine($"{item.Key} {item.Count()}");

            }
           
            Console.WriteLine("\n" +
                             "----------------------------------------" +
            
                "\nHamndata:\n");
            foreach (var boat in q4)
            {
                Console.WriteLine($"Tomma plater i hamnen: {boat.Count()}");
            }
            Console.WriteLine($"Totalvikt i Hamnen: {q2} Kg");
            try
            {
                var q3 = listOfAllBoats
                //.Where(b => b.ID != "")
                .Where(b => b.Speed != 0 && b.ID != "")
                .Select(b => b.Speed)
                .Average();
                Console.WriteLine($"Medelhastighet: {Math.Round(q3)} Km/h.");

            }
            catch (Exception)
            {
           //Console.WriteLine("-------------------------------------");
            }
            Console.WriteLine($"Antal avvisade båtar: {Berth.RejectedBoats}\n" +
                            $"---------------------------------------");
            Console.ResetColor();
        }
    }
}
