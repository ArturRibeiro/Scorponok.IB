using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Scorponok.IB.Web.Api.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateMessageRequestFailedResult : ObjectResult
    {
        public ValidateMessageRequestFailedResult(ModelStateDictionary modelState)
            : base(new ValidateMessageRequestResult(modelState))
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}