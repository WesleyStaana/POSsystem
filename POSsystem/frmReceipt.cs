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
    public partial class frmReceipt : Form
    {
        public frmReceipt()
        {
            InitializeComponent();
        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {
            lblTotal.Text = frmTransactionPayment.total.ToString();
            lblCash.Text = frmTransactionPayment.cash.ToString();
            lblChange.Text = frmTransactionPayment.change.ToString();
        }
    }
}
