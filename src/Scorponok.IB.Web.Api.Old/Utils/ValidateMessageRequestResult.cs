using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Scorponok.IB.Web.Api.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateMessageRequestResult
    {
        public string Message { get; } = "Validation Failed";

        public List<ValidateMessageRequestError> Errors { get; }

        public ValidateMessageRequestResult(ModelStateDictionary modelState)
            => Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidateMessageRequestError(key, x.ErrorMessage)))
                .ToList();
    }
}