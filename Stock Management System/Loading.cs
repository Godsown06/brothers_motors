using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brothers_Motors
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        int increaseTimer = 1;
        private void timerLoad_Tick(object sender, EventArgs e)
        {
            increaseTimer += 1;
            if (increaseTimer == 30)
            {
                lblProgress.Text = "Please wait...";
            }

            if (increaseTimer == 50)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }
    }
}
