using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_of_Britainia
{
    public class Weapon:Items
    {

        public Weapon(string n, int s, int m, decimal c,string d, decimal p)
        {
            Str = s;
            Mp = m;
            Cost = c;
            SellPrice = p;
            Name = n;
            Desription = d;
            ItemType = 1;
        }

    }
}
