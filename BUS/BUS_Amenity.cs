using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class BUS_Amenity
    {
        DAL_Amenities dal_amenities = new DAL_Amenities();
        public DataTable GetAmenitiesTableByCabinTypeID(string cabinTypeID)
        {
            return dal_amenities.GetAmenitiesTableByCabinTypeID(cabinTypeID);
        }
        public List<DTO_Amenity> GetAmenitiesListByCabinTypeID(string cabinTypeID)
        {
            List<DTO_Amenity> lsAmenities = new List<DTO_Amenity>();
            DataTable dt = GetAmenitiesTableByCabinTypeID(cabinTypeID);

            foreach (DataRow dr in dt.Rows)
            {
                DTO_Amenity amenity = new DTO_Amenity();

                amenity.ID = dr["ID"].ToString();
                amenity.Service = dr["Service"].ToString();
                amenity.Price = double.Parse(dr["Price"].ToString());

                lsAmenities.Add(amenity);
            }

            return lsAmenities;
        }

        public List<DTO_Amenity> GetPurchasedAmenitiesListByTicketID(string ticketID)
        {
            List<DTO_Amenity> lsAmenities = new List<DTO_Amenity>();
            DataTable dt = dal_amenities.GetPurchasedAmenitiesTableByTicketID(ticketID);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DTO_Amenity amenity = new DTO_Amenity();
                    amenity.ID = dr["ID"].ToString();
                    amenity.Service = dr["Service"].ToString();
                    amenity.Price = double.Parse(dr["Price"].ToString());

                    lsAmenities.Add(amenity);
                }
            }

            return lsAmenities;
        }
    }
}
