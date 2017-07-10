using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Callsheets;
using Raccord.Data.EntityFramework.Repositories.Callsheets;
using Raccord.Domain.Model.Callsheets;

namespace Raccord.Application.Services.Callsheets
{
    // Service used for character functionality
    public class CallsheetService : ICallsheetService
    {
        private readonly ICallsheetRepository _callsheetRepository;

        // Initialises a new CharacterService
        public CallsheetService(
            ICallsheetRepository callsheetRepository
            )
        {
            if(callsheetRepository == null)
                throw new ArgumentNullException(nameof(callsheetRepository));
            
            _callsheetRepository = callsheetRepository;
        }

        // Gets all characters for a project
        public IEnumerable<CallsheetSummaryDto> GetAllForParent(long projectID)
        {
            var characters = _callsheetRepository.GetAllForProject(projectID);

            var dtos = characters.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single character by id
        public FullCallsheetDto Get(Int64 ID)
        {
            var character = _callsheetRepository.GetFull(ID);

            var dto = character.TranslateFull();

            return dto;
        }

        // Gets a summary of a single character
        public CallsheetSummaryDto GetSummary(Int64 ID)
        {
            var character = _callsheetRepository.GetSummary(ID);

            var dto = character.TranslateSummary();

            return dto;
        }

        // Adds a character
        public long Add(CallsheetDto dto)
        {
            var callsheet = new Callsheet
            {
                ShootingDayID = dto.ShootingDay.ID,
                ProjectID = dto.ProjectID,
            };

            _callsheetRepository.Add(callsheet);
            _callsheetRepository.Commit();

            return callsheet.ID;
        }

        // Updates a character
        public long Update(CallsheetDto dto)
        {
            var callsheet = _callsheetRepository.GetSingle(dto.ID);

            _callsheetRepository.Edit(callsheet);
            _callsheetRepository.Commit();

            return  callsheet.ID;
        }

        // Deletes a character
        public void Delete(long ID)
        {
            var callsheet = _callsheetRepository.GetSingle(ID);

            _callsheetRepository.Delete(callsheet);

            _callsheetRepository.Commit();
        }

    }
}