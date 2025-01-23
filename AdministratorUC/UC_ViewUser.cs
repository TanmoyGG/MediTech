using System;
using System.Linq;
using System.Windows.Forms;
using MediTech.Controller;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;

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
            //for admin
            IAdminDAO adminDao = new AdminDaoImpl();
            var adminController = new AdminController(adminDao);
            var allAdmins = adminController.SearchAdmin(txtSearch.Text);
            guna2DataGridView1.AutoGenerateColumns = true;
            guna2DataGridView1.DataSource = allAdmins.ToList();
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            //for pharmacist
            IChemistDAO chemistDao = new ChemistDaoImpl();
            var chemistController = new ChemistController(chemistDao);
            var allChemists = chemistController.SearchChemist(txtSearch.Text);
            guna2DataGridView2.AutoGenerateColumns = true;
            guna2DataGridView2.DataSource = allChemists.ToList();
            guna2DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void UcViewUser_Load(object sender, EventArgs e)
        {
            //for admin
            IAdminDAO adminDao = new AdminDaoImpl();
            var adminController = new AdminController(adminDao);
            var allAdmins = adminController.GetAllAdmins(); //problem
            guna2DataGridView1.AutoGenerateColumns = true;
            guna2DataGridView1.DataSource = allAdmins.ToList();
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            //for pharmacist
            IChemistDAO chemistDao = new ChemistDaoImpl();
            var chemistController = new ChemistController(chemistDao);
            var allChemists = chemistController.GetAllChemists();
            guna2DataGridView2.AutoGenerateColumns = true;
            guna2DataGridView2.DataSource = allChemists.ToList();
            guna2DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                var selectedrowindex = guna2DataGridView1.SelectedCells[0].RowIndex;
                var selectedRow = guna2DataGridView1.Rows[selectedrowindex];
                var id = Convert.ToInt32(selectedRow.Cells["A_Id"].Value);
                IAdminDAO adminDao = new AdminDaoImpl();
                var adminController = new AdminController(adminDao);
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

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView2.SelectedRows.Count > 0)
            {
                var selectedrowindex = guna2DataGridView2.SelectedCells[0].RowIndex;
                var selectedRow = guna2DataGridView2.Rows[selectedrowindex];
                var id = Convert.ToInt32(selectedRow.Cells["P_Id"].Value);
                IChemistDAO chemistDao = new ChemistDaoImpl();
                var chemistController = new ChemistController(chemistDao);
                chemistController.DeleteChemist(id);
                UcViewUser_Load(sender, e);
            }
            else
            {
                MessageBox.Show(@"Please select a row to delete.");
            }
        }
    }
}