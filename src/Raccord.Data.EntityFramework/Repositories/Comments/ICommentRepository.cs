using System.Collections.Generic;
using Raccord.Core.Enums;
using Raccord.Domain.Model.Comments;

namespace Raccord.Data.EntityFramework.Repositories.Comments
{
    // Interface defining a repository for crew members
    public interface ICommentRepository : IBaseRepository<Comment, long>
    {
      Comment GetFull(long ID);
      IEnumerable<Comment> GetForParent(long parentID, ParentCommentType parentType);
      void RemoveComment(long ID);
    }
}