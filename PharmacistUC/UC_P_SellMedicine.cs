using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;
using MediTech.Model;
using System;
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
    }
}