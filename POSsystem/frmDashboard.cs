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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void MaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser user = new frmUser();
            user.Show();
            this.Hide();
        }

        private void positionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPosition position = new frmPosition();
            position.Show();
            this.Hide();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItems items = new frmItems();
            items.Show();
            this.Hide();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransaction transact = new frmTransaction();
            transact.Show();
            this.Hide();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void lblLogout_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmMouse mouse = new frmMouse();
            mouse.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmKeyboard keyboard = new frmKeyboard();
            keyboard.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmHeadset headset = new frmHeadset();
            headset.Show();
            this.Hide();
        }
    }
}
