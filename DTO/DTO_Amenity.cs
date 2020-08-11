using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Amenity
    {
        private string _ID;
        private string _Service;
        private double _Price;

        public DTO_Amenity(string iD, string service, double price)
        {
            ID = iD;
            Service = service;
            Price = price;
        }

        public DTO_Amenity() { }

        public string ID { get => _ID; set => _ID = value; }
        public string Service { get => _Service; set => _Service = value; }
        public double Price { get => _Price; set => _Price = value; }
    }
}
