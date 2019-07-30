using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_of_Britainia
{
    class Fighter:Player
    {
        public Fighter(string n) : base(n)
        {
            name = n;
            maxhp = 25;
            mp = 0;
            str = 9;
            currenthp = maxhp;
        }
    }
}
