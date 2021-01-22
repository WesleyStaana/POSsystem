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
    public partial class frmStockIn : Form
    {
        private String connectionString = "SERVER=localhost;DATABASE=possystem_db;UID=root;PASSWORD=staana0522;charset=utf8;";
        public frmStockIn()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO items_tbl(Stocks_On_Hand) VALUES (" +
                "'" + txtQuantity.Text + "'" + ")";

            conn.Open();

            command.ExecuteNonQuery();

            MessageBox.Show("Quantity Added!");

            conn.Close();
            this.loadItemList();
        }
        private void frmStockIn_Load(object sender, EventArgs e)
        {
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
