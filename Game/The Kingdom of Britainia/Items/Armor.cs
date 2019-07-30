using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_of_Britainia
{
    public class Armor:Items
    {
        public Armor(string n, int s, int m, decimal c, string d, decimal p)
        {
            Name = n;
            Str = s;
            Mp = m;
            Cost = c;
            Desription = d;
            SellPrice = p;
        }
    }
}
