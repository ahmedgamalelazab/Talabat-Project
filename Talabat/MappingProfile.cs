using AutoMapper;
using Entities.Identity;
using Entities.Models;
using Entities.Order_Aggregate;
using Shared.DataTransfierObject;
using System.Configuration;
using Talabat.Helper;

namespace Talabat
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Agent, AgentDto>();
            CreateMap<AgentForCreatingDto, Agent>();
            CreateMap<AgentsForUpdateDto, Agent>();

            CreateMap<Client, ClientDto>()
                .ForMember(d => d.ClientType, o => o.MapFrom(s => s.ClientType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ClientPictureUrlResolver>());
            CreateMap<Client, ClientDto>();
            CreateMap<ClientForCreatingDto, Client>();
            CreateMap<ClientForUpdateDto, Client>();

            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<AddressDto, ShappingAddress>();

            CreateMap<Product, ProductDto>()
                    .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                    .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                    .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());
            CreateMap<CreateProductDto, Product>();

            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, O => O.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.DeliveryMethodCost, O => O.MapFrom(s => s.DeliveryMethod.Cost));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, O => O.MapFrom(s => s.Product.ProductId))
                .ForMember(d => d.ProductName, O => O.MapFrom(s => s.Product.ProductName))
                .ForMember(d => d.PictureUrl, O => O.MapFrom<OrderItemPictureUrlSolver>());
        }
    }
}
