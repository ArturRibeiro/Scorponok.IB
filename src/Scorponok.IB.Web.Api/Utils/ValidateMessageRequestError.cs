using Newtonsoft.Json;

namespace Scorponok.IB.Web.Api.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateMessageRequestError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        public string Message { get; }

        public ValidateMessageRequestError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
}