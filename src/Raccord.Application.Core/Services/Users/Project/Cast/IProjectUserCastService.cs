namespace Raccord.Application.Core.Services.Users.Project.Cast
{
    // Interface for project user cast functionality
    public interface IProjectUserCastService
    {
      void Link(long projectUserID, long castMemberId);
      void RemoveLink(long projectUserID, long castMemberId);
    }
}