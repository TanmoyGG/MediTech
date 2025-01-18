using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MediTech.Controller;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;
using MediTech.Model;

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
            txtDOB.Value = DateTime.Now;
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
            try
            {
                // Check if any field is empty
                if (string.IsNullOrWhiteSpace(txtUserRole.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtMobileNo.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please fill all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Name (No special characters except dot (.) and comma (,))
                if (!Regex.IsMatch(txtName.Text, @"^[a-zA-Z.,\s]+$"))
                {
                    MessageBox.Show("Name can only contain letters, spaces, dot (.), and comma (,).", "Name Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Mobile Number (Must start with 01 and have exactly 11 digits)
                if (!Regex.IsMatch(txtMobileNo.Text, @"^01\d{9}$"))
                {
                    MessageBox.Show("Mobile number must start with '01' and have exactly 11 digits.", "Mobile Number Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Email Address
                if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Please enter a valid email address.", "Email Address Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Validate Username (Only lowercase letters and numbers, no special characters)
                if (!Regex.IsMatch(txtUserName.Text, @"^[a-z0-9]+$"))
                {
                    MessageBox.Show(
                        "Username can only contain lowercase letters and numbers, with no spaces or special characters.","UserName Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Password
                if (!Regex.IsMatch(txtPassword.Text,
                        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
                {
                    MessageBox.Show(
                        "Password must be at least 8 characters long and include at least 1 uppercase letter, 1 lowercase letter, 1 number, and 1 special character.","Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if Username is Unique
                if (!IsUsernameUnique(txtUserName.Text))
                {
                    MessageBox.Show("Username is already taken. Please choose a different username.", "UserName Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Proceed with adding the user
                if (txtUserRole.Text == "Administrator")
                {
                    IAdminDAO adminDao = new AdminDaoImpl();
                    var adminController = new AdminController(adminDao);

                    var admin = new Admin
                    {
                        A_Email = txtEmail.Text,
                        A_Name = txtName.Text,
                        A_Dob = txtDOB.Value,
                        A_MobileNo = txtMobileNo.Text,
                        A_UserName = txtUserName.Text,
                        A_Password = txtPassword.Text
                    };

                    adminController.AddAdmin(admin); // for email sending
                    MessageBox.Show("Admin Added Successfully\nLogin Details sent to Email");
                    btnReset_Click(sender, e);
                }
                else if (txtUserRole.Text == "Pharmacist")
                {
                    IChemistDAO chemistDao = new ChemistDaoImpl();
                    var chemistController = new ChemistController(chemistDao);

                    var chemist = new Chemist
                    {
                        P_Email = txtEmail.Text,
                        P_Name = txtName.Text,
                        P_Dob = txtDOB.Value,
                        P_MobileNo = txtMobileNo.Text,
                        P_UserName = txtUserName.Text,
                        P_Password = txtPassword.Text
                    };

                    chemistController.InsertChemist(chemist); // for email sending
                    MessageBox.Show("Pharmacist Added Successfully\nLogin Details sent to Email");
                    btnReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Invalid User Role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private bool IsUsernameUnique(string text)
        {
            IAdminDAO adminDao = new AdminDaoImpl();
            var adminController = new AdminController(adminDao);

            var chemistController = new ChemistController(new ChemistDaoImpl());

            return adminController.GetAdminByUserName(text) == null &&
                   chemistController.GetChemistByUsername(text) == null;
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