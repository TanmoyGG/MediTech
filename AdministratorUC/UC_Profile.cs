using System;
using System.Windows.Forms;

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