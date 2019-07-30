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

namespace The_Kingdom_of_Britainia
{
    public partial class Forest : Form
    {
        //variables
        int progression = 0;
        Inventory inventory;
        Thread thread;
        bool specialWin = false;
        List<string> text = new List<string>();
        bool treeWin = false;
        bool basWin = false;
        bool chest = false;

        //event handlers
        public event EventHandler<ViewInvetoryEvent> ViewInevtory;
        public event EventHandler<ViewInventoryWeapon> ViewInevtoryWeapon;
        public event EventHandler<ViewInventoryPotion> ViewInevtoryPotion;

        public Forest(Inventory i)
        {
            InitializeComponent();
            inventory = i;
            MessageBox.Show("You finally have arrived in the forest!");
            //if player is at the start they cant go back
            if(progression==0)
            {
                btnBack.Visible = false;
            }
        }


        //return to town button
        private void btnRTT_Click(object sender, EventArgs e)
        {
            buttonClick();
            this.Close();
            thread = new Thread(openTown);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        //open the town
        private void openTown()
        {
            Application.Run(new Town(inventory));
        }

        //whenever any button is clicked attempt to fight a monster
        private void buttonClick()
        {
            
            Random rng = new Random();
            int chance = rng.Next(0, 101);

            if (chance > 50)
            {
                //MessageBox.Show("A monster has appeared!");
                //Fight fight = new Fight(inventory);
                //fight.ShowDialog();
            }

        }

        //button one click
        private void btnOne_Click(object sender, EventArgs e)
        {
            buttonClick();

            switch (progression)
            {
                //To the cave
                case 0:
                 progression = 1;
                    break;
                //striaght ahead in the cave
                case 1:
                    progression = 3;
                    break;
                    //hatchet in the tree
                case 2:
                    if (treeWin == false)
                    {
                        Random rng = new Random();
                        int treeSwing = rng.Next(1, 11);
                        inventory.player.currenthp = inventory.player.currenthp - treeSwing;
                        MessageBox.Show($"As you try to take the hatchet the tree comes to life and attacks you with it's branch for {treeSwing} damage!");

                        Monster tree = new Monster("Tree", 1, 3, 20, 0, "hurled razor leaves at you", "slapped you with a branch");
                        bool dub = false;
                        Fight fight = new Fight(inventory, tree, dub);
                        fight.specialWin += special;
                        fight.ShowDialog();

                        if (specialWin == true)
                        {
                            if (inventory.player is Fighter)
                            {
                                Weapon hatchet = new Weapon("Hatchet", 20, 0, 0, "Magic infused hatchet that will deal up to 20 damage.", 100);
                                inventory.playerItems.Add(hatchet);
                            }
                            else if (inventory.player is Wizard)
                            {

                            }
                            MessageBox.Show("You successfull pull the hatchet from the tree and it is added to your inventory.");
                            text[progression] = "The tree has returned to normal. All you can do is turn back.";
                            treeWin = true;
                            specialWin = false;
                            btnOne.Visible = false;
                        }
                        
                    }
                    if(treeWin==true)
                    {
                        btnOne.Visible = false;
                    }
                   
                    break;
                    //chest
                case 3:
                    if (chest == false)
                    {
                        Potions smallPotion = new Potions("Small Potion", 5, 0, 0, 0, "Grants 5 hp", 3, 1);
                        inventory.playerItems.Add(smallPotion);
                        inventory.playerItems.Add(smallPotion);
                        MessageBox.Show("The chest contained x2 Small potions!");
                        textBox1.Text = "You venture straight ahead into the darkness. Continuing onwards you can start to make out a small source of light and sprint forwards. You reach a room lit by a torch on the wall. To the right there is a path to follow. Will you continue or cower away?";
                        chest = true;
                    }
                    break;
                    //boss
                case 5:
                    progression = 6;
                    break;
            }

            progressionChange();
        }
        
        //special win method
        public void special(object sender, EventArgs e)
        {
            specialWin = true;
        }

        //back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            buttonClick();

            switch (progression)
            {
                case 1:
                    progression = 0;
                        break;
                case 2:
                    progression = 0;
                    break;
                case 3:
                    progression = 1;
                    break;
                case 4:
                    progression = 1;
                    break;
                case 5:
                    progression = 3;
                    break;
                case 6:
                    if (basWin == false)
                    {
                        MessageBox.Show("As you start to turn back you hear a ear piercing growl coming from the right! You turn and barely dodge a tail whip from a Basilisk!");
                        MessageBox.Show("You have no choice but to turn and face the beast!");
                        Monster bas = new Monster("Basilisk", 75, 10, 13, 1, "sunk it's fangs into you", "tail whipped you");
                        bool dub = false;
                        Fight fight = new Fight(inventory,bas, dub);
                        fight.specialWin += special;
                        fight.ShowDialog();

                        if (specialWin == true)
                        {
                            if (inventory.player is Fighter)
                            {
                                Weapon claws = new Weapon("Claws", 15, 0, 0, "Wearable claws that deal up to 15 damage", 70);
                                inventory.playerItems.Add(claws);
                                MessageBox.Show($"After defeating the Basilisk the body deterates leaving nothing but the beast's claws behind!");
                                MessageBox.Show($"{claws.Name} has been added to your inventory!");
                            }
                            else if (inventory.player is Wizard)
                            {
                                Spells rockFall = new Spells("Rock fall", 12, 0, 0, 0, 0, "Summons rocks above the targets hits and deal up to 12 damage", 0, 70);
                                inventory.spells.Add(rockFall);
                                MessageBox.Show($"After defeating the Basilisk a mystical force overwhemls you and you gain a new power");
                                MessageBox.Show($"{rockFall.Name} has been added to your spell list!");
                            }

                            basWin = true;
                            specialWin = false;
                            btnOne.Visible = false;

                            MessageBox.Show("Congratulation you beat the first level!");
                            progression = 1;

                            this.Close();
                            thread = new Thread(openTown);
                            thread.SetApartmentState(ApartmentState.STA);
                            thread.Start();

                        }
                    }
                    break;
            }
            progressionChange();
        }

