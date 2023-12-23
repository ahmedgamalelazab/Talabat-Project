using AutoMapper;

using Entities.Order_Aggregate;
using Shared.DataTransfierObject;

namespace Talabat.Helper
{
    public class OrderItemPictureUrlSolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        public IConfiguration _configuration { get; }

        public OrderItemPictureUrlSolver(IConfiguration configuration)
        {
            _configuration=configuration;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Product.PictureUrl))
                return $"{_configuration["BaseApiUrl"]}/{source.Product.PictureUrl}";
            return null;
        }
    }
}
