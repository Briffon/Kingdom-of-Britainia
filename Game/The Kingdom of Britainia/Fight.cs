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
    public partial class Fight : Form
    {
        Thread thread;
        Inventory inventory;
        List<Monster> monsters= new List<Monster>();
        int currentM = 0;
        bool win = false;
        int rounds=1;
        Spells buff;
        int buffRound;
        Potions pBuff;
        int pBuffRound;
        bool active = false;
        bool pActive = false;
        bool special = false;
        //public event handler for special monster win
        public event EventHandler specialWin;

        public Fight(Inventory i,Monster m=null,bool w=false)
        {
            InitializeComponent();
            inventory = i;
            this.ControlBox = false;
            //Is this special battle?
            if (m == null)
            {
                generateMonsters();
                Random random = new Random();
                currentM = random.Next(0, monsters.Count);
            }
            else
            {
                monsters.Add(m);
                special = true;
            }
            updateHealth();
            lblRounds.Text = $"Round:{rounds}";
        }

        //attack button
        private void btnAttack_Click(object sender, EventArgs e)
        {
            //variables
            Random rng = new Random();
            int weaponDamage = 0;
            int playerDamage = rng.Next(0, inventory.player.str + 1);

            //check for weapon
            if (inventory.activeWeapon != null)
            {
                //calc for weapon damage
                weaponDamage = rng.Next(0, (inventory.activeWeapon.Str+inventory.activeWeapon.Mp) + 1);

                //deal damage to monster
                monsters[currentM].CurrentHp = monsters[currentM].CurrentHp  -(weaponDamage + playerDamage);

                MessageBox.Show($"You dealt {weaponDamage + playerDamage} to {monsters[currentM].Name}!!!");

                //check to see if the monster died
                if (monsters[currentM].CurrentHp <= 0)
                {
                    playerWon(); 
                }

            }

            else
            {
                //deal damage to monster
                monsters[currentM].CurrentHp = monsters[currentM].CurrentHp - playerDamage;

                MessageBox.Show($"You dealt {playerDamage} to {monsters[currentM].Name}!!!");

                //check to see if the monster died
                if (monsters[currentM].CurrentHp <= 0)
                {
                    playerWon();
                }
            }

            updateHealth();

            //monster attack
            if (win != true)
            {
                monsterAttack();
            }

            rounds++;
            lblRounds.Text = $"Round:{rounds}";
        }

        //load monsters
        private void generateMonsters()
        {
            switch (inventory.player.progress)
            {
                case 0:
                    Monster wolf = new Monster("Wolf", 10, 0, 4, 0, "", "Slashed at you");
                    Monster goblin  = new Monster("Goblin", 5, 0, 6, 0, "", "Stabed you with a spear");
                    Monster skeleton  = new Monster("Skeleton", 10, 0, 4, 0, "", "Shot you with a bow");
                    List<Monster> temp = new List<Monster>();
                    temp.Add(goblin);
                    temp.Add(skeleton);
                    monsters = temp;
                    break;
            }
        }

        //make the current monster attack
        private void monsterAttack()
        {
            Random rng = new Random();
            int monsterDamage = 0;
            int armorRating=0;

            //check for armor
            if (inventory.activeArmor != null)
            {
                armorRating = rng.Next(1, inventory.activeArmor.ArmorRating + 1);
            }

            //if monster is special
            if (monsters[currentM].Type == 1)
            {
                int speciaAttackChance = rng.Next(0, 101);

                //if they execute a special attack
                if (speciaAttackChance > 65)
                {
                    monsterDamage = (rng.Next(0, monsters[currentM].Str + 1)) + monsters[currentM].Mp;
                    if (monsterDamage > 0)
                    {
                        MessageBox.Show($"{monsters[currentM].Name} {monsters[currentM].Special} and dealt {monsterDamage} to you!!!");
                    }
                    else if (monsterDamage <= 0)
                    {
                        MessageBox.Show($"The {monsters[currentM].Name} missed their attack!");
                    }
                }

                //if they miss the special opportunity
                else
                {
                    monsterDamage = rng.Next(0, monsters[currentM].Str + 1);

                    //if the armor rating blocks the attack
                    if (armorRating >= monsterDamage && monsterDamage != 0)
                    {
                        MessageBox.Show("The monsters attack couldnt pierce your armor!");
                    }
                    //if monster hits players
                    else if (monsterDamage > 0)
                    {
                        //if armor rating blocks some of the damage
                        if (monsterDamage > armorRating)
                        {
                            monsterDamage = monsterDamage - armorRating;

                        }
                        MessageBox.Show($"{monsters[currentM].Name} {monsters[currentM].Normal} and dealt {monsterDamage} to you!!!");
                    }
                    //if monster misses
                    else if (monsterDamage <= 0)
                    {
                        MessageBox.Show($"The {monsters[currentM].Name} missed their attack!");
                    }
                   
                }
            }

            //if it is a normal monster
            else if(monsters[currentM].Type==0)
            {
                monsterDamage = rng.Next(0, monsters[currentM].Str + 1);

                if (monsterDamage > 0)
                {
                    MessageBox.Show($"{monsters[currentM].Name} {monsters[currentM].Normal} and dealt {monsterDamage} to you!!!");
                }
                else if (monsterDamage <= 0)
                {
                    MessageBox.Show($"The {monsters[currentM].Name} missed their attack!");
                }
            }

           

            else
            {
                inventory.player.currenthp = inventory.player.currenthp - monsterDamage;
            }
           

            if (inventory.player.currenthp<=0)
            {
                playerLost();
            }
            updateHealth();
            spellRound();
            potionRound();
        }

        //in the event of the player losing
        private void playerLost()
        {
            Random rng = new Random();
            int gold = 0;
            switch (monsters[currentM].Type)
            {
                case 0:
                    gold = rng.Next(1, 6);
                    break;
            }

            if (inventory.playerGold - gold > 0)
            {
                inventory.playerGold = inventory.playerGold - gold;
                MessageBox.Show($"The {monsters[currentM].Name} defeated you and took {gold} gold from you!!!");
            }
            else if(inventory.playerGold - gold < 0)
            {
                inventory.playerGold = 0;
                MessageBox.Show($"The {monsters[currentM].Name} defeated you and took the rest of your gold from you!!!");
            }
            

            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Application.OpenForms[i].Close();
            }
            inventory.player.currenthp = inventory.player.maxhp;
            thread = new Thread(openTown);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        //if the player won
        private void playerWon()
        {
            Random rng = new Random();
            int gold = 0;
            int exp = 0;

            switch(monsters[currentM].Type)
            {
                case 0:
                    gold = rng.Next(1,11);
                   exp=rng.Next(2, 15);
                    break;
                case 1:
                    gold = rng.Next(15, 125);
                    exp = rng.Next(100, 385);
                    break;
            }

            inventory.playerGold += gold;
            inventory.player.exp += exp;
            MessageBox.Show($"You defeated {monsters[currentM].Name} and got {gold} gold!!!!");
            MessageBox.Show($"You have obtained {exp} exp!");
            Application.OpenForms["Fight"].Close();

            if(inventory.player.exp>=inventory.player.expThreshold)
            {
                 //reset exp and set new threshhold
                 inventory.player.exp = 0;
                 inventory.player.expThreshold = inventory.player.expThreshold * 1.5;
                 inventory.player.level = inventory.player.level + 1;
          
                 //increase stats
                 double increnmation = .25;
                 double result = Math.Round(inventory.player.maxhp * increnmation);
                 double strChange = Math.Round(inventory.player.str * increnmation);
                 double mpChange = Math.Round(inventory.player.mp * increnmation);

                //set new stats
                inventory.player.maxhp += (int)result;
                inventory.player.str += (int)strChange;
                inventory.player.mp += (int)mpChange;

                MessageBox.Show($"Congratulations you leveled up to level {inventory.player.level}!");
                MessageBox.Show($"Your health went up to {inventory.player.maxhp}!");
                MessageBox.Show($"Your STR went up to {inventory.player.str}!");
                MessageBox.Show($"Your MP went up to {inventory.player.mp}!");

            }

            if(special==true)
            {
                EventArgs e = new EventArgs();
                specialWin?.Invoke(this, e);
            }

            win = true;
        }

        //update form for health
        private void updateHealth()
        {
            lblPhp.Text = $"Player HP:{inventory.player.currenthp}";
            lblMhp.Text = $"{monsters[currentM].Name} HP:{monsters[currentM].CurrentHp}";
       
        }

        //open the town
        private void openTown()
        {
            Application.Run(new Town(inventory));
        }

        //spell attack
        private void btnSpells_Click(object sender, EventArgs e)
        {
            SpellForm spellAttack = new SpellForm(inventory.spells,currentM,monsters,inventory,rounds);
            //subscriptions
            spellAttack.FormClose += formClose;
            spellAttack.spellRounds += spellRoundUpdate;

            spellAttack.ShowDialog();

            //check to see if the monster died
            if (monsters[currentM].CurrentHp <= 0)
            {
                playerWon();
            }


            //monster attack
            if (win != true)
            {
                monsterAttack();
                rounds++;
                lblRounds.Text = $"Round:{rounds}";
                updateHealth();
            }

            
        }

        //buf checker
        public void spellRoundUpdate(object sender, SpellRounds e)
        {
            buffRound = e.currentRound;
            buff = e.activeSpell;
            active = true;
        }

        //debuffs if needed
        public void spellRound()
        {
            if (active != false)
            {
                if (buffRound + 3 == rounds)
                {
                    if (buff.Mp > 0 && buff.Str < 0)
                    {
                        inventory.player.mp = inventory.player.mp - buff.Mp;
                        MessageBox.Show($"Your mp has returned to normal!");
                    }
                    else if (buff.Str > 0 && buff.Mp < 0)
                    {
                        inventory.player.str = inventory.player.str - buff.Str;
                        MessageBox.Show($"Your str has returned to normal!");
                    }
                    else if (buff.Str > 0 && buff.Mp > 0)
                    {
                        inventory.player.str = inventory.player.str - buff.Str;
                        inventory.player.mp = inventory.player.mp - buff.Mp;
                        MessageBox.Show($"Your str and mp has returned to normal!");
                    }

                }
            }
        }

        //on form close of the spell menu
        public void formClose(object sender, EventArgs e)
        {
            updateHealth();
        }

        //use an item
        private void btnItems_Click(object sender, EventArgs e)
        {
            UseItem use = new UseItem(inventory,rounds);
            use.potionRounds += potionRounds;
            use.ShowDialog();

            if(win!=true)
            {
                monsterAttack();
                rounds++;
                lblRounds.Text = $"Round:{rounds}";
                updateHealth();
            }
        }

        //event hand method for potion round tracker
        public void potionRounds(object sender, PotionRoundscs e)
        {
            pBuff = e.potion;
            pBuffRound = e.currentRound;
            pActive = true;
        }

        public void potionRound()
        {
            if (pActive!=false)
            { 
                if (pBuffRound + 3 == rounds)
                {
                    if (pBuff.Mp > 0 && pBuff.Str < 0)
                    {
                        inventory.player.mp = inventory.player.mp - pBuff.Mp;
                        MessageBox.Show($"Your mp has returned to normal!");
                    }
                    else if (pBuff.Str > 0 && pBuff.Mp < 0)
                    {
                        inventory.player.str = inventory.player.str - pBuff.Str;
                        MessageBox.Show($"Your str has returned to normal!");
                    }
                    else if (pBuff.Str > 0 && pBuff.Mp > 0)
                    {
                        inventory.player.str = inventory.player.str - pBuff.Str;
                        inventory.player.mp = inventory.player.mp - pBuff.Mp;
                        MessageBox.Show($"Your str and mp has returned to normal!");
                    }
                    active = false;
                }
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            int run = rng.Next(0, 101);

            if(run>67)
            {
                MessageBox.Show("You got away!");
                this.Close();
            }
            else
            {
                MessageBox.Show("You couldnt get away!");
                monsterAttack();
            }
        }
    }
}
