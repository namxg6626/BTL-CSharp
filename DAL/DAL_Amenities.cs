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
    }
}
