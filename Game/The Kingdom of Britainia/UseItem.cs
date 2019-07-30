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
    public partial class UseItem : Form
    {
        Inventory inventory;
        List<Potions> potions = new List<Potions>();
        int currentRound;
        public event EventHandler<PotionRoundscs> potionRounds;
        public UseItem(Inventory i, int r)
        {
            InitializeComponent();
            inventory = i;
            currentRound = r;
            cmbItems.Items.Clear();
            potions.Clear();
            foreach (Items item in inventory.playerItems)
            {
                if (item is Potions)
                {
                    cmbItems.Items.Add(item.Name);
                    potions.Add((Potions)item);
                }
            }
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            if(cmbItems.SelectedIndex!=-1)
            {
                Potions selectedPotion = potions[cmbItems.SelectedIndex];

                //if potion is raising mp and str
                if (selectedPotion.Mp > 0 && selectedPotion.Str>0)
                {
                    inventory.player.mp=selectedPotion.Mp + inventory.player.mp;
                    inventory.player.str = selectedPotion.Str + inventory.player.str;
                    MessageBox.Show($"Your mp has been raised by {selectedPotion.Mp} and your str by {selectedPotion.Str} for {selectedPotion.Rounds} rounds!");
                    PotionRoundscs pot = new PotionRoundscs();
                    pot.currentRound = currentRound;
                    pot.potion = selectedPotion;
                    potionRounds?.Invoke(this, pot);
                    for (int i = 0; i < inventory.playerItems.Count; i++)
                    {
                        if (inventory.playerItems[i] == selectedPotion)
                        {
                            inventory.playerItems.RemoveAt(i);
                        }
                    }
                }

                //if potion is raising Mp
                else if(selectedPotion.Mp>0&&selectedPotion.Str<0)
                {
                    inventory.player.mp = selectedPotion.Mp + inventory.player.mp;
                    MessageBox.Show($"Your mp has been raised by {selectedPotion.Mp}  for {selectedPotion.Rounds} rounds!");
                    PotionRoundscs pot = new PotionRoundscs();
                    pot.currentRound = currentRound;
                    pot.potion = selectedPotion;
                    potionRounds?.Invoke(this, pot);
                    for (int i = 0; i < inventory.playerItems.Count; i++)
                    {
                        if (inventory.playerItems[i] == selectedPotion)
                        {
                            inventory.playerItems.RemoveAt(i);
                        }
                    }

                }

                //if potion is raising Str
                else if (selectedPotion.Str>0&&selectedPotion.Mp<0)
                {
                    inventory.player.str = selectedPotion.Str + inventory.player.str;
                    MessageBox.Show($"Your str has been raised by {selectedPotion.Str} for {selectedPotion.Rounds} rounds!");
                    PotionRoundscs pot = new PotionRoundscs();
                    pot.currentRound = currentRound;
                    pot.potion = selectedPotion;
                    potionRounds?.Invoke(this, pot);
                    for (int i = 0; i < inventory.playerItems.Count; i++)
                    {
                        if (inventory.playerItems[i] == selectedPotion)
                        {
                            inventory.playerItems.RemoveAt(i);
                        }
                    }
                }

                //if potion is restoring health
                else if(selectedPotion.Health>0)
                {
                    inventory.player.currenthp = inventory.player.currenthp + selectedPotion.Health;
                    if(inventory.player.currenthp>inventory.player.maxhp)
                    {
                        inventory.player.currenthp = inventory.player.maxhp;
                    }

                    MessageBox.Show($"You hp has been restore to {inventory.player.currenthp}!");
                    for (int i = 0; i < inventory.playerItems.Count; i++)
                    {
                        if (inventory.playerItems[i] == selectedPotion)
                        {
                            inventory.playerItems.RemoveAt(i);
                        }
                    }
                }
            }
            this.Close();
        }
    }
}
