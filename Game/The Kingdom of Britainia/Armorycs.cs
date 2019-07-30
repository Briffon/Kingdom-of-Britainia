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
    public partial class Armorycs : Form
    {
        Inventory inventory;
        public Armorycs(Inventory i)
        {
            InitializeComponent();
            inventory = i;
            inventory.loadArmory();
            cmdItems.Items.Clear();
            foreach (Items item in inventory.armoryStoreitems)
            {
                cmdItems.Items.Add(item.Name);
            }
            lblGold.Text = i.playerGold.ToString();
        }

        //seletion change
        private void cmdItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdItems.SelectedIndex != -1)
            {
                lblPrice.Text = inventory.armoryStoreitems[cmdItems.SelectedIndex].Cost.ToString();
            }
        }

        //buy button
        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (cmdItems.SelectedIndex != -1)
            {
                if (inventory.playerGold >= inventory.armoryStoreitems[cmdItems.SelectedIndex].Cost)
                {
                    inventory.playerGold = inventory.playerGold - inventory.armoryStoreitems[cmdItems.SelectedIndex].Cost;
                    lblGold.Text = inventory.playerGold.ToString();
                    inventory.playerItems.Add(inventory.armoryStoreitems[cmdItems.SelectedIndex]);
                    MessageBox.Show($"You bought {inventory.armoryStoreitems[cmdItems.SelectedIndex].Name} and have {inventory.playerGold} gold remaining!");
                }

                else
                {
                    MessageBox.Show("Insufficient funds");
                }
            }
        }

        //exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
