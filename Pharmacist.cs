﻿using System.Windows.Forms;

namespace MediTech
{
    public partial class Pharmacist : Form
    {
        public Pharmacist()
        {
            InitializeComponent();
        }

        private void Pharmacist_Load(object sender, System.EventArgs e)
        {
            uC_P_Dashboard1.Visible = false;
            btnDashboard.PerformClick();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private void btnAddMedicine_Click(object sender, System.EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, System.EventArgs e)
        {
            var fm = new Form1();
            fm.Show();
            Hide();
        }

        private void btnSellMedicine_Click(object sender, System.EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, System.EventArgs e)
        {
            uC_P_Dashboard1.Visible = true;
            uC_P_Dashboard1.BringToFront();
        }
    }
}