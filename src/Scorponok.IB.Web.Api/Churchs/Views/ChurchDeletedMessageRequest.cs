using System.Runtime.Serialization;

namespace Scorponok.IB.Web.Api.Churchs.Views
{
    [DataContract(Namespace = "Scorponok.IB.Web.Api")]
    public class ChurchDeletedMessageRequest
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Photo")]
        public string Photo { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "MobileTelephone")]
        public string MobileTelephone { get; set; }

        [DataMember(Name = "TelephoneFixed")]
        public string TelephoneFixed { get; set; }
    }
}