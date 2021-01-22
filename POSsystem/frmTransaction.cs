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
            toPay.setTxtTotal(lblTotal.Text);
            this.Hide();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmTransactionAddItem toAdd = new frmTransactionAddItem();
            toAdd.Show();
            toAdd.setTransact(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
            this.Hide();
        }

        private void frmTransaction_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
            
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label2.Text = DateTime.Now.ToLongDateString();
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void dataGridViewTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

  
        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            lvTransaction.Items.Clear();
        }

        public void addToCart(string temp1, string temp2, string temp3, string temp4, string temp5, string temp6)
        {
            ListViewItem item = new ListViewItem(temp1);
            item.SubItems.Add(temp2);
            item.SubItems.Add(temp3);
            item.SubItems.Add(temp4);
            item.SubItems.Add(temp5);
            item.SubItems.Add(temp6);
            lvTransaction.Items.Add(item);
            lblTotal.Text = temp6.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvTransaction.Items.Count; i++)
            {
                if (lvTransaction.Items[i].Selected)
                {
                    lvTransaction.Items[i].Remove();
                    i--;
                }
            }
        }
    }
}
