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
    public class BUS_AmenityTicket
    {
        DAL_AmenitiesTickets dal_amenitiesTickets = new DAL_AmenitiesTickets();
        public void InsertARow(DTO_AmenityTicket amenityTicket)
        {
            dal_amenitiesTickets.InsertARow(amenityTicket);
        }

        public void DeleteArow(DTO_AmenityTicket amenityTicket)
        {
            dal_amenitiesTickets.DeleteARow(amenityTicket);
        }

        public List<DTO_AmenityTicket> GetAmenitiesTicketListByTicketID(string ticketID)
        {
            List<DTO_AmenityTicket> lsAmenitiesTicket = new List<DTO_AmenityTicket>();
            DataTable dt = dal_amenitiesTickets.GetAmenitiesTicketTableByTicketID(ticketID);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DTO_AmenityTicket amenityTicket = new DTO_AmenityTicket();
                    amenityTicket.AmenityID = dr["AmenityID"].ToString();
                    amenityTicket.TicketID = dr["TicketID"].ToString();
                    amenityTicket.Price = double.Parse(dr["Price"].ToString());

                    lsAmenitiesTicket.Add(amenityTicket);
                }
            }

            return lsAmenitiesTicket;
        }
    }
}
