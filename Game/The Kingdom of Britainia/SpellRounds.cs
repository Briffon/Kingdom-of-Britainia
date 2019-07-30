using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_of_Britainia
{
    public class SpellRounds : EventArgs
    {
        public int rounds { get; set; }
        public int currentRound { get; set; }
        public Spells activeSpell { get; set; }
        public SpellRounds()
        {
            
        }
    }
}
