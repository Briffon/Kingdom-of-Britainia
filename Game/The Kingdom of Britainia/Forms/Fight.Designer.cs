namespace The_Kingdom_of_Britainia
{
    partial class Fight
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAttack = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            this.btnSpells = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblPhp = new System.Windows.Forms.Label();
            this.lblMhp = new System.Windows.Forms.Label();
            this.lblRounds = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(370, 257);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(90, 275);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(83, 35);
            this.btnAttack.TabIndex = 1;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // btnItems
            // 
            this.btnItems.Location = new System.Drawing.Point(212, 275);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(83, 35);
            this.btnItems.TabIndex = 2;
            this.btnItems.Text = "Items";
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnSpells
            // 
            this.btnSpells.Location = new System.Drawing.Point(90, 316);
            this.btnSpells.Name = "btnSpells";
            this.btnSpells.Size = new System.Drawing.Size(83, 35);
            this.btnSpells.TabIndex = 3;
            this.btnSpells.Text = "Spells";
            this.btnSpells.UseVisualStyleBackColor = true;
            this.btnSpells.Click += new System.EventHandler(this.btnSpells_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(212, 316);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(83, 35);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lblPhp
            // 
            this.lblPhp.AutoSize = true;
            this.lblPhp.Location = new System.Drawing.Point(18, 275);
            this.lblPhp.Name = "lblPhp";
            this.lblPhp.Size = new System.Drawing.Size(35, 13);
            this.lblPhp.TabIndex = 5;
            this.lblPhp.Text = "label1";
            // 
            // lblMhp
            // 
            this.lblMhp.AutoSize = true;
            this.lblMhp.Location = new System.Drawing.Point(301, 275);
            this.lblMhp.Name = "lblMhp";
            this.lblMhp.Size = new System.Drawing.Size(35, 13);
            this.lblMhp.TabIndex = 6;
            this.lblMhp.Text = "label2";
            // 
            // lblRounds
            // 
            this.lblRounds.AutoSize = true;
            this.lblRounds.Location = new System.Drawing.Point(18, 338);
            this.lblRounds.Name = "lblRounds";
            this.lblRounds.Size = new System.Drawing.Size(35, 13);
            this.lblRounds.TabIndex = 7;
            this.lblRounds.Text = "label1";
            // 
            // Fight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 359);
            this.Controls.Add(this.lblRounds);
            this.Controls.Add(this.lblMhp);
            this.Controls.Add(this.lblPhp);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnSpells);
            this.Controls.Add(this.btnItems);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Fight";
            this.Text = "Fight";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Button btnSpells;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblPhp;
        private System.Windows.Forms.Label lblMhp;
        private System.Windows.Forms.Label lblRounds;
    }
}