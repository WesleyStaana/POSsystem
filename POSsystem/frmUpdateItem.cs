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
    public partial class frmUpdateItem : Form
    {
        private String connectionString = "SERVER=localhost;DATABASE=possystem_db;UID=root;PASSWORD=staana0522;charset=utf8;";
        public frmUpdateItem()
        {
            InitializeComponent();
        }

        private void frmUpdateItem_Load(object sender, EventArgs e)
        {
            this.loadItemList();



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public frmUpdateItem(ListView.SelectedListViewItemCollection info)
        {
            InitializeComponent();
            txtCode.Text = info[0].Text;
            txtItemName.Text = info[0].SubItems[1].Text;
            txtDescription.Text = info[0].SubItems[2].Text;
            txtUnitPrice.Text = info[0].SubItems[3].Text;
            txtQuantity.Text = info[0].SubItems[4].Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE items_tbl SET " +
                "Item_Name = '" + txtItemName.Text + "', " +
                "Description = '" + txtDescription.Text + "', " +
                "Unit_Price = '" + txtUnitPrice.Text + "', " +
                "Stocks_On_Hand = '" + txtQuantity.Text + "'" +
                "WHERE Item_Code= '" + txtCode.Text + "'";

            conn.Open();

            command.ExecuteNonQuery();
            MessageBox.Show("Record Updated!");

            conn.Close();
            this.loadItemList();
        }

        private void loadItemList() // To connect and refresh List and database
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

            conn.Close();
        }
    }
}