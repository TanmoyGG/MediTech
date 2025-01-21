using System;
using System.Windows.Forms;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;

namespace MediTech.PharmacistUC
{
    public partial class UC_P_Dashboard : UserControl
    {
        public UC_P_Dashboard()
        {
            InitializeComponent();
        }

        private void UC_P_Dashboard_Load(object sender, EventArgs e)
        {
            loadChart();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            chart1.Series["Valid Medicines"].Points.Clear();
            chart1.Series["Expired Medicines"].Points.Clear();
            loadChart();
        }

        public void loadChart()
        {
            IMedicineDAO medicineDao = new MedicineDAOImpl();
            MedicineController medicineController = new MedicineController(medicineDao);

            this.chart1.Series["Valid Medicines"].Points.AddXY("Medicine Validity Chart", medicineController.CountTotalValidMedicines());
            this.chart1.Series["Expired Medicines"].Points.AddXY("Medicine Validity Chart", medicineController.CountTotalExpiredMedicines());
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}