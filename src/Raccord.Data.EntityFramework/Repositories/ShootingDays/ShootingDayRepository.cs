using Raccord.Domain.Model.ShootingDays;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Raccord.Data.EntityFramework.Repositories.ShootingDays
{
    // Repository for Shooting Day
    public class ShootingDayRepository : BaseRepository<ShootingDay, long>, IShootingDayRepository
    {
        public ShootingDayRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ShootingDay> GetAllForCrewUnit(long crewUnitID)
        {
            var query = GetIncludedSummary();

            return query.Where(d=> d.CrewUnitID == crewUnitID).OrderBy(sd => sd.Date);
        }

        public IEnumerable<ShootingDay> GetAllForProject(long projectID)
        {
            var query = GetIncludedProject();

            return query.Where(d=> d.CrewUnit.ProjectID == projectID).OrderBy(sd => sd.Date);
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

        public IEnumerable<ShootingDay> GetAllForCharacters(long[] characterIDs)
        {
            var query = GetIncludedCharacter();

            return query.Where(sd => characterIDs.Any(cId => sd.CallsheetID.HasValue && sd.Callsheet.CallsheetScenes.Any(cs=> cs.Characters.Any(c => c.CharacterScene.CharacterID == cId)))
                                    ||
                                    characterIDs.Any(cId => sd.ScheduleDayID.HasValue && sd.ScheduleDay.ScheduleScenes.Any(ss=> ss.Characters.Any(c => c.CharacterScene.CharacterID == cId)))
                                    );
        }

        public IEnumerable<ShootingDay> GetAllForLocationSets(long[] locationSetIDs)
        {
            var query = GetIncludedLocationSet();

            return query.Where(sd => locationSetIDs.Any(lId => sd.CallsheetID.HasValue && sd.Callsheet.CallsheetScenes.Any(cs => cs.LocationSetID == lId))
                                    ||
                                    locationSetIDs.Any(lId => sd.ScheduleDayID.HasValue && sd.ScheduleDay.ScheduleScenes.Any(cs => cs.LocationSetID == lId))
                                    );
        }

        public IEnumerable<ShootingDay> GetAllForBreakdownItem(long breakdownItemID)
        {
            var query = GetIncludedBreakdownItem();

            return query.Where(sd => sd.ShootingDayScenes.Any(sds=> sds.Scene.BreakdownItemScenes.Any(bis => bis.BreakdownItemID == breakdownItemID))
                                    ||
                                    sd.CallsheetID.HasValue && sd.Callsheet.CallsheetScenes.Any(cs=> cs.Scene.BreakdownItemScenes.Any(bis => bis.BreakdownItemID == breakdownItemID))
                                    ||
                                    sd.ScheduleDayID.HasValue && sd.ScheduleDay.ScheduleScenes.Any(ss=> ss.Scene.BreakdownItemScenes.Any(bis => bis.BreakdownItemID == breakdownItemID))
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

        public IEnumerable<ShootingDay> GetAllForCrewUnitCalendarScenes(long[] crewUnitIDs, DateTime start, DateTime end){
            var query = GetIncludedCalendarCrewUnitScenes();

            return query.Where(sd =>
                (sd.Date >= start && sd.Date < end)
                &&
                crewUnitIDs.Any(cid => cid == sd.CrewUnitID)
                );
        }

        public IEnumerable<ShootingDay> GetAllForCharacterCalendarScenes(long[] characterIds, DateTime start, DateTime end){
            var query = GetIncludedCalendarCharacterScenes();

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
                        .ThenInclude(s=> s.SceneIntro)
                        .Include(sd=> sd.ShootingDayScenes)
                        .ThenInclude(sds=> sds.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .ThenInclude(sl=> sl.LocationSets)
                        .ThenInclude(ls=> ls.Location)
                        .Include(sd=> sd.ShootingDayScenes)
                        .ThenInclude(sds=> sds.Scene)
                        .ThenInclude(s=> s.TimeOfDay)
                        .Include(sd=> sd.ShootingDayScenes)
                        .ThenInclude(sds=> sds.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(isc=> isc.Image)
                        .Include(sd=> sd.ShootingDayScenes)
                        .ThenInclude(sds=> sds.CallsheetScene)
                        .Include(sds=> sds.Slates)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.SceneIntro)
                        .Include(sds=> sds.Slates)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(sds=> sds.Slates)
                        .ThenInclude(s=> s.Scene)
                        .ThenInclude(s=> s.TimeOfDay)
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

            return query.Include(sd => sd.CrewUnit)
                        .Include(sd=> sd.ShootingDayScenes)
                        .Include(sd=> sd.ScheduleDay)
                        .ThenInclude(sd=> sd.ScheduleScenes)
                        .Include(sd=> sd.Callsheet)
                        .ThenInclude(cs=> cs.CallsheetScenes);
        }

        private IQueryable<ShootingDay> GetIncludedCharacter()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd => sd.CrewUnit)
                        .Include(sd=> sd.ShootingDayScenes)
                        .Include(sd=> sd.ScheduleDay)
                            .ThenInclude(sd=> sd.ScheduleScenes)
                                .ThenInclude(sc => sc.Characters)
                                    .ThenInclude(c => c.CharacterScene)
                        .Include(sd=> sd.ScheduleDay)
                            .ThenInclude(sd=> sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.SceneIntro)
                        .Include(sd=> sd.ScheduleDay)
                            .ThenInclude(sd=> sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.ScriptLocation)
                        .Include(sd=> sd.ScheduleDay)
                            .ThenInclude(sd=> sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.TimeOfDay)
                        .Include(sd=> sd.ScheduleDay)
                            .ThenInclude(sd=> sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.ImageScenes)
                                        .ThenInclude(i => i.Image)
                        .Include(sd=> sd.Callsheet)
                            .ThenInclude(cs=> cs.CallsheetScenes)
                                .ThenInclude(css => css.Characters)
                                    .ThenInclude(c => c.CharacterScene)
                        .Include(sd=> sd.Callsheet)
                            .ThenInclude(sd=> sd.CallsheetScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.SceneIntro)
                        .Include(sd=> sd.Callsheet)
                            .ThenInclude(sd=> sd.CallsheetScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.ScriptLocation)
                        .Include(sd=> sd.Callsheet)
                            .ThenInclude(sd=> sd.CallsheetScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.TimeOfDay)
                        .Include(sd=> sd.Callsheet)
                            .ThenInclude(sd=> sd.CallsheetScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.ImageScenes)
                                        .ThenInclude(i => i.Image);
        }

        private IQueryable<ShootingDay> GetIncludedLocationSet()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd => sd.CrewUnit)
                        .Include(sd=> sd.ShootingDayScenes)
                        .Include(sd=> sd.ScheduleDay)
                            .ThenInclude(sd=> sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.SceneIntro)
                        .Include(sd=> sd.ScheduleDay)
                            .ThenInclude(sd=> sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.ScriptLocation)
                        .Include(sd=> sd.ScheduleDay)
                            .ThenInclude(sd=> sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.TimeOfDay)
                        .Include(sd=> sd.ScheduleDay)
                            .ThenInclude(sd=> sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.ImageScenes)
                                        .ThenInclude(i => i.Image)
                        .Include(sd=> sd.Callsheet)
                            .ThenInclude(sd=> sd.CallsheetScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.SceneIntro)
                        .Include(sd=> sd.Callsheet)
                            .ThenInclude(sd=> sd.CallsheetScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.ScriptLocation)
                        .Include(sd=> sd.Callsheet)
                            .ThenInclude(sd=> sd.CallsheetScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.TimeOfDay)
                        .Include(sd=> sd.Callsheet)
                            .ThenInclude(sd=> sd.CallsheetScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.ImageScenes)
                                        .ThenInclude(i => i.Image);
        }

        private IQueryable<ShootingDay> GetIncludedBreakdownItem()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd => sd.CrewUnit)
                        .Include(sd=> sd.ShootingDayScenes)
                            .ThenInclude(sds => sds.Scene)
                                .ThenInclude(s => s.BreakdownItemScenes)
                        .Include(sd=> sd.ScheduleDay)
                            .ThenInclude(sd=> sd.ScheduleScenes)
                                .ThenInclude(sds => sds.Scene)
                                    .ThenInclude(s => s.BreakdownItemScenes)
                        .Include(sd=> sd.Callsheet)
                            .ThenInclude(cs=> cs.CallsheetScenes)
                                .ThenInclude(sds => sds.Scene)
                                    .ThenInclude(s => s.BreakdownItemScenes);
        }

        private IQueryable<ShootingDay> GetIncludedCalendarCrewUnit()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd => sd.CrewUnit)
                            .ThenInclude(sd => sd.Project)
                        .Include(sd => sd.Callsheet)
                        .Include(sd => sd.ScheduleDay);
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

        private IQueryable<ShootingDay> GetIncludedCalendarCrewUnitScenes()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd => sd.CrewUnit)
                            .ThenInclude(sd => sd.Project)
                        .Include(sd => sd.ShootingDayScenes)
                            .ThenInclude(sds => sds.Scene)
                                .ThenInclude(s => s.SceneIntro)
                        .Include(sd => sd.ShootingDayScenes)
                            .ThenInclude(sds => sds.Scene)
                                .ThenInclude(s => s.ScriptLocation)
                        .Include(sd => sd.ShootingDayScenes)
                            .ThenInclude(sds => sds.Scene)
                                .ThenInclude(s => s.TimeOfDay)
                        .Include(sd => sd.Callsheet)
                            .ThenInclude(cs => cs.CallsheetScenes)
                                .ThenInclude(cs => cs.Scene)
                                    .ThenInclude(s => s.SceneIntro)
                        .Include(sd => sd.Callsheet)
                            .ThenInclude(cs => cs.CallsheetScenes)
                                .ThenInclude(cs => cs.Scene)
                                    .ThenInclude(s => s.ScriptLocation)
                        .Include(sd => sd.Callsheet)
                            .ThenInclude(cs => cs.CallsheetScenes)
                                .ThenInclude(cs => cs.Scene)
                                    .ThenInclude(s => s.TimeOfDay)
                        .Include(sd => sd.ScheduleDay)
                            .ThenInclude(sd => sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.SceneIntro)
                        .Include(sd => sd.ScheduleDay)
                            .ThenInclude(sd => sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.ScriptLocation)
                        .Include(sd => sd.ScheduleDay)
                            .ThenInclude(sd => sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.TimeOfDay);
        }

        private IQueryable<ShootingDay> GetIncludedCalendarCharacterScenes()
        {
            IQueryable<ShootingDay> query = _context.Set<ShootingDay>();

            return query.Include(sd => sd.CrewUnit)
                            .ThenInclude(sd => sd.Project)
                        .Include(sd => sd.ShootingDayScenes)
                            .ThenInclude(sds => sds.Scene)
                                .ThenInclude(s => s.SceneIntro)
                        .Include(sd => sd.ShootingDayScenes)
                            .ThenInclude(sds => sds.Scene)
                                .ThenInclude(s => s.ScriptLocation)
                        .Include(sd => sd.ShootingDayScenes)
                            .ThenInclude(sds => sds.Scene)
                                .ThenInclude(s => s.TimeOfDay)
                        .Include(sd => sd.Callsheet)
                            .ThenInclude(c => c.CallsheetScenes)
                                .ThenInclude(cs => cs.Characters)
                        .Include(sd => sd.Callsheet)
                            .ThenInclude(cs => cs.CallsheetScenes)
                                .ThenInclude(cs => cs.Scene)
                                    .ThenInclude(s => s.SceneIntro)
                        .Include(sd => sd.Callsheet)
                            .ThenInclude(cs => cs.CallsheetScenes)
                                .ThenInclude(cs => cs.Scene)
                                    .ThenInclude(s => s.ScriptLocation)
                        .Include(sd => sd.Callsheet)
                            .ThenInclude(cs => cs.CallsheetScenes)
                                .ThenInclude(cs => cs.Scene)
                                    .ThenInclude(s => s.TimeOfDay)
                        .Include(sd => sd.ScheduleDay)
                            .ThenInclude(sd => sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Characters)
                        .Include(sd => sd.ScheduleDay)
                            .ThenInclude(sd => sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.SceneIntro)
                        .Include(sd => sd.ScheduleDay)
                            .ThenInclude(sd => sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.ScriptLocation)
                        .Include(sd => sd.ScheduleDay)
                            .ThenInclude(sd => sd.ScheduleScenes)
                                .ThenInclude(ss => ss.Scene)
                                    .ThenInclude(s => s.TimeOfDay);
        }
    }
}
