using System;
using System.Windows.Forms;

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
    }
}