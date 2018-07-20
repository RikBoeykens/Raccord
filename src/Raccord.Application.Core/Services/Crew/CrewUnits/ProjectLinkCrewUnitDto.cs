using System.Collections.Generic;
using Raccord.Application.Core.Services.Crew.CrewMembers;

namespace Raccord.Application.Core.Services.Crew.CrewUnits
{
  public class ProjectLinkCrewUnitDto : CrewUnitDto
  {
    private IEnumerable<CrewMemberDto> _crewMembers;
    public long LinkID { get; set; }

    public IEnumerable<CrewMemberDto> CrewMembers
    {
      get
      {
        return _crewMembers ?? new List<CrewMemberDto>();
      }
      set
      {
        _crewMembers = value;
      }
    }
  }
}