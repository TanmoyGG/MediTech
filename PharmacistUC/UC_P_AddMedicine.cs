using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;
using MediTech.Model;

namespace MediTech.PharmacistUC
{
    public partial class UC_P_AddMedicine : UserControl
    {
        public UC_P_AddMedicine()
        {
            InitializeComponent();
        }

        private void txtMGroupName_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any field is empty
                if (string.IsNullOrWhiteSpace(txtMName.Text) ||
                    string.IsNullOrWhiteSpace(txtMGroupName.Text) ||
                    string.IsNullOrWhiteSpace(txtMType.Text) ||
                    string.IsNullOrWhiteSpace(txtPricePerUnit.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    MessageBox.Show("Please fill all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Medicine Name (No special characters except dot (.) and comma (,))
                if (!Regex.IsMatch(txtMName.Text, @"^[a-zA-Z.,\s]+$"))
                {
                    MessageBox.Show("Medicine name can only contain letters, spaces, dot (.), and comma (,).",
                        "Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Medicine Group Name (No special characters except dot (.) and comma (,))
                if (!Regex.IsMatch(txtMGroupName.Text, @"^[a-zA-Z.,\s]+$"))
                {
                    MessageBox.Show("Medicine group name can only contain letters, spaces, dot (.), and comma (,).",
                        "Group Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Price (Must be a valid decimal number)
                if (!decimal.TryParse(txtPricePerUnit.Text, out var price) || price <= 0)
                {
                    MessageBox.Show("Please enter a valid price greater than 0.", "Price Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Quantity (Must be a valid integer greater than 0)
                if (!int.TryParse(txtQuantity.Text, out var quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity greater than 0.", "Quantity Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Proceed with adding the medicine
                IMedicineDAO medicineDao = new MedicineDAOImpl();
                var medicineController = new MedicineController(medicineDao);

                var medicine = new Medicine
                {
                    M_Name = txtMName.Text,
                    M_GroupName = txtMGroupName.Text,
                    M_Type = txtMType.Text,
                    ManuDate = txtManuDate.Value,
                    ExpDate = txtExpDate.Value,
                    Price = price,
                    Quantity = quantity
                };

                medicineController.InsertMedicine(medicine);
                MessageBox.Show("Medicine Added Successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btnReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add medicine! Error: {ex.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMName.Clear();
            txtMGroupName.Clear();
            txtMType.SelectedIndex = -1;
            txtManuDate.ResetText();
            txtExpDate.ResetText();
            txtPricePerUnit.Clear();
            txtQuantity.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}