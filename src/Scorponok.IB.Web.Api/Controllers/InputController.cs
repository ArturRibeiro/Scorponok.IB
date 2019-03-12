using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.Models.Contributions.Commands;
using Scorponok.IB.Web.Api.App.Contributions;
using Scorponok.IB.Web.Api.Utils;

namespace Scorponok.IB.Web.Api.Controllers
{
    [Produces("application/json"), Route("api/Input")]
    public class InputController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public InputController(IMapper mapper, IBus bus, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _mapper = mapper;
            _bus = bus;
        }

        [HttpPost, Route("addValue"), ValidateMessageRequest]
        public async Task<IActionResult> Register([FromBody] ValueMessageRequest request)
        {
            if (!request.IsMember) return Ok();

            var command = _mapper.Map<RegisterContributionCommand>(request);
            await _bus.SendCommand(command);

            return Ok();
        }
    }
}