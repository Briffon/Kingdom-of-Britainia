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
    public partial class InventoryForm : Form
    {
        Inventory inventory;
        public event EventHandler<ViewInventoryWeapon> Equip;
        public event EventHandler<viewInventoryArmor> EquipArmor;

        public InventoryForm(Inventory i)
        {
            InitializeComponent();
            inventory = i;

            //set stats
            lblCurrentHp.Text = inventory.player.currenthp.ToString();
            lblMaxHp.Text = inventory.player.maxhp.ToString();
            lblLevel.Text = inventory.player.level.ToString();
            lblEXP.Text = inventory.player.exp.ToString();
            lblMagicPower.Text = inventory.player.mp.ToString();
            lblStr.Text = inventory.player.str.ToString();
            lblLevelUp.Text = (inventory.player.expThreshold - inventory.player.exp).ToString();
            lblGold.Text = inventory.playerGold.ToString();

            if(inventory.activeArmor!=null)
            {
                lblArmorRating.Text = inventory.activeArmor.ArmorRating.ToString();
            }
        }
        
        //view inventory event method
        public void ViewInvetory(object sender, ViewInvetoryEvent e)
        {
            TreeNode node = new TreeNode();

            node.Text = $"Spell:{e.Name}";
            node.Tag = e;
            if (e.Health > 0)
            {
                TreeNode health = new TreeNode();
                health.Text = e.Health.ToString();
                node.Nodes.Add("Health:"+health.Text);
            }
            if (e.Str > 0)
            {
                TreeNode str = new TreeNode();
                str.Text = e.Str.ToString();
                node.Nodes.Add("Str:"+str.Text);
            }
            if (e.Mp > 0)
            {
                TreeNode mp = new TreeNode();
                mp.Text = e.Mp.ToString();
                node.Nodes.Add("MP:"+mp.Text);
            }
            if (e.Rounds > 0)
            {
                TreeNode rounds = new TreeNode();
                rounds.Text = e.Rounds.ToString();
                node.Nodes.Add("Rounds:"+rounds.Text);
            }
            TreeNode sellPrice = new TreeNode();
            sellPrice.Text = e.SellPrice.ToString();
            node.Nodes.Add("Sell Price:"+sellPrice.Text);
            TreeNode description = new TreeNode();
            description.Text = e.Desription;
            node.Nodes.Add(description);

            treeView1.Nodes.Add(node);

        }

        //view inventory event method for weapons
        public void ViewInventoryWeapon(object sender, ViewInventoryWeapon e)
        {
            TreeNode node = new TreeNode();
            if (inventory.activeWeapon != null)
            {
                if (e.Name == inventory.activeWeapon.Name)
                {
                    node.Text = "(Equipped)" + e.Name;
                }
            }
            else
            {
                node.Text = e.Name;
            }
            node.Tag = e;
            if (e.Health > 0)
            {
                TreeNode health = new TreeNode();
                health.Text = e.Health.ToString();
                node.Nodes.Add("Health:" + health.Text);
            }
            if (e.Str > 0)
            {
                TreeNode str = new TreeNode();
                str.Text = e.Str.ToString();
                node.Nodes.Add("Str:" + str.Text);
            }
            if (e.Mp > 0)
            {
                TreeNode mp = new TreeNode();
                mp.Text = e.Mp.ToString();
                node.Nodes.Add("MP:" + mp.Text);
            }
            TreeNode sellPrice = new TreeNode();
            sellPrice.Text = e.SellPrice.ToString();
            node.Nodes.Add("Sell Price:" + sellPrice.Text);
            TreeNode description = new TreeNode();
            description.Text = e.Desription;
            node.Nodes.Add(description);

            treeView1.Nodes.Add(node);

        }

        //view inventory event method for potions
        public void ViewInventoryPotion(object sender, ViewInventoryPotion e)
        {
            TreeNode node = new TreeNode();

            node.Text = e.Name;
            node.Tag = e;
            if (e.Health > 0)
            {
                TreeNode health = new TreeNode();
                health.Text = e.Health.ToString();
                node.Nodes.Add("Health:" + health.Text);
            }
            if (e.Str > 0)
            {
                TreeNode str = new TreeNode();
                str.Text = e.Str.ToString();
                node.Nodes.Add("Str:" + str.Text);
            }
            if (e.Mp > 0)
            {
                TreeNode mp = new TreeNode();
                mp.Text = e.Mp.ToString();
                node.Nodes.Add("MP:" + mp.Text);
            }
            TreeNode sellPrice = new TreeNode();
            sellPrice.Text = e.SellPrice.ToString();
            node.Nodes.Add("Sell Price:" + sellPrice.Text);
            TreeNode description = new TreeNode();
            description.Text = e.Desription;
            node.Nodes.Add(description);

            treeView1.Nodes.Add(node);

        }

        //view inventory event method for armor
        public void ViewInventoryArmor(object sender, viewInventoryArmor e)
        {
            TreeNode node = new TreeNode();
            if (inventory.activeArmor != null)
            {
                if (e.Name == inventory.activeWeapon.Name)
                {
                    node.Text = "(Equipped)" + e.Name;
                }
            }
            else
            {
                node.Text = e.Name;
            }
            node.Tag = e;
            if (e.Health > 0)
            {
                TreeNode health = new TreeNode();
                health.Text = e.Health.ToString();
                node.Nodes.Add("Health:" + health.Text);
            }
            if (e.ArmorRating > 0)
            {
                TreeNode str = new TreeNode();
                str.Text = e.ArmorRating.ToString();
                node.Nodes.Add("Armor Rating:" + str.Text);
            }

            TreeNode sellPrice = new TreeNode();
            sellPrice.Text = e.SellPrice.ToString();
            node.Nodes.Add("Sell Price:" + sellPrice.Text);
            TreeNode description = new TreeNode();
            description.Text = e.Desription;
            node.Nodes.Add(description);

            treeView1.Nodes.Add(node);
        }

        //equip button
        private void btnEquip_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is ViewInventoryWeapon)
            {
                ViewInventoryWeapon weapon = new ViewInventoryWeapon();
                weapon = (ViewInventoryWeapon)treeView1.SelectedNode.Tag;
                Equip?.Invoke(this, weapon);
                foreach (TreeNode item in treeView1.Nodes)
                {
                    if (item.Text.Contains("Equipped")&&item.Tag is ViewInventoryWeapon)
                    {
                        item.Text = item.Text.Substring(10);
                    }
                }
                treeView1.SelectedNode.Text = "(Equipped)" + treeView1.SelectedNode.Text;
            }

            else if(treeView1.SelectedNode.Tag is viewInventoryArmor)
            {
                viewInventoryArmor armor = new viewInventoryArmor();
                armor = (viewInventoryArmor)treeView1.SelectedNode.Tag;
                EquipArmor?.Invoke(this, armor);
                foreach (TreeNode item in treeView1.Nodes)
                {
                    if(item.Text.Contains("Equipped")&&item.Tag is viewInventoryArmor)
                    {
                        item.Text = item.Text.Substring(10);
                    }
                }
                treeView1.SelectedNode.Text = "(Equipped)" + treeView1.SelectedNode.Text;
                lblArmorRating.Text = inventory.activeArmor.ArmorRating.ToString();
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //sell item
        private void btnSell_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode.Tag is ViewInventoryWeapon)
            {
                
                ViewInventoryWeapon weapon = new ViewInventoryWeapon();
                weapon = (ViewInventoryWeapon)treeView1.SelectedNode.Tag;
                inventory.playerGold += weapon.SellPrice;
                treeView1.SelectedNode.Remove();
                inventory.playerItems.RemoveAt(treeView1.SelectedNode.Index);
                MessageBox.Show($"You sold {weapon.Name} for {weapon.SellPrice} gold!");
                lblGold.Text = inventory.playerGold.ToString();
            }
            else if(treeView1.SelectedNode.Tag is ViewInventoryPotion)
            {
                ViewInventoryPotion potion = new ViewInventoryPotion();
                potion = (ViewInventoryPotion)treeView1.SelectedNode.Tag;
                inventory.playerGold += potion.SellPrice;
                treeView1.SelectedNode.Remove();
                inventory.playerItems.RemoveAt(treeView1.SelectedNode.Index);
                MessageBox.Show($"You sold {potion.Name} for {potion.SellPrice} gold!");
                lblGold.Text = inventory.playerGold.ToString();
            }
            else if (treeView1.SelectedNode.Tag is ViewInvetoryEvent )
            {
                ViewInvetoryEvent spell = new ViewInvetoryEvent();
                spell = (ViewInvetoryEvent)treeView1.SelectedNode.Tag;
                inventory.playerGold += spell.SellPrice;
                treeView1.SelectedNode.Remove();
                for (int i = 0; i <inventory.spells.Count; i++)
                {
                    if(inventory.spells[i].Name==spell.Name)
                    {
                        inventory.spells.RemoveAt(i);
                    }
                }
                MessageBox.Show($"You sold {spell.Name} for {spell.SellPrice} gold!");
                lblGold.Text = inventory.playerGold.ToString();
            }

            this.Close();
        }
    }
}
