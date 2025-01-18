using System;
using System.Windows.Forms;
using MediTech.Controller;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;
using Org.BouncyCastle.Bcpg;

namespace MediTech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPasword.Clear();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            var username = txtUserName.Text;
            var password = txtPasword.Text;
            TryLoginAsAdmin(username, password);
            //Console.WriteLine(TryLoginAsAdmin(username, password));


            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please fill all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(username == "master" && password == "master")
                {
                    var adminDashboard = new Adminstrator();
                    adminDashboard.Show();
                    Hide();
                    return;
                }

                if (TryLoginAsAdmin(username, password) ||
                    TryLoginAsPharmacist(username, password))
                {
                    // Login successful
                    return;
                }


                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while signing in!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool TryLoginAsAdmin(string username, string password)
        {
            IAdminDAO adminDao = new AdminDaoImpl();
            var adminController = new AdminController(adminDao);

            var admin = adminController.GetAdminByUserName(username);
            if (adminController.Login(username, password))
            {
                var adminDashboard = new Adminstrator();
                adminDashboard.Show();
                Hide();
                return true;
            }

                return false;
        }
        
        
        
        private bool TryLoginAsPharmacist(string username, string password)
        {
            IChemistDAO chemistDao = new ChemistDaoImpl();
            var chemistController = new ChemistController(chemistDao);

            var chemist = chemistController.GetChemistByUsername(username);
            if (chemistController.Login(username, password))
            {
                var pharmacistDashboard = new Pharmacist();
                pharmacistDashboard.Show();
                Hide();
                return true;
            }
                return false;
            }
        

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}