using System.Collections.Generic;
using Raccord.API.ViewModels.Users.ProjectRoles;

namespace Raccord.API.ViewModels.Account
{
  public class UserPermissionSummaryViewModel
  {
    private IEnumerable<ProjectPermissionSummaryViewModel> _projectPermissions;
    // Gets or sets if user is admin
    public bool IsAdmin { get; set; }

    public IEnumerable<ProjectPermissionSummaryViewModel> ProjectPermissions
    {
      get
      {
        return _projectPermissions ?? (_projectPermissions = new List<ProjectPermissionSummaryViewModel>());
      }
      set
      {
        _projectPermissions = value;
      }
    }
  }
}