        //whenever the progression has changed
        private void progressionChange()
        {
            //show the back button only if there not at the start
            //show the return to town button on is at the very begining

            if (progression > 0)
            {
                btnBack.Visible = true;
                btnRTT.Visible = false;
            }
            else if (progression <= 0)
            {
                btnBack.Visible = false;
                btnRTT.Visible = true;
            }
      

            //all options should be visible by deault
            btnOne.Visible = true;
            btnTwo.Visible = true;
            btnThree.Visible = true;
            //if the tree as been deafeated and there on the hatchet level
            if(treeWin==true&&progression==2)
            {
                btnOne.Visible = false;
            }

            //text for player
            //0
            text.Add("Here you see 3 different paths. The first leading to a cave, the second seems to be endless and the last has a sign at the front reading “BEWARE”. Will you travel at your own risk, or cower away?");
            //1
            text.Add("Inside the cave it’s dark and you can barely make out what’s in front of you. Will you continue straight ahead, right or cower away?");
            //2
            text.Add("You go for what seems like forever until you stumble upon a tree with a hatchet in it. Will you take the hatchet or cower away?");
            //3
            text.Add("Continuing onwards you can start to make out a small source of light and sprint forwards. You reach a room lit by a torch on the wall. In the corner you see a small chest and to left another path to follow. Will you continue or cower away?");
            //4
            text.Add("You go on for what feels like forever until you hit a dead end.  The only place to go is back where you started.");
            //5
            text.Add("As you follow down the cave you hear what seems to be growling of a ferocious beast. You stop and consider your options. Will you continue or cower away?");
            //6
            text.Add("As you continue the growls mysterly stop and you reach a large open room. Here you can see several skeletons ranging from human to orc.  The room appears to be a dead end with nothing but the deceased.");

            //change button text depending on which stage they are at
            switch(progression)
            {
                case 0:
                    MessageBox.Show("You return to the forest entrance!");
                    btnOne.Text = "Cave";
                    btnTwo.Text = "Endless";
                    btnThree.Text = "Beware";
                    break;
                case 1:
                    MessageBox.Show("You venture inside the cave at your own risk...");
                    btnOne.Text = "Striaght";
                    btnTwo.Text = "Right";
                    btnThree.Visible=false;
                    break;
                case 2:
                    MessageBox.Show("You start down the endless path...");
                    btnOne.Text = "Hatchet";
                    btnTwo.Visible = false;
                    btnThree.Visible = false;
                    break;
                case 3:
                    MessageBox.Show("You venture into the darkness...");
                    if (chest == false) { btnOne.Text = "Chest"; }
                    else if (chest == true)
                    {
                        btnOne.Visible=false;
                        textBox1.Text ="Continuing onwards you can start to make out a small source of light and sprint forwards. You reach a room lit by a torch on the wall. To the left there is a path to follow. Will you continue or cower away?";
                    }
                    btnTwo.Text = "Left";
                    btnThree.Visible = false;
                    break;
                case 4:
                    MessageBox.Show("You venture to the right of the cave...");
                    btnOne.Visible = false;
                    btnTwo.Visible=false;
                    btnThree.Visible = false;
                    break;
                case 5:
                    MessageBox.Show("Torch in hand you continue down the path...");
                    btnOne.Text = "Continue";
                    btnTwo.Visible = false;
                    btnThree.Visible = false;
                    break;
                case 6:
                    btnOne.Visible = false;
                    btnTwo.Visible = false;
                    btnThree.Visible = false;
                    break;
            }

            //change text for their stage
            textBox1.Text = text[progression];
        }

        //button two
        private void btnTwo_Click(object sender, EventArgs e)
        {
            buttonClick();

            switch (progression)
            {
                //Down the endless path to the tree
                case 0:
                    progression = 2;
                    break;

                case 1:
                    progression = 4;
                    break;

                case 3:
                    progression = 5;
                    break;
            }

            progressionChange();
        }

        //view inventory
        private void button1_Click(object sender, EventArgs e)
        {
            InventoryForm view = new InventoryForm(inventory);
            ViewInevtory += view.ViewInvetory;
            ViewInevtoryWeapon += view.ViewInventoryWeapon;
            ViewInevtoryPotion += view.ViewInventoryPotion;
            view.Equip += inventory.Equip;

            foreach (Items item in inventory.playerItems)
            {

                if (item is Weapon)
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

        
    }
}
    

