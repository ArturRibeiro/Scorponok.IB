using System;
using Scorponok.IB.Core.Commands;

namespace Scorponok.IB.Domain.Models.Contributions.Commands
{
    public class RegisterContributionCommand : Command
    {
        public double Value { get; private set; }

        public Guid MemberId { get; private set; }

        public short TypeContribution { get; private set; }

        public DateTime DeliveryDate { get; private set; }

        public override bool IsValid()
            => true;
    }
}