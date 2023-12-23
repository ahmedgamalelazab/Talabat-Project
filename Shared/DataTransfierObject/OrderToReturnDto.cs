using Entities.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransfierObject
{
    public class OrderToReturnDto 
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public ShappingAddress ShappingAddress { get; set; }
        public string DeliveryMethod { get; set; } // navigation proprety [One]
        public decimal DeliveryMethodCost { get; set; }
        public string OrderStatus { get; set; } 
        public string PaymentIntentId { get; set; }

        // Price of the order 
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderItemDto> Items { get; set; }  // navigation Propertry [Many]
    }
}
