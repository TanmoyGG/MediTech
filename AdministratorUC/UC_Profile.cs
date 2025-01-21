using System;
using System.Text.RegularExpressions;
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
                labelUserName.Text = globalVariable.AdminLogin.A_UserName;
                labelUserID.Text = globalVariable.AdminLogin.A_Id.ToString();
                txtName.Text = globalVariable.AdminLogin.A_Name;
                txtDOB.Value = globalVariable.AdminLogin.A_Dob;
                txtMobileNo.Text = globalVariable.AdminLogin.A_MobileNo;
                txtEmail.Text = globalVariable.AdminLogin.A_Email;
                txtPassword.Text = globalVariable.AdminLogin.A_Password;
            }
            else
            {
                txtUserRole.Text = "Pharmacist";
                labelUserName.Text = globalVariable.ChemistLogin.P_UserName;
                labelUserID.Text = globalVariable.ChemistLogin.P_Id.ToString();
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
            try
            {
                // Check if any field is empty
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtMobileNo.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
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
                    MessageBox.Show("Mobile number must start with '01' and have exactly 11 digits.",
                        "Mobile Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Email Address
                if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Please enter a valid email address.", "Email Address Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Validate Password
                if (!Regex.IsMatch(txtPassword.Text,
                        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
                {
                    MessageBox.Show(
                        "Password must be at least 8 characters long and include at least 1 uppercase letter, 1 lowercase letter, 1 number, and 1 special character.",
                        "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Proceed with updating the user
                if (globalVariable.AdminLogin != null)
                {
                    //admin update
                    IAdminDAO adminDao = new AdminDaoImpl();
                    var adminController = new AdminController(adminDao);

                    var admin = new Admin
                    {
                        A_UserName = labelUserName.Text,
                        A_Id = globalVariable.AdminLogin.A_Id,
                        A_Name = txtName.Text,
                        A_Dob = txtDOB.Value,
                        A_MobileNo = txtMobileNo.Text,
                        A_Email = txtEmail.Text,
                        A_Password = txtPassword.Text
                    };

                    adminController.UpdateAdmin(admin);
                    MessageBox.Show("Profile Updated Successfully \n New Login Details Sent To Email", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //chemist update
                    IChemistDAO chemistDao = new ChemistDaoImpl();
                    var chemistController = new ChemistController(chemistDao);

                    var chemist = new Chemist
                    {
                        P_UserName = labelUserName.Text,
                        P_Id = globalVariable.ChemistLogin.P_Id,
                        P_Name = txtName.Text,
                        P_Dob = txtDOB.Value,
                        P_MobileNo = txtMobileNo.Text,
                        P_Email = txtEmail.Text,
                        P_Password = txtPassword.Text
                    };

                    chemistController.UpdateChemist(chemist);
                    MessageBox.Show("Profile Updated Successfully \n New Login Details Sent To Email", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed! Error: {ex.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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