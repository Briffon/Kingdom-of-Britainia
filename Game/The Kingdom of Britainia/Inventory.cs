using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_of_Britainia
{
    public class Inventory
    {
        public Player player { get; set; }
        public decimal playerGold { get; set; }
        public List<Items> playerItems = new List<Items>();
        public List<Items> generalStoreitems = new List<Items>();
        public List<Items> armoryStoreitems = new List<Items>();
        public List<Spells> magicStoreitems = new List<Spells>();
        public ViewInventoryWeapon activeWeapon;
        public viewInventoryArmor activeArmor;
        public List<Spells> spells = new List<Spells>();

        public Inventory()
        {
            playerGold = 10;
        }

        //loads items for general store
        public void loadGeneral()
        {
            Potions smallPotion = new Potions("Small Potion", 5, 0, 0, 0, "Grants 5 hp", 3,1);
            Potions potion = new Potions("Potion", 10, 0, 0, 0, "Grants 10 hp", 7,1);
            Potions largePotion = new Potions("large Potion", 16, 0, 0, 0, "Grants 16 hp", 15,1);
            Potions vigor = new Potions("Vigor", 0, 2, 2, 3, "Lightly increases mp and str for 3 rounds", 15, 1);

            generalStoreitems.Add(smallPotion);
            generalStoreitems.Add(potion);
            generalStoreitems.Add(largePotion);
            generalStoreitems.Add(vigor);
        }

        //loads items for Armory
        public void loadArmory()
        {
            if (player is Fighter)
            {
                //weapons
                Weapon ironSword = new Weapon("Iron Sword", 5, 0, 23, "A fairly crafted iron blade that can deal up to 5 damage", 1);
                Weapon steelSword = new Weapon("Steel Sword", 11, 0, 40, "A trusy blade made of steel that can deal up to 11 damage", 7);

                //armor
                Armor leather = new Armor("Leather Armor",2,0,23,"Light armor that can block up to 2 damage",2);
                Armor paddedLeather = new Armor("Padded Leather Armor", 5, 0, 45, "Reinforced leather that can block up to 5 damage", 14);
                Armor scaleMail = new Armor("Scale Mail", 7, 0, 95, "Medium armor that can block up to 9 damage", 26);


                armoryStoreitems.Add(ironSword);
                armoryStoreitems.Add(steelSword);
                armoryStoreitems.Add(leather);
                armoryStoreitems.Add(paddedLeather);
            }

            else if (player is Wizard)
            {
              
            }
            
        }

        //load magic store
        public void loadMagic()
        {
            Spells bolt = new Spells("Lightning Bolt", 8, 0, 0, 0, 0, "A bolt of lightning that can deal up to 8 damage!",40,8);
            Spells lesserHeal = new Spells("Lesser Heal", 0, 4,0, 0, 2, "A basic cantrip that will restore 4 points of HP", 15,3);
            magicStoreitems.Add(bolt);
            magicStoreitems.Add(lesserHeal);
        }

        //equip weapon
        public void Equip(object sender, ViewInventoryWeapon e)
        {
            
            activeWeapon = e;
        }

        //equip armor
        public void EquipArmor(object sender, viewInventoryArmor e)
        {

            activeArmor = e;
        }
    }
}
