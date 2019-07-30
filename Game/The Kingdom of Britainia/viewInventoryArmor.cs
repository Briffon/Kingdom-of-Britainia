using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_of_Britainia
{
    public class viewInventoryArmor:EventArgs
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int ArmorRating { get; set; }
        public string Desription { get; set; }
        public decimal Cost { get; set; }
        public decimal SellPrice { get; set; }
        public int ItemType { get; set; }
    
    }
}
