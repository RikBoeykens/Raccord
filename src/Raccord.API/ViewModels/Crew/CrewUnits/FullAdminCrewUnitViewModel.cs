using System.Collections.Generic;
using Raccord.API.ViewModels.Users.Projects;

namespace Raccord.API.ViewModels.Crew.CrewUnits
{
  public class FullAdminCrewUnitViewModel : CrewUnitViewModel
  {

    private IEnumerable<LinkedProjectUserUserViewModel> _projectUsers;

    public IEnumerable<LinkedProjectUserUserViewModel> ProjectUsers
    {
      get
      {
        return _projectUsers ?? new List<LinkedProjectUserUserViewModel>();
      }
      set
      {
        _projectUsers = value;
      }
    }
  }
}