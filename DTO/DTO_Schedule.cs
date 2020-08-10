using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Schedule
    {
        private string _ID;
        private string _Date;
        private string _Time;
        private string _AircraftID;
        private string _RouteID;
        private string _FlightNumber;
        private string _EconomyPrice;
        private string _Confirmed;

        public DTO_Schedule(string iD, string date, string time, string aircraftID, string routeID, string flightNumber, string economyPrice, string confirmed)
        {
            ID = iD;
            Date = date;
            Time = time;
            AircraftID = aircraftID;
            RouteID = routeID;
            FlightNumber = flightNumber;
            EconomyPrice = economyPrice;
            Confirmed = confirmed;
        }

        public DTO_Schedule() { }

        public string ID { get => _ID; set => _ID = value; }
        public string Date { get => _Date; set => _Date = value; }
        public string Time { get => _Time; set => _Time = value; }
        public string AircraftID { get => _AircraftID; set => _AircraftID = value; }
        public string RouteID { get => _RouteID; set => _RouteID = value; }
        public string FlightNumber { get => _FlightNumber; set => _FlightNumber = value; }
        public string EconomyPrice { get => _EconomyPrice; set => _EconomyPrice = value; }
        public string Confirmed { get => _Confirmed; set => _Confirmed = value; }
    }
}
