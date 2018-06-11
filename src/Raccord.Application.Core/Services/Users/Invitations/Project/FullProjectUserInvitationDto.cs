using System;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Cast;
using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Users.ProjectRoles;

namespace Raccord.Application.Core.Services.Users.Invitations.Project
{
  public class FullProjectUserInvitationDto
  {
    private UserInvitationDto _userInvitation;
    private ProjectRoleDto _role;
    private ProjectDto _project;
    private IEnumerable<ProjectUserCrewUnitDto> _crewUnits;
    private CastMemberDto _castMember;
    public long ID { get; set; }

    // Linked user
    public UserInvitationDto UserInvitation
    {
      get
      {
        return _userInvitation ?? new UserInvitationDto();
      }
      set
      {
        _userInvitation = value;
      }
    }
    public ProjectRoleDto ProjectRole
    {
      get
      {
        return _role ?? new ProjectRoleDto();
      }
      set
      {
        _role = value;
      }
    }
    public ProjectDto Project
    {
      get
      {
        return _project ?? new ProjectDto();
      }
      set
      {
        _project = value;
      }
    }

    /// <summary>
    /// Cast Member linked to the project user
    /// </summary>
    /// <returns></returns>
    public CastMemberDto CastMember
    {
        get
        {
            return _castMember ?? (_castMember = new CastMemberDto());
        }
        set
        {
            _castMember = value;
        }
    }

    /// <summary>
    /// Crew Units of the user
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ProjectUserCrewUnitDto> CrewUnits
    {
        get
        {
            return _crewUnits ?? new List<ProjectUserCrewUnitDto>();
        }
        set
        {
            _crewUnits = value;
        }
    }
  }
}