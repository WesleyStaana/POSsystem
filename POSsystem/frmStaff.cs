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
    public partial class frmStaff : Form
    {

        private String connectionString = "SERVER=localhost;DATABASE=possystem_db;UID=root;PASSWORD=staana0522;charset=utf8;";

        public frmStaff()
        {
            InitializeComponent();
            Fillcombo();
        }

        void Fillcombo() //Passing Database Value to Combobox
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT * FROM position_tbl";

            adapter.SelectCommand = command;

            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);

            conn.Open();

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "position_tbl");
            for (int index = 0; index < dataSet.Tables[0].Rows.Count; index++)
            {
                cmbPosition.Items.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(1).ToString());
                
            }
            conn.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            
        }

      

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO user_tbl(Last_name, First_name, Middle_Initial, Position, Username, Password) VALUES (" +
                "'" + txtLastName.Text + "'," + 
                "'" + txtFirstName.Text + "'," + 
                "'" + txtMI.Text + "'," + 
                "'" + cmbPosition.Text + "'," + 
                "'" + txtUserName.Text + "'," + 
                "'" + txtPassword.Text + "'" + 
                ")";

            conn.Open();

            command.ExecuteNonQuery();

            MessageBox.Show("Record Saved!");

            conn.Close();

           
        }

        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {

        }

        public frmStaff(ListView.SelectedListViewItemCollection info)
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

    }
}
