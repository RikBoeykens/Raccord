using System.Collections.Generic;
using Raccord.API.ViewModels.Crew.CrewMembers;

namespace Raccord.API.ViewModels.Crew.CrewUnits
{
  public class ProjectLinkCrewUnitViewModel : CrewUnitViewModel
  {
    private IEnumerable<CrewMemberViewModel> _crewMembers;
    public long LinkID { get; set; }

    public IEnumerable<CrewMemberViewModel> CrewMembers
    {
      get
      {
        return _crewMembers ?? new List<CrewMemberViewModel>();
      }
      set
      {
        _crewMembers = value;
      }
    }
  }
}