using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Comments
{
  public interface ICommentService
  {
    CommentDto Get(long ID);
    IEnumerable<CommentDto> GetForParent(GetCommentDto dto);

    long Add(PostCommentDto dto);

    long Update(PostCommentDto dto);

    void Remove(long ID);
  }
}