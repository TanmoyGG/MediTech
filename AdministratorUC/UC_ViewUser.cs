﻿using System;
using System.Windows.Forms;

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
    }
}