using System.Threading.Tasks;
using Raccord.Application.Core.Common.Paging;

namespace Raccord.Application.Core.Services.Users
{
    public interface IUserService : IAllService<UserSummaryDto>
    {
        PagedDataDto<AdminUserSummaryDto> GetAdminPaged(PaginationRequestDto requestDto);
        // Returns a single full instance
        AdminFullUserDto Get(string ID);

        // Returns a summary of a single user
        UserSummaryDto GetSummary(string ID);

        // Adds a single instance
        Task<string> Add(CreateUserDto dto);
        
        // Updates a single instance
        Task<string> Update(UserDto dto);

        // Deletes a single instance
        Task Delete(string ID);
    }
}