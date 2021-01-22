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
    public partial class frmUser : Form
    {

        private String connectionString = "SERVER=localhost;DATABASE=possystem_db;UID=root;PASSWORD=staana0522;charset=utf8;";
        public frmUser()
        {
            InitializeComponent();
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStaff staff = new frmStaff();
            staff.ShowDialog();
            this.loadUserList();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            this.loadUserList();
        }

        private void loadUserList()
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
            lvUser.Items.Clear();
            for (int index = 0; index < dataSet.Tables[0].Rows.Count; index++)
            {
                lvUser.Items.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(0).ToString());
                lvUser.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(1).ToString());
                lvUser.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(2).ToString());
                lvUser.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(3).ToString());
                lvUser.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(4).ToString());
                lvUser.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(5).ToString());
                lvUser.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(6).ToString());

            }

            conn.Close();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmUpdateStaff UpdateStaff = new frmUpdateStaff(lvUser.SelectedItems);
            UpdateStaff.ShowDialog();
            this.loadUserList();
        }

        private void frmUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
        }
    }
}
