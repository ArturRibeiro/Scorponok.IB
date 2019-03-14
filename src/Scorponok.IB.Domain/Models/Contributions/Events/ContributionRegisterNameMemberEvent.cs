using Scorponok.IB.Core.Events;
using Scorponok.IB.Domain.Models.Members;

namespace Scorponok.IB.Domain.Models.Contributions.Events
{
    public class ContributionRegisterNameMemberEvent : Event
    {
        public Member Member { get; private set; }

        public static class Factory
        {
            public static ContributionRegisterNameMemberEvent Create(Member member)
                => new ContributionRegisterNameMemberEvent() { Member = member };
        }
    }
}