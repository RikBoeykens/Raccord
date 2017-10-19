using System.Collections.Generic;
using Raccord.Domain.Model.Crew.CrewMembers;

namespace Raccord.Data.EntityFramework.Repositories.Crew.CrewMembers
{
    // Interface defining a repository for crew members
    public interface ICrewMemberRepository : IBaseRepository<CrewMember>
    {
        IEnumerable<CrewMember> GetAllForDepartment(long departmentID);
        CrewMember GetFull(long ID);
        CrewMember GetSummary(long ID);
        int SearchCount(string searchText, long? projectID, string userID, bool isAdmin);
        IEnumerable<CrewMember> Search(string searchText, long? projectID, string userID, bool isAdmin);
    }
}