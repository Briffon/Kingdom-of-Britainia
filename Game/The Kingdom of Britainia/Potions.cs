using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_of_Britainia
{
    public class Potions:Items
    {
        public Potions(string n, int h, int s, int m, int r, string d, decimal c,decimal p)
        {
            Name = n;
            Health = h;
            Str = s;
            Mp = m;
            Rounds = r;
            Desription = d;
            Cost = c;
            SellPrice = p;
            ItemType = 0;
        }
    }
}
