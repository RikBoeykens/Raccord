using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Users.Invitations.Project;
using Raccord.Data.EntityFramework.Repositories.Users.Invitations.Projects;
using Raccord.Domain.Model.Users.Invitations;

namespace Raccord.Application.Services.Users.Invitations.Project
{
  public class ProjectUserInvitationService : IProjectUserInvitationService
  {
    private readonly IProjectUserInvitationRepository _projectUserInvitationRepository;

    public ProjectUserInvitationService(
      IProjectUserInvitationRepository projectUserInvitationRepository
      )
    {
      _projectUserInvitationRepository = projectUserInvitationRepository;
    }
    public IEnumerable<ProjectUserInvitationSummaryDto> GetProjects(Guid invitationID)
    {
      var projectUsers = _projectUserInvitationRepository.GetAllForInvitation(invitationID);

      var dtos = projectUsers.Select(l => l.Translate());

      return dtos;
    }

    public ProjectUserInvitationSummaryDto Get(long ID)
    {
      var projectUser = _projectUserInvitationRepository.GetSummary(ID);

      var dto = projectUser.Translate();

      return dto;
    }

    // Adds a callsheet scene
    public long Add(ProjectUserInvitationDto dto)
    {
      var projectUserInvitation = new ProjectUserInvitation
      {
        ProjectID = dto.ProjectID,
        UserInvitationID = dto.UserInvitationID,
        RoleID = dto.RoleID,
      };

      _projectUserInvitationRepository.Add(projectUserInvitation);
      _projectUserInvitationRepository.Commit();

      return projectUserInvitation.ID;
    }

    // Updates a callsheet scene
    public long Update(ProjectUserInvitationDto dto)
    {
      var projectUserInvitation = _projectUserInvitationRepository.GetSingle(dto.ID);

      projectUserInvitation.RoleID = dto.RoleID;

      _projectUserInvitationRepository.Edit(projectUserInvitation);
      _projectUserInvitationRepository.Commit();

      return projectUserInvitation.ID;
    }

    // Deletes a callsheet scene
    public void Delete(long ID)
    {
      var projectUserInvitation = _projectUserInvitationRepository.GetSingle(ID);

      _projectUserInvitationRepository.Delete(projectUserInvitation);

      _projectUserInvitationRepository.Commit();
    }
  }
}