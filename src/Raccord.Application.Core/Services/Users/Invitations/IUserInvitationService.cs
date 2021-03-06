using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raccord.Application.Core.Common.Paging;

namespace Raccord.Application.Core.Services.Users.Invitations
{
  public interface IUserInvitationService
  {
    IEnumerable<UserInvitationSummaryDto> GetAll();
    PagedDataDto<AdminUserInvitationSummaryDto> GetAdminPaged(PaginationRequestDto requestDto);
    FullUserInvitationDto GetFull(Guid ID);
    UserInvitationDto Get(Guid ID);

    UserInvitationSummaryDto GetSummary(Guid ID);

    Guid Add(UserInvitationDto dto);

    Guid Update(UserInvitationDto dto);

    void Delete(Guid ID);
    Task<string> CreateUserFromInvitation(CreateUserFromInvitationDto dto);
  }
}