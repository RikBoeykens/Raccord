using Raccord.Domain.Model.Cast;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Cast
{
    // Repository for cast members
    public class CastMemberRepository : BaseRepository<CastMember, long>, ICastMemberRepository
    {
        public CastMemberRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<CastMember> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(i=> i.ProjectID == projectID);
        }

        public CastMember GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public CastMember GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public int SearchCount(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            var query = GetSearchQuery(searchText, projectID, userID, isAdmin, excludeIds);

            return query.Count();            
        }

        public IEnumerable<CastMember> Search(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            return GetSearchQuery(searchText, projectID, userID, isAdmin, excludeIds);
        }

        private IQueryable<CastMember> GetIncludedFull()
        {
            IQueryable<CastMember> query = _context.Set<CastMember>();

            return query.Include(cm => cm.ProjectUser)
                            .ThenInclude(pu=> pu.User)
                        .Include(cm => cm.ProjectUserInvitation)
                            .ThenInclude(pu=> pu.UserInvitation)
                        .Include(cm => cm.Characters)
                            .ThenInclude(i=> i.CharacterScenes)
                                .ThenInclude(i=> i.Scene)
                                    .ThenInclude(s=> s.IntExt)
                        .Include(cm => cm.Characters)
                            .ThenInclude(i=> i.CharacterScenes)
                                .ThenInclude(i=> i.Scene)
                                    .ThenInclude(s=> s.DayNight)
                        .Include(cm => cm.Characters)
                            .ThenInclude(i=> i.CharacterScenes)
                                .ThenInclude(i=> i.Scene)
                                    .ThenInclude(s=> s.ScriptLocation)
                        .Include(cm => cm.Characters)
                            .ThenInclude(i=> i.CharacterScenes)
                                .ThenInclude(i=> i.Scene)
                                    .ThenInclude(s=> s.ImageScenes)
                                        .ThenInclude(i=> i.Image)
                        .Include(cm => cm.Characters)
                            .ThenInclude(i=> i.ImageCharacters)
                                .ThenInclude(ic=> ic.Image);
        }

        private IQueryable<CastMember> GetIncludedSummary()
        {
            IQueryable<CastMember> query = _context.Set<CastMember>();

            return query.Include(cm => cm.ProjectUser)
                            .ThenInclude(pu=> pu.User)
                        .Include(cm => cm.ProjectUserInvitation)
                            .ThenInclude(pu=> pu.UserInvitation)
                        .Include(cm => cm.Characters)
                            .ThenInclude(c => c.ImageCharacters)
                                .ThenInclude(ic => ic.Character);
        }

        private IQueryable<CastMember> GetIncluded()
        {
            IQueryable<CastMember> query = _context.Set<CastMember>();

            return query;
        }

        private IQueryable<CastMember> GetIncludedSearch()
        {
            IQueryable<CastMember> query = _context.Set<CastMember>();

            return query.Include(s=> s.Project)
                            .ThenInclude(p=> p.ProjectUsers)
                        .Include(cm=> cm.ProjectUser)
                            .ThenInclude(pu=> pu.User)
                        .Include(cm => cm.ProjectUserInvitation)
                            .ThenInclude(pu=> pu.UserInvitation);
        }

        private IQueryable<CastMember> GetSearchQuery(string searchText, long? projectID, string userID, bool isAdmin, long[] excludeIds)
        {
            var query = GetIncludedSearch();

            query = query.Where(s=>
                                    (s.FirstName.ToLower().Contains(searchText.ToLower()) 
                                    ||
                                    s.LastName.ToLower().Contains(searchText.ToLower()))
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
    }
}
