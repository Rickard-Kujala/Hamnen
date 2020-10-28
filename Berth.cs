using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hamnen
{
    class Berth
    {
        public static int RejectedBoats = 0;
        public Boat[] Lot { get; set; } = new Boat[2];
        public bool IsEmpty { get; set; } = true;
        public static void Moor(List<Boat> boats, Berth[] docks)
        {
            for (int i = 0; i < docks.Length; i++)
            {
                if (docks[i] is null)
                    docks[i] = new Berth();
            }

            foreach (var boat in boats)
            {

                if (boat is RowingBoat)
                {
                    RowingBoat.FindBerth(docks, boat);
                }
                else
                {
                    FindBerth(docks, boat);
                }
                //else if (boat is MotorBoat)
                //{
                //    MotorBoat.FindBerth(docks, boat);
                //}
            }
            boats.Clear();
        }
        public static void GenerateBoats(int numberOfBoats, List<Boat> boats)
        {
            for (int i = 0; i < numberOfBoats; i++)
            {
                int TypeOfBoat = Boat.GetRandomValue(1, 4);
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
                }
            }
        }
        public static void Departure(Berth[] docks)
        {
            for (int i = 0; i < docks.Length; i++)
            {
                //if (boat != null && boat.Lot[0] != null && boat.Lot[0].DaysLeftInTheDock == 0)
                //{
                //    boat.Lot[0] = null;
                //    boat.IsEmpty = true;
                //}
                //if (boat != null && boat.Lot[1] != null && boat.Lot[1].DaysLeftInTheDock == 0)
                //{
                //    boat.Lot[1] = null;
                //    boat.IsEmpty = true;
                //}
                if (docks[i] != null && docks[i].Lot[0] != null && docks[i].IsEmpty==false && docks[i].Lot[0].DaysLeftInTheDock==0 )
                {
                    SetToTrue(docks[i].Lot[0], docks, i);
                    docks[i].Lot[0] = null;

                }
                if (docks[i] != null  && docks[i].Lot[1] is RowingBoat && docks[i].Lot[1].DaysLeftInTheDock == 0)
                {
                    docks[i].Lot[1] = null;
                }
            }
        }

        private static void SetToTrue(Boat b, Berth[] docks, int j)
        {
            for (int i = 0; i < b.Size; i++)
            {
                docks[j].IsEmpty = true;
                j++;
            }
        }

        public static void Print(Berth[] docks)
        {
            Console.Clear();
            BoatInfo(docks);
            //Console.WriteLine("Kajplats         ID          Vikt           Toppfart");
            //for (int i = 0; i < docks.Length; i++)
            //{
            //    if (docks[i].IsEmpty == true)
            //    {
            //        // Console.WriteLine($"{i + 1}:");
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        Console.WriteLine("Tomt_________");
            //        Console.ForegroundColor = ConsoleColor.White;


            //    }
            //    else
            //    {
            //        // Console.WriteLine($"{i + 1}:");
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine($"Upptaget\n________");
            //        Console.ForegroundColor = ConsoleColor.White;
            //        BoatInfo(docks);

            //    }

            //}
        }

        private static void BoatInfo(Berth[] docks)
        {
            Console.WriteLine("Kajplats\t\tTyp av båt\t\tID\t\tVikt Kg\t\tToppfart Km/h\n");

            List<Boat> boatPupulation = new List<Boat>();
            for (int i = 0; i < docks.Length; i++)
            {
                if (docks[i].IsEmpty ==false && docks[i].Lot[0] != null)
                {
                    boatPupulation.Add(docks[i].Lot[0]);
                }
                if (docks[i].IsEmpty == false && docks[i].Lot[1] != null)
                {
                    boatPupulation.Add(docks[i].Lot[1]);

                }
                if (docks[i].Lot[0]==null && docks[i].IsEmpty)
                {
                    boatPupulation.Add(new EmptyBerth("",0,0,0,i+1,"Tomt",0));

                }
            }
            var q = boatPupulation
                .OrderBy(b=> b.DockNumber);
            foreach (var Boat in q)
            {
                Console.ForegroundColor = ConsoleColor.White;

                if (Boat is EmptyBerth)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine($"{Boat.DockNumber}\t\t\t{Boat.Type}\t\t\t{Boat.ID}\t\t\t");

                }
                else
                {

                    Console.WriteLine($"{Boat.DockNumber}-{Boat.DockNumber+Boat.Size}\t\t\t{Boat.Type}\t\t{Boat.ID}\t\t{Boat.Weight}\t\t{Boat.Speed}\t\tDagar kvar {Boat.DaysLeftInTheDock} ");
                }
                Console.ForegroundColor = ConsoleColor.White;

            }
            var q2 = boatPupulation
                .Select(b => b.Weight)
                .Sum();
            Console.WriteLine($"Totalvikt: {q2}");
            var q3 = boatPupulation
                .Select(b => b.Speed)
                .Average();
            Console.WriteLine($"Medelhastighet: {q3} knop.");
            Console.WriteLine($"Antal avvisade båtar: {RejectedBoats}");
        }
        public static void FindBerth(Berth[] docks, Boat b)
        {
            bool rejected = true;
            for (int i = 0; i < docks.Length; i++)
            {
                ///     Om det finns en lucka..     ///
                if (

                    i + 3 < docks.Length
                    && Multiply(b, docks, i)
                    //&& docks[i].IsEmpty ==  true
                    //&& docks[i + 1].IsEmpty == true
                    //&& docks[i + 2].IsEmpty == true
                    && docks[i + 3].IsEmpty == false)


                {
                    docks[i].Lot[0] = b;
                    SetToFalse(b, docks, i);
                    //docks[i].IsEmpty = false;
                    //docks[i + 1].IsEmpty = false;
                    //docks[i + 2].IsEmpty = false;
                    b.DockNumber = i + 1;
                    rejected = false;
                    break;

                }
                ///     Om det finns en lucka och den sista platsen är den sista i arrayen..     ///
                else if (
                    i + b.Size == docks.Length
                    && Multiply(b, docks, i)
                    //&& docks[i].IsEmpty == true
                    //&& docks[i + 1].IsEmpty == true
                    //&& docks[i + 2].IsEmpty == true)
                    )
                {
                    docks[i].Lot[0] = b;
                    SetToFalse(b, docks, i);
                    //docks[i].IsEmpty = false;
                    //docks[i + 1].IsEmpty = false;
                    //docks[i + 2].IsEmpty = false;
                    b.DockNumber = i + 1;
                    rejected = false;

                    break;
                }
                else if (
                    i + b.Size < docks.Length && Multiply(b, docks, i)

                    //&& docks[i].IsEmpty == true
                    //&& docks[i + 1].IsEmpty == true
                    //&& docks[i + 2].IsEmpty == true)
                    )
                {
                    docks[i].Lot[0] = b;
                    //docks[i].IsEmpty = false;
                    //docks[i + 1].IsEmpty = false;
                    //docks[i + 2].IsEmpty = false;
                    SetToFalse(b, docks, i);
                    b.DockNumber = i + 1;//Ändra till string $"{i}-{i+boat.size}"
                    rejected = false;
                    break;
                }


            }
            if (rejected)
            {
                Berth.RejectedBoats++;

            }

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

    }
}


