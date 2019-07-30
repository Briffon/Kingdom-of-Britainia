using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_of_Britainia
{
    public class Monster
    {
        public string Name { get; set; }
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public int Mp { get; set; }
        public int Str { get; set; }
        public int Type { get; set; }
        public string Special { get; set; }
        public string Normal { get; set; }

        public Monster(string n, int h,int mp, int s, int t, string sp, string na)
        {
            Name = n;
            MaxHp = h;
            CurrentHp = h;
            Mp = mp;
            Str = s;
            Type = t;
            Special = sp;
            Normal = na;
        }

        public void attack(Player p)
        {
          
        }

        public void specialAttack(Player p)
        {
           
        }
    }
}
