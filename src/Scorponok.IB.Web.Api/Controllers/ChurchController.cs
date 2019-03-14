using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Domain.Models.Churchs.Commands;
using Scorponok.IB.Web.Api.App.Churchs.Views;
using Scorponok.IB.Web.Api.Utils;

namespace Scorponok.IB.Web.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json"), Route("api/Church")]
    public class ChurchController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        [HttpGet, Route("get")]
        public async Task<IActionResult> GetChurch()
        {
            return Ok(new
            {
                Name = "Artur"
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="bus">Service bus</param>
        /// <param name="notifications">Domain Notification</param>
        public ChurchController(IMapper mapper, IBus bus, INotificationHandler<DomainNotification> notifications)
        : base(notifications)
        {
            _mapper = mapper;
            _bus = bus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [HttpPost, Route("register"), ValidateMessageRequest]
        public async Task<IActionResult> Register([FromBody]ChurchRegisteringMessageRequest view)
        {
            var command = _mapper.Map<RegisterChurchCommand>(view);
            await _bus.SendCommand(command);

            //if (!ModelState.IsValid)
            //{
            //    NotifyModelStateErrors();
            //    return Response(view);
            //}

            //_app.RegisterChurch(view);

            return Response(view);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [HttpPut, Route("update"), ValidateMessageRequest]
        public async Task<IActionResult> UpdateChurch([FromBody] ChurchUpdatedMessageRequest view)
        {
            var command = _mapper.Map<UpdateChurchCommand>(view);
            await _bus.SendCommand(command);
            return Response(view);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="churchId"></param>
        /// <returns></returns>
        [HttpDelete, Route("delete/{churchId:Guid}")]
        public async Task<IActionResult> DeletedChurch(Guid churchId)
        {
            var deleteChurchCommand = DeleteChurchCommand.Factory.Create(churchId);
            await _bus.SendCommand(deleteChurchCommand);
            return Response($"Church: {churchId} deleted.");
        }

    }
}
