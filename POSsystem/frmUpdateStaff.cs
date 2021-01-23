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
    public partial class frmUpdateStaff : Form
    {
        private String connectionString = "SERVER=localhost;DATABASE=possystem_db;UID=root;PASSWORD=staana0522;charset=utf8;";

        public frmUpdateStaff()
        {
            InitializeComponent();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE user_tbl SET " +
                "Last_Name = '" + txtLastName.Text + "', " +
                "First_Name = '" + txtFirstName.Text + "', " +
                "Middle_Initial = '" + txtMI.Text + "', " +
                "Position = '" + cmbPosition.Text + "', " +
                "Username = '" + txtUserName.Text + "', " +
                "Password = '" + txtPassword.Text + "'" +
                "WHERE ID_No= '" + txtStaffId.Text + "'";

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

            command.CommandText = "SELECT * FROM user_tbl";

            adapter.SelectCommand = command;

            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);

            conn.Open();

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "user_tbl");

            conn.Close();
        }

        public frmUpdateStaff(ListView.SelectedListViewItemCollection info)
        {
            InitializeComponent();
            txtStaffId.Text = info[0].Text;
            txtLastName.Text = info[0].SubItems[1].Text;
            txtFirstName.Text = info[0].SubItems[2].Text;
            txtMI.Text = info[0].SubItems[3].Text;
            cmbPosition.Text = info[0].SubItems[4].Text;
            txtUserName.Text = info[0].SubItems[5].Text;
            txtPassword.Text = info[0].SubItems[6].Text;
        }

        private void frmUpdateStaff_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM position_tbl";
            MySqlDataReader dtreader;


            conn.Open();
            dtreader = command.ExecuteReader();
            while (dtreader.Read())
            {
                string pname = dtreader.GetString(1);
                cmbPosition.Items.Add(pname);

            }
            conn.Close();
            this.loadItemList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       

    }
}
