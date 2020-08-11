using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class PurchaseAmanities : Form
    {
        public PurchaseAmanities()
        {
            InitializeComponent();
        }

        // booking reference ex: 12345E
        private void btnOk_Click(object sender, EventArgs e)
        {
            string bookingReference = tbBookReference.Text;

            BUS_Flight bus_flight = new BUS_Flight();
            List<DTO_Flight> lsFlight = bus_flight.GetFlightsListByBookingReference(bookingReference);
            DataTable items = new DataTable();
            items.Columns.Add("FlightDetail", typeof(string));
            items.Columns.Add("TicketID", typeof(string));

            foreach (DTO_Flight flight in lsFlight)
            {
                items.Rows.Add(
                    string.Format(
                        "{0}, {1}-{2}, {3}, {4}", 
                        flight.FlightNumber, 
                        flight.DepartureAirportCode, 
                        flight.ArrivalAirportCode, 
                        flight.Date,
                        flight.Time
                    ), 
                    flight.TicketID
                );
            }

            cbFlights.DataSource = items;
            cbFlights.DisplayMember = "FlightDetail";
            cbFlights.ValueMember = "TicketID";

            return;
        }

        private void btnShowAnimities_Click(object sender, EventArgs e)
        {
            string ticketID = cbFlights.SelectedValue.ToString();
            BUS_Ticket bus_ticket = new BUS_Ticket();
            DTO_Ticket ticket = bus_ticket.GetTicketByID(ticketID);

            BUS_CabinType bus_cabinType = new BUS_CabinType();
            DTO_CabinType cabinType = bus_cabinType.GetCabinTypeByID(ticket.CabinTypeID);

            lbFullname.Text = string.Format("{0} {1}", ticket.FirstName, ticket.LastName);
            lbPassportNumber.Text = ticket.PassportNumber;
            lbCabinClass.Text = cabinType.Name;

            gbAmenities.Enabled = true;
            foreach (Control control in gbAmenities.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox chkB = (CheckBox)control;
                    chkB.Checked = false;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
