using System;
using System.Windows.Forms;

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}