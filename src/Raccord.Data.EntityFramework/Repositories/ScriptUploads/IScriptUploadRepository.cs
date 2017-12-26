using Raccord.Domain.Model.ScriptUploads;
using System.Collections.Generic;

namespace Raccord.Data.EntityFramework.Repositories.ScriptUploads
{
    // Interface defining a repository for ScriptUploads
    public interface IScriptUploadRepository : IBaseRepository<ScriptUpload>
    {
        IEnumerable<ScriptUpload> GetAllForProject(long projectID);
        ScriptUpload GetFull(long ID);
        ScriptUpload GetSummary(long ID);
    }
}