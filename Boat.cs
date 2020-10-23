using System;

namespace Hamnen
{
    abstract class Boat

    {
        public string ID { get; set; }
        public int Weight { get; set; }
        public int Speed { get; set; }
        public int DaysLeftInTheDock { get; set; }
        public bool HasLeftTheDock { get; set; }
        public int DockNumber { get; set; }
        public static  Random RandomValue = new Random();

        public Boat(string id, int weight, int speed, int daysleftinthedock, bool hasleftthedock, int docknumber)
        {
            ID = id;
            Weight = weight;
            Speed = speed;
            DaysLeftInTheDock = daysleftinthedock;
            HasLeftTheDock = hasleftthedock;
            DockNumber = docknumber;
        }
        public static int GetRandomValue(int minValue, int maxValue)
        {
            int i = RandomValue.Next(minValue, maxValue+1);
            return i; 
        }
        public static string GetID(string type)
        {
            string ID = $"{type}-";
            for (int i = 0; i < 3; i++)
            {
                char randomchar = (char)RandomValue.Next('A', 'Z');
                ID += randomchar;
            }
            return ID;
        }


    }
}

