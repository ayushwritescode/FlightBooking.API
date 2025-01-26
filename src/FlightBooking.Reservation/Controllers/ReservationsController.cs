using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlightBooking.Reservation.Application.Mediator.Commands;
using FlightBooking.Reservation.Application.Mediator.Queries.Reservation;

namespace FlightBooking.Reservation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class ReservationsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ReservationsController(IMediator mediator, ILogger<ReservationsController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        [HttpGet("{reservationCode}")]
        public IActionResult GetReservation(string reservationCode)
        {
            var query = new GetReservationQuery() { ReservationNumber = reservationCode };

            if (string.IsNullOrEmpty(query.ReservationNumber))
                return BadRequest();

            var result = _mediator.Send(query).Result;

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommand command)
        {
            if (command == null)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Created(Url.RouteUrl(result), result);
        }
    }

}
