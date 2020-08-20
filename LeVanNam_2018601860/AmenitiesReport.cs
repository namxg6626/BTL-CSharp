using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class AmenitiesReport : Form
    {
        public AmenitiesReport()
        {
            InitializeComponent();
        }

        private void AmenitiesReport_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Activate();
        }

        private void btnMakeReport_Click(object sender, EventArgs e)
        {
            //DateTimePicker _temp = dtFrom;
            //label4.Text = _temp.Value.ToString("yyyy/MM/dd");
            string flightNumber = tbFlightNumber.Text;
            string from = dtFrom.Value.ToString("yyyy/MM/dd");
            string to = dtTo.Value.ToString("yyyy/MM/dd");
            BUS_AmenityReport bus_amenityReport = new BUS_AmenityReport();
            DataTable dataSource = bus_amenityReport.GetAllPurchasedAmenitiesReportTable(flightNumber, from, to);
            dataGridView1.DataSource = dataSource;
        }
    }
}
