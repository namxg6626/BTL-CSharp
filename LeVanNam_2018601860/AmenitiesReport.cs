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
using DTO;

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
            dtFrom.Format = DateTimePickerFormat.Custom;
            dtFrom.CustomFormat = "dd/MM/yyyy";

            dtTo.Format = DateTimePickerFormat.Custom;
            dtTo.CustomFormat = "dd/MM/yyyy";

            this.Activate();
        }

        private void btnMakeReport_Click(object sender, EventArgs e)
        {
            DTO_AmenityReport amenityReport = new DTO_AmenityReport(
                tbFlightNumber.Text,
                dtFrom.Value,
                dtTo.Value
            );
            BUS_AmenityReport bus_amenityReport = new BUS_AmenityReport();
            dataGridView1.DataSource = bus_amenityReport.GetAmenitiesReportTable(amenityReport);
        }
    }
}
