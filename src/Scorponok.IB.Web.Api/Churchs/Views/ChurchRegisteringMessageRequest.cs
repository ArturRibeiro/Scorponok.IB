using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Scorponok.IB.Web.Api.Churchs.Views
{
    [DataContract(Namespace = "Scorponok.IB.Web.Api")]
    public class ChurchRegisteringMessageRequest
    {
        [Required(ErrorMessage = "Name invalid.")]
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Telephone fixed invalid.")]
        [DataMember(Name = "TelephoneFixed")]
        public string TelephoneFixed { get; set; }

        [EmailAddress(ErrorMessage = "E-mail invalid")]
        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "Id")]
        public Guid? Id { get; set; }

        [DataMember(Name = "Photo")]
        public string Photo { get; set; }
        
        [DataMember(Name = "Region")]
        public byte Region { get; set; }

        [DataMember(Name = "Prefix")]
        public byte Prefix { get; set; }

        [DataMember(Name = "MobileTelephone")]
        public string MobileTelephone { get; set; }


    }
}