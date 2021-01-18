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
    public partial class frmItemAddItem : Form
    {
        public frmItemAddItem()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmItemAddItem_Load(object sender, EventArgs e)
        {
            string[] Category = new string[] {
                "Mouse",
                "Keyboard",
                "Headset",
                "Mousepad"
            };
            for (int i = 0; i < 4; i++)
            {
                cbCategory.Items.Add(Category[i].ToString());
            }
        }
    }
}
