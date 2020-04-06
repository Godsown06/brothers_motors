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
    public partial class Forgotpassword : Form
    {
        public Forgotpassword()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == null || txtEmail.Text == "") { MessageBox.Show("Email is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); txtEmail.Focus(); }
            else if (txtUsername.Text == null || txtUsername.Text == "") { MessageBox.Show("Username is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); txtUsername.Focus(); }
            else if (txtPassword.Text == null || txtPassword.Text == "") { MessageBox.Show("Password is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); txtPassword.Focus(); }
            else if (txtRetypePassword.Text == null || txtRetypePassword.Text == txtPassword.Text) { MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); txtPassword.Focus(); }
            else
            {
            
            }
        }

    }
}
