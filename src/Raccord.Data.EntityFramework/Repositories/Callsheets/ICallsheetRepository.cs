using Raccord.Domain.Model.Callsheets;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets
{
    // Interface defining a repository for Int/Ext
    public interface ICallsheetRepository : IBaseRepository<Callsheet, long>
    {
        IEnumerable<Callsheet> GetAllForCrewUnit(long crewUnitID);
        IEnumerable<Callsheet> GetAllForProject(long projectID);
        Callsheet GetFull(long ID);
        Callsheet GetSummary(long ID);
        int SearchCount(string searchText, long? projectID);
        IEnumerable<Callsheet> Search(string searchText, long? projectID);
    }
}