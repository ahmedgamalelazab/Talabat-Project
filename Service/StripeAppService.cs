using Contracts;
using Entities.Models;
using Entities.Order_Aggregate;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

using Stripe;
using Stripe.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product = Entities.Models.Product;

namespace Service
{
    public class StripeAppService : IStripeAppService
    {
        private readonly IConfiguration _Configuration;
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StripeAppService(
            IConfiguration configuration, IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
            _Configuration=configuration;
            _basketRepository=basketRepository;
            _unitOfWork=unitOfWork;
        }


        public async Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _Configuration["StripeSettings:SecretKey"];

            var basket = await _basketRepository.GetBasketAsync(basketId);

            if (basket == null) return null;

            var shippingPrice = 0m;

            if(basket.DelivaryMethodId.HasValue)
            {
                var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(basket.DelivaryMethodId.Value);
                shippingPrice = deliveryMethod.Cost;
                basket.ShippingPrice = shippingPrice;
            }
            /// must when create basket not take shipping price from basket but in database 
            foreach (var item in basket.Items)
            {
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                if (item.Price != product.Price)
                    item.Price = product.Price;

            }

            // create payment Intent create reference PaymentIntent
            PaymentIntent Intent;
            var service = new PaymentIntentService();
            if (string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions()
                {
                    Amount =(long)basket.Items.Sum(item => item.Quantity * item.Price * 100) + (long)shippingPrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string>() { "card" }
                };
                Intent = await service.CreateAsync(options);

                basket.PaymentIntentId = Intent.Id;
                basket.ClientSecret = Intent.ClientSecret;
            }
            else // Update Payment Intent 
            {
                var options = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)basket.Items.Sum(item => item.Quantity * item.Price * 100) + (long)shippingPrice * 100
                };
                await service.UpdateAsync(basket.PaymentIntentId, options);
            }

            await _basketRepository.UpdateBasketAsync(basket);
            return basket;
        }
    }
}
    