using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Tickets : DBConnect
    {
        public DataTable GetAllTicketsTable()
        {
			try
			{
				DataTable dt = base.GetTable("select * from Tickets");
				return dt;
			}
			catch (Exception)
			{
				return null;
			}
        }
		public DataTable GetTicketsTableByBookingReference(string bookingReference)
		{
			try
			{
				string query = string.Format("select * from Tickets where BookingReference like '{0}'", bookingReference);
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
