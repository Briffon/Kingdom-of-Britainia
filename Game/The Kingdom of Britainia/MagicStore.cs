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
    public partial class MagicStore : Form
    {
        Inventory inventory;

        public MagicStore(Inventory i)
        {
            InitializeComponent();
            inventory = i;
            inventory.loadMagic();
            cmdItems.Items.Clear();
            foreach (Items item in inventory.magicStoreitems)
            {
                cmdItems.Items.Add(item.Name);
            }
            lblGold.Text = i.playerGold.ToString();
        }

        //selection  change
        private void cmdItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdItems.SelectedIndex != -1)
            {
                lblPrice.Text = inventory.magicStoreitems[cmdItems.SelectedIndex].Cost.ToString();
            }
        }

        //buy button
        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (cmdItems.SelectedIndex != -1)
            {
                if (inventory.playerGold >= inventory.magicStoreitems[cmdItems.SelectedIndex].Cost)
                {
                    inventory.playerGold = inventory.playerGold - inventory.magicStoreitems[cmdItems.SelectedIndex].Cost;
                    lblGold.Text = inventory.playerGold.ToString();
                    inventory.spells.Add(inventory.magicStoreitems[cmdItems.SelectedIndex]);
                    MessageBox.Show($"You bought {inventory.magicStoreitems[cmdItems.SelectedIndex].Name} and have {inventory.playerGold} gold remaining!");
                }

                else
                {
                    MessageBox.Show("Insufficient funds");
                }
            }
        }

        //exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
