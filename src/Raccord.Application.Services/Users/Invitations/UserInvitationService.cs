using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Raccord.Application.Core.Common.Paging;
using Raccord.Application.Core.ExternalServices.Communication.Mail;
using Raccord.Application.Core.Services.Users;
using Raccord.Application.Core.Services.Users.Invitations;
using Raccord.Core.Options;
using Raccord.Data.EntityFramework.Repositories.Cast;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewMembers;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits.Members;
using Raccord.Data.EntityFramework.Repositories.Users.Invitations;
using Raccord.Data.EntityFramework.Repositories.Users.Invitations.Projects;
using Raccord.Data.EntityFramework.Repositories.Users.Projects;
using Raccord.Domain.Model.Cast;
using Raccord.Domain.Model.Crew.CrewMembers;
using Raccord.Domain.Model.Crew.CrewUnits;
using Raccord.Domain.Model.Users;
using Raccord.Domain.Model.Users.Invitations;
using InvitationUtilities = Raccord.Application.Services.Users.Invitations.Utilities;

namespace Raccord.Application.Services.Users.Invitations
{
  public class UserInvitationService : IUserInvitationService
  {
    private readonly IUserInvitationRepository _userInvitationRepository;
    private readonly IProjectUserInvitationRepository _projectUserInvitationRepository;
    private readonly IProjectUserRepository _projectUserRepository;
    private readonly ICrewUnitMemberRepository _crewUnitMemberRepository;
    private readonly ICrewMemberRepository _crewMemberRepository;
    private readonly ICastMemberRepository _castMemberRepository;
    private readonly IUserService _userService;
    private readonly ISendMailService _sendMailService;
    private readonly UISettings _uiSettings;

    public UserInvitationService(
      IUserInvitationRepository userInvitationRepository,
      IProjectUserInvitationRepository projectUserInvitationRepository,
      IProjectUserRepository projectUserRepository,
      ICrewUnitMemberRepository crewUnitMemberRepository,
      ICrewMemberRepository crewMemberRepository,
      ICastMemberRepository castMemberRepository,
      IUserService userService,
      ISendMailService sendMailService,
      IOptions<UISettings> uiSettings
    ){
      _userInvitationRepository = userInvitationRepository;
      _projectUserInvitationRepository = projectUserInvitationRepository;
      _projectUserRepository = projectUserRepository;
      _crewUnitMemberRepository = crewUnitMemberRepository;
      _crewMemberRepository = crewMemberRepository;
      _castMemberRepository = castMemberRepository;
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

    public PagedDataDto<AdminUserInvitationSummaryDto> GetAdminPaged(PaginationRequestDto requestDto)
    {
      var userInvitations = _userInvitationRepository.GetAll();

      return userInvitations.GetPaged<UserInvitation, AdminUserInvitationSummaryDto>(requestDto, (userInvitation)=>
      {
        var projectCount = _projectUserInvitationRepository.GetCountForInvitation(userInvitation.ID);
        return userInvitation.TranslateAdminSummary(projectCount);
      });
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

      var projectUserInvitations = _projectUserInvitationRepository.GetAllForInvitation(ID);

      var dto = projectUser.TranslateFull(projectUserInvitations);

      return dto;
    }

    // Gets a single project user by id
    public FullUserInvitationDto GetFullAdmin(Guid ID)
    {
      var projectUser = _userInvitationRepository.GetFull(ID);

      var projectUserInvitations = _projectUserInvitationRepository.GetAllForInvitation(ID);

      var dto = projectUser.TranslateFullAdmin(projectUserInvitations);

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
        Email = dto.Email,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Password = dto.Password
      });

      userInvitation.AcceptedDate = DateTime.UtcNow;
      
      _userInvitationRepository.Edit(userInvitation);
      _userInvitationRepository.Commit();

      var projectUserInvitations = _projectUserInvitationRepository.GetAllForCreateUser(userInvitation.ID);

      foreach(var projectUserInvitation in projectUserInvitations.ToList())
      {
        var projectUser = new ProjectUser
        {
          ProjectID = projectUserInvitation.ProjectID,
          UserID = createdUserId,
          RoleID = projectUserInvitation.RoleID,
          CastMemberID = projectUserInvitation.CastMemberID
        };
        _projectUserRepository.Add(projectUser);
        _projectUserRepository.Commit();

        if(projectUser.CastMemberID.HasValue)
        {
          LinkCastMember(projectUser.CastMemberID.Value, projectUser.ID);
        }
        
        foreach(var crewUnitInvitationMember in projectUserInvitation.CrewUnitInvitationMembers.ToList())
        {
          var crewUnitMember = new CrewUnitMember
          {
            CrewUnitID = crewUnitInvitationMember.CrewUnitID,
            ProjectUserID = projectUser.ID
          };
          _crewUnitMemberRepository.Add(crewUnitMember);
          _crewUnitMemberRepository.Commit();
          foreach(var invitationCrewMember in crewUnitInvitationMember.CrewMembers.ToList())
          {
            var crewMember = _crewMemberRepository.GetSingle(invitationCrewMember.ID);
            crewMember.CrewUnitMemberID = crewUnitMember.ID;
            _crewMemberRepository.Edit(crewMember);
            _crewMemberRepository.Commit();
          }
        }
      }
      SendAcceptedInvitationEmail(dto.FirstName, dto.LastName);
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

    private void SendAcceptedInvitationEmail(string firstName, string lastName)
    {
      var body = $"User {firstName} {lastName} has accepted the invitation";

      _sendMailService.SendMail(new SendMailRequestDto{
        Subject = "Raccord Invitation Accepted",
        Body = body
      });
    }

    private void LinkCastMember(long castMemberID, long projectUserID)
    {
          var castMember = _castMemberRepository.GetSingle(castMemberID);
          castMember.ProjectUserID = projectUserID;
          _castMemberRepository.Edit(castMember);
          _castMemberRepository.Commit();
    }
  }
}