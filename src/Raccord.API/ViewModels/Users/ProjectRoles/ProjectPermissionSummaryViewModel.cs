using System.Collections.Generic;
using Raccord.Core.Enums;

namespace Raccord.API.ViewModels.Users.ProjectRoles
{
  public class ProjectPermissionSummaryViewModel
  {
    private IEnumerable<ProjectPermissionEnum> _permissions;

    /// <summary>
    /// ID of the the role
    /// </summary>
    /// <returns></returns>
    public long ProjectID { get; set; }

    public IEnumerable<ProjectPermissionEnum> ProjectPermissions
    {
      get
      {
        return _permissions ?? (_permissions = new List<ProjectPermissionEnum>());
      }
      set
      {
        _permissions = value;
      }
    }
  }
}