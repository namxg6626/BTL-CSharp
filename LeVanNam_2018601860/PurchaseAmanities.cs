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
        List<DTO_Amenity> lsPurchasedAmenitiesByTicketID = new List<DTO_Amenity>();
        List<DTO_Amenity> lsAmenities = new List<DTO_Amenity>();
        double previousAmenitiesCost = 0;
        double currentAmenitiesCost = 0;

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

            ClearAllAmenityCheckBoxes();
            ClearAllLablesDataHolder();
            ResetAmenityData();

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
            gbFlightList.Enabled = true;
            gbAmenities.Enabled = false;
        }

        private void btnShowAnimities_Click(object sender, EventArgs e)
        {
            ClearAllAmenityCheckBoxes();
            ResetAmenityData();

            // Declare phase

            string ticketID = cbFlights.SelectedValue.ToString();
            DTO_Ticket ticket = new BUS_Ticket().GetTicketByID(ticketID);
            DTO_CabinType cabinType = new BUS_CabinType().GetCabinTypeByID(ticket.CabinTypeID);
            lsAmenities = new BUS_Amenity().GetAmenitiesListByCabinTypeID(ticket.CabinTypeID);
            lsPurchasedAmenitiesByTicketID = new BUS_Amenity().GetPurchasedAmenitiesListByTicketID(ticketID);

            // Handle UI logic

            lbFullname.Text = string.Format("{0} {1}", ticket.FirstName, ticket.LastName);
            lbPassportNumber.Text = ticket.PassportNumber;
            lbCabinClass.Text = cabinType.Name;
            gbAmenities.Enabled = true;

            DynamicRenderingCheckBoxes();
            CalculateAmenityCost();
        }

        private void DynamicAmenityCheckBox_CustomClickEvent(object sender, EventArgs e)
        {
            CalculateAmenityCost();
        }
        //
        // Common methods
        //
        private void DynamicRenderingCheckBoxes()
        {
            string ticketID = cbFlights.SelectedValue.ToString();
            BUS_AmenityTicket bus_amenityTicket = new BUS_AmenityTicket();
            previousAmenitiesCost = 0;

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


                //if this amenity is selected before, check its check box
                foreach (DTO_Amenity purchasedAmenity in lsPurchasedAmenitiesByTicketID)
                    if (purchasedAmenity.ID == lsAmenities[i].ID)
                    {
                        chkBox.Checked = true;
                        previousAmenitiesCost += purchasedAmenity.Price;
                        break;
                    }

                // disable default amenities
                if (lsAmenities[i].Price == 0)
                {
                    chkBox.Checked = true;
                    chkBox.Enabled = false;
                }

                gbAmenities.Controls.Add(chkBox);
            }
            previousAmenitiesCost = previousAmenitiesCost + Math.Round(previousAmenitiesCost * 0.05, 2);
        }

        private void CalculateAmenityCost()
        {
            currentAmenitiesCost = 0;

            foreach (Control control in gbAmenities.Controls)
            {
                CheckBox chkBox = (CheckBox)control;
                DTO_Amenity amenity = amenityKeyValuePairs[chkBox.Text];

                if (chkBox.Checked && chkBox.Enabled)
                {
                    currentAmenitiesCost += amenity.Price;
                }
            }

            double taxes = Math.Round(currentAmenitiesCost * 0.05, 2);
            double total = currentAmenitiesCost + taxes;

            lbPaid.Text = "$" + (currentAmenitiesCost + taxes).ToString();
            lbItemsSelected.Text = "$" + currentAmenitiesCost.ToString();
            lbDutiesAndTaxes.Text = "$" + taxes.ToString();
            lbTotalPayable.Text = (total - previousAmenitiesCost).ToString();
            currentAmenitiesCost = total;
        }

        private void ClearAllAmenityCheckBoxes()
        {
            while (gbAmenities.Controls.Count > 0)
            {
                int lastIndex = gbAmenities.Controls.Count - 1;
                gbAmenities.Controls.Remove(gbAmenities.Controls[lastIndex]);
            }
        }

        private void ClearAllLablesDataHolder()
        {
            string defaultString_1 = "[XXXX XXXX]";
            string defaultString_2 = "[$XX]";

            lbFullname.Text = defaultString_1;
            lbPassportNumber.Text = defaultString_1;
            lbCabinClass.Text = defaultString_1;

            lbItemsSelected.Text = defaultString_2;
            lbDutiesAndTaxes.Text = defaultString_2;
            lbTotalPayable.Text = defaultString_2;
            lbPaid.Text = defaultString_2;
        }

        private void ResetAmenityData()
        {
            lsAmenities = new List<DTO_Amenity>();
            lsPurchasedAmenitiesByTicketID = new List<DTO_Amenity>();
            amenityKeyValuePairs = new Dictionary<string, DTO_Amenity>();
        }
    }
}
