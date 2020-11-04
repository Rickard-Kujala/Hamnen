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
                        if (FindBerth(docksTwo,boat))
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
        public static bool FindBerth(Berth[] docks, Boat b)
        {
            bool rejected = true;
            for (int i = 0; i < docks.Length; i++)
            {
                ///     Om det finns en lucka..     ///
                if (i + 3 < docks.Length
                    && SearchForGap(b, docks, i)
                    && docks[i + 3].IsEmpty == false)

                {
                    docks[i].Lot[0] = b;
                    SetNumberOfElementsToFalse(b, docks, i);
                    b.DockNumber = i + 1;
                    rejected = false;
                    break;
                }
                ///     Om det finns en lucka och den sista platsen är den sista i arrayen..     ///
                else if (i + b.Size == docks.Length
                    && SearchForGap(b, docks, i))
                {
                    docks[i].Lot[0] = b;
                    SetNumberOfElementsToFalse(b, docks, i);
                    b.DockNumber = i + 1;
                    rejected = false;
                    break;
                }
                else if (i + b.Size < docks.Length && SearchForGap(b, docks, i))
                {
                    docks[i].Lot[0] = b;
                    SetNumberOfElementsToFalse(b, docks, i);
                    b.DockNumber = i + 1;
                    rejected = false;
                    break;
                }
            }
            return rejected;
        }
        public static bool SearchForGap(Boat b, Berth[] docks, int listIdex)
        {
            int count = 0;
            bool found = false;
            for (int i = 0; i < b.Size; i++)
            {
                if (docks[listIdex].IsEmpty)
                {
                    count++;
                }
                listIdex++;
            }
            if (count == b.Size)
            {
                found = true;
            }
            return found;
        }
        public static void SetNumberOfElementsToFalse(Boat b, Berth[] docks, int listIndex)
        {
            for (int i = 0; i < b.Size; i++)
            {
                docks[listIndex].IsEmpty = false;
                listIndex++;
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
                s = $"Är {((SailBoat)b).Length} meter lång.";
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


