using System;
using System.Runtime.Serialization;

namespace Scorponok.IB.Web.Api.App.Contributions
{
    [DataContract(Namespace = "Scorponok.IB.Web.Api")]
    public class ValueMessageRequest
    {
        [DataMember(Name = "Value")]
        public double Value { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "MemberId")]
        public Guid MemberId { get; set; }

        [DataMember(Name = "TypeContribution")]
        public short TypeContribution { get; set; }

        [DataMember(Name = "ContributionDate")]
        public DateTime ContributionDate { get; set; }

        public bool IsMember => !string.IsNullOrEmpty(this.Name);
    }
}