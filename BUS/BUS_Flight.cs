using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Flight
    {
        DAL_Flights dal_flights = new DAL_Flights();

        public DataTable GetFlightsTableByBookingReference(string bookingReference)
        {
            return dal_flights.GetFlightsTableByBookingReference(bookingReference);
        }

        public List<DTO_Flight> GetFlightsListByBookingReference(string bookingReference)
        {
            List<DTO_Flight> lsFlight = new List<DTO_Flight>();
            DataTable dt = GetFlightsTableByBookingReference(bookingReference);

            foreach (DataRow dr in dt.Rows)
            {
                DTO_Flight flight = new DTO_Flight();

                flight.TicketID = dr["TicketID"].ToString();
                flight.FlightNumber = dr["FlightNumber"].ToString();
                flight.DepartureAirportCode = dr["DepartureAirportCode"].ToString();
                flight.ArrivalAirportCode = dr["ArrivalAirportCode"].ToString();
                flight.Date = DateTime.Parse(dr["Date"].ToString()).ToString("MM/dd/yyyy");
                flight.Time = dr["Time"].ToString();

                lsFlight.Add(flight);
            }

            return lsFlight;
        }
    }
}
