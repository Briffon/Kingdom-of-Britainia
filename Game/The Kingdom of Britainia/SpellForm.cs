using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Kingdom_of_Britainia
{
    public partial class SpellForm : Form
    {
        List<Spells> spells = new List<Spells>();
        Monster currentMonster = new Monster("",0,0,0,0,"","");
        Inventory inventory = new Inventory();
        public event EventHandler FormClose;
        public event EventHandler<SpellRounds> spellRounds;
        int currentRound = 0;

        public SpellForm(List<Spells>i, int m, List<Monster>mon,Inventory o, int Round)
        {
            InitializeComponent();
            spells = i;
            foreach (Spells item in spells)
            {
                cmbSpells.Items.Add(item.Name);
            }
            currentMonster = mon[m];
            inventory = o;
            currentRound = Round;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //use  a spell
        private void btnUse_Click(object sender, EventArgs e)
        {
            //if they user selected a spell
            if (cmbSpells.SelectedIndex != -1)
            {
                
                Spells temp = new Spells("", 0, 0, 0, 0, 0, "", 0,0);
                temp = spells[cmbSpells.SelectedIndex];
                Random rng = new Random();
                switch(temp.SpellType)
                {
                    //if spell only deals damage
                    case 0:
                        int spellDamage=rng.Next(0, temp.Mp+1);
                        int damage= (rng.Next(0, inventory.player.mp + 1) + spellDamage);
                        //if attack misses
                        if (damage>0)
                        {
                            currentMonster.CurrentHp = currentMonster.CurrentHp - damage;
                            MessageBox.Show($"You dealt {damage} to the {currentMonster.Name}!");
                        }
                        else
                        {
                            MessageBox.Show($"{spells[cmbSpells.SelectedIndex].Name} missed!");
                        }

                        break;
                        //if spell is a buff
                    case 1:
                        if(temp.Mp>0&&temp.Str<0)
                        {
                            inventory.player.mp = inventory.player.mp + temp.Mp;
                            MessageBox.Show($"Your mp was increased by {temp.Mp} for {temp.Rounds}");
                        }
                        else if (temp.Str > 0&&temp.Mp<0)
                        {
                            inventory.player.str = inventory.player.str + temp.Str;
                            MessageBox.Show($"Your str was increased by {temp.Str} for {temp.Rounds}");
                        }
                        else if (temp.Str > 0 && temp.Mp > 0)
                        {
                            inventory.player.str = inventory.player.str + temp.Str;
                            inventory.player.mp = inventory.player.mp + temp.Mp;
                            MessageBox.Show($"Your str was increased by {temp.Str} and your mp was increased by {temp.Mp} for {temp.Rounds}");
                        }
                        break;
                        //if spell restores hp
                    case 2:
                        if(temp.Health>0)
                        {
                            inventory.player.currenthp = inventory.player.currenthp + temp.Health;
                            if(inventory.player.currenthp>inventory.player.maxhp)
                            {
                                inventory.player.currenthp = inventory.player.maxhp;
                            }

                            MessageBox.Show($"Your health has been restored to {inventory.player.currenthp}");
                        }
                        break;
                }
                SpellRounds spelRounds = new SpellRounds();
                spelRounds.rounds = temp.Rounds;
                spelRounds.currentRound = currentRound;
                spelRounds.activeSpell = temp;
                spellRounds?.Invoke(this, spelRounds);
            }

            this.Close();
        }

        private void SpellForm_Deactivate(object sender, EventArgs e)
        {
            FormClose?.Invoke(this, e);
        }
    }
}
