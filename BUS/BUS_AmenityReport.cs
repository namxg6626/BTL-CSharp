using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_AmenityReport
    {
        DAL_AmenityReport dal_amenityReport = new DAL_AmenityReport();
        public DataTable GetAllPurchasedAmenitiesReportTable(string flightNumber, string dateFrom, string dateTo)
        {
            return dal_amenityReport.GetAllPurchasedAmenitiesReportTable(flightNumber, dateFrom, dateTo);
        }
    }
}
