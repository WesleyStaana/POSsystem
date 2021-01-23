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

        private void frmReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmTransaction transact = new frmTransaction();
            transact.Show();
        }

        private void lblItem2_Click(object sender, EventArgs e)
        {

        }

        private void lblItem3_Click(object sender, EventArgs e)
        {

        }

        private void lblItem1_Click(object sender, EventArgs e)
        {

        }

        private void lblPrice1_Click(object sender, EventArgs e)
        {

        }

        private void lblItem4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblPrice2_Click(object sender, EventArgs e)
        {

        }

        private void lblPrice3_Click(object sender, EventArgs e)
        {

        }

        private void lblPrice4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void setReceipt(ListView holder)
        {
            for (int i = 0; i < holder.Items.Count; i++)
            {
                ListViewItem item = new ListViewItem(holder.Items[i].SubItems[1].Text);
                item.SubItems.Add(holder.Items[i].SubItems[3].Text);
                item.SubItems.Add(holder.Items[i].SubItems[5].Text);
                lvReceipt.Items.Add(item);
            }
        }

    }
}
