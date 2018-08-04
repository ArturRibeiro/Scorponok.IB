using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.Models.Churchs.Commands;
using Scorponok.IB.Web.Api.Churchs.Views;
using Scorponok.IB.Web.Api.Utils;

namespace Scorponok.IB.Web.Api.Controllers
{
    [Produces("application/json"), Route("api/Church")]
    public class ChurchController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="bus">Service bus</param>
        /// <param name="notifications">Domain Notification</param>
        public ChurchController(IMapper mapper, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        : base(notifications)
        {
            _mapper = mapper;
            _bus = bus;
        }

        [HttpPost, Route("register"), ValidateMessageRequest]
        public IActionResult Post([FromBody]ChurchRegisteringMessageRequest view)
        {
            var command = _mapper.Map<RegisterChurchCommand>(view);
            _bus.SendCommand(command);

            //if (!ModelState.IsValid)
            //{
            //    NotifyModelStateErrors();
            //    return Response(view);
            //}

            //_app.RegisterChurch(view);

            return Response(view);
        }

        [HttpPut("{id}"), Route("update")]
        public IActionResult UpdateChurch([FromBody] ChurchUpdatedMessageRequest view)
        {
            var command = _mapper.Map<RegisterChurchCommand>(view);
            _bus.SendCommand(command);
            return Response(view);
        }

        [HttpDelete("{id}"), Route("delete")]
        public IActionResult DeletedChurch(ChurchDeletedMessageRequest view)
        {
            var command = _mapper.Map<DeleteChurchCommand>(view);
            _bus.SendCommand(command);
            return Response(view);
        }

    }
}
