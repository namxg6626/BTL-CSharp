using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Flight
    {
        private string _TicketID;
        private string _FlightNumber;
        private string _DepartureAirportCode;
        private string _ArrivalAirportCode;
        private string _Date;
        private string _Time;

        public DTO_Flight(string ticketID, string flightNumber, string departureAirportCode, string arrivalAirportCode, string date, string time)
        {
            TicketID = ticketID;
            FlightNumber = flightNumber;
            DepartureAirportCode = departureAirportCode;
            ArrivalAirportCode = arrivalAirportCode;
            Date = date;
            Time = time;
        }

        public DTO_Flight() { }

        public string TicketID { get => _TicketID; set => _TicketID = value; }
        public string FlightNumber { get => _FlightNumber; set => _FlightNumber = value; }
        public string DepartureAirportCode { get => _DepartureAirportCode; set => _DepartureAirportCode = value; }
        public string ArrivalAirportCode { get => _ArrivalAirportCode; set => _ArrivalAirportCode = value; }
        public string Date { get => _Date; set => _Date = value; }
        public string Time { get => _Time; set => _Time = value; }
    }
}
