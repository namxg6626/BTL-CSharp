using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CabinType
    {
        private string _ID;
        private string _Name;

        public DTO_CabinType(string iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public DTO_CabinType() { }

        public string ID { get => _ID; set => _ID = value; }
        public string Name { get => _Name; set => _Name = value; }
    }
}
