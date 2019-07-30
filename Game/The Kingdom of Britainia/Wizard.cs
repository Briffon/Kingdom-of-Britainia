using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_of_Britainia
{
    class Wizard:Player
    {
        public Wizard(string n) : base(n)
        {
            name = n;
            maxhp = 12;
            mp = 10;
            str = 1;
            currenthp = maxhp;
        }
    }
}
