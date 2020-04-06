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
    public partial class Addnewproduct : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Brother_motors;Integrated Security=True");

        public Addnewproduct()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public void ProductCode()
        {
            Random rnd = new Random();
            int prodNum = rnd.Next(1000, 9999);
            txtProductCode.Text = "P-" + prodNum.ToString();
        }

        public void count()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from add_new_product", con);
            int ns = (int)cmd.ExecuteScalar();
            cmd = null;
            con.Close();

            int nss = ns + 1;

            SqlDataAdapter cmdd = new SqlDataAdapter("", con);

            //txtreg.Text = DateTime.Now.Year.ToString() + "/0" + nss.ToString();

        }

        private void Addnewproduct_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "images files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picProductImg.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnRemoveImg_Click(object sender, EventArgs e)
        {
            picProductImg.Image = null;
        }

        private void btnAddImgList_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveImgList_Click(object sender, EventArgs e)
        {

        }

        private void lstProductImgList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void clearFields()
        {

            txtProductName1.Clear();
            txtProductName2.Clear();
            txtCode.Clear();
            cmbCategory.SelectedItem = null;
            cmbSubCategory.SelectedItem = null;
            txtDescription.Clear();
            txtPurchase.Clear();
            txtDiscount.Clear();
            txtSalesRate.Clear();
            txtReorderPoint.Clear();
            txtOpeningStock.Clear();
            txtBarcode.Clear();
            cmbPurchaseUnit.SelectedItem = null;
            cmbSalesUnit.SelectedItem = null;
            picProductImg.Image = null;
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            clearFields();
            txtProductCode.Focus();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Saveitems();
        }


        public void Saveitems()
        {
            if (txtProductCode.Text == "")
            {
                MessageBox.Show("Please Generate Product Code", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductCode.Focus();
                return;
            }

            if (txtProductName1.Text == "")
            {
                MessageBox.Show("Product Name 1 is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductName1.Focus();
                return;
            }

            if (txtProductName2.Text == "")
            {
                MessageBox.Show("Product Name 2 is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductName2.Focus();
                return;
            }

            if (txtCode.Text == "")
            {
                MessageBox.Show("Product Code is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
                return;
            }

            if (cmbCategory.Text == "")
            {
                MessageBox.Show("Product  Category is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCategory.Focus();
                return;
            }

            if (cmbSubCategory.Text == "")
            {
                MessageBox.Show("Product  Sub-Category is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSubCategory.Focus();
                return;
            }

            if (txtDescription.Text == "")
            {
                MessageBox.Show("Product Description is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescription.Focus();
                return;
            }

            if (txtPurchase.Text == "")
            {
                MessageBox.Show("Purchase Rate is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPurchase.Focus();
                return;
            }

            if (txtDiscount.Text == "")
            {
                MessageBox.Show("Discount is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiscount.Focus();
                return;
            }

            if (txtSalesRate.Text == "")
            {
                MessageBox.Show("Sales Rate is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSalesRate.Focus();
                return;
            }

            if (txtReorderPoint.Text == "")
            {
                MessageBox.Show("Reorder's Point is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReorderPoint.Focus();
                return;
            }

            if (txtOpeningStock.Text == "")
            {
                MessageBox.Show("Opening STock is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOpeningStock.Focus();
                return;
            }

            if (txtBarcode.Text == "")
            {
                MessageBox.Show("Barcode is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBarcode.Focus();
                return;
            }

            if (cmbPurchaseUnit.Text == "")
            {
                MessageBox.Show("Please select a Purchase Unit!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbPurchaseUnit.Focus();
                return;
            }

            if (cmbSalesUnit.Text == "")
            {
                MessageBox.Show("Please select a Sales Unit Unit!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSalesUnit.Focus();
                return;
            }

            if (picProductImg.Image == null)
            {
                MessageBox.Show("Please select an Image!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowse.Focus();
                return;
            }
            try
            {
                con.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("select product_code from add_new_product where product_code = ''" + txtProductCode.Text + "", con);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Product Code already founded!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProductCode.Clear(); txtProductCode.Focus(); return;
                }
            }
            catch (Exception) { }
            finally { con.Close(); }

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into add_new_product values('" + txtProductCode.Text + "','" + txtProductName1.Text + "','" + txtProductName2.Text + "','" + txtCode.Text + "','" + cmbCategory.Text + "','" + cmbSubCategory.Text + "','" + txtDescription.Text + "','" + txtPurchase.Text + "','" + txtDiscount.Text + "','" + txtSalesRate.Text + "','" + txtReorderPoint.Text + "','" + txtOpeningStock.Text + "','" + txtBarcode.Text + "','" + cmbPurchaseUnit.Text + "','" + cmbSalesUnit.Text + "',@image)", con);
                MemoryStream ms = new MemoryStream();
                picProductImg.Image.Save(ms, picProductImg.Image.RawFormat);
                cmd.Parameters.Add("@image", SqlDbType.Image).Value = ms.ToArray();
                cmd.ExecuteNonQuery(); con.Close(); MessageBox.Show("Product Sucessfully Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) { }
            finally { con.Close(); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProductCode.Text == "")
            {
                MessageBox.Show("Please Generate Product Code", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductCode.Focus();
                return;
            }

            if (txtProductName1.Text == "")
            {
                MessageBox.Show("Product Name 1 is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductName1.Focus();
                return;
            }

            if (txtProductName2.Text == "")
            {
                MessageBox.Show("Product Name 2 is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductName2.Focus();
                return;
            }

            if (txtCode.Text == "")
            {
                MessageBox.Show("Product Code is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
                return;
            }

            if (cmbCategory.Text == "")
            {
                MessageBox.Show("Product  Category is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCategory.Focus();
                return;
            }

            if (cmbSubCategory.Text == "")
            {
                MessageBox.Show("Product  Sub-Category is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSubCategory.Focus();
                return;
            }

            if (txtDescription.Text == "")
            {
                MessageBox.Show("Product Description is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescription.Focus();
                return;
            }

            if (txtPurchase.Text == "")
            {
                MessageBox.Show("Purchase Rate is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPurchase.Focus();
                return;
            }

            if (txtDiscount.Text == "")
            {
                MessageBox.Show("Discount is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiscount.Focus();
                return;
            }

            if (txtSalesRate.Text == "")
            {
                MessageBox.Show("Sales Rate is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSalesRate.Focus();
                return;
            }

            if (txtReorderPoint.Text == "")
            {
                MessageBox.Show("Reorder's Point is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReorderPoint.Focus();
                return;
            }

            if (txtOpeningStock.Text == "")
            {
                MessageBox.Show("Opening STock is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOpeningStock.Focus();
                return;
            }

            if (txtBarcode.Text == "")
            {
                MessageBox.Show("Barcode is required!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBarcode.Focus();
                return;
            }

            if (cmbPurchaseUnit.Text == "")
            {
                MessageBox.Show("Please select a Purchase Unit!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbPurchaseUnit.Focus();
                return;
            }

            if (cmbSalesUnit.Text == "")
            {
                MessageBox.Show("Please select a Sales Unit Unit!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSalesUnit.Focus();
                return;
            }

            if (picProductImg.Image == null)
            {
                MessageBox.Show("Please select an Image!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowse.Focus();
                return;
            }

            try   //checks if product code is valid
            {
                con.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("select product_code from add_new_product where product_code = ''" + txtProductCode.Text + "", con);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Product Code not founded!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProductCode.Clear(); txtProductCode.Focus(); return;
                }
            }
            catch (Exception) { }
            finally { con.Close(); }

            try  //makes sure there is changed between textboxes
            {
                con.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("select * from add_new_product where product_code = ''" + txtProductCode.Text + "", con);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("No Fields were changed! \nError Updating Data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProductCode.Clear(); txtProductCode.Focus(); return;
                }
            }
            catch (Exception) { }
            finally { con.Close(); }

            try  //updates when validations are false
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update into add_new_product set product_name_1 ='" + txtProductName1.Text + "', product_name_2 = '" + txtProductName2.Text + "', code = '" + txtCode.Text + "', category = '" + cmbCategory.Text + "', subcategory = '" + cmbSubCategory.Text + "', description'" + txtDescription.Text + "', purchase_rate'" + txtPurchase.Text + "', discount = '" + txtDiscount.Text + "', sales_rate'" + txtSalesRate.Text + "', reorder_point'" + txtReorderPoint.Text + "', opening_stock = '" + txtOpeningStock.Text + "', barcode = '" + txtBarcode.Text + "', purchase_unit = '" + cmbPurchaseUnit.Text + "', sales_unit = '" + cmbSalesUnit.Text + "',image = @image)", con);
                MemoryStream ms = new MemoryStream();
                picProductImg.Image.Save(ms, picProductImg.Image.RawFormat);
                cmd.Parameters.Add("@image", SqlDbType.Image).Value = ms.ToArray(); cmd.ExecuteNonQuery(); con.Close(); MessageBox.Show("Successfully Updated", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) { }
            finally { con.Close(); }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtProductCode.Text == "")
            {
                MessageBox.Show("Please Generate Product Code", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductCode.Focus();
                return;
            }

            try
            {
                con.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("select product_code from add_new_product where product_code = ''" + txtProductCode.Text + "", con);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Product Code not founded!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProductCode.Clear(); txtProductCode.Focus(); return;
                }
            }
            catch (Exception) { }
            finally { con.Close(); }

            try
            {
                DialogResult result1 = MessageBox.Show("Are you sure you want to delete products of this product code?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from add_new_product where product_code = '" + txtProductCode.Text + "'", con);
                    cmd.ExecuteNonQuery(); con.Close(); MessageBox.Show("Products deleted successfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception) { }
            finally { con.Close(); }

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (txtProductCode.Text == string.Empty)
            {
                MessageBox.Show("Please Input Product Code!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                con.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("select * from add_new_product where product_code =  '" + txtProductCode.Text + "' ", con);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Product Code not found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProductCode.Focus();
                    return;
                }
                con.Close();
            }
            catch (Exception)
            { }
            finally { con.Close(); }

            try
            {
                con.Open();
                SqlCommand cmdd = new SqlCommand("select * from add_new_product where product_code = '" + txtProductCode.Text + "'", con);
                SqlDataReader dtt = cmdd.ExecuteReader();
                while (dtt.Read())
                {
                    txtProductName1.Text = dtt.GetValue(2).ToString();
                    txtProductName2.Text = dtt.GetValue(3).ToString();
                    txtCode.Text = dtt.GetValue(4).ToString();
                    cmbCategory.Text = dtt.GetValue(5).ToString();
                    cmbSubCategory.Text = dtt.GetValue(6).ToString();
                    txtDescription.Text = dtt.GetValue(7).ToString();
                    txtPurchase.Text = dtt.GetValue(8).ToString();
                    txtDiscount.Text = dtt.GetValue(10).ToString();
                    txtSalesRate.Text = dtt.GetValue(11).ToString();
                    txtReorderPoint.Text = dtt.GetValue(12).ToString();
                    txtOpeningStock.Text = dtt.GetValue(13).ToString();
                    txtBarcode.Text = dtt.GetValue(14).ToString();
                    cmbPurchaseUnit.Text = dtt.GetValue(15).ToString();
                    cmbSalesUnit.Text = dtt.GetValue(16).ToString();

                }
                con.Close();

                MemoryStream stream = new MemoryStream();
                con.Open();
                SqlCommand command = new SqlCommand("select image from add_new_product where product_code = '" + txtProductCode.Text + "'", con);
                byte[] img = (byte[])command.ExecuteScalar();
                stream.Write(img, 0, img.Length);
                con.Close();
                Bitmap bitmap = new Bitmap(stream);
                picProductImg.Image = bitmap;
            }
            catch { }
            finally { con.Close(); }
        }


        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            paImportExcel.Visible = true;
            paImportExcel.Location = new Point(33, 83);
            paImportExcel.Size = new Size(701, 382);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            this.MaximumSize = MaximumSize;
            this.MinimumSize = MinimumSize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //using C# code..Import Excel File in using open file dialog and save Excel sheet name in combo box...
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Title = "Select file";
                openDialog.InitialDirectory = @"c:\";
                openDialog.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
                openDialog.FilterIndex = 1;
                openDialog.RestoreDirectory = true;
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openDialog.FileName != "")
                    {
                        txtfilename.Text = openDialog.FileName;
                        //cmbExcelSheet.DataSource = GetSheetNames(openDialog.FileName);
                    }
                    else
                    {
                        MessageBox.Show("chose Excel sheet path..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(txtfilename.Text))
            {

            }
            else
            {
                MessageBox.Show("No File is Selected");
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            paImportExcel.Visible = false;
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtfilename.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtProductName1.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                btnGenerate.Focus();
            }
        }

        private void txtProductName1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtProductName2.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtProductCode.Focus();
            }
        }

        private void txtProductName2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtCode.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtProductName1.Focus();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                cmbCategory.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtProductName2.Focus();
            }
        }

        private void cmbCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                cmbSubCategory.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtCode.Focus();
            }
        }

        private void cmbSubCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtDescription.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                cmbCategory.Focus();
            }
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtPurchase.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                cmbSubCategory.Focus();
            }
        }

        private void txtPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtSalesRate.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtDescription.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtDiscount.Focus();
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtVAT.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtDescription.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtPurchase.Focus();
            }
        }

        private void txtSalesRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtReorderPoint.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtPurchase.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                txtVAT.Focus();
            }
        }

        private void txtVAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                cmbSalesUnit.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtDiscount.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                txtSalesRate.Focus();
            }
        }

        private void txtReorderPoint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtOpeningStock.Focus();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtSalesRate.Focus();
            }
        }

        private void txtOpeningStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtReorderPoint.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                txtBarcode.Focus();
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtOpeningStock.Focus();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                cmbPurchaseUnit.Focus();
            }
        }

        private void cmbPurchaseUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtBarcode.Focus();
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                e.Handled = true;
                cmbSalesUnit.Focus();
            }
        }

        private void cmbSalesUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                txtVAT.Focus();
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                e.Handled = true;
                cmbPurchaseUnit.Focus();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ProductCode();
        }


        private void Addnewproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && (e.Alt || e.Control || e.Shift))
            {
                Saveitems();
            }
            if (e.KeyCode == Keys.F1 && (e.Alt || e.Control || e.Shift))
            {
                ProductCode();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //retreives product category column into category combo box
            try
            {
                con.Open();
                SqlDataAdapter cmdd = new SqlDataAdapter("select distinct productcategory from product_category", con);
                DataTable dtt = new DataTable();
                cmdd.Fill(dtt);
                foreach (DataRow row in dtt.Rows)
                {
                    if (cmbCategory.Items.Contains(row["productcategory"].ToString()))
                    {

                    }
                    else
                    {
                        cmbCategory.Items.Add(row["productcategory"].ToString());
                    }
                }

            }
            catch (Exception) { }
            finally { con.Close(); }
        }

        private void cmbCategory_TextChanged(object sender, EventArgs e)
        {
            cmbSubCategory.SelectedItem = null;
            cmbSubCategory.Items.Clear();
            try
            {

                SqlDataAdapter cmdd = new SqlDataAdapter("select distinct * from product_category where productcategory = '" + cmbCategory.Text + "'", con);
                DataTable dtt = new DataTable();
                cmdd.Fill(dtt);
                foreach (DataRow row in dtt.Rows)
                {
                    if (cmbSubCategory.Items.Contains(row["productsubcategory"].ToString())) //populates subcategory
                    { }
                    else
                    {
                        cmbSubCategory.Items.Add(row["productsubcategory"].ToString());
                    }

                }

            }
            catch (Exception) { }

        }

        private void cmbSubCategory_TextChanged(object sender, EventArgs e)
        {
            cmbPurchaseUnit.SelectedItem = null;
            cmbSalesUnit.SelectedItem = null;
            cmbPurchaseUnit.Items.Clear();
            cmbSalesUnit.Items.Clear();
            try
            {

                SqlDataAdapter cmdd = new SqlDataAdapter("select distinct productpurchaseunit,productsalesunit  from product_category where productsubcategory = '" + cmbSubCategory.Text + "'", con);
                DataTable dtt = new DataTable();
                cmdd.Fill(dtt);
                foreach (DataRow row in dtt.Rows)
                {
                    if (cmbPurchaseUnit.Items.Contains(row["productpurchaseunit"].ToString()))  //populates product purchase unit
                    { }
                    else
                    {
                        cmbPurchaseUnit.Items.Add(row["productpurchaseunit"].ToString());
                    }

                    if (cmbSalesUnit.Items.Contains(row["productsalesunit"].ToString()))  //populates product sales unit
                    { }
                    else
                    {
                        cmbSalesUnit.Items.Add(row["productsalesunit"].ToString());
                    }
                }
            }
            catch { }
        }

        private void cmbCategory_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Items.Contains(cb.Text) && cb.Text != "") { MessageBox.Show("Property not valid!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbCategory.Text = string.Empty; cmbCategory.Focus(); }
        }

        private void cmbSubCategory_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Items.Contains(cb.Text) && cb.Text != "") { MessageBox.Show("Property not valid!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbSubCategory.Text = string.Empty; cmbSubCategory.Focus(); }
        }

        private void cmbPurchaseUnit_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Items.Contains(cb.Text) && cb.Text != "") { MessageBox.Show("Property not valid!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbPurchaseUnit.Text = string.Empty; cmbPurchaseUnit.Focus(); }
        }

        private void cmbSalesUnit_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Items.Contains(cb.Text) && cb.Text != "") { MessageBox.Show("Property not valid!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbSalesUnit.Text = string.Empty; cmbSalesUnit.Focus(); }
        }
    }
}
