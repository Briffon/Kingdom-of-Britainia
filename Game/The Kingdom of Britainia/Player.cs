using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_of_Britainia
{
    public class Player
    {
        public string name { get; set; }
        public int maxhp { get; set; }
        public int currenthp { get; set; }
        public int mp { get; set; }
        public int str { get; set; }
        public int level { get; set; }
        public int exp { get; set; }
        public double expThreshold { get; set; }
        public int progress { get; set; }

        public Player(string n)
        {
            level = 1;
            exp = 0;
            progress = 0;
            expThreshold = 100;
           
        }

        public void Attack(Monster m)
        {

        }

        public void SpellAttack(Monster m, int spell, Inventory i)
        {
 

        }
    }
}
