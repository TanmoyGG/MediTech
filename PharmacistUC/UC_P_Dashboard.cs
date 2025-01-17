using System;
using System.Windows.Forms;

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
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}