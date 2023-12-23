using Entities.Models;
using Entities.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync
             (string buyerEmail, string basketId, int deliveryMethodDId, ShappingAddress shappingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail, bool trackChanges);
        Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
