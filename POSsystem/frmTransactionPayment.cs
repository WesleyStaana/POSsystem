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
        public static float cash, total, change;
        private ListView holder;
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
            receipt.setReceipt(holder);
            this.Hide();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            checker(txtTotal, "0.00");
            Calculate();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            checker(txtCash, "0.00");
            Calculate();
        }

        private void frmTransactionPayment_Load(object sender, EventArgs e)
        {
            
        }

        private void txtTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit.PerformClick();
            }
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit.PerformClick();
            }
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
            double total = Convert.ToDouble(txtTotal.Text);
            double cash = Convert.ToDouble(txtCash.Text);

            if (cash > 0 && total > 0)
            {
                lblChange.Text = Convert.ToString(cash - total);
            }

            else if (cash > 0 && total == 0)
            {
                lblChange.Text = "0.00";
            }

            else if (cash == 0 && total > 0)
            {
                lblChange.Text = "0.00";
            }

            else if (cash == 0 && total == 0)
            {
                lblChange.Text = "0.00";
            }
        }
        public void setTxtTotal(string total)
        {
            txtTotal.Text = total;
        }

        public void setList(ListView list)
        {
            holder = list;
        }
    }
}
