using System;
using System.Windows.Forms;
using MediTech.Controller;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;

namespace MediTech.AdministratorUC
{
    public partial class UcDashboard : UserControl
    {
        public UcDashboard()
        {
            InitializeComponent();
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            btnReload.PerformClick();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void labelPharmacist_Click(object sender, EventArgs e)
        {
        }

        private void labelAdmin_Click(object sender, EventArgs e)
        {
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            IAdminDAO adminDao = new AdminDaoImpl();
            var adminController = new AdminController(adminDao);
            labelAdmin.Text = adminController.DisplayTotalAdmins().ToString();

            IChemistDAO chemistDao = new ChemistDaoImpl();
            var chemistController = new ChemistController(chemistDao);
            labelPharmacist.Text = chemistController.DisplayTotalPharmacists().ToString();
        }
    }
}