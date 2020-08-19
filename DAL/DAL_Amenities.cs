using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Amenities : DBConnect
    {
        public DataTable GetAmenitiesTableByCabinTypeID(string cabinTypeID)
        {
			try
			{
				string query = "exec proc_GetAmenitiesByCabinTypeID " + cabinTypeID;
				DataTable dt = base.GetTable(query);

				return dt;
			}
			catch (Exception)
			{
				return null;
			}
        }

		public DataTable GetPurchasedAmenitiesTableByTicketID(string ticketID)
		{
			try
			{
				string query = string.Format("exec proc_GetPurchasedAmenitiesByTicketID {0}", ticketID);
				return base.GetTable(query);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetAllPaidAmenities()
		{
			try
			{
				return this.GetTable("select * from Amenities where price <> 0");
			}
			catch (Exception)
			{
				return null;
			}
		}
    }
}
