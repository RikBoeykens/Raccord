using System;
using System.Collections.Generic;
using Raccord.API.ViewModels.Cast;
using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.API.ViewModels.Projects;
using Raccord.API.ViewModels.Users.ProjectRoles;

namespace Raccord.API.ViewModels.Users.Invitations.Project
{
  public class FullProjectUserInvitationViewModel
  {
    private ProjectViewModel _project;
    private UserInvitationViewModel _userInvitation;
    protected CastMemberViewModel _castMember;
    private ProjectRoleViewModel _role;
    private IEnumerable<ProjectLinkCrewUnitViewModel> _crewUnits;
    public long ID { get; set; }
    public ProjectRoleViewModel ProjectRole
    {
      get
      {
        return _role ?? new ProjectRoleViewModel();
      }
      set
      {
        _role = value;
      }
    }
    public ProjectViewModel Project
    {
      get
      {
        return _project ?? new ProjectViewModel();
      }
      set
      {
        _project = value;
      }
    }

    // Linked user
    public UserInvitationViewModel UserInvitation
    {
        get
        {
            return _userInvitation ?? new UserInvitationViewModel();
        }
        set
        {
            _userInvitation = value;
        }
    }

    /// <summary>
    /// Crew members linked to the project user
    /// </summary>
    /// <returns></returns>
    public CastMemberViewModel CastMember
    {
        get
        {
            return _castMember ?? (_castMember = new CastMemberViewModel());
        }
        set
        {
            _castMember = value;
        }
    }
    public IEnumerable<ProjectLinkCrewUnitViewModel> CrewUnits
    {
        get
        {
            return _crewUnits ?? new List<ProjectLinkCrewUnitViewModel>();
        }
        set
        {
            _crewUnits = value;
        }
    }
  }
}