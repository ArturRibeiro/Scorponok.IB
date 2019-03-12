using System;
using Scorponok.IB.Core.Models;

namespace Scorponok.IB.Domain.Models.Contributions
{
    public class Contribution : Entity
    {

        public bool IsValid() => true;

        #region Factory

        public static class Factory
        {
            public static Contribution Create()
                => new Contribution()
                {
                    
                };
        }

        #endregion
    }
}