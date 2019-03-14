using System;
using System.Collections.Generic;
using System.Diagnostics;
using Scorponok.IB.Core.Models;
using Scorponok.IB.Domain.Models.Contributions;

namespace Scorponok.IB.Domain.Models.Members
{
    public class Member : Entity
    {

        #region Properties

        public string Name { get; private set; }

        public IList<Contribution> Contributions { get; private set; }

        #endregion

        #region Factory

        public static class Factory
        {
            public static Member Create(string name, Guid memberId)
                => new Member()
                {
                    Name = name,
                    Id = memberId
                };
        }

        #endregion

    }
}