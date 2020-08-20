using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_AmenityReport : DBConnect
    {
        public DataTable GetReportByAmenityIDAndCabinID(string flightNumber, string amenityID, string cabinID, string dateFrom, string dateTo)
        {
			try
			{
				string query = string.Format("select * from func_GetReportByAmenityIDAndCabinID(N'{0}', {1}, {2}, '{3}', '{4}')", flightNumber, amenityID, cabinID, dateFrom, dateTo);
				DataTable dt = this.GetTable(query);

				return dt;
			}
			catch (Exception)
			{
				return null;
			}
        }

		public DataTable GetAllPurchasedAmenitiesReportTable(string flightNumber, string dateFrom, string dateTo)
		{
			try
			{
				DataTable result = new DataTable();
				DAL_Amenities dal_amenities = new DAL_Amenities();
				DAL_CabinTypes dal_cabinTypes = new DAL_CabinTypes();
				DataTable amenitiesTable = dal_amenities.GetAllAmenities();
				DataTable cabinTypesTable = dal_cabinTypes.GetAllCabinTypesTable();

				result.Columns.Add("Name");

				foreach (DataRow dr in amenitiesTable.Rows)
					result.Columns.Add(dr["Service"].ToString());

				foreach (DataRow drCabin in cabinTypesTable.Rows)
				{
					DataRow dr;
					dr = result.NewRow();
					dr["Name"] = drCabin["Name"].ToString();

					foreach (DataRow drAmenity in amenitiesTable.Rows)
					{
						DataTable dt = this.GetReportByAmenityIDAndCabinID(flightNumber, drAmenity["ID"].ToString(), drCabin["ID"].ToString(), dateFrom, dateTo);
						try
						{
							dr[drAmenity["Service"].ToString()] = dt.Rows[0]["Total"];
						}
						// if no row exists, set to 0
						catch (Exception)
						{
							dr[drAmenity["Service"].ToString()] = "0";
						}
					}

					result.Rows.Add(dr);
				}

				return result;
			}
			catch (Exception e)
			{
				return null;
			}
		}
    }
}
