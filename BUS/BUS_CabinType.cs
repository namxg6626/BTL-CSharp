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
    public class BUS_CabinType
    {
        public BUS_CabinType() { }

        private DAL_CabinTypes dal_cabinTypes = new DAL_CabinTypes();
        public DTO_CabinType GetCabinTypeByID(string cabinTypeID)
        {
            DataTable dt = dal_cabinTypes.GetCabinTypeTableByID(cabinTypeID);
            DataRow dr = dt.Rows[0];
            DTO_CabinType cabinType = new DTO_CabinType();

            cabinType.ID = dr[0].ToString();
            cabinType.Name = dr[1].ToString();

            return cabinType;
        }
    }
}
