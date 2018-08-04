using Microsoft.AspNetCore.Mvc.Filters;

namespace Scorponok.IB.Web.Api.Utils
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class ValidateMessageRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidateMessageRequestFailedResult(context.ModelState);
            }

            base.OnActionExecuting(context);
        }
    }
}