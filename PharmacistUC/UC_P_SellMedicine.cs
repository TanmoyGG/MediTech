using System;
using System.Windows.Forms;

namespace MediTech.PharmacistUC
{
    public partial class UC_P_SellMedicine : UserControl
    {
        public UC_P_SellMedicine()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}