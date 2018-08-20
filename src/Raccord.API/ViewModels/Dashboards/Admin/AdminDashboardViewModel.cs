using Raccord.API.ViewModels.Common.Paging;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users;
using Raccord.API.ViewModels.Users.Invitations;

namespace Raccord.API.ViewModels.Dashboards.Admin
{
  public class AdminDashboardViewModel
  {
    private PagedDataViewModel<AdminProjectSummaryViewModel> _projects;
    private PagedDataViewModel<AdminUserSummaryViewModel> _users;
    private PagedDataViewModel<AdminUserInvitationSummaryViewModel> _invitations;

    public PagedDataViewModel<AdminProjectSummaryViewModel> Projects
    {
      get
      {
        return _projects ?? new PagedDataViewModel<AdminProjectSummaryViewModel>();
      }
      set
      {
        _projects = value;
      }
    }
    public PagedDataViewModel<AdminUserSummaryViewModel> Users
    {
      get
      {
        return _users ?? new PagedDataViewModel<AdminUserSummaryViewModel>();
      }
      set
      {
        _users = value;
      }
    }
    public PagedDataViewModel<AdminUserInvitationSummaryViewModel> Invitations
    {
      get
      {
        return _invitations ?? new PagedDataViewModel<AdminUserInvitationSummaryViewModel>();
      }
      set
      {
        _invitations = value;
      }
    }
  }
}