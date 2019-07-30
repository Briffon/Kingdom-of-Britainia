namespace The_Kingdom_of_Britainia
{
    partial class MagicStore
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
            this.Goods = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.cmdItems = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Goods.SuspendLayout();
            this.SuspendLayout();
            // 
            // Goods
            // 
            this.Goods.Controls.Add(this.btnExit);
            this.Goods.Controls.Add(this.lblPrice);
            this.Goods.Controls.Add(this.label4);
            this.Goods.Controls.Add(this.lblGold);
            this.Goods.Controls.Add(this.btnBuy);
            this.Goods.Controls.Add(this.cmdItems);
            this.Goods.Controls.Add(this.label2);
            this.Goods.Controls.Add(this.label1);
            this.Goods.Location = new System.Drawing.Point(12, 12);
            this.Goods.Name = "Goods";
            this.Goods.Size = new System.Drawing.Size(201, 191);
            this.Goods.TabIndex = 8;
            this.Goods.TabStop = false;
            this.Goods.Text = "Goods";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(99, 158);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(75, 112);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(35, 13);
            this.lblPrice.TabIndex = 11;
            this.lblPrice.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Item Price:";
            // 
            // lblGold
            // 
            this.lblGold.Location = new System.Drawing.Point(50, 28);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(35, 13);
            this.lblGold.TabIndex = 0;
            this.lblGold.Text = "0";
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(15, 158);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 10;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // cmdItems
            // 
            this.cmdItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdItems.FormattingEnabled = true;
            this.cmdItems.Items.AddRange(new object[] {
            "Lightning Bolt",
            "Lesser Heal"});
            this.cmdItems.Location = new System.Drawing.Point(53, 65);
            this.cmdItems.Name = "cmdItems";
            this.cmdItems.Size = new System.Drawing.Size(121, 21);
            this.cmdItems.TabIndex = 9;
            this.cmdItems.SelectedIndexChanged += new System.EventHandler(this.cmdItems_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gold:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Items:";
            // 
            // MagicStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 210);
            this.Controls.Add(this.Goods);
            this.Name = "MagicStore";
            this.Text = "Magic Store";
            this.Goods.ResumeLayout(false);
            this.Goods.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Goods;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.ComboBox cmdItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}