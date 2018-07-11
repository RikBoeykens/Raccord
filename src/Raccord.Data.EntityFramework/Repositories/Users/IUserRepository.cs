using System.Collections.Generic;
using Raccord.Domain.Model.Users;

namespace Raccord.Data.EntityFramework.Repositories.Users
{
    public interface IUserRepository
    {
        ApplicationUser Get(string id);
        ApplicationUser GetSummary(string id);
        ApplicationUser GetFull(string id);
        ApplicationUser GetFullAdmin(string id);
        ApplicationUser GetForPermissions(string id);
        IEnumerable<ApplicationUser> GetAll();
        void Edit(ApplicationUser entity);
        void Commit();
        int SearchCount(string searchText, string userID, string[] excludeIds);
        IEnumerable<ApplicationUser> Search(string searchText, string userID, string[] excludeIds);
    }
}