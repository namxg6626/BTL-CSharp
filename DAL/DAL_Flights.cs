using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Flights : DBConnect
    {
        public DataTable GetFlightsTableByBookingReference(string bookingReference)
        {
            try
            {
                string query = string.Format("exec proc_GetFlightsByBookingReference '{0}'", bookingReference);
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
