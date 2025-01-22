using System;
using System.Windows.Forms;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;

namespace MediTech.PharmacistUC
{
    public partial class UC_P_ModifyMedicine : UserControl
    {
        public UC_P_ModifyMedicine()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                IMedicineDAO medicineDao = new MedicineDAOImpl();
                var meidinceController = new MedicineController(medicineDao);

                var md = meidinceController.GetMedicineById(Convert.ToInt32(txtMediID.Text));
                    
                if (md != null)
                {
                    txtMediID.Text = md.M_Id.ToString();
                    txtMediName.Text = md.M_Name;
                    txtMediGroupName.Text = md.M_GroupName;
                    txtManuDate.Text = md.ManuDate.ToString();
                    txtExpireDate.Text = md.ExpDate.ToString();
                    txtPricePerUnit.Text = md.Price.ToString();
                    txtAvailableQuantity.Text = md.Quantity.ToString();
                }
                else
                {
                    MessageBox.Show("No Medicine Found With This ID!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Searching criteria invalid!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMediID.Clear();
            txtMediName.Clear();
            txtMediGroupName.Clear();
            txtManuDate.Value = DateTime.Now;
            txtExpireDate.Value = DateTime.Now;
            txtPricePerUnit.Clear();
            txtAvailableQuantity.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                IMedicineDAO medicineDao = new MedicineDAOImpl();
                var meidinceController = new MedicineController(medicineDao);

                var md = meidinceController.GetMedicineById(Convert.ToInt32(txtMediID.Text));
                
                    md.M_Name = txtMediName.Text;
                    md.M_GroupName = txtMediGroupName.Text;
                    md.ManuDate = DateTime.Parse(txtManuDate.Text);
                    md.ExpDate = DateTime.Parse(txtExpireDate.Text);
                    md.Price = decimal.Parse(txtPricePerUnit.Text);
                    if(txtAddQuantity.Text != "0")
                    {
                        md.Quantity += int.Parse(txtAddQuantity.Text);
                    }
                    else
                    {
                        txtAddQuantity.ResetText();
                    }
                    meidinceController.UpdateMedicine(md);
                    MessageBox.Show("Medicine Updated Successfully!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSearch.PerformClick();
                    
            }
            catch (Exception exception)
            {
                MessageBox.Show("Update Failed!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}