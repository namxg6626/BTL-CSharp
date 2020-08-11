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
using System.Text.RegularExpressions;

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
        }

        private void btnShowAnimities_Click(object sender, EventArgs e)
        {
            // clear checkBoxes first

            ClearAllAmenityCheckBoxes();

            // Declare phase

            string ticketID = cbFlights.SelectedValue.ToString();
            BUS_Ticket bus_ticket = new BUS_Ticket();
            DTO_Ticket ticket = bus_ticket.GetTicketByID(ticketID);

            BUS_CabinType bus_cabinType = new BUS_CabinType();
            DTO_CabinType cabinType = bus_cabinType.GetCabinTypeByID(ticket.CabinTypeID);

            BUS_Amenity bus_amenity = new BUS_Amenity();
            List<DTO_Amenity> lsAmenities = bus_amenity.GetAmenitiesListByCabinTypeID(ticket.CabinTypeID);

            Dictionary<string, DTO_Amenity> amenityKeyValuePairs = new Dictionary<string, DTO_Amenity>();
            string regex = @"\s";

            // Handle UI logic

            lbFullname.Text = string.Format("{0} {1}", ticket.FirstName, ticket.LastName);
            lbPassportNumber.Text = ticket.PassportNumber;
            lbCabinClass.Text = cabinType.Name;

            gbTest.Enabled = true;
            for (int i = 0; i <  lsAmenities.Count; i++)
            {
                string key = string.Format("{0} (${1})", lsAmenities[i].Service, lsAmenities[i].Price);
                amenityKeyValuePairs.Add(key, lsAmenities[i]);

                CheckBox chkBox = new CheckBox();
                chkBox.Name = "chkb" + Regex.Replace(lsAmenities[i].Service, regex, "");
                chkBox.Text = key;
                chkBox.Font = new Font(Font.FontFamily, 8.5f);
                chkBox.Location = new Point((i / 4) * 230 + 20, (i % 4) * 20 + 40);
                chkBox.AutoSize = true;

                // default amenities
                if (lsAmenities[i].Price == 0)
                {
                    chkBox.Checked = true;
                    chkBox.Enabled = false;
                }

                gbTest.Controls.Add(chkBox);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearAllAmenityCheckBoxes()
        {
            for (int i = 0; i < gbTest.Controls.Count; i++)
            {
                gbTest.Controls[i].Visible = false;
                gbTest.Controls[i].Enabled = false;
                gbTest.Controls.Remove(gbTest.Controls[i]);
            }
        }
    }
}
