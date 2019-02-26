using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scorponok.IB.Core.Notifications;

namespace Scorponok.IB.Web.Api.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;

        protected ApiController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected IEnumerable<DomainNotification> Notifications
            => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected async Task NotifyModelStateErrors()
        {
            foreach (var err in ModelState.Values.SelectMany(v => v.Errors))
            {
                var errMsg = err.Exception == null ? err.ErrorMessage : err.Exception.Message;
                await NotifyError(string.Empty, errMsg);
            }
        }

        protected async Task NotifyError(string code, string message)
            => await _notifications.Handle(new DomainNotification(code, message), default(CancellationToken));

        //protected void AddIdentityErrors(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        NotifyError(result.ToString(), error.Description);
        //    }
        //}
    }
}