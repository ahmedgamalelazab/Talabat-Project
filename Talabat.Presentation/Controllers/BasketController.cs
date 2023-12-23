using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransfierObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Presentation.Controllers
{
    [ApiController]
    [Route("api/basket")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        
        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository=basketRepository;
            _mapper=mapper;
        }

        [HttpGet] // Get : /api/basket?id = 1
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost] // Post : /api/basket
        public async Task<IActionResult> UpdateBasket(CustomerBasketDto customer)
        {
            var CustomerBasketMapped = _mapper.Map<CustomerBasketDto, CustomerBasket>(customer);
            var updateOrCreatedBasket = await _basketRepository.UpdateBasketAsync(CustomerBasketMapped);
            return Ok(updateOrCreatedBasket);
        }

        [HttpDelete] //Delete : /api/basket
        public async Task DeleteBasket(string id)
        {
            await _basketRepository.DeleteBasket(id);
        }

    }
}
