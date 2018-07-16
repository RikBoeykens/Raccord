using Raccord.Domain.Model.Characters;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Characters
{
    // Repository for characters
    public class CharacterRepository : BaseRepository<Character, long>, ICharacterRepository
    {
        public CharacterRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<Character> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(i=> i.ProjectID == projectID);
        }

        public IEnumerable<Character> GetAllForCastMember(long castMemberID)
        {
            var query = GetIncludedSummary();

            return query.Where(i=> i.CastMemberID == castMemberID);
        }

        public Character GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public Character GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            var query = GetSearchQuery(searchText, projectID, userID, isAdmin, excludeIds);

            return query.Count();            
        }

        public IEnumerable<Character> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            return GetSearchQuery(searchText, projectID, userID, isAdmin, excludeIds);
        }

        private IQueryable<Character> GetIncludedFull()
        {
            IQueryable<Character> query = _context.Set<Character>();

            return query.Include(i=> i.CharacterScenes)
                            .ThenInclude(i=> i.Scene)
                                .ThenInclude(s=> s.SceneIntro)
                        .Include(i=> i.CharacterScenes)
                            .ThenInclude(i=> i.Scene)
                                .ThenInclude(s=> s.TimeOfDay)
                        .Include(i=> i.CharacterScenes)
                            .ThenInclude(i=> i.Scene)
                                .ThenInclude(s=> s.ScriptLocation)
                        .Include(i=> i.CharacterScenes)
                            .ThenInclude(i=> i.Scene)
                                .ThenInclude(s=> s.ImageScenes)
                                    .ThenInclude(i=> i.Image)
                        .Include(i=> i.CharacterScenes)
                            .ThenInclude(cs=> cs.ScheduleDays)
                                .ThenInclude(sd=> sd.ScheduleScene)
                                    .ThenInclude(ss=> ss.ScheduleDay)
                        .Include(i=> i.CharacterScenes)
                            .ThenInclude(cs=> cs.ScheduleDays)
                                .ThenInclude(sd=> sd.ScheduleScene)
                                    .ThenInclude(ss=> ss.Scene)
                                        .ThenInclude(s=> s.SceneIntro)
                        .Include(i=> i.CharacterScenes)
                            .ThenInclude(cs=> cs.ScheduleDays)
                                .ThenInclude(sd=> sd.ScheduleScene)
                                    .ThenInclude(ss=> ss.Scene)
                                        .ThenInclude(s=> s.TimeOfDay)
                        .Include(i=> i.CharacterScenes)
                            .ThenInclude(cs=> cs.ScheduleDays)
                                .ThenInclude(sd=> sd.ScheduleScene)
                                    .ThenInclude(ss=> ss.Scene)
                                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(i=> i.CharacterScenes)
                            .ThenInclude(cs=> cs.ScheduleDays)
                                .ThenInclude(sd=> sd.ScheduleScene)
                                    .ThenInclude(ss=> ss.LocationSet)
                                        .ThenInclude(ls=> ls.Location)
                        .Include(i=> i.CharacterScenes)
                            .ThenInclude(cs=> cs.ScheduleDays)
                                .ThenInclude(sd=> sd.ScheduleScene)
                                    .ThenInclude(ss=> ss.Scene)
                                        .ThenInclude(s=> s.ImageScenes)
                                            .ThenInclude(s=> s.Image)
                        .Include(i=> i.ImageCharacters)
                            .ThenInclude(ic=> ic.Image)
                        .Include(i=> i.CharacterScenes)
                            .ThenInclude(cs=> cs.ScheduleDays)
                                .ThenInclude(sd=> sd.ScheduleScene)
                                    .ThenInclude(ss=> ss.ScheduleDay)
                                        .ThenInclude(sd=> sd.ShootingDay)
                        .Include(c => c.CastMember)
                            .ThenInclude(c=> c.ProjectUser)
                                .ThenInclude(pu => pu.User);
        }

        private IQueryable<Character> GetIncludedSummary()
        {
            IQueryable<Character> query = _context.Set<Character>();

            return query.Include(i=> i.CharacterScenes)
                        .Include(i=> i.ImageCharacters)
                            .ThenInclude(ic=> ic.Image);
        }

        private IQueryable<Character> GetIncluded()
        {
            IQueryable<Character> query = _context.Set<Character>();

            return query;
        }

        private IQueryable<Character> GetIncludedSearch()
        {
            IQueryable<Character> query = _context.Set<Character>();

            return query.Include(i=> i.Project)
                        .ThenInclude(p=> p.ProjectUsers);
        }

        private IQueryable<Character> GetSearchQuery(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            var query = GetIncludedSearch();

            query = query.Where(i=> i.Name.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(i=> i.ProjectID==projectID.Value);

            if(!isAdmin)
                query = query.Where(l=> l.Project.ProjectUsers.Any(c=> c.UserID == userID));

            if(excludeIds.Any())
            {
                query = query.Where(c=> !excludeIds.Any(id=> id == c.ID));
            }

            return query;
        }
    }
}
