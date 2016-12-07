using Raccord.Domain.Model.Projects;
using System.Collections.Generic;
using System.Linq;

namespace Raccord.Data.EntityFramework.Repositories.Projects
{
    // Repository for projects
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(RaccordDBContext context) : base(context) 
        {
        }

        public int SearchCount(string searchText)
        {
            return _context.Set<Project>().Count(p=> p.Title.ToLower().Contains(searchText.ToLower()));            
        }

        public IEnumerable<Project> Search(string searchText)
        {
            return _context.Set<Project>().Where(p=> p.Title.ToLower().Contains(searchText.ToLower()));
        }
    }
}
