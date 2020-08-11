using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Ticket
    {
        DAL_Tickets dal_tickets = new DAL_Tickets();
        public List<DTO_Ticket> GetTicketsByBookingReference(string bookingReference)
        {
            List<DTO_Ticket> lsTicket = new List<DTO_Ticket>();
            DataTable dt = dal_tickets.GetTicketsTableByBookingReference(bookingReference);

            foreach (DataRow dr in dt.Rows)
            {
                DTO_Ticket ticket = new DTO_Ticket();

                ticket.ID = dr[0].ToString();
                ticket.UserID = dr[1].ToString();
                ticket.ScheduleID = dr[2].ToString();
                ticket.CabinTypeID = dr[3].ToString();
                ticket.FirstName = dr[4].ToString();
                ticket.LastName = dr[5].ToString();
                ticket.Phone = dr[6].ToString();
                ticket.PassportNumber = dr[7].ToString();
                ticket.PassportCountryID = dr[8].ToString();
                ticket.BookingReference = dr[9].ToString();
                ticket.Confirmed = dr[10].ToString();

                lsTicket.Add(ticket);
            }

            return lsTicket;
        }
        
        public DTO_Ticket GetTicketByID(string ID)
        {
            DataTable dt = dal_tickets.GetTicketTableByID(ID);
            DataRow dr = dt.Rows[0];
            DTO_Ticket ticket = new DTO_Ticket();

            ticket.ID = dr["ID"].ToString();
            ticket.UserID = dr["UserID"].ToString();
            ticket.ScheduleID = dr["ScheduleID"].ToString();
            ticket.CabinTypeID = dr["CabinTypeID"].ToString();
            ticket.FirstName = dr["FirstName"].ToString();
            ticket.LastName = dr["LastName"].ToString();
            ticket.Phone = dr["Phone"].ToString();
            ticket.PassportNumber = dr["PassportNumber"].ToString();
            ticket.PassportCountryID = dr["PassportCountryID"].ToString();
            ticket.BookingReference = dr["BookingReference"].ToString();
            ticket.Confirmed = dr["Confirmed"].ToString();

            return ticket;
        }
    }
}
