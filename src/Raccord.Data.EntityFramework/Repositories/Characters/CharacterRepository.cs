using Raccord.Domain.Model.Characters;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Characters
{
    // Repository for characters
    public class CharacterRepository : BaseRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<Character> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(i=> i.ProjectID == projectID);
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

        public int SearchCount(string searchText, long? projectID)
        {
            var query = GetSearchQuery(searchText, projectID);

            return query.Count();            
        }

        public IEnumerable<Character> Search(string searchText, long? projectID)
        {
            return GetSearchQuery(searchText, projectID);
        }

        private IQueryable<Character> GetIncludedFull()
        {
            IQueryable<Character> query = _context.Set<Character>();

            return query.Include(i=> i.CharacterScenes)
                        .ThenInclude(i=> i.Scene)
                        .ThenInclude(s=> s.IntExt)
                        .Include(i=> i.CharacterScenes)
                        .ThenInclude(i=> i.Scene)
                        .ThenInclude(s=> s.DayNight)
                        .Include(i=> i.CharacterScenes)
                        .ThenInclude(i=> i.Scene)
                        .ThenInclude(s=> s.Location)
                        .Include(i=> i.CharacterScenes)
                        .ThenInclude(i=> i.Scene)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(i=> i.Image)
                        .Include(i=> i.ImageCharacters)
                        .ThenInclude(ic=> ic.Image);
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

            return query.Include(i=> i.Project);
        }

        private IQueryable<Character> GetSearchQuery(string searchText, long? projectID)
        {
            var query = GetIncludedSearch();

            query = query.Where(i=> i.Name.ToLower().Contains(searchText.ToLower()));

            if(projectID.HasValue)
                query = query.Where(i=> i.ProjectID==projectID.Value);

            return query;
        }
    }
}
