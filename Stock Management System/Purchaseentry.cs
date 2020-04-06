using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Brothers_Motors
{
    public partial class Purchaseentry : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Brother_motors;Integrated Security=True");

        public Purchaseentry()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void Purchaseentry_Load(object sender, EventArgs e)
        {
            invoiceno();
            txtpreviousdue.Text = lblbalance.Text;
            if (txtamount.Text == "0.00" || txtamount.Text == "0") { txtdiscountpercent.Enabled = false; txtvatpercent.Enabled = false; } else { txtdiscountpercent.Enabled = true; txtvatpercent.Enabled = true; }
            if (txtvatpercent.Text == "" || txtdiscountpercent.Text == "") { btntotalamount.Enabled = false; } else { btntotalamount.Enabled = true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            supplierid();
        }

        private void txtsubtotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtpreviousdue.Focus();
            }
        }

        private void txtpreviousdue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtsubtotal.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txttotal.Focus();
            }
        }

        private void txttotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtpreviousdue.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtfreightcharges.Focus();
            }
        }

        private void txtfreightcharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txttotal.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtothercharges.Focus();
            }
        }

        private void txtothercharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtfreightcharges.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtroundoff.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtcontactno.Focus();
            }
        }

        private void txtroundoff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtroundoff.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtgrandtotal.Focus();
            }
        }

        private void txtgrandtotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtroundoff.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txttotalpaid.Focus();
            }
        }

        private void txttotalpaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtgrandtotal.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtbalance.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtbarcode.Focus();
            }
        }

        private void txtbalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txttotalpaid.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                btnadd.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtproductname.Focus();
            }
        }

        private void txtinvoiceno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtsupplierid.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtsuppliername.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtcash.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtinvoiceno.Focus();
            }
        }

        private void txtcash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtaddress.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtremarks.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                dateTimePicker1.Focus();
            }
        }

        private void txtremarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtcontactno.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtproductcode.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtcash.Focus();
            }
        }

        private void txtproductcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtremarks.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtbarcode.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtproductname.Focus();
            }
        }

        private void txtproductname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtproductcode.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtbalance.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtpriceperunit.Focus();
            }
        }

        private void txtpriceperunit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtproductname.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtquantity.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtdiscount.Focus();
            }
        }

        private void txtdiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtpriceperunit.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtdiscountpercent.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtvat.Focus();
            }
        }

        private void txtvat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtdiscount.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtvatpercent.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txttotalamount.Focus();
            }
        }

        private void txttotalamount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtvat.Focus();
            }
        }

        private void txtvatpercent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtdiscountpercent.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txttotalamount.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtvat.Focus();
            }
        }

        private void txtdiscountpercent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtquantity.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtvatpercent.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtdiscount.Focus();
            }
         
        }

        private void txtquantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtproductname.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtdiscountpercent.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtpriceperunit.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtamount.Focus();
            }
        }

        private void txtbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtcontactno.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtproductname.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtproductcode.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txttotalpaid.Focus();
            }
        }

        private void txtcontactno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtcity.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtbarcode.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtremarks.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtothercharges.Focus();
            }
        }

        private void txtcity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtaddress.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtcontactno.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtfreightcharges.Focus();
            }
        }

        private void txtaddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtsuppliername.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtcity.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txttotal.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtcash.Focus();
            }
        }

        private void txtsuppliername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtsupplierid.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtaddress.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtpreviousdue.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                dateTimePicker1.Focus();
            }
        }

        private void txtsupplierid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtsupplierid.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtsuppliername.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtsubtotal.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtinvoiceno.Focus();
            }
        }

        private void txtamount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtproductname.Focus();
            }
          
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtbalance.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtquantity.Focus();
            }
        }

        private void cmbdiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtamount.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtdiscount.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                btnadd.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtdiscountpercent.Focus();
            }
        }

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblbuyprice.Text = "0.00";
                double amount = Convert.ToDouble(txtamount.Text);  //takes in txtamount value
                double discount = Convert.ToDouble(txtdiscount.Text);
                double buyprice = amount - discount;
                lblbuyprice.Text = buyprice.ToString();
            }
            catch (Exception) { }
        }

        private void txtquantity_TextChanged(object sender, EventArgs e)
        {
            txtamount.Text = "0";

            try
            {
                double priceperunit = Convert.ToDouble(txtpriceperunit.Text);
                int quantity = Convert.ToInt32(txtquantity.Text);
                double amount = priceperunit * quantity;
                txtamount.Text = amount.ToString();
            }
            catch (Exception) { }
        }

        private void txtpriceperunit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allows 0-9, backspace and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                MessageBox.Show("Letters are not allowed", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
            //checks to make sure only one decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1) { MessageBox.Show("Only one decimal is allowed", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information); e.Handled = true; e.Handled = true; }
            }
        }

        private void txtdiscountpercent_TextChanged(object sender, EventArgs e)
        {
            txtdiscount.Clear();
            txtdiscount.Text = "0";
            try
            {
                double amount = Convert.ToDouble(txtamount.Text);  //takes in txtamount value
                double discountpercent = Convert.ToDouble(txtdiscountpercent.Text);  //takes in discount percent
                double percent = discountpercent / 100;  // calculate the percentage of txtamount
                double discount = amount * percent;  //now the discountvalue
                txtdiscount.Text = discount.ToString();
            }
            catch (Exception) { }
            if (txtvatpercent.Text == "" || txtdiscountpercent.Text == "") { btntotalamount.Enabled = false; } else { btntotalamount.Enabled = true; }
        }

        private void txtpriceperunit_TextChanged(object sender, EventArgs e)
        {
            txtvatpercent.Clear();
            txtdiscountpercent.Clear();
            txtamount.Text = "0";
            try
            {
                double priceperunit = Convert.ToDouble(txtpriceperunit.Text);
                int quantity = Convert.ToInt32(txtquantity.Text);
                double amount = priceperunit * quantity;
                txtamount.Text = amount.ToString();
            }
            catch (Exception) { }
        }

        private void txtpriceperunit_Enter(object sender, EventArgs e)
        {
            if (txtpriceperunit.Text == "0.00") { txtpriceperunit.Clear(); }
        }

        private void txtpriceperunit_Leave(object sender, EventArgs e)
        {
            if (txtpriceperunit.Text == "") { txtpriceperunit.Text = "0.00"; }
        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {
            if (txtamount.Text == "0.00" || txtamount.Text == "0") { txtdiscountpercent.Enabled = false; txtvatpercent.Enabled = false; } else { txtdiscountpercent.Enabled = true; txtvatpercent.Enabled = true; }
        }

        private void txtvatpercent_TextChanged(object sender, EventArgs e)
        {
            txtvat.Text = "0";
            try
            {
                double amount = Convert.ToDouble(txtamount.Text);
                double vatpercent = Convert.ToDouble(txtvatpercent.Text);
                double vat = (vatpercent / 100) * amount;
                txtvat.Text = vat.ToString();
            }
            catch (Exception) { }
            if (txtvatpercent.Text == "" || txtdiscountpercent.Text == "") { btntotalamount.Enabled = false; } else { btntotalamount.Enabled = true; }
        }

        private void btntotalamount_Click(object sender, EventArgs e)
        {
            try
            {
                double amount = Convert.ToDouble(txtamount.Text);
                double discount = Convert.ToDouble(txtdiscount.Text);
                double vat = Convert.ToDouble(txtvat.Text);
                double totalAmount = (amount - discount) + vat;
                txttotalamount.Text = totalAmount.ToString();
                double sub_total = Convert.ToDouble(txtsubtotal.Text);
                double subtotal = Convert.ToDouble(txttotalamount.Text) + sub_total;

                txtsubtotal.Text = subtotal.ToString();
            }
            catch (Exception) { }
        }

      private void txtcash_TextChanged(object sender, EventArgs e)
        {
            if (txtcash.Text == "Credit") { txttotal.Enabled = false; } else { txttotal.Enabled = true; }
        }

        private void txtcash_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Items.Contains(cb.Text) && cb.Text != "") { MessageBox.Show("Property not valid!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtcash.Text = string.Empty; txtcash.Focus(); }
        }

        private void txtbalance_TextChanged(object sender, EventArgs e)
        {
            lblbalance.Text = txtbalance.Text;
        }

        public void invoiceno()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT (*) FROM PurchaseEntry", con);
            int countrow = Convert.ToInt32(cmd.ExecuteScalar());
            cmd = null;
            con.Close();

            double rownumber = 1 + countrow;
            txtinvoiceno.Text = "S-" + rownumber;

            SqlDataAdapter cmdd = new SqlDataAdapter("SELECT COUNT (*) FROM PurchaseEntry where Invoice_NO = '" + txtinvoiceno.Text + "'", con);
            DataTable dt = new DataTable();
            cmdd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                rownumber = 1 + rownumber;
                txtinvoiceno.Text = "S-" + rownumber;

            }
        }

        public void supplierid()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT (*) FROM PurchaseEntry", con);
            int countrow = Convert.ToInt32(cmd.ExecuteScalar());
            cmd = null;
            con.Close();

            double rownumber = 1 + countrow;
            txtsupplierid.Text = "S-" + rownumber;

            SqlDataAdapter cmdd = new SqlDataAdapter("SELECT COUNT (*) FROM PurchaseEntry where Supplier_ID = '"+ txtsupplierid.Text + "'", con);
            DataTable dt = new DataTable();
            cmdd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                rownumber = 1 + rownumber;
                txtsupplierid.Text = "S-" + rownumber;

            }
        }

        private void Purchaseentry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && (e.Alt || e.Control || e.Shift))
            {
                supplierid();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {

        }
    }
}
