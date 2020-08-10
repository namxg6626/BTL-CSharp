using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Schedules : DBConnect
    {
        public DataTable GetScheduleTableByID(string ID)
        {
			try
			{
				string query = string.Format("select * from Schedules where ID like '{0}'", ID);
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
