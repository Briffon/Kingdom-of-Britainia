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
    public partial class General_Store : Form
    {
        Inventory inventory;

        public General_Store(Inventory i)
        {
            InitializeComponent();
            inventory = i;
            inventory.loadGeneral();
            cmdItems.Items.Clear();
            foreach (Items item in inventory.generalStoreitems)
            {
                cmdItems.Items.Add(item.Name);
            }
            lblGold.Text = i.playerGold.ToString();
        }

        //selection change
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdItems.SelectedIndex!=-1)
            {
                lblPrice.Text = inventory.generalStoreitems[cmdItems.SelectedIndex].Cost.ToString();
            }
        }

        //buy button
        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (cmdItems.SelectedIndex != -1)
            {
                if (inventory.playerGold >= inventory.generalStoreitems[cmdItems.SelectedIndex].Cost)
                {
                    inventory.playerGold = inventory.playerGold - inventory.generalStoreitems[cmdItems.SelectedIndex].Cost;
                    lblGold.Text = inventory.playerGold.ToString();
                    inventory.playerItems.Add(inventory.generalStoreitems[cmdItems.SelectedIndex]);
                    MessageBox.Show($"You bought {inventory.generalStoreitems[cmdItems.SelectedIndex].Name} and have {inventory.playerGold} gold remaining!");
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
