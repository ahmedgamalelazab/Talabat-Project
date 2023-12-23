using AutoMapper;
using Contracts;
using Entities.Order_Aggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository;
using Service.Contracts;
using Shared.DataTransfierObject;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<DeliveryMethod> _delivaryRepo;

        public OrderController(IOrderService order, IMapper mapper, IRepositoryBase<DeliveryMethod> delivaryRepo)
        {
            _order=order;
            _mapper=mapper;
            _delivaryRepo=delivaryRepo;
        }

        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto orderDto)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email); 
            var mapAddress = _mapper.Map<AddressDto, ShappingAddress>(orderDto.ShipToAddress);
            var order = await _order.CreateOrderAsync(buyerEmail, orderDto.BasketId, orderDto.DeliveryMethodId, mapAddress);
            
            if (order == null) return BadRequest();
            return Ok(_mapper.Map<Order, OrderToReturnDto>(order));
        }

        [HttpGet] // Get : api/Orders
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrdersForUser()
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var orders = await _order.GetOrdersForUserAsync(buyerEmail, trackChanges:false);
            return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders));
        }

        [HttpGet("deliveryMethods")]
        public async Task<IActionResult> GetAllDelivery()
        {
            var delivaryMethod = await _order.GetDeliveryMethodsAsync();
            return Ok(delivaryMethod);
        }

        [HttpGet("{delivaryMethodId}")]
        public async Task<IActionResult> GetDelivaryMethodId(int delivaryMethodId)
        {
            var delivaryMethod = await _delivaryRepo.GetByIdAsync(delivaryMethodId);
            return Ok(delivaryMethod);
        }
    }
}
