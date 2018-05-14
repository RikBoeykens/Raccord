using System.Collections.Generic;
using Raccord.Application.Core.Services.Users.Project;

namespace Raccord.Application.Core.Services.Crew.CrewUnits
{
  public class FullAdminCrewUnitDto : CrewUnitDto
  {
    private IEnumerable<LinkedProjectUserUserDto> _projectUsers;

    public IEnumerable<LinkedProjectUserUserDto> ProjectUsers
    {
      get
      {
        return _projectUsers ?? new List<LinkedProjectUserUserDto>();
      }
      set
      {
        _projectUsers = value;
      }
    }
  }
}