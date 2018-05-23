using Raccord.Domain.Model.Comments;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Comments
{
    // Repository for comments
    public class CommentRepository : BaseRepository<Comment, long>, ICommentRepository
    {
        public CommentRepository(RaccordDBContext context) : base(context) 
        {
        }

        public Comment GetFull(long ID)
        {
            var query = GetIncluded();

            return query.FirstOrDefault(c=> c.ID == ID);
        }

        public IEnumerable<Comment> GetForParent(long? projectID, long? commentID)
        {
          var query = GetIncluded();

          return query.Where(c=> c.ParentProjectID == projectID &&
                                c.ParentCommentID == commentID);
        }

        public void RemoveComment(long ID)
        {
            var query = GetIncluded();

            var comment = query.FirstOrDefault(c=> c.ID == ID);

            foreach(var childCommentId in comment.Comments.ToList().Select(c=>c.ID))
            {
                RemoveComment(childCommentId);
            }

            _context.Remove(comment);
            Commit();
        }

        private IQueryable<Comment> GetIncluded()
        {
            IQueryable<Comment> query = _context.Set<Comment>();

            return query.Include(c=> c.User)
                        .Include(c=> c.Comments);
        }
    }
}