using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_AmenitiesTickets : DBConnect
    {
        public void InsertARow(DTO_AmenityTicket amenityTicket)
        {
            try
            {
                string query = string.Format("EXEC proc_InsertAmenitiesTickets @amenityID = {0}, @ticketID = {1}", amenityTicket.AmenityID, amenityTicket.TicketID);
                ExcuteNonQuery(query);
            }
            catch (Exception e)
            {
                return;
            }
        }
        
        public void DeleteARow(DTO_AmenityTicket amenityTicket)
        {
            try
            {
                string query = string.Format("delete from AmenitiesTickets where AmenityID like {0} and TicketID like {1}", amenityTicket.AmenityID, amenityTicket.TicketID);
                ExcuteNonQuery(query);
            }
            catch (Exception e)
            {
                return;
            }
        }

        public DataTable GetAmenitiesTicketTableByTicketID(string ticketID)
        {
            try
            {
                string query = string.Format("select * from AmenitiesTickets where TicketID like {0}", ticketID);
                DataTable dt = base.GetTable(query);

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
