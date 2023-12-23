using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Order_Aggregate
{
    public class DeliveryMethod : BaseEntity
    {
        public DeliveryMethod()
        {
            
        }

        public DeliveryMethod(string shortName, string deliveryTIme, string description, decimal cost)
        {
            ShortName=shortName;
            DeliveryTIme=deliveryTIme;
            Description=description;
            Cost=cost;
        }

        public string ShortName{ get; set; }
        public string DeliveryTIme{ get; set; }
        public string Description{ get; set; }
        public decimal Cost{ get; set; }

    }
}
