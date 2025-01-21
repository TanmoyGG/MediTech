using System;
using System.Text.RegularExpressions;
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
            labelUserName.Text = " UserName";
            labelUserID.Text = " UserID";
            txtSearch.Clear();
            txtName.Clear();
            txtDOB.Value = DateTime.Now;
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
                var chemistController = new ChemistController(chemistDao);

                var ch = chemistController.GetChemistByCriteria(txtSearch.Text, null, txtName.Text, txtEmail.Text,
                    txtMobileNo.Text);
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
                // Check if any field is empty
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtMobileNo.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
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
                        "Mobile Number Error",
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
                IChemistDAO chemistDao = new ChemistDaoImpl();
                var chemistController = new ChemistController(chemistDao);

                var ch = new Chemist
                {
                    P_Id = int.Parse(labelUserID.Text),
                    P_Name = txtName.Text,
                    P_Dob = DateTime.Parse(txtDOB.Text),
                    P_MobileNo = txtMobileNo.Text,
                    P_Email = txtEmail.Text,
                    P_Password = txtPassword.Text
                };

                chemistController.UpdateChemist(ch);
                MessageBox.Show("Pharmacist updated successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Pharmacist update failed! Error: {ex.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}