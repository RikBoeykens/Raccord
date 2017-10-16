using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Crew;

namespace Raccord.Application.Services.Crew
{
    // Service used for crew functionality
    public class CrewService : ICrewService
    {

        // Initialises a new CallsheetSceneService
        public CrewService()
        {
        }

        // Gets all callsheet scenes for a scene
        public IEnumerable<CrewUserProjectDto> GetProjects(string userID)
        {
            return new List<CrewUserProjectDto>();
        }

        // Gets all callsheet scenes for a day
        public IEnumerable<CrewUserUserDto> GetUsers(long projectID)
        {
            return new List<CrewUserUserDto>();
        }

        // Gets a single crew user by id
        public FullCrewUserDto Get(long ID)
        {
            return new FullCrewUserDto();
        }

        // Adds a callsheet scene
        public long Add(CrewUserDto dto)
        {
            return 0;
        }

        // Updates a callsheet scene
        public long Update(CrewUserDto dto)
        {
            return 0;
        }

        // Deletes a callsheet scene
        public void Delete(Int64 ID)
        {
        }
    }
}