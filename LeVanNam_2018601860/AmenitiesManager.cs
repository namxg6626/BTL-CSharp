using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class AmenitiesManager : Form
    {
        public AmenitiesManager()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit program?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            PurchaseAmanities purchaseAmanities = new PurchaseAmanities();
            purchaseAmanities.ShowDialog();

            this.WindowState = FormWindowState.Normal;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            AmenitiesReport amenitiesReport = new AmenitiesReport();
            amenitiesReport.ShowDialog();

            this.WindowState = FormWindowState.Normal;
        }
    }
}
