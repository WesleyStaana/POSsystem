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
    public partial class frmMouse : Form
    {
        public frmMouse()
        {
            InitializeComponent();
        }

        private void frmMouse_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
        }
    }
}
