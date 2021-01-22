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
    public partial class frmHeadset : Form
    {
        public frmHeadset()
        {
            InitializeComponent();
        }

        private void frmHeadset_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
        }
    }
}
