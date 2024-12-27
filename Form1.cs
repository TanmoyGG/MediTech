using System;
using System.Windows.Forms;

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
            switch (txtUserName.Text)
            {
                case "admin" when txtPasword.Text == "admin":
                {
                    var a = new Adminstrator();
                    a.Show();
                    Hide();
                    break;
                }
                case "pharmacist" when txtPasword.Text == "pharmacist":
                {
                    var p = new Pharmacist();
                    p.Show();
                    Hide();
                    break;
                }
                default:
                    MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
            }
        }
    }
}