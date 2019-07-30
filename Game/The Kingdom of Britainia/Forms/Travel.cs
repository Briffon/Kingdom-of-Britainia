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
    public partial class Travel : Form
    {
        int progress;
        Thread thread;
        Inventory inventory;
        public Travel(Inventory i)
        {
            InitializeComponent();
            inventory = i;
            if(progress==0)
            {
                cmdAreas.Items.Add("Forest");
            }
        }

        //event progress method
        public void Progress(object sender, PlayerProgess e)
        {
            progress = e.Progress;
        }

        //close window
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            switch(cmdAreas.SelectedIndex)
            {
                case 0:
                    this.Close();
                    Application.OpenForms["Town"].Close();
                    thread = new Thread(openForest);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    break;
            }
        }

        private void openForest()
        {
            Application.Run(new Forest(inventory));
        }
    }

}
