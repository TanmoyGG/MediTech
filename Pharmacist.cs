using System;
using System.Windows.Forms;

namespace MediTech
{
    public partial class Pharmacist : Form
    {
        public Pharmacist()
        {
            InitializeComponent();
        }

        private void Pharmacist_Load(object sender, EventArgs e)
        {
            uC_P_Dashboard1.Visible = false;
            uC_P_AddMedicine1.Visible = false;
            uC_P_ViewMedicine1.Visible = false;
            uC_P_SellMedicine1.Visible = false;
            ucProfile1.Visible = false;
            uC_P_ModifyMedicine1.Visible = false;
            btnDashboard.PerformClick();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            uC_P_AddMedicine1.Visible = true;
            uC_P_AddMedicine1.BringToFront();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var fm = new Form1();
            fm.Show();
            Hide();
        }

        private void btnSellMedicine_Click(object sender, EventArgs e)
        {
            uC_P_SellMedicine1.Visible = true;
            uC_P_SellMedicine1.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            uC_P_Dashboard1.Visible = true;
            uC_P_Dashboard1.BringToFront();
        }

        private void btnViewMedicine_Click(object sender, EventArgs e)
        {
            uC_P_ViewMedicine1.Visible = true;
            uC_P_ViewMedicine1.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ucProfile1.Visible = true;
            ucProfile1.BringToFront();
        }

        private void btnModifyMedicine_Click(object sender, EventArgs e)
        {
            uC_P_ModifyMedicine1.Visible = true;
            uC_P_ModifyMedicine1.BringToFront();
        }
    }
}