using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Order_Aggregate
{
    public class Order : BaseEntity
    {
        public Order()
        {
            
        }

        public Order(string buyerEmail, ShappingAddress shappingAddress, DeliveryMethod deliveryMethod, decimal subTotal, ICollection<OrderItem> items, string paymentIntentId)
        {
            BuyerEmail=buyerEmail;
            ShappingAddress=shappingAddress;
            DeliveryMethod=deliveryMethod;
            SubTotal=subTotal;
            Items=items;
            PaymentIntentId=paymentIntentId;
        }

        public string BuyerEmail{ get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public ShappingAddress ShappingAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; } // navigation proprety [One]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public string? PaymentIntentId { get; set; }

        // Price of the order 
        public decimal SubTotal{ get; set; }
        
        public ICollection<OrderItem> Items { get; set; }  // navigation Propertry [Many]
        public decimal GetTotal()
        {
            return SubTotal + DeliveryMethod.Cost;
        }
    }
}
