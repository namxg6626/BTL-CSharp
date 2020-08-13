using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_AmenityTicket
    {
        private string _AmenityID;
        private string _TicketID;
        private double _Price;

        public DTO_AmenityTicket(string amenityID, string ticketID, double price)
        {
            AmenityID = amenityID;
            TicketID = ticketID;
            Price = price;
        }

        public DTO_AmenityTicket() { }
        public string AmenityID { get => _AmenityID; set => _AmenityID = value; }
        public string TicketID { get => _TicketID; set => _TicketID = value; }
        public double Price { get => _Price; set => _Price = value; }
    }
}
