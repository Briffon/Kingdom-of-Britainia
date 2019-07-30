namespace The_Kingdom_of_Britainia
{
    partial class InventoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnEquip = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.Stats = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblLevelUp = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMagicPower = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEXP = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentHp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxHp = new System.Windows.Forms.Label();
            this.btnSell = new System.Windows.Forms.Button();
            this.lbsdf = new System.Windows.Forms.Label();
            this.lblArmorRating = new System.Windows.Forms.Label();
            this.Stats.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(11, 9);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(245, 341);
            this.treeView1.TabIndex = 0;
            // 
            // btnEquip
            // 
            this.btnEquip.Location = new System.Drawing.Point(11, 357);
            this.btnEquip.Name = "btnEquip";
            this.btnEquip.Size = new System.Drawing.Size(75, 23);
            this.btnEquip.TabIndex = 1;
            this.btnEquip.Text = "Equip";
            this.btnEquip.UseVisualStyleBackColor = true;
            this.btnEquip.Click += new System.EventHandler(this.btnEquip_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(181, 357);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Stats
            // 
            this.Stats.Controls.Add(this.lbsdf);
            this.Stats.Controls.Add(this.lblArmorRating);
            this.Stats.Controls.Add(this.label2);
            this.Stats.Controls.Add(this.lblGold);
            this.Stats.Controls.Add(this.label13);
            this.Stats.Controls.Add(this.lblLevelUp);
            this.Stats.Controls.Add(this.label11);
            this.Stats.Controls.Add(this.lblLevel);
            this.Stats.Controls.Add(this.label9);
            this.Stats.Controls.Add(this.lblMagicPower);
            this.Stats.Controls.Add(this.label7);
            this.Stats.Controls.Add(this.lblEXP);
            this.Stats.Controls.Add(this.label5);
            this.Stats.Controls.Add(this.lblStr);
            this.Stats.Controls.Add(this.label3);
            this.Stats.Controls.Add(this.lblCurrentHp);
            this.Stats.Controls.Add(this.label1);
            this.Stats.Controls.Add(this.lblMaxHp);
            this.Stats.Location = new System.Drawing.Point(262, 12);
            this.Stats.Name = "Stats";
            this.Stats.Size = new System.Drawing.Size(259, 338);
            this.Stats.TabIndex = 3;
            this.Stats.TabStop = false;
            this.Stats.Text = "Stats";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Gold:";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(84, 275);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(41, 13);
            this.lblGold.TabIndex = 13;
            this.lblGold.Text = "label14";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 239);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Next level up:";
            // 
            // lblLevelUp
            // 
            this.lblLevelUp.AutoSize = true;
            this.lblLevelUp.Location = new System.Drawing.Point(84, 239);
            this.lblLevelUp.Name = "lblLevelUp";
            this.lblLevelUp.Size = new System.Drawing.Size(41, 13);
            this.lblLevelUp.TabIndex = 11;
            this.lblLevelUp.Text = "label14";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "level:";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(60, 176);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(41, 13);
            this.lblLevel.TabIndex = 11;
            this.lblLevel.Text = "label12";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Magic Power:";
            // 
            // lblMagicPower
            // 
            this.lblMagicPower.AutoSize = true;
            this.lblMagicPower.Location = new System.Drawing.Point(84, 143);
            this.lblMagicPower.Name = "lblMagicPower";
            this.lblMagicPower.Size = new System.Drawing.Size(41, 13);
            this.lblMagicPower.TabIndex = 11;
            this.lblMagicPower.Text = "label10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "EXP:";
            // 
            // lblEXP
            // 
            this.lblEXP.AutoSize = true;
            this.lblEXP.Location = new System.Drawing.Point(60, 209);
            this.lblEXP.Name = "lblEXP";
            this.lblEXP.Size = new System.Drawing.Size(35, 13);
            this.lblEXP.TabIndex = 7;
            this.lblEXP.Text = "label8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Strength:";
            // 
            // lblStr
            // 
            this.lblStr.AutoSize = true;
            this.lblStr.Location = new System.Drawing.Point(60, 105);
            this.lblStr.Name = "lblStr";
            this.lblStr.Size = new System.Drawing.Size(35, 13);
            this.lblStr.TabIndex = 9;
            this.lblStr.Text = "label6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Current Hp:";
            // 
            // lblCurrentHp
            // 
            this.lblCurrentHp.AutoSize = true;
            this.lblCurrentHp.Location = new System.Drawing.Point(73, 66);
            this.lblCurrentHp.Name = "lblCurrentHp";
            this.lblCurrentHp.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentHp.TabIndex = 7;
            this.lblCurrentHp.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Max Hp:";
            // 
            // lblMaxHp
            // 
            this.lblMaxHp.AutoSize = true;
            this.lblMaxHp.Location = new System.Drawing.Point(59, 27);
            this.lblMaxHp.Name = "lblMaxHp";
            this.lblMaxHp.Size = new System.Drawing.Size(35, 13);
            this.lblMaxHp.TabIndex = 5;
            this.lblMaxHp.Text = "label2";
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(96, 357);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 23);
            this.btnSell.TabIndex = 4;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // lbsdf
            // 
            this.lbsdf.AutoSize = true;
            this.lbsdf.Location = new System.Drawing.Point(6, 307);
            this.lbsdf.Name = "lbsdf";
            this.lbsdf.Size = new System.Drawing.Size(71, 13);
            this.lbsdf.TabIndex = 14;
            this.lbsdf.Text = "Armor Rating:";
            // 
            // lblArmorRating
            // 
            this.lblArmorRating.AutoSize = true;
            this.lblArmorRating.Location = new System.Drawing.Point(84, 307);
            this.lblArmorRating.Name = "lblArmorRating";
            this.lblArmorRating.Size = new System.Drawing.Size(13, 13);
            this.lblArmorRating.TabIndex = 15;
            this.lblArmorRating.Text = "0";
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 388);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.Stats);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEquip);
            this.Controls.Add(this.treeView1);
            this.Name = "InventoryForm";
            this.Text = "Inventory";
            this.Stats.ResumeLayout(false);
            this.Stats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnEquip;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox Stats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaxHp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEXP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentHp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblMagicPower;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblLevelUp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lbsdf;
        private System.Windows.Forms.Label lblArmorRating;
    }
}