using Raccord.Domain.Model.Comments;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Comments
{
    // Repository for comments
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(RaccordDBContext context) : base(context) 
        {
        }

        public IEnumerable<Comment> GetForParent(long? projectID, long? commentID)
        {
          var query = GetIncluded();

          return query.Where(c=> c.ParentProjectID == projectID &&
                                c.ParentCommentID == commentID);
        }

        private IQueryable<Comment> GetIncluded()
        {
            IQueryable<Comment> query = _context.Set<Comment>();

            return query.Include(c=> c.User);
        }
    }
}