using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_of_Britainia
{
    public class Spells:Items
    { 
        public int SpellType { get; set; }

        public Spells(string n, int m, int h, int s, int r, int t, string d, decimal p,decimal sp)
        {
            Name = n;
            Mp = m;
            Str = s;
            Health = h;
            Desription = d;
            Rounds = r;
            SpellType = t;
            ItemType = 2;
            Cost = p;
            SellPrice = sp;
        }
    }
}
