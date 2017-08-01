using System.Threading.Tasks;

namespace Raccord.Application.Core.Services.Users
{
    public interface IUserService : IAllService<UserSummaryDto>
    {
        // Returns a single full instance
        FullUserDto Get(string ID);

        // Adds a single instance
        Task<string> Add(CreateUserDto dto);
        
        // Updates a single instance
        Task<string> Update(UserDto dto);

        // Deletes a single instance
        Task Delete(string ID);
    }
}