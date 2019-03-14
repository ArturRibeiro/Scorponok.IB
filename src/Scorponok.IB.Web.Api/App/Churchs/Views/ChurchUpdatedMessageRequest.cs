using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Scorponok.IB.Web.Api.App.Churchs.Views
{
    [DataContract(Namespace = "Scorponok.IB.Web.Api")]
    public class ChurchUpdatedMessageRequest
    {
        [Required(ErrorMessage = "id invalid.")]
        [DataMember(Name = "Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name invalid.")]
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Photo")]
        public string Photo { get; set; }

        [Required(ErrorMessage = "Email invalid.")]
        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile invalid.")]
        [DataMember(Name = "CellPhone")]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "Telephone fixed invalid.")]
        [DataMember(Name = "HomePhone")]
        public string HomePhone { get; set; }
    }
}