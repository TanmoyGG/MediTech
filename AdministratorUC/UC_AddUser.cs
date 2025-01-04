using System;
using System.Windows.Forms;

namespace MediTech.AdministratorUC
{
    public partial class UcAddUser : UserControl
    {
        public UcAddUser()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserRole.SelectedIndex = -1;
            txtName.Clear();
            txtDOB.ResetText();
            txtMobileNo.Clear();
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void UC_AddUser_Load(object sender, EventArgs e)
        {
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}