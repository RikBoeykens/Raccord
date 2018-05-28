using Raccord.Domain.Model.Callsheets;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets
{
    // Repository for Shooting Day
    public class CallsheetRepository : BaseRepository<Callsheet, long>, ICallsheetRepository
    {
        public CallsheetRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<Callsheet> GetAllForCrewUnit(long crewUnitID)
        {
            var query = GetIncludedCrewUnit();

            return query.Where(d=> d.CrewUnitID == crewUnitID);
        }

        public IEnumerable<Callsheet> GetAllForProject(long projectID)
        {
            var query = GetIncludedCrewUnit();

            return query.Where(d=> d.CrewUnit.ProjectID == projectID);
        }

        public Callsheet GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(d => d.ID == ID);
        }

        public Callsheet GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(d => d.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID)
        {
            var query = GetSearchQuery(searchText, projectID);

            return query.Count();
        }

        public IEnumerable<Callsheet> Search(string searchText, long? projectID)
        {
            return GetSearchQuery(searchText, projectID);

        }

        private IQueryable<Callsheet> GetIncludedFull()
        {
            IQueryable<Callsheet> query = _context.Set<Callsheet>();

            return query.Include(sd=> sd.CallsheetScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(sd=> sd.CallsheetScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(sd=> sd.CallsheetScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(sd=> sd.CallsheetScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(i=> i.Image)
                        .Include(ss=> ss.CallsheetScenes)
                        .ThenInclude(ss=> ss.Characters)
                        .ThenInclude(cs=> cs.CharacterScene)
                        .ThenInclude(cs=> cs.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=> ic.Image)
                        .Include(sd=> sd.CallsheetScenes)
                        .ThenInclude(ss=> ss.LocationSet)
                        .ThenInclude(ls=> ls.Location)
                        .Include(sd=> sd.CallsheetScenes)
                        .ThenInclude(ss=> ss.LocationSet)
                        .ThenInclude(ls=> ls.ScriptLocation)
                        .Include(sd=> sd.CallsheetScenes)
                        .ThenInclude(ss=> ss.Scene)
                        .ThenInclude(s=> s.BreakdownItemScenes)
                        .ThenInclude(bis=> bis.BreakdownItem)
                        .Include(sd=> sd.ShootingDay)
                        .Include(cs=> cs.CallsheetCharacters)
                        .ThenInclude(cc=> cc.Character)
                        .ThenInclude(c=> c.ImageCharacters)
                        .ThenInclude(ic=>ic.Image)
                        .Include(cs=> cs.CallsheetCharacters)
                        .ThenInclude(cc=> cc.CharacterCalls)
                        .ThenInclude(cc=> cc.CallType)
                        .Include(cs=> cs.CallsheetCharacters)
                        .ThenInclude(cc=> cc.Character)
                        .ThenInclude(cc => cc.CastMember)
                        .ThenInclude(cm => cm.ProjectUser)
                        .ThenInclude(cm => cm.User)
                        .Include(cs => cs.CrewUnit);
        }

        private IQueryable<Callsheet> GetIncludedSummary()
        {
            IQueryable<Callsheet> query = _context.Set<Callsheet>();

            return query.Include(cs=> cs.ShootingDay);
        }

        private IQueryable<Callsheet> GetIncludedCrewUnit()
        {
            IQueryable<Callsheet> query = _context.Set<Callsheet>();

            return query.Include(cs=> cs.ShootingDay)
                        .Include(sd => sd.CrewUnit);
        }

        private IQueryable<Callsheet> GetIncluded()
        {
            IQueryable<Callsheet> query = _context.Set<Callsheet>();

            return query.Include(cs=> cs.ShootingDay);
        }

        private IQueryable<Callsheet> GetIncludedSearch()
        {
            IQueryable<Callsheet> query = _context.Set<Callsheet>();

            return query.Include(cs=> cs.ShootingDay)
                        .Include(cs => cs.CrewUnit);
        }


        private IQueryable<Callsheet> GetSearchQuery(string searchText, long? projectID)
        {
            var query = GetIncludedSearch();

            query = query.Where(l=> l.ShootingDay.Number.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(l=> l.CrewUnit.ProjectID==projectID.Value);

            return query;
        }
    }
}
