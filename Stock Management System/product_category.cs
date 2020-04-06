using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Brothers_Motors
{
    public partial class product_category : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Brother_motors;Integrated Security=True");
        public product_category()
        {
            InitializeComponent();
            this.MaximumSize = MaximumSize;
            this.MinimumSize = MinimumSize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblid.Text != "ID") { MessageBox.Show("Please Clear Field and Re-enter", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (txtproductcategory.Text == "")
            {
                MessageBox.Show("please enter product category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtproductcategory.Focus(); return;
            }
            if (txtproductsubcategory.Text == "")
            {
                MessageBox.Show("please enter product subcategory category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtproductsubcategory.Focus(); return;
            }
            if (txtpurchaseunit.Text == "")
            {
                MessageBox.Show("please enter product purchase unit category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpurchaseunit.Focus(); return;
            }
            if (txtsalesunit.Text == "")
            {
                MessageBox.Show("please enter product sales unit category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsalesunit.Focus(); return;
            }

            try
            {
                con.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("select * from product_category where productcategory = '"+ txtproductcategory.Text +"' and productsubcategory = '"+ txtproductsubcategory.Text +"' and productpurchaseunit = '"+ txtpurchaseunit.Text +"' and productsalesunit = '"+ txtsalesunit.Text +"'  ",con);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("product category or product subcategory or product purchase unit or product sale unit already exits!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtproductcategory.Focus();
                    return;
                }
            }
            catch (Exception) 
            { }
            finally { con.Close(); }

            try 
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into product_Category values('" + txtproductcategory.Text + "','" + txtproductsubcategory.Text + "','" + txtpurchaseunit.Text + "','" + txtsalesunit.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Product Categories Inserted!","Sucess",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception)
            { }
            finally { con.Close(); }
        }

        private void txtproductcategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtproductsubcategory.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                textBox1.Focus();
            }

        }

        private void txtproductsubcategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtpurchaseunit.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtproductcategory.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                textBox1.Focus();
            }
        }

        private void txtpurchaseunit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtsalesunit.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtproductsubcategory.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                textBox2.Focus();
            }
        }

        private void txtsalesunit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                textBox2.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtpurchaseunit.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtsalesunit.Clear();
            txtpurchaseunit.Clear();
            txtproductcategory.Clear();
            txtproductsubcategory.Clear();
            lblid.Text = "ID";
            btnsave.Enabled = true;
        }

        void refreshdatagrid()
        {

            SqlDataAdapter cmd = new SqlDataAdapter("select * from product_category ", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void product_category_Load(object sender, EventArgs e)
        {
            refreshdatagrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1 == null || dataGridView1.Rows.Count == 1)
            {
                dataGridView1.Enabled = false;
            }
            else
            {
                dataGridView1.Enabled = true ;
                string edit = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (edit == "Edit")
                {
                    txtproductcategory.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txtproductsubcategory.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txtpurchaseunit.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    txtsalesunit.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    lblid.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    btnsave.Enabled = false;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (lblid.Text == "ID")
            { MessageBox.Show("please Click on edit in the datagridview to change values!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); return;  }
            if (txtproductcategory.Text == "")
            {
                MessageBox.Show("please enter product category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtproductcategory.Focus(); return;
            }
            if (txtproductsubcategory.Text == "")
            {
                MessageBox.Show("please enter product subcategory category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtproductsubcategory.Focus(); return;
            }
            if (txtpurchaseunit.Text == "")
            {
                MessageBox.Show("please enter product purchase unit category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpurchaseunit.Focus(); return;
            }
            if (txtsalesunit.Text == "")
            {
                MessageBox.Show("please enter product sales unit category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsalesunit.Focus(); return;
            }

            try  //makes sure there is changes in the field before updating
            {
                con.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("select * from product_category where id = '"+ lblid.Text +"'  ", con);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("No fiels were changed! \nError Updating data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtproductcategory.Focus();
                    return;
                }
            }
            catch (Exception)
            { }
            finally { con.Close(); }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please fill in category field!","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }

            SqlDataAdapter cmd = new SqlDataAdapter("select * from product_category where productcategory ='"+ textBox1.Text +"'", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else { MessageBox.Show("Category not found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please fill in subcategory field!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            SqlDataAdapter cmd = new SqlDataAdapter("select * from product_category where productcategory ='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else { MessageBox.Show("Subcategory not found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            

          
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refreshdatagrid();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                textBox2.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtproductcategory.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtpurchaseunit.Focus();
            }

            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                textBox1.Focus();
            }
        }
    }
}
