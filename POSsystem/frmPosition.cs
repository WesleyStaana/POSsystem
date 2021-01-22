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
    public partial class frmPosition : Form
    {

        private String connectionString = "SERVER=localhost;DATABASE=possystem_db;UID=root;PASSWORD=staana0522;charset=utf8;";

        public frmPosition()
        {
            InitializeComponent();
            lvPosition.Click += new System.EventHandler(lvPosition_Click);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
            this.Hide();
        }

        private void frmPosition_Load(object sender, EventArgs e)
        {
            this.loadPositionList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(btnAdd.Text.Equals("Add"))
            {
                btnAdd.Text = "SAVE";
            }
            else
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO position_tbl(Position) VALUES (" +
                    "'" + txtDescription.Text + "'" + 
                    ")";

                conn.Open();

                command.ExecuteNonQuery();

                MessageBox.Show("Record Saved!");

                conn.Close();

                btnAdd.Text = "Add";

                this.loadPositionList();

            }
        }

        private void loadPositionList()
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
            lvPosition.Items.Clear();
            for (int index = 0; index < dataSet.Tables[0].Rows.Count; index++)
            {
                lvPosition.Items.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(0).ToString());
                lvPosition.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(1).ToString());
            }

            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(btnUpdate.Text.Equals("Update"))
            {
                btnUpdate.Text = "SAVE";
            }
            else
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "UPDATE position_tbl SET " +
                    "Position = '" + txtDescription.Text + "'" +
                    "WHERE No= '" + txtPosition.Text + "'";

                conn.Open();

                command.ExecuteNonQuery();
                MessageBox.Show("Record Updated!");

                conn.Close();


                btnUpdate.Text = "Update";

                this.loadPositionList();
            }
        }

        private void lvPosition_Click(Object sender, EventArgs e )
        {
            txtPosition.Text = lvPosition.SelectedItems[0].Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete?" , "Message" , MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "DELETE FROM position_tbl WHERE No = '" + txtPosition.Text + "'";

                conn.Open();

                command.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Record Deleted");

                this.loadPositionList();
            }
        }

        private void frmPosition_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
        }

        private void lvPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
