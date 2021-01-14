using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSsystem
{
    public partial class frmTransaction : Form
    {
        public frmTransaction()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            frmTransactionPayment toPay = new frmTransactionPayment();
            toPay.Show();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmTransactionAddItem toAdd = new frmTransactionAddItem();
            toAdd.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmTransaction_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
