using System.Collections.Generic;
using Raccord.Domain.Model.Comments;

namespace Raccord.Data.EntityFramework.Repositories.Comments
{
    // Interface defining a repository for crew members
    public interface ICommentRepository : IBaseRepository<Comment>
    {
      Comment GetFull(long ID);
      IEnumerable<Comment> GetForParent(long? projectID, long? commentID);
      void RemoveComment(long ID);
    }
}