using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Comments;
using Raccord.Core.Enums;
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
      var comments = _commentRepository.GetForParent(dto.ParentID, dto.ParentType);

      return comments.Select(c=> c.Translate());
    }
    public CommentDto Get(long ID)
    {
      var comment = _commentRepository.GetFull(ID);

      return comment.Translate();
    }

    public long Add(PostCommentDto dto)
    {
      var comment = new Comment
      {
        Text = dto.Text,
        UserID = dto.UserID
      };

      if(dto.ParentType == ParentCommentType.BreakdownItem)
      {
        comment.ParentBreakdownItemID = dto.ParentID;
      }
      if(dto.ParentType == ParentCommentType.Character)
      {
        comment.ParentCharacterID = dto.ParentID;
      }
      if(dto.ParentType == ParentCommentType.Comment)
      {
        comment.ParentCommentID = dto.ParentID;
      }
      if(dto.ParentType == ParentCommentType.Image)
      {
        comment.ParentImageID = dto.ParentID;
      }
      if(dto.ParentType == ParentCommentType.Location)
      {
        comment.ParentLocationID = dto.ParentID;
      }
      if(dto.ParentType == ParentCommentType.Project)
      {
        comment.ParentProjectID = dto.ParentID;
      }
      if(dto.ParentType == ParentCommentType.Scene)
      {
        comment.ParentSceneID = dto.ParentID;
      }
      if(dto.ParentType == ParentCommentType.ScriptLocation)
      {
        comment.ParentScriptLocationID = dto.ParentID;
      }
      if(dto.ParentType == ParentCommentType.Slate)
      {
        comment.ParentSlateID = dto.ParentID;
      }
      if(dto.ParentType == ParentCommentType.Take)
      {
        comment.ParentTakeID = dto.ParentID;
      }

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
      _commentRepository.RemoveComment(ID);
    }
  }
}