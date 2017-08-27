using Raccord.Domain.Model.ShootingDays;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.ShootingDays
{
    // Repository for Shooting Day
    public class ShootingDayRepository : BaseRepository<ShootingDay>, IShootingDayRepository
    {
        public ShootingDayRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ShootingDay> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(d=> d.ProjectID == projectID);
        }

        public ShootingDay GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(d => d.ID == ID);
        }

        public ShootingDay GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(d => d.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID)
        {
            var query = GetSearchQuery(searchText, projectID);

            return query.Count();
        }

        public IEnumerable<ShootingDay> Search(string searchText, long? projectID)
        {
            return GetSearchQuery(searchText, projectID);

        }

        private IQueryable<ShootingDay> GetIncludedFull()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd=> sd.ShootingDayScenes)
                        .ThenInclude(sds=> sds.Scene)
                        .ThenInclude(s=> s.ShootingDayScenes)
                        .ThenInclude(sds=> sds.ShootingDay)
                        .Include(sd=> sd.ShootingDayScenes)
                        .ThenInclude(sds=> sds.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(sd=> sd.ShootingDayScenes)
                        .ThenInclude(sds=> sds.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(sd=> sd.ShootingDayScenes)
                        .ThenInclude(sds=> sds.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(sd=> sd.ShootingDayScenes)
                        .ThenInclude(sds=> sds.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(isc=> isc.Image)
                        .Include(sd=> sd.ShootingDayScenes)
                        .ThenInclude(sds=> sds.CallsheetScene)
                        .Include(sds=> sds.Slates)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(sds=> sds.Slates)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(sds=> sds.Slates)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.DayNight);
        }

        private IQueryable<ShootingDay> GetIncludedSummary()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd=> sd.ShootingDayScenes);
        }

        private IQueryable<ShootingDay> GetIncluded()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query;
        }


        private IQueryable<ShootingDay> GetSearchQuery(string searchText, long? projectID)
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            query = query.Where(l=> l.Number.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(l=> l.ProjectID==projectID.Value);

            return query;
        }
    }
}
