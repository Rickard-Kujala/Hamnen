using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen
{
    class EmptyBerth : Boat
    {
        public EmptyBerth(string id, int weight, int speed, int daysleftinthedock, int docknumber, string type, int size)
            : base(id, weight, speed, daysleftinthedock, docknumber, type, size)
        {

        }
    }
}
