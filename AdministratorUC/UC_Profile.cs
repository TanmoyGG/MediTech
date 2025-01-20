using System;
using System.Windows.Forms;
using MediTech.Controller;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;
using MediTech.Model;

namespace MediTech.AdministratorUC
{
    public partial class UcProfile : UserControl
    {
        public UcProfile()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void UC_Profile_Load(object sender, EventArgs e)
        {
            if (globalVariable.AdminLogin != null)
            {
                txtUserRole.Text = "Admin";
                txtName.Text = globalVariable.AdminLogin.A_Name;
                txtDOB.Value = globalVariable.AdminLogin.A_Dob;
                txtMobileNo.Text = globalVariable.AdminLogin.A_MobileNo;
                txtEmail.Text = globalVariable.AdminLogin.A_Email;
                txtPassword.Text = globalVariable.AdminLogin.A_Password;
            }
            else
            {
                txtUserRole.Text = "Chemist";
                txtName.Text = globalVariable.ChemistLogin.P_Name;
                txtDOB.Value = globalVariable.ChemistLogin.P_Dob;
                txtMobileNo.Text = globalVariable.ChemistLogin.P_MobileNo;
                txtEmail.Text = globalVariable.ChemistLogin.P_Email;
                txtPassword.Text = globalVariable.ChemistLogin.P_Password;
            }
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserRole.Clear();
            txtName.Clear();
            txtDOB.Value = DateTime.Now;
            txtMobileNo.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserRole_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}