using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Raccord.Application.Core.ExternalServices.Communication.Mail;
using Raccord.Application.Core.Services.Users;
using Raccord.Application.Core.Services.Users.Invitations;
using Raccord.Core.Options;
using Raccord.Data.EntityFramework.Repositories.Users.Invitations;
using Raccord.Data.EntityFramework.Repositories.Users.Invitations.Projects;
using Raccord.Data.EntityFramework.Repositories.Users.Projects;
using Raccord.Domain.Model.Users;
using Raccord.Domain.Model.Users.Invitations;

namespace Raccord.Application.Services.Users.Invitations
{
  public class UserInvitationService : IUserInvitationService
  {
    private readonly IUserInvitationRepository _userInvitationRepository;
    private readonly IProjectUserInvitationRepository _projectUserInvitationRepository;
    private readonly IProjectUserRepository _projectUserRepository;
    private readonly IUserService _userService;
    private readonly ISendMailService _sendMailService;
    private readonly UISettings _uiSettings;

    public UserInvitationService(
      IUserInvitationRepository userInvitationRepository,
      IProjectUserInvitationRepository projectUserInvitationRepository,
      IProjectUserRepository projectUserRepository,
      IUserService userService,
      ISendMailService sendMailService,
      IOptions<UISettings> uiSettings
    ){
      _userInvitationRepository = userInvitationRepository;
      _projectUserInvitationRepository = projectUserInvitationRepository;
      _projectUserRepository = projectUserRepository;
      _userService = userService;
      _sendMailService = sendMailService;
      _uiSettings = uiSettings.Value;
    }

    // Gets all callsheet scenes for a scene
    public IEnumerable<UserInvitationSummaryDto> GetAll()
    {
      var invitations = _userInvitationRepository.GetAll();

      var dtos = invitations.Select(l => l.TranslateSummary());

      return dtos;
    }

    // Gets a single project user by id
    public UserInvitationDto Get(Guid ID)
    {
      var projectUser = _userInvitationRepository.GetSingle(ID);

      var dto = projectUser.Translate();

      return dto;
    }

    // Gets a single project user by id
    public FullUserInvitationDto GetFull(Guid ID)
    {
      var projectUser = _userInvitationRepository.GetFull(ID);

      var dto = projectUser.TranslateFull();

      return dto;
    }

    // Gets a single project user by id
    public UserInvitationSummaryDto GetSummary(Guid ID)
    {
      var projectUser = _userInvitationRepository.GetSingle(ID);

      var dto = projectUser.TranslateSummary();

      return dto;
    }

    // Adds a callsheet scene
    public Guid Add(UserInvitationDto dto)
    {
      var userInvitation = new UserInvitation
      {
        Email = dto.Email,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
      };

      _userInvitationRepository.Add(userInvitation);
      _userInvitationRepository.Commit();

      SendInviteEmail(userInvitation.ID, dto.Email, dto.FirstName);

      return userInvitation.ID;
    }

    // Updates a callsheet scene
    public Guid Update(UserInvitationDto dto)
    {
      var userInvitation = _userInvitationRepository.GetSingle(dto.ID);

      userInvitation.FirstName = dto.FirstName;
      userInvitation.LastName = dto.LastName;

      _userInvitationRepository.Edit(userInvitation);
      _userInvitationRepository.Commit();

      return userInvitation.ID;
    }

    public void Delete(Guid ID)
    {
      var userInvitation = _userInvitationRepository.GetSingle(ID);

      _userInvitationRepository.Delete(userInvitation);

      _userInvitationRepository.Commit();
    }

    public async Task<string> CreateUserFromInvitation(CreateUserFromInvitationDto dto)
    {
      var userInvitation = _userInvitationRepository.GetSingle(dto.ID);
      if(userInvitation.AcceptedDate.HasValue)
      {
        throw new Exception("Already created");
      }
      var createdUserId = await _userService.Add(new CreateUserDto
      {
        Email = userInvitation.Email,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Password = dto.Password
      });

      userInvitation.AcceptedDate = DateTime.UtcNow;
      
      _userInvitationRepository.Edit(userInvitation);
      _userInvitationRepository.Commit();

      var projectUserInvitations = _projectUserInvitationRepository.GetAllForInvitation(userInvitation.ID);

      var projectUsers = projectUserInvitations.ToList().Select(pu => new ProjectUser
      {
        ProjectID = pu.ProjectID,
        UserID = createdUserId,
        RoleID = pu.RoleID
      });
      foreach(var projectUser in projectUsers)
      {
        _projectUserRepository.Add(projectUser);
      }
      _projectUserRepository.Commit();

      return createdUserId;
    }

    private void SendInviteEmail(Guid invitationID, string email, string firstName)
    {
      var invitationUrl = $"{_uiSettings.Uri}/invitations/{invitationID}";

      var body = $"Dear {firstName}, you have been invited to try raccord. You can access it with the following url: {invitationUrl}. Click on the link, create your account and have a look!";

      _sendMailService.SendMail(new SendMailRequestDto{
        Recipient = email,
        Subject = "Raccord Invitation",
        Body = body
      });
    }
  }
}