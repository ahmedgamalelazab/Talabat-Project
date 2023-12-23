using Contracts;
using Entities.Models;
using Entities.Order_Aggregate;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStripeAppService _paymentService;

        public OrderService(IBasketRepository basketRepo,
                IUnitOfWork unitOfWork,
                IStripeAppService paymentService
            )
        {
            _basketRepo=basketRepo;
            _unitOfWork=unitOfWork;
            _paymentService=paymentService;
        }

        public async Task<Order> CreateOrderAsync
            (string buyerEmail, string basketId, int deliveryMethodDId, ShappingAddress shappingAddress)
        {
            // 1. Get Basket From Baskets Repo
            var basket = await _basketRepo.GetBasketAsync(basketId);
            // 2. Get Selected Items at Basket From Products Repo
            var orderItems = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var productItem = new ProductItemOrder(product.Id, product.Name, product.PictureUrl);
                var orderItem = new OrderItem(productItem, product.Price, item.Quantity);
                orderItems.Add(orderItem);  
            }
            // 3. Calculate SubTotal
            var sbutotal = orderItems.Sum(item => item.Price * item.Quantity);
            // 4. Get Delivery Method From DeliveryMethods Repo
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodDId);
            // 5. Create Order 
            var existingOrder = await _unitOfWork.Repository<Order>().FindById
                (o => o.PaymentIntentId.Equals(basket.PaymentIntentId), trackChanges:false);
            if (existingOrder != null)
            {
                _unitOfWork.Repository<Order>().Delete(existingOrder);
                await _paymentService.CreateOrUpdatePaymentIntent(basketId);
            }
            var order = new Order(buyerEmail, shappingAddress, deliveryMethod, sbutotal, orderItems, basket.PaymentIntentId);
            await _unitOfWork.Repository<Order>().CreateAsync(order);
            // 6. Save to Database [TODO]
            var result = await _unitOfWork.complete();
            if(result<=0)
            {
                return null;
            }
            /*try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                throw;
            }*/

            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
            return deliveryMethod;
        }

        public Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail, bool trackChanges)
        {
            var orders = await _unitOfWork.Repository<Order>().FindByCondition(o => o.BuyerEmail.Equals(buyerEmail),trackChanges, new List<Expression<Func<Order, object>>> { o => o.DeliveryMethod ,o => o.Items }).ToListAsync();
            return orders;
        }
    }
}
