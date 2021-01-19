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
    public partial class frmTransactionPayment : Form
    {
        public static float cash;
        public static float total;
        public static float change;

        public frmTransactionPayment()
        {
            InitializeComponent();
        }

        public class Computation 
        {
            public static float getTotal(float cash, float total)
            {
                return cash - total;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            cash = float.Parse(txtCash.Text);
            total = float.Parse(txtTotal.Text);
            change = Computation.getTotal(cash, total);

            frmReceipt receipt = new frmReceipt();
            receipt.Show();
            this.Hide();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtCash.Text.Length > 0 && txtTotal.Text.Length > 0)
            {
                lblChange.Text = Convert.ToString(Convert.ToDouble(txtCash.Text) - Convert.ToDouble(txtTotal.Text));
            }

            if (txtCash.Text.Length > 0 && txtTotal.Text.Length == 0)
            {
                lblChange.Text = "0.00";
            }

            if (txtCash.Text.Length == 0 && txtTotal.Text.Length > 0)
            {
                lblChange.Text = "0.00";
            }

            if (txtCash.Text.Length == 0 && txtTotal.Text.Length == 0)
            {
                lblChange.Text = "0.00";
            }
        }

        private void txtCash_TextChanged_1(object sender, EventArgs e)
        {
            if (txtCash.Text.Length > 0 && txtTotal.Text.Length > 0)
            {
                lblChange.Text = Convert.ToString(Convert.ToDouble(txtCash.Text) - Convert.ToDouble(txtTotal.Text));
            }

            if (txtCash.Text.Length > 0 && txtTotal.Text.Length == 0)
            {
                lblChange.Text = "0.00";
            }

            if (txtCash.Text.Length == 0 && txtTotal.Text.Length > 0)
            {
                lblChange.Text = "0.00";
            }

            if (txtCash.Text.Length == 0 && txtTotal.Text.Length == 0)
            {
                lblChange.Text = "0.00";
            }
        }
    }
}
