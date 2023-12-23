using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AddressForClient: BaseEntity
    {
        public AddressForClient()
        {
        }

        public AddressForClient(string country, string city, string street, int clientId)
        {
            Country=country;
            City=city;
            Street=street;
            ClientId=clientId;
        }

        public string Country{ get; set; }
        public string City{ get; set; }
        public string Street{ get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
