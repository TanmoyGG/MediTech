using System.Windows.Forms;

namespace MediTech.AdministratorUC
{
    public partial class UcSalesReport : UserControl
    {
        public UcSalesReport()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}