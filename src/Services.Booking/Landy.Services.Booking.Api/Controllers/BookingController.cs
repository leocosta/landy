using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using Landy.Services.Booking.Core.Commands;
using System;
using Landy.Services.Booking.Core.Queries;

namespace Landy.Services.Booking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> logger;
        private readonly IMediator mediator;

        public BookingController(ILogger<BookingController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("book")]
        public async Task<IActionResult> CreateAsync([FromBody]CreateBookCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("book/{id}")]
        public async Task<IActionResult> GetBook([FromQuery]Guid id)
        {
            var query = new GetBookQuery { BookId = id };
            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        [Route("checkout")]
        public async Task<IActionResult> CheckoutAsync([FromBody]CreateCheckoutCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }
    }
}
