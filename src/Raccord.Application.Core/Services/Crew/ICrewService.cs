using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Crew
{
    // Interface for location functionality
    public interface ICrewService
    {
        IEnumerable<CrewUserProjectDto> GetProjects(string userID);

        IEnumerable<CrewUserUserDto> GetUsers(long projectID);

        FullCrewUserDto Get(long ID);

        long Add(CrewUserDto dto);

        long Update(CrewUserDto dto);

        void Delete(long ID);
    }
}