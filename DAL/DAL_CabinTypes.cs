using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CabinTypes : DBConnect
    {
        public DataTable GetAllCabinTypesTable()
        {
			try
			{
				DataTable dt = base.GetTable("select * from CabinTypes");
				return dt;
			}
			catch (Exception)
			{
				return null;
			}
        }
		public DataTable GetCabinTypeTableByID(string cabinTypeID)
		{
			try
			{
				string query = string.Format("select * from CabinTypes where ID like '{0}'", cabinTypeID);
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
