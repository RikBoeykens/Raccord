using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Shots;
using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits;
using Raccord.Domain.Model.Crew.CrewUnits;

namespace Raccord.Application.Services.Crew.CrewUnits
{
    // Service used for crew unit functionality
    public class CrewUnitService : ICrewUnitService
    {
        private readonly ICrewUnitRepository _crewUnitRepository;

        // Initialises a new CrewUnitService
        public CrewUnitService(ICrewUnitRepository crewUnitRepository)
        {
            if(crewUnitRepository == null)
            {
                throw new ArgumentNullException(nameof(crewUnitRepository));
            }
            
            _crewUnitRepository = crewUnitRepository;
        }

        // Gets all crew units for a project
        public IEnumerable<CrewUnitSummaryDto> GetAllForParent(long projectID)
        {
            var crewUnits = _crewUnitRepository.GetAllForProject(projectID);

            var dtos = crewUnits.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets all crew units for a project
        public IEnumerable<CrewUnitSummaryDto> GetAllForUser(long projectID, string userID)
        {
            var crewUnits = _crewUnitRepository.GetAllForUser(projectID, userID);

            var dtos = crewUnits.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single crew unit by id
        public FullCrewUnitDto Get(long ID)
        {
            var crewUnit = _crewUnitRepository.GetFull(ID);

            var dto = crewUnit.TranslateFull();

            return dto;
        }

        // Gets a single crew unit by id
        public FullAdminCrewUnitDto GetForAdmin(long ID)
        {
            var crewUnit = _crewUnitRepository.GetFullAdmin(ID);

            var dto = crewUnit.TranslateFullAdmin();

            return dto;
        }

        // Gets a summary of a single crew unit
        public CrewUnitSummaryDto GetSummary(long ID)
        {
            var crewUnit = _crewUnitRepository.GetSummary(ID);

            var dto = crewUnit.TranslateSummary();

            return dto;
        }

        // Adds a crew unit
        public long Add(CrewUnitDto dto)
        {
            var crewUnit = new CrewUnit
            {
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID
            };

            _crewUnitRepository.Add(crewUnit);
            _crewUnitRepository.Commit();

            return crewUnit.ID;
        }

        // Updates a crew unit
        public long Update(CrewUnitDto dto)
        {
            var crewUnit = _crewUnitRepository.GetSingle(dto.ID);

            crewUnit.Name = dto.Name;
            crewUnit.Description = dto.Description;

            _crewUnitRepository.Edit(crewUnit);
            _crewUnitRepository.Commit();

            return crewUnit.ID;
        }

        // Deletes a crew unit
        public void Delete(long ID)
        {
            var crewUnit = _crewUnitRepository.GetSingle(ID);

            _crewUnitRepository.Delete(crewUnit);

            _crewUnitRepository.Commit();
        }
    }
}