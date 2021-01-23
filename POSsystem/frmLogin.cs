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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "admin")
            {
                this.Hide();
                frmDashboard f2 = new frmDashboard();
                f2.Show();
            }
            else if (username == "cashier" && password == "cashier")
            {
                this.Hide();
                frmTransaction transaction = new frmTransaction();
                transaction.Show();
                
            }
            else if (username != "cashier" && password == "cashier")
            {
                MessageBox.Show("Invalid username, please try again.");
            }
            else if (username == "cashier" && password != "cashier")
            {
                MessageBox.Show("Invalid password, please try again.");
            }
            else if (username != "admin" && password == "admin")
            {
                MessageBox.Show("Invalid username, please try again.");
            }
            else if (username == "admin" && password != "admin")
            {
                MessageBox.Show("Invalid password, please try again.");
            }
            else
            {
                MessageBox.Show("Invalid input, please try again.");
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                btnLogin.PerformClick();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
