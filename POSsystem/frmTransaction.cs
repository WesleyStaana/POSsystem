using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace POSsystem
{
    public partial class frmTransaction : Form
    {
        private frmTransactionAddItem transaction = null;

        public void setItem(frmTransactionAddItem test)
        {
            transaction = test;
        }

        private String connectionString = "SERVER=localhost;DATABASE=possystem_db;UID=root;PASSWORD=staana0522;charset=utf8;";
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
            this.loadItemList();
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

        public void loadItemList()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT * FROM items_tbl";

            adapter.SelectCommand = command;

            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);

            conn.Open();

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "items_tbl");
            lvTransaction.Items.Clear();
            for (int index = 0; index < dataSet.Tables[0].Rows.Count; index++)
            {
                lvTransaction.Items.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(0).ToString());
                lvTransaction.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(1).ToString());
                lvTransaction.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(2).ToString());
                lvTransaction.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(3).ToString());
                lvTransaction.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(4).ToString());


            }

            conn.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void setItemCode(string Code)
        {
            
        }

    }
}
