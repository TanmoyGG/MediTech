using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MediTech.Controller;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;
using MediTech.Model;

namespace MediTech.AdministratorUC
{
    public partial class UcViewUser : UserControl
    {
        public UcViewUser()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void UcViewUser_Load(object sender, EventArgs e)
        {
            //for admin
            IAdminDAO adminDao = new AdminDaoImpl();
            AdminController adminController = new AdminController(adminDao);
            IEnumerable<Admin> allAdmins = adminController.GetAllAdmins();
            guna2DataGridView1.AutoGenerateColumns = true;
            guna2DataGridView1.DataSource = allAdmins.ToList();
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            
            //for pharmacist
            IChemistDAO chemistDao = new ChemistDaoImpl();
            ChemistController chemistController = new ChemistController(chemistDao);
            IEnumerable<Chemist> allChemists = chemistController.GetAllChemists();
            guna2DataGridView2.AutoGenerateColumns = true;
            guna2DataGridView2.DataSource = allChemists.ToList();
            guna2DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                int selectedrowindex = guna2DataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[selectedrowindex];
                int id = Convert.ToInt32(selectedRow.Cells["A_Id"].Value);
                IAdminDAO adminDao = new AdminDaoImpl();
                AdminController adminController = new AdminController(adminDao);
                adminController.RemoveAdmin(id);
                UcViewUser_Load(sender, e);
            }
            else
            {
                MessageBox.Show(@"Please select a row to delete.");
            }

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}