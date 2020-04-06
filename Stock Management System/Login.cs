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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true) { txtPassword.UseSystemPasswordChar = false; }
            else if (txtPassword.UseSystemPasswordChar == false) { txtPassword.UseSystemPasswordChar = true; }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
            Newuser newuser = new Newuser();
            newuser.Show();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgotpassword forgotpassword = new Forgotpassword();
            forgotpassword.ShowDialog();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtUsername.Text == null)
            {
                MessageBox.Show("Username is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            else if (txtPassword.Text == "" || txtPassword.Text == null)
            {
                MessageBox.Show("Password is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
            else
            {
                timerFadeOut.Start();
            }
        }

        private void timerFadeOut_Tick(object sender, EventArgs e)
        {
            this.Opacity += -0.1;
            if (this.Opacity <= 0)
            {
                timerFadeOut.Stop();
                this.Dispose();
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
            }
        }

    }
}
