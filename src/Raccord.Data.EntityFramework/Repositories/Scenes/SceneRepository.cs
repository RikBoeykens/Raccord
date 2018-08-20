using Raccord.Domain.Model.Scenes;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Scenes
{
    // Repository for scenes
    public class SceneRepository : BaseRepository<Scene, long>, ISceneRepository
    {
        public SceneRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<Scene> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(s=> s.ProjectID == projectID).OrderBy(t => t.SortingOrder);
        }

        public Scene GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(l => l.ID == ID);
        }

        public Scene GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(l => l.ID == ID);
        }


        public int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            var query = GetSearchQuery(searchText, projectID, userID, isAdmin, excludeIds);

            return query.Count();            
        }

        public IEnumerable<Scene> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            return GetSearchQuery(searchText, projectID, userID, isAdmin, excludeIds);
        }

        public IEnumerable<Scene> GetScriptForProject(long projectID)
        {
            var query = GetIncludedScript();

            return query.Where(s=> s.ProjectID == projectID).OrderBy(t=> t.SortingOrder);
        }

        public IEnumerable<Scene> GetScriptForCallsheet(long callsheetID)
        {
            var query = GetIncludedScript();

            return query.Where(s=> s.CallsheetScenes.Any(cs=> cs.CallsheetID == callsheetID))
                        .OrderBy(t=> t.SortingOrder);
        }

        public IEnumerable<Scene> GetScriptForCharacters(long[] characterIDs)
        {
            var query = GetIncludedScript();

            return query.Where(s=> s.CharacterScenes.Any(c => characterIDs.Any())).OrderBy(t=> t.SortingOrder);
        }

        public Scene GetScript(long ID)
        {
            var query = GetIncludedScript();

            return query.FirstOrDefault(s=> s.ID == ID);
        }

        public IEnumerable<Scene> Filter(
            long projectID, 
            IEnumerable<long> sceneIntroIDs, 
            IEnumerable<long> scriptLocationIDs, 
            IEnumerable<long> timeOfDayIDs,
            IEnumerable<long> locationSetIDs,
            IEnumerable<long> locationIDs,
            IEnumerable<long> characterIDs,
            IEnumerable<long> castMemberIDs,
            IEnumerable<long> breakdownItemIDs,
            IEnumerable<long> scheduleDayIDs,
            IEnumerable<long> scheduleSceneShootingDayIDs,
            IEnumerable<long> callsheetIDs,
            IEnumerable<long> callsheetSceneShootingDayIDs,
            IEnumerable<long> shootingDayIDs,
            string searchText,
            int? minPageLength,
            int? maxPageLength
        )
        {
            var query = GetIncludedFilter();

            query = query.Where(s=> s.ProjectID == projectID);

            if(sceneIntroIDs.Any())
            {
                query = query.Where(s => sceneIntroIDs.Any(id=> id == s.SceneIntroID));
            }

            if(scriptLocationIDs.Any())
            {
                query = query.Where(s => scriptLocationIDs.Any(id=> id == s.ScriptLocationID));
            }

            if(timeOfDayIDs.Any())
            {
                query = query.Where(s => timeOfDayIDs.Any(id=> id == s.TimeOfDayID));
            }

            if(locationSetIDs.Any())
            {
                query = query.Where(s => locationSetIDs.All(id=> s.ScriptLocation.LocationSets.Any(ls=> ls.ID == id)));
            }

            if(locationIDs.Any())
            {
                query = query.Where(s => locationIDs.All(id=> s.ScriptLocation.LocationSets.Any(ls=> ls.LocationID == id)));
            }

            if(characterIDs.Any())
            {
                query = query.Where(s => characterIDs.All(id=> s.CharacterScenes.Any(cs=> cs.CharacterID == id)));
            }

            if(castMemberIDs.Any())
            {
                query = query.Where(s => castMemberIDs.All(id=> s.CharacterScenes.Any(cs=> cs.Character.CastMemberID == id)));
            }

            if(breakdownItemIDs.Any())
            {
                query = query.Where(s => breakdownItemIDs.All(id=> s.BreakdownItemScenes.Any(bis=> bis.BreakdownItemID == id)));
            }

            if(scheduleDayIDs.Any())
            {
                query = query.Where(s => scheduleDayIDs.All(id=> s.ScheduleScenes.Any(ss=> ss.ScheduleDayID == id)));
            }

            if(scheduleSceneShootingDayIDs.Any())
            {
                query = query.Where(s => scheduleSceneShootingDayIDs.All(id=> s.ScheduleScenes.Any(ss=> ss.ScheduleDay.ShootingDayID == id)));
            }

            if(callsheetIDs.Any())
            {
                query = query.Where(s => callsheetIDs.All(id=> s.CallsheetScenes.Any(ss=> ss.CallsheetID == id)));
            }

            if(callsheetSceneShootingDayIDs.Any())
            {
                query = query.Where(s => callsheetSceneShootingDayIDs.All(id=> s.CallsheetScenes.Any(ss=> ss.Callsheet.ShootingDayID == id)));
            }

            if(shootingDayIDs.Any())
            {
                query = query.Where(s => shootingDayIDs.All(id=> s.ShootingDayScenes.Any(ss=> ss.ShootingDayID == id)));
            }

            if(!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(s => s.Summary.ToLower().Contains(searchText.ToLower()) ||
                                        s.Number.ToLower().Contains(searchText.ToLower())
                                    );
            }

            if(minPageLength.HasValue)
            {
                query = query.Where(s=> s.PageLength >= minPageLength);
            }

            if(maxPageLength.HasValue)
            {
                query = query.Where(s=> s.PageLength <= maxPageLength);
            }

            return query.OrderBy(t => t.SortingOrder);
        }

        private IQueryable<Scene> GetIncludedFull()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.SceneIntro)
                         .Include(s => s.ScriptLocation)
                         .Include(s => s.TimeOfDay)
                         .Include(s=> s.ImageScenes)
                         .ThenInclude(i=> i.Image)
                         .Include(s=> s.CharacterScenes)
                         .ThenInclude(cs=> cs.Character)
                         .ThenInclude(c=> c.ImageCharacters)
                         .ThenInclude(ic=> ic.Image)
                         .Include(s=> s.BreakdownItemScenes)
                         .ThenInclude(bis=> bis.BreakdownItem)
                         .ThenInclude(bi=> bi.BreakdownType)
                         .Include(s=> s.BreakdownItemScenes)
                         .ThenInclude(bis=> bis.BreakdownItem)
                         .ThenInclude(bi=> bi.ImageBreakdownItems)
                         .ThenInclude(ibi=> ibi.Image)
                         .Include(s => s.ScheduleScenes)
                            .ThenInclude(ss=> ss.ScheduleDay)
                                .ThenInclude(sd=> sd.ScheduleScenes)
                         .Include(s => s.ScheduleScenes)
                            .ThenInclude(ss=> ss.ScheduleDay)
                                .ThenInclude(sd=> sd.ShootingDay)
                                    .ThenInclude(sd => sd.CrewUnit)
                         .Include(s => s.ScheduleScenes)
                            .ThenInclude(ss=> ss.LocationSet)
                                .ThenInclude(ls=> ls.Location)
                         .Include(s=> s.Slates)
                         .ThenInclude(s=> s.ImageSlates)
                         .ThenInclude(s=> s.Image)
                         .Include(s=> s.Slates)
                         .ThenInclude(s=> s.ShootingDay);
        }

        private IQueryable<Scene> GetIncludedSummary()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.SceneIntro)
                         .Include(s => s.ScriptLocation)
                         .Include(s => s.TimeOfDay)
                         .Include(s=> s.ImageScenes)
                         .ThenInclude(i=> i.Image);
        }

        private IQueryable<Scene> GetIncluded()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.SceneIntro)
                         .Include(s => s.ScriptLocation)
                         .Include(s => s.TimeOfDay);
        }

        private IQueryable<Scene> GetIncludedSearch()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.SceneIntro)
                         .Include(s => s.ScriptLocation)
                         .Include(s => s.TimeOfDay)
                         .Include(s=> s.Project)
                         .ThenInclude(p=> p.ProjectUsers);
        }

        private IQueryable<Scene> GetIncludedFilter()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.SceneIntro)
                         .Include(s => s.ScriptLocation)
                            .ThenInclude(sl=> sl.LocationSets)
                                .ThenInclude(ls=> ls.Location)
                         .Include(s => s.TimeOfDay)
                         .Include(s => s.CharacterScenes)
                            .ThenInclude(cs => cs.Character)
                         .Include(s => s.BreakdownItemScenes)
                         .Include(s => s.ScheduleScenes)
                            .ThenInclude(ss=> ss.ScheduleDay)
                         .Include(s => s.CallsheetScenes)
                            .ThenInclude(cs=> cs.Callsheet)
                         .Include(s=> s.ImageScenes)
                         .ThenInclude(i=> i.Image);
        }

        private IQueryable<Scene> GetSearchQuery(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            var query = GetIncludedSearch();

            query = query.Where(s=> 
                s.Summary.ToLower().Contains(searchText.ToLower()) ||
                s.Number.ToLower().Contains(searchText.ToLower())
            );

            if(projectID.HasValue)
                query = query.Where(s=> s.ProjectID==projectID.Value);

            if(!isAdmin)
                query = query.Where(s=> s.Project.ProjectUsers.Any(c=> c.UserID == userID));

            if(excludeIds.Any())
            {
                query = query.Where(c=> !excludeIds.Any(id=> id == c.ID));
            }

            return query;
        }

        private IQueryable<Scene> GetIncludedScript()
        {
            IQueryable<Scene> query = _context.Set<Scene>();

            return query.Include(s => s.SceneIntro)
                         .Include(s => s.ScriptLocation)
                         .Include(s => s.TimeOfDay)
                         .Include(s=> s.ImageScenes)
                         .ThenInclude(i=> i.Image)
                         .Include(s => s.Actions)
                         .Include(s=> s.Dialogues)
                         .ThenInclude(d=> d.Character);
        }
    }
}
