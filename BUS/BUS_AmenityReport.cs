using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_AmenityReport
    {
        DAL_AmenityReport dal_amenityReport = new DAL_AmenityReport();
        public DataTable GetAmenitiesReportTable(DTO_AmenityReport amenityReport)
        {
            return dal_amenityReport.GetAmenitiesReportTable(amenityReport);
        }
    }
}
