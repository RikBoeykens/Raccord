using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Crew;
using Raccord.Application.Core.Services.Crew;
using Raccord.Data.EntityFramework.Repositories.Crew;

namespace Raccord.Application.Services.Crew
{
    // Service used for crew functionality
    public class CrewService : ICrewService
    {
        private readonly ICrewRepository _crewRepository;

        // Initialises a new CallsheetSceneService
        public CrewService(ICrewRepository crewRepository)
        {
            if(crewRepository == null)
                throw new ArgumentNullException(nameof(crewRepository));
            
            _crewRepository = crewRepository;
        }

        // Gets all callsheet scenes for a scene
        public IEnumerable<CrewUserProjectDto> GetProjects(string userID)
        {
            var crewUsers = _crewRepository.GetAllForUser(userID);

            var dtos = crewUsers.Select(l => l.TranslateProject());

            return dtos;
        }

        // Gets all callsheet scenes for a day
        public IEnumerable<CrewUserUserDto> GetUsers(long projectID)
        {
            var crewUsers = _crewRepository.GetAllForProject(projectID);

            var dtos = crewUsers.Select(l => l.TranslateUser());

            return dtos;
        }

        // Gets a single crew user by id
        public FullCrewUserDto Get(long ID)
        {
            var crewUser = _crewRepository.GetFull(ID);

            var dto = crewUser.TranslateFull();

            return dto;
        }

        // Adds a callsheet scene
        public long Add(CrewUserDto dto)
        {
            var crewUser = new CrewUser
            {
                ProjectID = dto.ProjectID,
                UserID = dto.UserID,
            };

            _crewRepository.Add(crewUser);
            _crewRepository.Commit();

            return crewUser.ID;
        }

        // Updates a callsheet scene
        public long Update(CrewUserDto dto)
        {
            var crewUser = _crewRepository.GetSingle(dto.ID);

            _crewRepository.Edit(crewUser);
            _crewRepository.Commit();

            return crewUser.ID;
        }

        // Deletes a callsheet scene
        public void Delete(Int64 ID)
        {
            var crewUser = _crewRepository.GetSingle(ID);

            _crewRepository.Delete(crewUser);

            _crewRepository.Commit();
        }
    }
}