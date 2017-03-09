using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;
using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownTypes;

namespace Raccord.Application.Services.Breakdowns.BreakdownTypes
{
    // Service used for breakdown type functionality
    public class BreakdownTypeService : IBreakdownTypeService
    {
        private readonly IBreakdownTypeRepository _breakdownTypeRepository;

        // Initialises a new BreakdownTypeService
        public BreakdownTypeService(IBreakdownTypeRepository breakdownTypeRepository)
        {
            if(breakdownTypeRepository == null)
                throw new ArgumentNullException(nameof(breakdownTypeRepository));
            
            _breakdownTypeRepository = breakdownTypeRepository;
        }

        // Gets all breakdown types
        public IEnumerable<BreakdownTypeSummaryDto> GetAllForProject(long projectID)
        {
            var breakdownTypes = _breakdownTypeRepository.GetAllForProject(projectID);

            var dtos = breakdownTypes.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single breakdown type by id
        public FullBreakdownTypeDto Get(long ID)
        {
            var breakdownType = _breakdownTypeRepository.GetFull(ID);

            var dto = breakdownType.TranslateFull();

            return dto;
        }

        // Gets a summary of a single breakdown type
        public BreakdownTypeSummaryDto GetSummary(long ID)
        {
            var breakdownType = _breakdownTypeRepository.GetSingle(ID);

            var dto = breakdownType.TranslateSummary();

            return dto;
        }

        // Adds a breakdown type
        public long Add(BreakdownTypeDto dto)
        {
            var breakdownType = new BreakdownType
            {
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID
            };

            _breakdownTypeRepository.Add(breakdownType);
            _breakdownTypeRepository.Commit();

            return breakdownType.ID;
        }

        // Updates a breakdown type
        public long Update(BreakdownTypeDto dto)
        {
            var breakdownType = _breakdownTypeRepository.GetSingle(dto.ID);

            breakdownType.Name = dto.Name;
            breakdownType.Description = dto.Description;

            _breakdownTypeRepository.Edit(breakdownType);
            _breakdownTypeRepository.Commit();

            return breakdownType.ID;
        }

        // Deletes a breakdown type
        public void Delete(Int64 ID)
        {
            var breakdownType = _breakdownTypeRepository.GetSingle(ID);

            _breakdownTypeRepository.Delete(breakdownType);

            _breakdownTypeRepository.Commit();
        }
    }
}