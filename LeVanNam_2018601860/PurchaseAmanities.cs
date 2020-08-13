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
        Dictionary<string, DTO_Amenity> amenityKeyValuePairs = new Dictionary<string, DTO_Amenity>();

        public PurchaseAmanities()
        {
            InitializeComponent();
        }
        //
        // UI Event methods
        //
        private void btnSave_Click(object sender, EventArgs e)
        {
            string ticketID = cbFlights.SelectedValue.ToString();
            BUS_AmenityTicket bus_amenityTicket = new BUS_AmenityTicket();
            DTO_AmenityTicket amenityTicket = new DTO_AmenityTicket();
            amenityTicket.TicketID = ticketID;

            foreach (Control control in gbAmenities.Controls)
            {
                CheckBox chkBox = (CheckBox)control;
                amenityTicket.AmenityID = amenityKeyValuePairs[chkBox.Text].ID;

                if (chkBox.Checked && chkBox.Enabled)
                    bus_amenityTicket.InsertARow(amenityTicket);

                else if (!chkBox.Checked)
                    bus_amenityTicket.DeleteArow(amenityTicket);

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Reset Displaying data

            gbAmenities.Enabled = false;
            ClearAllAmenityCheckBoxes();
            ClearAllLableDataHolder();

            string bookingReference = tbBookReference.Text.ToUpper();

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
            // Declare phase

            string ticketID = cbFlights.SelectedValue.ToString();
            BUS_Ticket bus_ticket = new BUS_Ticket();
            DTO_Ticket ticket = bus_ticket.GetTicketByID(ticketID);

            BUS_CabinType bus_cabinType = new BUS_CabinType();
            DTO_CabinType cabinType = bus_cabinType.GetCabinTypeByID(ticket.CabinTypeID);

            BUS_Amenity bus_amenity = new BUS_Amenity();
            List<DTO_Amenity> lsAmenities = bus_amenity.GetAmenitiesListByCabinTypeID(ticket.CabinTypeID);

            // Handle UI logic

            lbFullname.Text = string.Format("{0} {1}", ticket.FirstName, ticket.LastName);
            lbPassportNumber.Text = ticket.PassportNumber;
            lbCabinClass.Text = cabinType.Name;

            gbAmenities.Enabled = true;
            DynamicRenderingCheckBoxes(lsAmenities, ticketID);
            CalculateAmenityCost();
        }

        private void DynamicAmenityCheckBox_CustomClickEvent(object sender, EventArgs e)
        {
            CalculateAmenityCost();
        }
        //
        // Common methods
        //
        private void DynamicRenderingCheckBoxes(List<DTO_Amenity> lsAmenities, string ticketID)
        {
            BUS_AmenityTicket bus_amenityTicket = new BUS_AmenityTicket();
            List<DTO_AmenityTicket> lsAmenitiesTicket = bus_amenityTicket.GetAmenitiesTicketListByTicketID(ticketID);

            for (int i = 0; i < lsAmenities.Count; i++)
            {
                string key = string.Format("{0} (${1})", lsAmenities[i].Service, lsAmenities[i].Price);
                amenityKeyValuePairs.Add(key, lsAmenities[i]);

                CheckBox chkBox = new CheckBox();
                chkBox.Name = "chkb" + Regex.Replace(lsAmenities[i].Service, @"\s", "");
                chkBox.Text = key;
                chkBox.Font = new Font(Font.FontFamily, 8.5f);
                chkBox.Location = new Point((i / 4) * 230 + 20, (i % 4) * 20 + 40);
                chkBox.AutoSize = true;
                chkBox.Click += new EventHandler(DynamicAmenityCheckBox_CustomClickEvent);

                // if this amenity is selected before, check its check box
                foreach (DTO_AmenityTicket amenityTicket in lsAmenitiesTicket)
                {
                    if (amenityTicket.AmenityID == lsAmenities[i].ID)
                    {
                        chkBox.Checked = true;
                        chkBox.Enabled = false;
                        break;
                    }
                }

                // disable default amenities
                if (lsAmenities[i].Price == 0)
                {
                    chkBox.Checked = true;
                    chkBox.Enabled = false;
                }

                gbAmenities.Controls.Add(chkBox);
            }
        }

        private void CalculateAmenityCost()
        {
            double itemsSelectedCost = 0;

            foreach (Control control in gbAmenities.Controls)
            {
                CheckBox chkBox = (CheckBox)control;
                if (chkBox.Checked && chkBox.Enabled)
                {
                    itemsSelectedCost += amenityKeyValuePairs[chkBox.Text].Price;
                }
            }

            double taxes = Math.Round(itemsSelectedCost % 0.05, 2);
            lbItemsSelected.Text = "$" + itemsSelectedCost.ToString();
            lbDutiesAndTaxes.Text = "$" + taxes.ToString();
            lbTotalPayable.Text = "$" + (itemsSelectedCost + taxes).ToString();
        }

        private void ClearAllAmenityCheckBoxes()
        {
            amenityKeyValuePairs = new Dictionary<string, DTO_Amenity>();
            for (int i = 0; i < gbAmenities.Controls.Count; i++)
            {
                gbAmenities.Controls[i].Click -= DynamicAmenityCheckBox_CustomClickEvent;
                gbAmenities.Controls.Remove(gbAmenities.Controls[i]);
                ((CheckBox)gbAmenities.Controls[i]).Enabled = false;
                ((CheckBox)gbAmenities.Controls[i]).Visible = false;
            }
        }

        private void ClearAllLableDataHolder()
        {
            string defaultString_1 = "[XXXX XXXX]";
            string defaultString_2 = "[$XX]";

            lbFullname.Text = defaultString_1;
            lbPassportNumber.Text = defaultString_1;
            lbCabinClass.Text = defaultString_1;

            lbItemsSelected.Text = defaultString_2;
            lbDutiesAndTaxes.Text = defaultString_2;
            lbTotalPayable.Text = defaultString_2;
        }
    }
}
