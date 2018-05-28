using Raccord.Domain.Model.ScriptUploads;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.ScriptUploads
{
    // Repository for script uploads
    public class ScriptUploadRepository : BaseRepository<ScriptUpload, long>, IScriptUploadRepository
    {
        public ScriptUploadRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<ScriptUpload> GetAllForProject(long projectID)
        {
            var query = GetIncludedSummary();

            return query.Where(i=> i.ProjectID == projectID);
        }

        public ScriptUpload GetFull(long ID)
        {
            var query = GetIncludedFull();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        public ScriptUpload GetSummary(long ID)
        {
            var query = GetIncludedSummary();

            return query.FirstOrDefault(i => i.ID == ID);
        }

        private IQueryable<ScriptUpload> GetIncludedFull()
        {
            IQueryable<ScriptUpload> query = _context.Set<ScriptUpload>();

            return query.Include(s=> s.Characters)
                        .Include(s => s.ScriptLocations)
                        .Include(s => s.Scenes)
                        .ThenInclude(s=> s.IntExt)
                        .Include(s => s.Scenes)
                        .ThenInclude(s=> s.DayNight)
                        .Include(s => s.Scenes)
                        .ThenInclude(s=> s.ScriptLocation)
                        .Include(s => s.Scenes)
                        .ThenInclude(s=> s.ImageScenes)
                        .ThenInclude(i=> i.Image);
        }

        private IQueryable<ScriptUpload> GetIncludedSummary()
        {
            IQueryable<ScriptUpload> query = _context.Set<ScriptUpload>();

            return query.Include(s=> s.Characters)
                        .Include(s => s.ScriptLocations)
                        .Include(s => s.Scenes);
        }
    }
}
