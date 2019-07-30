using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace The_Kingdom_of_Britainia
{
    public partial class Form1 : Form
    {
        Thread thread;
        Inventory inventory = new Inventory();
        public Form1()
        {
            InitializeComponent();
        }

        //start the game
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && cmdClass.SelectedIndex != -1)
            {

                switch (cmdClass.SelectedIndex)
                {
                    case 0:
                        Fighter fighter = new Fighter(txtName.Text);
                        inventory.player = fighter;
                        break;

                    case 1:
                        Wizard wizard = new Wizard(txtName.Text);
                        Spells flare = new Spells("Flare", 5, 0, 0, 0, 0,"A small flame that can deal up to 5 damage",0,1);
                        inventory.player = wizard;
                        inventory.spells.Add(flare);
                        break;
                }

                inventory.playerGold = 10;

                Weapon woodenSword = new Weapon("Wooden Sword", 4, 0, 0, "A dinky wooden sword that can deal up to 4 damage", 1);
                inventory.playerItems.Add(woodenSword);

                Spells buff = new Spells("Small Buff", 2, 0, 2, 3, 1, "A small increase to STR and MP", 0,1);
                inventory.spells.Add(buff);

                this.Close();
                thread = new Thread(openTown);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();

            }
            else
            {
                MessageBox.Show("Please enter a name and choose a class");
            }
        }

        private void openTown()
        {
            Application.Run(new Town(inventory));
        }

        //load file
        private void button1_Click(object sender, EventArgs e)
        {
            Inventory tempInven = new Inventory();
            inventory.player =tempInven.player;
            inventory = tempInven;
            inventory.playerItems = tempInven.playerItems;
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

                                Weapon weapon = new Weapon(name, str, mp, cost, description, sellprice);
                                inventory.playerItems.Add(weapon);
                                break;
                        }

                    }
                }
                //spells
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

                        Spells spell = new Spells(name, mp, hp, str, rounds, spellType, description,cost,sellprice);
                        inventory.spells.Add(spell);

                    }
                }


                this.Close();
                thread = new Thread(openTown);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }
    }
}

