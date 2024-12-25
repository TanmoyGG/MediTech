using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediTech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            if (txtUserName.Text == "admin" && txtPasword.Text == "admin")
            {
                Adminstrator a = new Adminstrator();
                a.Show();
                this.Hide();
            }
            else if (txtUserName.Text == "pharmacist" && txtPasword.Text == "pharmacist")
            {
                Pharmacist p = new Pharmacist();
                p.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
