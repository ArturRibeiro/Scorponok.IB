using System;
using Scorponok.IB.Core.Models;
using Scorponok.IB.Domain.Models.Members;

namespace Scorponok.IB.Domain.Models.Contributions
{
    public class Contribution : Entity
    {
        #region Properties
        public double Value { get; private set; }

        public DateTime Registered { get; private set; } = DateTime.Now;

        public DateTime DeliveryDate { get; private set; }

        public TypeContribution TypeContribution { get; private set; }

        public Member Member { get; private set; }

        #endregion

        public bool IsValid() => true;

        #region Factory

        public static class Factory
        {
            public static Contribution Create(Member member, DateTime contributionDate, double value, TypeContribution typeContribution)
                => new Contribution()
                {
                    Member = member,
                    DeliveryDate = contributionDate,
                    Value = value,
                    TypeContribution = typeContribution
                };
        }

        #endregion
    }
}