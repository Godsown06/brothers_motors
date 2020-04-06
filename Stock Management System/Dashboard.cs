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
    public partial class Dashboard : Form


   
    {

        public static Dashboard dashboard = new Dashboard();

        public Dashboard()
        {
            InitializeComponent();
            this.Opacity = 0;
            dashboard.Show(); 
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToShortDateString() + " || " + DateTime.Now.ToLongTimeString();

            if (this.Opacity < 1)
            {
                this.Opacity += 0.1;
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login login = new Login();
            login.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C://WINDOWS//System32//calc.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C://WINDOWS//System32//notepad.exe");
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addnewproduct addnewproduct = new Addnewproduct();
            addnewproduct.ShowDialog();
        }

        private void stockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stockin stockin = new Stockin();
            stockin.ShowDialog();
        }

        private void puToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchaseentry purchaseentry = new Purchaseentry();
            purchaseentry.ShowDialog();
        }

        private void purchaseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchaselist purchaselist = new Purchaselist();
            purchaselist.ShowDialog();
        }

        private void purchaseProductInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchaseproductin purchaseproductin = new Purchaseproductin();
            purchaseproductin.ShowDialog();
        }

        private void salesItemHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salesitemhistory salesitemhistory = new Salesitemhistory();
            salesitemhistory.ShowDialog();
        }

        private void salesInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salesinvoice salesinvoice = new Salesinvoice();
            salesinvoice.ShowDialog();
        }

        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salesreturn salesreturn = new Salesreturn();
            salesreturn.ShowDialog();
        }

        private void newQuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Newquotation newquotation = new Newquotation();
            newquotation.ShowDialog();
        }

        private void commissionPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commissionpayment commissionpayment = new Commissionpayment();
            commissionpayment.ShowDialog();
        }

        private void noteBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addnewnotebook addnewnotebook = new Addnewnotebook();
            addnewnotebook.ShowDialog();
        }

        private void addProductsCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            product_category category = new product_category();
            category.ShowDialog();
        }
    }
}
