using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Landy.Services.Offer.Core.Commands;
using src.Services.Offer.Landy.Services.Offer.Core.Queries;

namespace Landy.Services.Offer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        private readonly ILogger<OffersController> logger;
        private readonly IMediator mediator;

        public OffersController(ILogger<OffersController> logger, IMediator mediator)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]GetOffersQuery query)
        {
            var response = await mediator.Send(query);

            return Ok(response.Offers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var query = new GetOfferQuery
            {
                OfferId = id
            };

            var response = await mediator.Send(query);

            return Ok(response.Offer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOfferCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response.Offer);
        }
    }
}
