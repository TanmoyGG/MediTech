using System;
using System.Windows.Forms;
using MediTech.DataAccess.Controller;
using MediTech.DataAccess.DAO;

namespace MediTech.AdministratorUC
{
    public partial class UcSalesReport : UserControl
    {
        public UcSalesReport()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UcSalesReport_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            ISalesReportDAO salesReportDao = new SalesReportDAOImpl();
            SalesReportController salesReportController = new SalesReportController(salesReportDao);
            var reports = salesReportController.GetAllReports();

            guna2DataGridView1.AutoGenerateColumns = true;
            guna2DataGridView1.DataSource = reports;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }
    }
}