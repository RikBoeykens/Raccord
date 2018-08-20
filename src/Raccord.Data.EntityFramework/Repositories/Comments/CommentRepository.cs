using Raccord.Domain.Model.Comments;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raccord.Core.Enums;

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

        public IEnumerable<Comment> GetForParent(long parentID, ParentCommentType parentType)
        {
          var query = GetIncluded();

          if(parentType == ParentCommentType.BreakdownItem)
          {
            return query.Where(c => c.ParentBreakdownItemID == parentID);
          }
          if(parentType == ParentCommentType.Character)
          {
            return query.Where(c => c.ParentCharacterID == parentID);
          }
          if(parentType == ParentCommentType.Comment)
          {
            return query.Where(c => c.ParentCommentID == parentID);
          }
          if(parentType == ParentCommentType.Image)
          {
            return query.Where(c => c.ParentImageID == parentID);
          }
          if(parentType == ParentCommentType.Location)
          {
            return query.Where(c => c.ParentLocationID == parentID);
          }
          if(parentType == ParentCommentType.Project)
          {
            return query.Where(c => c.ParentProjectID == parentID);
          }
          if(parentType == ParentCommentType.Scene)
          {
            return query.Where(c => c.ParentSceneID == parentID);
          }
          if(parentType == ParentCommentType.ScriptLocation)
          {
            return query.Where(c => c.ParentScriptLocationID == parentID);
          }
          if(parentType == ParentCommentType.Slate)
          {
            return query.Where(c => c.ParentSlateID == parentID);
          }
          if(parentType == ParentCommentType.Take)
          {
            return query.Where(c => c.ParentTakeID == parentID);
          }
          if(parentType == ParentCommentType.LocationSet)
          {
            return query.Where(c => c.ParentLocationSetID == parentID);
          }

          return new List<Comment>();
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

            return query.Include(c=> c.User);
        }
    }
}