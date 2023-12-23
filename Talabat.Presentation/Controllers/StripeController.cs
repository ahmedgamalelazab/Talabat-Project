using Entities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfierObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Presentation.Controllers
{
    [Route("api/payments")]
    [ApiController]
    [Authorize]
    public class StripeController : ControllerBase
    {
        private readonly IStripeAppService _stripeService;

        public StripeController(IStripeAppService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustomerBasketDto>> CreateOrUpdatePaymentIntent(string basketId)
        {
            var basket = _stripeService.CreateOrUpdatePaymentIntent(basketId);
            if (basket is null)
                throw new BasketPaymentBadRequest();
            return Ok(basket);
        }
    }
}
