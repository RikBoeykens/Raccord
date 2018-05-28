using Raccord.Domain.Model.Shots;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.Shots.Takes
{
    // Interface defining a repository for Takes
    public interface ITakeRepository : IBaseRepository<Take, long>
    {
        IEnumerable<Take> GetAllForSlate(long slateID);
        Take GetFull(long ID);
        Take GetSummary(long ID);
    }
}