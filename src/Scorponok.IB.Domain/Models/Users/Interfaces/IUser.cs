using System.Collections.Generic;
using System.Security.Claims;

namespace Scorponok.IB.Domain.Models.Users.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}