using DGVPrinterHelper;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;
using MediTech.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MediTech.PharmacistUC
{
    public partial class UC_P_SellMedicine : UserControl
    {
        public UC_P_SellMedicine()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UC_P_SellMedicine_Load(object sender, EventArgs e)
        {
            loadValidMedicine();
        }

        private void loadValidMedicine()
        {
            try
            {
                listBox1.Items.Clear();
                IMedicineDAO medicineDao = new MedicineDAOImpl();
                MedicineController medicineController = new MedicineController(medicineDao);

                var medicines = medicineController.GetValidMedicines();
                foreach (Medicine m in medicines)
                {
                    listBox1.Items.Add(m.M_Name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loading medicine: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                txtPricePerUnit.Clear();

                string selectedMedicine = listBox1.GetItemText(listBox1.SelectedItem);
                IMedicineDAO medicineDao = new MedicineDAOImpl();
                MedicineController medicineController = new MedicineController(medicineDao);
                Medicine medicine = medicineController.GetMedicineByName(selectedMedicine);

                txtMediID.Text = medicine.M_Id.ToString();
                txtMediName.Text = medicine.M_Name;
                txtPricePerUnit.Text = medicine.Price.ToString();
                txtMediExpDate.Text = medicine.ExpDate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loading medicine details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadValidMedicine();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
        }

        private void txtNoOfUnit_TextChanged(object sender, EventArgs e)
        {
            calculateTotalPrice();
        }

        private void calculateTotalPrice()
        {
            try
            {
                if (txtPricePerUnit.Text != "" && txtNoOfUnit.Text != "")
                {
                    decimal pricePerUnit = decimal.Parse(txtPricePerUnit.Text);
                    int noOfUnit = int.Parse(txtNoOfUnit.Text);
                    decimal totalPrice = pricePerUnit * noOfUnit;
                    txtTotalPrice.Text = totalPrice.ToString();
                }
                else
                {
                    txtTotalPrice.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in calculating total price: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            addToCart();
        }

        double valueAmount;
        int valueId;
        int noOfUnit;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                valueAmount = double.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                valueId = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                noOfUnit = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
        }

        protected int n, totalAmount = 0;
        protected Int64 quantity, newQuantity;

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (valueId != 0)
            {
                try
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                }
                catch (Exception)
                {
                }
                finally
                {
                    IMedicineDAO medicineDao = new MedicineDAOImpl();
                    MedicineController medicineController = new MedicineController(medicineDao);
                    Medicine selectedMedicine = medicineController.GetMedicineById(valueId);

                    selectedMedicine.Quantity += noOfUnit;
                    medicineController.UpdateMedicine(selectedMedicine);
                    labelPrice.Text = "Tk " + (double.Parse(labelPrice.Text.Replace("Tk ", "")) - valueAmount).ToString();
                }
            }
            else
            {
                MessageBox.Show("Row not selected!");
            }
        }

        private void btnSellAndPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Medicine Bill from MediTech Pharma";
            print.SubTitle = String.Format("Date: {0:yyyy-MM-dd} Time: {1:hh\\:mm}", DateTime.Now, DateTime.Now.TimeOfDay + "\nTotal Payable Amount : " + labelPrice.Text);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Software created by Homo Sapiens";
            print.FooterSpacing = 15;
            print.PrintDataGridView(guna2DataGridView1);

            // Database insertion in sales report table
            try
            {
                SalesReportController salesReportController = new SalesReportController(new SalesReportDAOImpl());
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    if (row.Cells["Column1"].Value != null && row.Cells["Column2"].Value != null &&
                        row.Cells["Column6"].Value != null && row.Cells["Column5"].Value != null)
                    {
                        SalesReport salesReport = new SalesReport
                        {
                            M_Id = Convert.ToInt32(row.Cells["Column1"].Value),
                            M_Name = row.Cells["Column2"].Value.ToString(),
                            Price = Convert.ToDecimal(row.Cells["Column6"].Value),
                            P_Name = globalVariable.ChemistLogin.P_Name, 
                            Quantity = Convert.ToInt32(row.Cells["Column5"].Value),
                            ReportDateTime = DateTime.Now
                        };

                        salesReportController.AddSalesReport(salesReport);
                    }
                }

                MessageBox.Show("Sales report successfully added to the database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving sales report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            totalAmount = 0;
            labelPrice.Text = "Tk 0";
            guna2DataGridView1.Rows.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            IMedicineDAO medicineDao = new MedicineDAOImpl();
            MedicineController medicineController = new MedicineController(medicineDao);
            
            var filteredMedicines = medicineController.GetValidMedicineByPartialCriteria(txtSearch.Text);

            listBox1.Items.Clear();

            foreach (var medicine in filteredMedicines)
            {
                listBox1.Items.Add(medicine.M_Name);
            }

        }

        private void addToCart()
        {
            try
            {

                if (string.IsNullOrEmpty(txtMediID.Text) )
                {
                    MessageBox.Show("Please select a medicine first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtNoOfUnit.Text, out int enteredQuantity) || enteredQuantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                IMedicineDAO medicineDao = new MedicineDAOImpl();
                MedicineController medicineController = new MedicineController(medicineDao);
                Medicine selectedMedicine = medicineController.GetMedicineById(int.Parse(txtMediID.Text));

                if (selectedMedicine == null)
                {
                    MessageBox.Show("Medicine not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedMedicine.Quantity < enteredQuantity)
                {
                    MessageBox.Show("Not enough stock available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update stock and add to the grid
                selectedMedicine.Quantity -= enteredQuantity;
                medicineController.UpdateMedicine(selectedMedicine);

                n = guna2DataGridView1.Rows.Add();
                guna2DataGridView1.Rows[n].Cells[0].Value = selectedMedicine.M_Id;
                guna2DataGridView1.Rows[n].Cells[1].Value = selectedMedicine.M_Name;
                guna2DataGridView1.Rows[n].Cells[2].Value = selectedMedicine.ExpDate.ToString("yyyy-MM-dd");
                guna2DataGridView1.Rows[n].Cells[3].Value = selectedMedicine.Price;
                guna2DataGridView1.Rows[n].Cells[4].Value = enteredQuantity;
                guna2DataGridView1.Rows[n].Cells[5].Value = (selectedMedicine.Price * enteredQuantity).ToString();

                // Update total amount
                totalAmount += (int)(selectedMedicine.Price * enteredQuantity);
                labelPrice.Text = $"Tk {totalAmount}";

                MessageBox.Show("Added to cart successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadValidMedicine();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cleartxt();
        }
        private void Cleartxt()
        {
            txtMediID.Clear();
            txtMediName.Clear();
            txtMediExpDate.ResetText();
            txtPricePerUnit.Clear();
            txtNoOfUnit.Clear();
            txtTotalPrice.Clear();
        }
    }
}