using System;
using System.Windows.Forms;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;
using MediTech.Model;

namespace MediTech.AdministratorUC
{
    public partial class UcPharmacists : UserControl
    {
        public UcPharmacists()
        {
            InitializeComponent();
        }

        private void UcPharmacists_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        
        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtName.Clear();
            txtDOB.Clear();
            txtMobileNo.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }


        private void txtDOB_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                IChemistDAO chemistDao = new ChemistDaoImpl();
                ChemistController chemistController = new ChemistController(chemistDao);
                
                Chemist ch = chemistController.GetChemistByCriteria(txtSearch.Text, null, txtName.Text, txtEmail.Text, txtMobileNo.Text);
                if (ch != null)
                {
                    labelUserName.Text = ch.P_UserName;
                    labelUserID.Text = ch.P_Id.ToString();
                    txtName.Text = ch.P_Name;
                    txtDOB.Text = ch.P_Dob.ToString();
                    txtMobileNo.Text = ch.P_MobileNo;
                    txtEmail.Text = ch.P_Email;
                    txtPassword.Text = ch.P_Password;
                }
                else
                {
                    MessageBox.Show("No pharmacist found!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Searching criteria invalid!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                IChemistDAO chemistDao = new ChemistDaoImpl();
                ChemistController chemistController = new ChemistController(chemistDao);
                Chemist ch = new Chemist
                {
                    P_Id = int.Parse(labelUserID.Text),
                    P_Name = txtName.Text,
                    P_Dob = DateTime.Parse(txtDOB.Text),
                    P_MobileNo = txtMobileNo.Text,
                    P_Email = txtEmail.Text,
                    P_UserName = labelUserName.Text,
                    P_Password = txtPassword.Text
                };
                chemistController.UpdateChemist(ch);
                MessageBox.Show("Pharmacist updated successfully!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Pharmacist update failed!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}