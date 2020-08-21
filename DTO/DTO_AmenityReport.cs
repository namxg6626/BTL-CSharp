using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_AmenityReport
    {
        private string _FlightNumber;
        private DateTime _From;
        private DateTime _To;

        public DTO_AmenityReport(string flightNumber, DateTime from, DateTime to)
        {
            FlightNumber = flightNumber;
            From = from;
            To = to;
        }

        public string FlightNumber { get => _FlightNumber; set => _FlightNumber = value; }
        public DateTime From { get => _From; set => _From = value; }
        public DateTime To { get => _To; set => _To = value; }
    }
}
