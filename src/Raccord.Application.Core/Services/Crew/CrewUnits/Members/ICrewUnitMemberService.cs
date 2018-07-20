using System.Collections.Generic;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Users.Project;

namespace Raccord.Application.Core.Services.Crew.CrewUnits.Members
{
    // Interface for crew unit member functionality
    public interface ICrewUnitMemberService
    {
        IEnumerable<ProjectLinkCrewUnitDto> GetCrewUnits(long projectUserID);
        IEnumerable<LinkedProjectUserUserDto> GetUsers(long crewUnitID);

        // Links a project user to a crew unit
        void AddLink(long projectUserID, long crewUnitID);

        // Removes link between project user and crew unit
        void RemoveLink(long ID);
    }
}