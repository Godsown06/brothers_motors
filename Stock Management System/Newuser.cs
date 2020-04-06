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
    public partial class Newuser : Form
    {
        public Newuser()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public void UserID()
        {
            Random rnd = new Random();
            int prodNum = rnd.Next(10, 99);

            if (cmbUserRole.SelectedIndex == 0)
            {
                txtUserID.Text = "A-" + DateTime.Now.Year + prodNum.ToString(); 
            }
            else if (cmbUserRole.SelectedIndex == 1)
            {
                txtUserID.Text = "M-" + DateTime.Now.Year + prodNum.ToString();
            }
            else if (cmbUserRole.SelectedIndex == 2)
            {
                txtUserID.Text = "S-" + DateTime.Now.Year + prodNum.ToString();
            }
        }

        private void Newuser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void cmbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserID();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "images files(*.jpg; *.jpeg)|*.jpg; *.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picUserPassport.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
