using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_of_Britainia
{
    public class PotionRoundscs:EventArgs
    {
        public int currentRound { get; set; }
        public Potions potion { get; set; }
    }
}
