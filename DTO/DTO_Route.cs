using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Route
    {
        private string _ID;
        private string _DepartureAirportID;
        private string _ArrivalAirportID;
        private string _Distance;
        private string _FlightTime;

        public DTO_Route(string iD, string departureAirportID, string arrivalAirportID, string distance, string flightTime)
        {
            ID = iD;
            DepartureAirportID = departureAirportID;
            ArrivalAirportID = arrivalAirportID;
            Distance = distance;
            FlightTime = flightTime;
        }

        public DTO_Route() { }

        public string ID { get => _ID; set => _ID = value; }
        public string DepartureAirportID { get => _DepartureAirportID; set => _DepartureAirportID = value; }
        public string ArrivalAirportID { get => _ArrivalAirportID; set => _ArrivalAirportID = value; }
        public string Distance { get => _Distance; set => _Distance = value; }
        public string FlightTime { get => _FlightTime; set => _FlightTime = value; }
    }
}
