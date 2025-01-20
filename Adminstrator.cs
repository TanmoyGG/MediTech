using System;
using System.Windows.Forms;
using MediTech.Model;

namespace MediTech
{
    public partial class Adminstrator : Form
    {
        
        public Adminstrator()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            globalVariable.AdminLogin = null;
            globalVariable.ChemistLogin = null;
            var fm = new Form1();
            fm.Show();
            Hide();
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = true;
            uC_Dashboard1.BringToFront();
        }

        private void Adminstrator_Load(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = false;
            uC_AddUser1.Visible = false;
            uC_ViewUser1.Visible = false;
            uC_Profile1.Visible = false;
            uC_SalesReport1.Visible = false;
            ucPharmacists1.Visible = false;
            uC_P_ViewMedicine1.Visible = false;
            btnDashBoard.PerformClick();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            uC_AddUser1.Visible = true;
            uC_AddUser1.BringToFront();
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            uC_ViewUser1.Visible = true;
            uC_ViewUser1.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            uC_SalesReport1.Visible = true;
            uC_SalesReport1.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            uC_Profile1.Visible = true;
            uC_Profile1.BringToFront();
        }

        private void btnPharmacist_Click(object sender, EventArgs e)
        {
            ucPharmacists1.Visible = true;
            ucPharmacists1.BringToFront();
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            uC_P_ViewMedicine1.Visible = true;
            uC_P_ViewMedicine1.BringToFront();
        }
    }
}