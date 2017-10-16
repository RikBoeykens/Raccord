using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Users.Project
{
    // Interface for location functionality
    public interface ICProjectUserService
    {
        IEnumerable<ProjectUserProjectDto> GetProjects(string userID);

        IEnumerable<ProjectUserUserDto> GetUsers(long projectID);

        FullProjectUserDto Get(long ID);

        long Add(ProjectUserDto dto);

        long Update(ProjectUserDto dto);

        void Delete(long ID);
    }
}