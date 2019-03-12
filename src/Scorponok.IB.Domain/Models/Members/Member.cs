using System.Collections.Generic;
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

    }
}