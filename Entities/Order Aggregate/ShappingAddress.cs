using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Order_Aggregate
{
    public class ShappingAddress
    {
        public ShappingAddress()
        {
            
        }

        public ShappingAddress(string firstName, string lastName, string street, string city, string county)
        {
            FirstName=firstName;
            LastName=lastName;
            Street=street;
            City=city;
            County=county;
        }

        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Street{ get; set; }
        public string City{ get; set; }
        public string County{ get; set; }
    }
}
