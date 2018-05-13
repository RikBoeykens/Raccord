using Raccord.Domain.Model.ShootingDays;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Raccord.Data.EntityFramework.Repositories.ShootingDays
{
    // Repository for Shooting Day
    public class ShootingDayRepository : BaseRepository<ShootingDay>, IShootingDayRepository
    {
        public ShootingDayRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ShootingDay> GetAllForCrewUnit(long crewUnitID)
        {
            var query = GetIncludedSummary();

            return query.Where(d=> d.CrewUnitID == crewUnitID);
        }

        public IEnumerable<ShootingDay> GetAllForProject(long projectID)
        {
            var query = GetIncludedProject();

            return query.Where(d=> d.CrewUnit.ProjectID == projectID);
        }

        public IEnumerable<ShootingDay> GetAllBeforeDate(long crewUnitID, DateTime date)
        {
            var query = GetIncludedSummary();

            return query.Where(d=> d.CrewUnitID == crewUnitID && d.Date < date);
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

        public IEnumerable<ShootingDay> GetAllForScene(long sceneID)
        {
            var query = GetIncludedScene();

            return query.Where(sd => sd.ShootingDayScenes.Any(sds=> sds.SceneID == sceneID)
                                    ||
                                    sd.CallsheetID.HasValue && sd.Callsheet.CallsheetScenes.Any(cs=> cs.SceneID==sceneID)
                                    ||
                                    sd.ScheduleDayID.HasValue && sd.ScheduleDay.ScheduleScenes.Any(ss=> ss.SceneID == sceneID)
                                    );
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

        public IEnumerable<ShootingDay> GetAllForCrewUnitCalendar(long[] crewUnitIDs, DateTime start, DateTime end){
            var query = GetIncludedCalendarCrewUnit();

            return query.Where(sd => 
                (sd.Date >= start && sd.Date < end)
                &&
                crewUnitIDs.Any(cid => cid == sd.CrewUnitID)
                );
        }

        public IEnumerable<ShootingDay> GetAllForCharacterCalendar(long[] characterIds, DateTime start, DateTime end){
            var query = GetIncludedCalendarCharacter();

            return query.Where(sd => 
                (sd.Date >= start && sd.Date < end)
                &&
                (
                    characterIds.Any(cid => sd.Callsheet.CallsheetScenes.Any(cs => cs.Characters.Any(c => c.CharacterScene.CharacterID == cid)))
                    ||
                    characterIds.Any(cid => sd.ScheduleDay.ScheduleScenes.Any(ss => ss.Characters.Any(c => c.CharacterScene.CharacterID == cid)))
                )
                );
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
                        .ThenInclude(sl=> sl.LocationSets)
                        .ThenInclude(ls=> ls.Location)
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
                        .ThenInclude(s=> s.DayNight)
                        .Include(sds=> sds.Slates)
                        .ThenInclude(sds=> sds.Takes)
                        .Include(sd=> sd.ShootingDayScenes)
                        .ThenInclude(sds=> sds.LocationSet)
                        .ThenInclude(ls=> ls.Location)
                        .Include(sd => sd.CrewUnit);
        }

        private IQueryable<ShootingDay> GetIncludedSummary()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd=> sd.ShootingDayScenes)
                        .Include(sd=> sd.Slates);
        }

        private IQueryable<ShootingDay> GetIncluded()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query;
        }

        private IQueryable<ShootingDay> GetIncludedProject()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd => sd.CrewUnit);
        }

        private IQueryable<ShootingDay> GetIncludedSearch()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd => sd.CrewUnit);
        }

        private IQueryable<ShootingDay> GetSearchQuery(string searchText, long? projectID)
        {
            var query = GetIncludedSearch();

            query = query.Where(l=> l.Number.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(l=> l.CrewUnit.ProjectID==projectID.Value);

            return query;
        }

        private IQueryable<ShootingDay> GetIncludedScene()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd=> sd.ShootingDayScenes)
                        .Include(sd=> sd.ScheduleDay)
                        .ThenInclude(sd=> sd.ScheduleScenes)
                        .Include(sd=> sd.Callsheet)
                        .ThenInclude(cs=> cs.CallsheetScenes);
        }

        private IQueryable<ShootingDay> GetIncludedCalendarCrewUnit()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd => sd.CrewUnit)
                            .ThenInclude(sd => sd.Project)
                        .Include(sd => sd.Callsheet)
                        .Include(sd => sd.ScheduleDay)
                            .ThenInclude(sd => sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Characters);
        }

        private IQueryable<ShootingDay> GetIncludedCalendarCharacter()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd => sd.CrewUnit)
                            .ThenInclude(sd => sd.Project)
                        .Include(sd => sd.ShootingDayScenes)
                        .Include(sd => sd.Callsheet)
                            .ThenInclude(c => c.CallsheetScenes)
                                .ThenInclude(cs => cs.Characters)
                        .Include(sd => sd.ScheduleDay)
                            .ThenInclude(sd => sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Characters);
        }
    }
}
