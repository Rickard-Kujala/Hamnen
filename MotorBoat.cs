namespace Hamnen
{
    class MotorBoat : Boat
    {
        public int HP { get; set; }
        public MotorBoat(string id, int weight, int speed, int daysleftinthedock, int docknumber, string type, int size, int hp)
            : base(id, weight, speed, daysleftinthedock, docknumber, type, size)
        {
            HP = hp;
        }
        public static Boat Generate()
        {
            string ID = Boat.GetID("M");
            int weight = Boat.GetRandomValue(200, 3000);
            int speed = Boat.GetRandomValue(1, 60);
            speed = Boat.ConvertToKmPerHour(speed);
            int hp = Boat.GetRandomValue(10, 1000);
            MotorBoat m = new MotorBoat(ID, weight, speed, 3, 1,"Motorbåt", 1, hp);
            return m;
        }
        //public static void FindBerth(Berth[] docks, Boat m)
        //{
        //    bool rejected = true;
        //    for (int i = 0; i < docks.Length; i++)
        //    {
        //        ///     Om det finns en lucka..     ///
        //        if (
                    
        //            i + 3 < docks.Length
        //            && Multiply(m, docks, i)
        //            //&& docks[i].IsEmpty ==  true
        //            //&& docks[i + 1].IsEmpty == true
        //            //&& docks[i + 2].IsEmpty == true
        //            && docks[i + 3].IsEmpty == false)
                    

        //        {
        //            docks[i].Lot[0] = m;
        //            SetToFalse(m, docks, i);
        //            //docks[i].IsEmpty = false;
        //            //docks[i + 1].IsEmpty = false;
        //            //docks[i + 2].IsEmpty = false;
        //            m.DockNumber = i + 1;
        //            rejected = false;
        //            break;

        //        }
        //        ///     Om det finns en lucka och den sista platsen är den sista i arrayen..     ///
        //        else if (
        //            i + 3 == docks.Length 
        //            && Multiply(m, docks, i)
        //            //&& docks[i].IsEmpty == true
        //            //&& docks[i + 1].IsEmpty == true
        //            //&& docks[i + 2].IsEmpty == true)
        //            )
        //        {
        //            docks[i].Lot[0] = m;
        //            SetToFalse(m, docks, i);
        //            //docks[i].IsEmpty = false;
        //            //docks[i + 1].IsEmpty = false;
        //            //docks[i + 2].IsEmpty = false;
        //            m.DockNumber = i + 1;
        //            rejected = false;

        //            break;
        //        }
        //        else if (
        //            i + 2 < docks.Length && Multiply(m,docks, i)

        //            //&& docks[i].IsEmpty == true
        //            //&& docks[i + 1].IsEmpty == true
        //            //&& docks[i + 2].IsEmpty == true)
        //            )
        //        {
        //            docks[i].Lot[0] = m;
        //            //docks[i].IsEmpty = false;
        //            //docks[i + 1].IsEmpty = false;
        //            //docks[i + 2].IsEmpty = false;
        //            SetToFalse(m, docks, i);
        //            m.DockNumber = i + 1;//Ändra till string $"{i}-{i+boat.size}"
        //            rejected = false;
        //            break;
        //        }
                

        //    }
        //    if (rejected)
        //    {
        //        Berth.RejectedBoats++;

        //    }

        //}
        //public static bool Multiply(Boat b, Berth[] docks, int j)
        //{
        //    int count = 0;
        //    bool found=false;
        //    for (int i=0; i < 3; i++)
        //    {
        //        if (docks[j].IsEmpty)
        //        {
        //            count++;
        //        }
        //        j++;
        //    }
        //    if (count==3)
        //    {
        //        found = true;
        //    }
        //    return found;
        //}
        //public static void SetToFalse(Boat b, Berth[] docks, int j)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        docks[j].IsEmpty = false;
        //        j++;
        //    }
        //}

       
    }
}
