using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace The_Kingdom_of_Britainia
{
    public partial class Town : Form
    {
        Inventory inventory;
        public event EventHandler<ViewInvetoryEvent> ViewInevtory;
        public event EventHandler<ViewInventoryWeapon> ViewInevtoryWeapon;
        public event EventHandler<ViewInventoryPotion> ViewInevtoryPotion;
        public event EventHandler<viewInventoryArmor> ViewInventoryArmor;
        public event EventHandler<PlayerProgess> Progress;


        public Town(Inventory i)
        {
            InitializeComponent();
            inventory = i;
        }

        //when user selects a new area
        private void cmdArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdArea.SelectedIndex != -1)
            {
                switch (cmdArea.SelectedIndex)
                {
                    case 0:
                        Armorycs armory = new Armorycs(inventory);
                        armory.ShowDialog();
                        break;

                    case 1:
                        General_Store general = new General_Store(inventory);
                        general.ShowDialog();
                        break;

                    case 2:
                        MagicStore magic = new MagicStore(inventory);
                        magic.ShowDialog();
                        break;

                    case 3:
                        inventory.player.currenthp = inventory.player.maxhp;
                        MessageBox.Show("You have been restored to Max HP!");
                        break;
                }
            }
        }

        //save button
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Player.txt";
            save.Filter = "Text File | *.txt";
            
            if(save.ShowDialog()==DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());

                if (inventory.player is Fighter)
                {
                    writer.WriteLine("Fighter");
                }
                else if(inventory.player is Wizard )
                {
                    writer.WriteLine("Wizard");
                }
                //player name
                    writer.WriteLine($"{inventory.player.name}");
                //player hp
                    writer.WriteLine($"{inventory.player.maxhp}");
                //player current hp
                    writer.WriteLine($"{inventory.player.currenthp}");
                //player mp
                    writer.WriteLine($"{inventory.player.mp}");
                //player str
                    writer.WriteLine($"{inventory.player.str}");
                //player level
                    writer.WriteLine($"{inventory.player.level}");
                //player exp
                    writer.WriteLine($"{inventory.player.exp}");
                //player progress
                    writer.WriteLine($"{inventory.player.progress}");
                //player gold
                    writer.WriteLine(inventory.playerGold);
                //items in inventory
                if (inventory.playerItems.Count != 0)
                {
                    foreach (Items item in inventory.playerItems)
                    {
                        writer.WriteLine("@");
                        writer.WriteLine(item.ItemType);
                        writer.WriteLine(item.Name);
                        writer.WriteLine(item.Health);
                        writer.WriteLine(item.Str);
                        writer.WriteLine(item.Mp);
                        writer.WriteLine(item.Rounds);
                        writer.WriteLine(item.Desription);
                        writer.WriteLine(item.Cost);
                        writer.WriteLine(item.SellPrice);

                        if (item is Spells)
                        {
                            writer.WriteLine(((Spells)item).SpellType);
                        }
                    }
                }
                //spells
                foreach (Spells item in inventory.spells)
                {
                    writer.WriteLine("$$");
                    writer.WriteLine(item.Name);
                    writer.WriteLine(item.Mp);
                    writer.WriteLine(item.Str);
                    writer.WriteLine(item.Health);
                    writer.WriteLine(item.Desription);
                    writer.WriteLine(item.Rounds);
                    writer.WriteLine(item.SpellType);
                    writer.WriteLine(item.ItemType);
                    writer.WriteLine(item.SellPrice);
                    writer.WriteLine(item.Cost);
                    
                    
                }
             
                writer.Dispose();
                writer.Close();
            }
        }

        //load button
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Load a file";
            open.Filter = "Text File | *.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(open.FileName);
                string s = "";

                List<string> lines = new List<string>();

                while ((s = reader.ReadLine()) != null)
                {
                    lines.Add(s);
                }

                if (lines[0] == "Fighter")
                {
                    Fighter fighter = new Fighter(lines[1]);
                    fighter.maxhp = int.Parse(lines[2]);
                    fighter.currenthp = int.Parse(lines[3]);
                    fighter.mp = int.Parse(lines[4]);
                    fighter.str = int.Parse(lines[5]);
                    fighter.level = int.Parse(lines[6]);
                    fighter.exp = int.Parse(lines[7]);
                    fighter.progress = int.Parse(lines[8]);
                    inventory.player = fighter;
                }
                else if (lines[0] == "Wizard")
                {
                    Wizard fighter = new Wizard(lines[1]);
                    fighter.maxhp = int.Parse(lines[2]);
                    fighter.currenthp = int.Parse(lines[3]);
                    fighter.mp = int.Parse(lines[4]);
                    fighter.str = int.Parse(lines[5]);
                    fighter.level = int.Parse(lines[6]);
                    fighter.exp = int.Parse(lines[7]);
                    fighter.progress = int.Parse(lines[8]);
                    inventory.player = fighter;
                }
                inventory.playerGold = int.Parse(lines[9]);

                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i] == "@")
                    {
                        inventory.playerItems.Clear();

                        switch (int.Parse(lines[i + 1]))
                        {

                            case 0:
                                Potions potion = new Potions(lines[i + 2], int.Parse(lines[i + 3]), int.Parse(lines[i + 4]), int.Parse(lines[i + 5]), int.Parse(lines[i + 6]), lines[i + 7], decimal.Parse(lines[i + 8]), decimal.Parse(lines[i + 9]));
                                
                                inventory.playerItems.Add(potion);
                                break;
                            case 1:
                                string name = lines[i + 2];
                                int hp = int.Parse(lines[i + 3]);
                                int str = int.Parse(lines[i + 4]); ;
                                int mp = int.Parse(lines[i + 5]);
                                int rounds = int.Parse(lines[i + 6]);
                                string description = lines[i + 7];
                                decimal cost = decimal.Parse(lines[i + 8]);
                                decimal sellprice = decimal.Parse(lines[i + 9]);

                                Weapon weapon = new Weapon(name,str,mp,cost,description, sellprice);
              
                                inventory.playerItems.Add(weapon);
                                break;
                        }

                    }
                }

                inventory.spells.Clear();
                inventory.generalStoreitems.Clear();
                inventory.armoryStoreitems.Clear();
                inventory.magicStoreitems.Clear();
                for (int i = 0; i < lines.Count; i++)
                {
                    
                    if (lines[i] == "$$")
                    {
                        string name = lines[i + 1];
                        int mp = int.Parse(lines[i + 2]);
                        int str = int.Parse(lines[i + 3]); ;
                        int hp = int.Parse(lines[i + 4]);
                        string description = lines[i + 5];
                        int rounds = int.Parse(lines[i + 6]);
                        int spellType = int.Parse(lines[i + 7]);
                        int itemType = int.Parse(lines[i + 8]);
                        decimal cost = decimal.Parse(lines[i + 10]);
                        decimal sellprice = decimal.Parse(lines[i + 9]);

                        Spells spell = new Spells(name, mp, hp, str, rounds, spellType, description, cost,sellprice);
                        inventory.spells.Add(spell);

                    }
                }

            }
        }

        //view inventory
        private void btnViewInventory_Click(object sender, EventArgs e)
        {
            InventoryForm view = new InventoryForm(inventory);
            ViewInevtory += view.ViewInvetory;
            ViewInevtoryWeapon += view.ViewInventoryWeapon;
            ViewInevtoryPotion += view.ViewInventoryPotion;
            ViewInventoryArmor += view.ViewInventoryArmor;
            view.Equip += inventory.Equip;
            view.EquipArmor += inventory.EquipArmor;

            foreach  (Items item in inventory.playerItems)
            {

                if(item is Weapon)
                {
                    ViewInventoryWeapon vie = new ViewInventoryWeapon();
                    vie.Cost = item.Cost;
                    vie.Desription = item.Desription;
                    vie.Health = item.Health;
                    vie.Mp = item.Mp;
                    vie.Name = item.Name;
                    vie.SellPrice = item.SellPrice;
                    vie.Str = item.Str;
                    ViewInevtoryWeapon?.Invoke(this, vie);
                }

                else if (item is Potions)
                {
                    ViewInventoryPotion vie = new ViewInventoryPotion();
                    vie.Cost = item.Cost;
                    vie.Desription = item.Desription;
                    vie.Health = item.Health;
                    vie.Mp = item.Mp;
                    vie.Name = item.Name;
                    vie.SellPrice = item.SellPrice;
                    vie.Str = item.Str;
                    vie.Rounds = item.Rounds;
                    ViewInevtoryPotion?.Invoke(this, vie);
                }

                else if (item is Armor)
                {
                    viewInventoryArmor vie = new viewInventoryArmor();
                    vie.Cost = item.Cost;
                    vie.Desription = item.Desription;
                    vie.Health = item.Health;
                    vie.ArmorRating = item.Str;
                    vie.Name = item.Name;
                    vie.SellPrice = item.SellPrice;
                    ViewInventoryArmor?.Invoke(this, vie);
                }

            }

            foreach (Spells item in inventory.spells)
            {
                ViewInvetoryEvent vie = new ViewInvetoryEvent();
                vie.Cost = item.Cost;
                vie.Desription = item.Desription;
                vie.Health = item.Health;
                vie.Mp = item.Mp;
                vie.Name = item.Name;
                vie.Rounds = item.Rounds;
                vie.SellPrice = item.SellPrice;
                vie.Str = item.Str;
                vie.SpellType = ((Spells)item).SpellType;
                ViewInevtory?.Invoke(this, vie);
            }

            view.ShowDialog();
        }

        private void btnTravel_Click(object sender, EventArgs e)
        {
            Travel travel = new Travel(inventory);
            Progress += travel.Progress;
            PlayerProgess p = new PlayerProgess();
            p.Progress = inventory.player.progress;
            Progress?.Invoke(this, p);
            travel.ShowDialog();
        }
    }
}
    
