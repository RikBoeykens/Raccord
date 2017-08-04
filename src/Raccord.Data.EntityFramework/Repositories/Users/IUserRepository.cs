using System.Collections.Generic;
using Raccord.Domain.Model.Users;

namespace Raccord.Data.EntityFramework.Repositories.Users
{
    public interface IUserRepository
    {
        ApplicationUser Get(string id);
        ApplicationUser GetSummary(string id);
        ApplicationUser GetFull(string id);
        IEnumerable<ApplicationUser> GetAll();
    }
}