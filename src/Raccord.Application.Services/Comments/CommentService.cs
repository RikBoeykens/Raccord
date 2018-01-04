using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Comments;
using Raccord.Data.EntityFramework.Repositories.Comments;
using Raccord.Domain.Model.Comments;

namespace Raccord.Application.Services.Comments
{
  public class CommentService: ICommentService
  {
    private readonly ICommentRepository _commentRepository;
    public CommentService(
      ICommentRepository commentRepository
    ){
      _commentRepository = commentRepository;
    }

    public IEnumerable<CommentDto> GetForParent(GetCommentDto dto)
    {
      var comments = _commentRepository.GetForParent(dto.ProjectID, dto.CommentID);

      return comments.Select(c=> c.Translate());
    }

    public long Add(PostCommentDto dto)
    {
      var comment = new Comment
      {
        Text = dto.Text,
        UserID = dto.UserID,
        ParentProjectID = dto.ProjectID,
        ParentCommentID = dto.CommentID
      };

      _commentRepository.Add(comment);
      _commentRepository.Commit();

      return comment.ID;
    }

    public long Update(PostCommentDto dto)
    {
      var comment = _commentRepository.GetSingle(dto.ID);

      comment.Text = dto.Text;

      _commentRepository.Edit(comment);
      _commentRepository.Commit();

      return comment.ID;
    }

    public void Remove(long ID)
    {
      var comment = _commentRepository.GetSingle(ID);

      _commentRepository.Delete(comment);
      _commentRepository.Commit();
    }
  }
}