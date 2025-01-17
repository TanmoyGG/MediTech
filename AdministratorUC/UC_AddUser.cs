using System;
using System.Windows.Forms;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;
using MediTech.Model;
using MediTech.OTP;

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
            if (txtUserRole.Text == "" || txtName.Text == "" || txtDOB.Text == "" || txtMobileNo.Text == "" ||
                txtEmail.Text == "" || txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill all the fields!");
            }
            else if (txtUserRole.Text == "Administrator")
            {
                IAdminDAO adminDao = new AdminDAOImpl();
                AdminController adminController = new AdminController(adminDao);
                
                Admin admin = new Admin
                {
                    A_Email = txtEmail.Text,
                    A_Name = txtName.Text,
                    A_Dob = txtDOB.Value,
                    A_MobileNo = txtMobileNo.Text,
                    A_UserName = txtUserName.Text,
                    A_Password = txtPassword.Text
                };
                adminController.AddAdmin(admin);
                
            }
            else if (txtUserRole.Text == "Pharmacist")
            {
                IChemistDAO chemistDao = new ChemistDAOImpl();
                ChemistController chemistController = new ChemistController(chemistDao);

                Chemist chemist = new Chemist
                {
                    P_Email = txtEmail.Text,
                    P_Name = txtName.Text,
                    P_Dob = txtDOB.Value,
                    P_MobileNo = txtMobileNo.Text,
                    P_UserName = txtUserName.Text,
                    P_Password = txtPassword.Text
                };
                chemistController.InsertChemist(chemist);
            }
            else
            {
                MessageBox.Show("Invalid User Role");
            }
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