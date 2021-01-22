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
    
    public partial class frmTransactionAddItem : Form
    {
        private String connectionString = "SERVER=localhost;DATABASE=possystem_db;UID=root;PASSWORD=staana0522;charset=utf8;";

        private frmTransaction listview = null;

        public void setItem(frmTransaction list)
        {
            listview = list;
        }


        public frmTransactionAddItem()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmItems item = new frmItems();
            item.setItem(this);
            item.ShowDialog();

            this.loadItemList();
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

        private void frmTransactionAddItem_Load(object sender, EventArgs e)
        {
           
        }

        public void setTxtItemCode(string itemCode)
        {
            txtItemCode.Text = itemCode;
        }

        public void setTxtItemName(string itemName)
        {
            txtItemName.Text = itemName;
        }

        public void setTxtUnitPrice(string UnitPrice)
        {
            txtUnitPrice.Text = UnitPrice;
        }

        public void setTxtQuantity(string Quantity)
        {
            txtQuantity.Text = Quantity;
        }

        public void setTxtDiscount(string Discount)
        {
            txtDiscount.Text = Discount;
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
           /* frmTransaction transaction = new frmTransaction();
            ListViewItem item = new ListViewItem(txtItemCode.Text);
            item.SubItems.Add(txtItemName.Text);
            item.SubItems.Add(txtUnitPrice.Text);
            item.SubItems.Add(txtQuantity.Text);
            item.SubItems.Add(txtDiscount.Text);
            item.SubItems.Add(lblTotalPrice.Text);
            transaction.lvTransaction.Items.Add(item);
            this.loadItemList();*/
            
            
        }
    }
}
