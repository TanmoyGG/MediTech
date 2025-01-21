using System;
using System.Windows.Forms;
using MediTech.Controller;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;

namespace MediTech.PharmacistUC
{
    public partial class UC_P_ViewMedicine : UserControl
    {
        public UC_P_ViewMedicine()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void UC_P_ViewMedicine_Load(object sender, EventArgs e)
        {
            loadMedicine();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            UC_P_ViewMedicine_Load(this,null);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void loadMedicine()
        {
            IMedicineDAO medicineDao = new MedicineDAOImpl();
            MedicineController medicineController = new MedicineController(medicineDao);
            var allMedicines = medicineController.GetAllMedicines();

            guna2DataGridView1.AutoGenerateColumns = true;
            guna2DataGridView1.DataSource = allMedicines;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                var selectedrowindex = guna2DataGridView1.SelectedCells[0].RowIndex;
                var selectedRow = guna2DataGridView1.Rows[selectedrowindex];
                var id = Convert.ToInt32(selectedRow.Cells["M_ID"].Value);
                IMedicineDAO medicineDao = new MedicineDAOImpl();
                MedicineController medicineController = new MedicineController(medicineDao);
                var deleteMedicine = new MedicineController(medicineDao);
                deleteMedicine.DeleteMedicine(id);
                UC_P_ViewMedicine_Load(sender, e);
            }
            else
            {
                MessageBox.Show(@"Please select a row to delete.");
            }
        }
    }
}