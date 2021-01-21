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
    public partial class frmTransactionAddItem : Form
    {
        public frmTransactionAddItem()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmItems item = new frmItems();
            item.Show();
        }

        private void checker(TextBox txtbox, string defaultValue)
        {
            if (txtbox.Text.Trim().Length == 0)
            {
                txtbox.Text = defaultValue;
            }
        }

        private void Calculate()
        {
            double unit_price = Convert.ToDouble(txtUnitPrice.Text);
            double quantity = Convert.ToDouble(txtQuantity.Text);
            double total = unit_price * quantity;

            double discount = Convert.ToDouble(txtDiscount.Text);
            double less = discount / 100;

            double actual_price = total - (total * less);

            if (unit_price > 0 && quantity > 0 && discount > 0)
            {
                lblTotalPrice.Text = Convert.ToString(actual_price);
            }

            else if (unit_price > 0 && quantity > 0 && discount == 0)
            {
                lblTotalPrice.Text = "0.00";
            }

            else if (unit_price > 0 && quantity == 0 && discount == 0)
            {
                lblTotalPrice.Text = "0.00";
            }

            else if (unit_price == 0 && quantity > 0 && discount == 0)
            {
                lblTotalPrice.Text = "0.00";
            }

            else if (unit_price == 0 && quantity == 0 && discount > 0)
            {
                lblTotalPrice.Text = "0.00";
            }

            else if (unit_price == 0 && quantity == 0 && discount == 0)
            {
                lblTotalPrice.Text = "0.00";
            }
        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            checker(txtUnitPrice, "0.00");
            Calculate();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            checker(txtQuantity, "0");
            Calculate();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            checker(txtDiscount, "0");
            Calculate();
        }
    }
}
