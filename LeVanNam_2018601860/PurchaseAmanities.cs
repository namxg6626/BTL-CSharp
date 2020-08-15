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
        //
        // Frequently used data in this form
        //
        private Dictionary<string, DTO_Amenity> amenityKeyValuePairs = new Dictionary<string, DTO_Amenity>();
        private List<DTO_Amenity> lsPurchasedAmenitiesByTicketID = new List<DTO_Amenity>();
        private List<DTO_Amenity> lsAmenities = new List<DTO_Amenity>();
        private double previousAmenitiesCost = 0;
        private bool isNewAmenitiesLoad = true;
        //
        // UI Event methods
        //
        private void btnOk_Click(object sender, EventArgs e)
        {
            LoadFlightsList();
        }

        private void btnShowAnimities_Click(object sender, EventArgs e)
        {
            ShowAmenities();
        }

        private void DynamicCheckBox_Click(object sender, EventArgs e)
        {
            CalculateAmenityCost();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Thanks for your purchase!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveAmenitiesTicket();
                ShowAmenities();
            }
            else
            {
                MessageBox.Show("Payment was canceled!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        // Common methods
        //
        private void LoadFlightsList()
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

        private void ShowAmenities()
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

            RenderCheckBoxes();
            CalculateAmenityCost();
        }

        private void RenderCheckBoxes()
        {
            string ticketID = cbFlights.SelectedValue.ToString();
            BUS_AmenityTicket bus_amenityTicket = new BUS_AmenityTicket();
            previousAmenitiesCost = 0;

            for (int i = 0; i < lsAmenities.Count; i++)
            {
                string key = string.Format("{0} (${1})", lsAmenities[i].Service, lsAmenities[i].Price);
                amenityKeyValuePairs.Add(key, lsAmenities[i]);

                CheckBox chkBox = new CheckBox();
                string chkBoxName = "chkb" + Regex.Replace(lsAmenities[i].Service, @"\s", "");
                Point location = new Point((i / 4) * 230 + 20, (i % 4) * 20 + 40);
                chkBox = CreateCheckBox(chkBoxName, key, location, new EventHandler(DynamicCheckBox_Click));


                //if this amenity is selected before, check its check box
                foreach (DTO_Amenity purchasedAmenity in lsPurchasedAmenitiesByTicketID)
                    if (purchasedAmenity.ID == lsAmenities[i].ID)
                    {
                        chkBox.Checked = true;
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
        }

        private CheckBox CreateCheckBox(string name, string text, Point location, EventHandler clickListener)
        {
            CheckBox chkBox = new CheckBox();
            chkBox.Name = name;
            chkBox.Text = text;
            chkBox.Location = location;
            chkBox.Click += clickListener;
            chkBox.Font = new Font(Font.FontFamily, 8.5f);
            chkBox.AutoSize = true;
            return chkBox;
        }

        private void CalculateAmenityCost()
        {
            double selectedAmenitiesCost = 0;

            foreach (Control control in gbAmenities.Controls)
            {
                CheckBox chkBox = (CheckBox)control;
                DTO_Amenity amenity = amenityKeyValuePairs[chkBox.Text];

                if (chkBox.Checked && chkBox.Enabled)
                {
                    selectedAmenitiesCost += amenity.Price;
                    if (isNewAmenitiesLoad)
                        previousAmenitiesCost += amenity.Price;
                }
            }

            if (isNewAmenitiesLoad)
            {
                previousAmenitiesCost = Math.Round(previousAmenitiesCost * 1.05, 2);
                lbPaid.Text = "$" + previousAmenitiesCost.ToString();
                isNewAmenitiesLoad = false;
            }

            double taxes = Math.Round(selectedAmenitiesCost * 0.05, 2);
            double total = selectedAmenitiesCost + taxes;

            lbItemsSelected.Text = "$" + selectedAmenitiesCost.ToString();
            lbDutiesAndTaxes.Text = "$" + taxes.ToString();
            lbTotalPayable.Text = "$" + (total - previousAmenitiesCost).ToString();
        }

        private void SaveAmenitiesTicket()
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
            previousAmenitiesCost = 0;
            isNewAmenitiesLoad = true;
        }
    }
}
