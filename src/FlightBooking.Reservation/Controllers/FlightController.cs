using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlightBooking.Reservation.Application.Mediator.Queries.Flight;

namespace FlightBooking.Reservation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class FlightController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public FlightController(IMediator mediator, ILogger<FlightController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        [HttpGet()]
        public async Task<IActionResult> GetByParamsAsync(GetFlightsByParamQuery requestParams)
        {
            if (string.IsNullOrEmpty(requestParams.Destination) || string.IsNullOrEmpty(requestParams.Origin))
            {
                return BadRequest();
            }

            var result = await _mediator.Send(requestParams);

            if (result?.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
