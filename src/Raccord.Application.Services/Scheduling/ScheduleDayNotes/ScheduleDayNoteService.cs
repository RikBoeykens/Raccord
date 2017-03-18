using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Services.Scheduling.ScheduleDayNotes;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDayNotes;
using Raccord.Domain.Model.Scheduling;

namespace Raccord.Application.Services.Scheduling.ScheduleDayNotes
{
    // Service used for schedule day note functionality
    public class ScheduleDayNoteService : IScheduleDayNoteService
    {
        private readonly IScheduleDayNoteRepository _scheduleDayNoteRepository;

        // Initialises a new ScheduleDayService
        public ScheduleDayNoteService(IScheduleDayNoteRepository scheduleDayNoteRepository)
        {
            if(scheduleDayNoteRepository == null)
                throw new ArgumentNullException(nameof(scheduleDayNoteRepository));
            
            _scheduleDayNoteRepository = scheduleDayNoteRepository;
        }

        // Gets all schedule days
        public IEnumerable<ScheduleDayNoteSummaryDto> GetAllForParent(long projectID)
        {
            var scheduleDayNotes = _scheduleDayNoteRepository.GetAllForScheduleDay(projectID);

            var dtos = scheduleDayNotes.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single schedule day by id
        public FullScheduleDayNoteDto Get(long ID)
        {
            var scheduleDayNote = _scheduleDayNoteRepository.GetFull(ID);

            var dto = scheduleDayNote.TranslateFull();

            return dto;
        }

        // Gets a summary of a single schedule day
        public ScheduleDayNoteSummaryDto GetSummary(long ID)
        {
            var scheduleDayNote = _scheduleDayNoteRepository.GetSingle(ID);

            var dto = scheduleDayNote.TranslateSummary();

            return dto;
        }

        // Adds a schedule day
        public long Add(ScheduleDayNoteDto dto)
        {
            var scheduleDayNote = new ScheduleDayNote
            {
                Content = dto.Content,
                ScheduleDayID = dto.ScheduleDayID
            };

            _scheduleDayNoteRepository.Add(scheduleDayNote);
            _scheduleDayNoteRepository.Commit();

            return scheduleDayNote.ID;
        }

        // Updates a schedule day
        public long Update(ScheduleDayNoteDto dto)
        {
            var scheduleDayNote = _scheduleDayNoteRepository.GetSingle(dto.ID);

            scheduleDayNote.Content = dto.Content;

            _scheduleDayNoteRepository.Edit(scheduleDayNote);
            _scheduleDayNoteRepository.Commit();

            return scheduleDayNote.ID;
        }

        // Deletes a schedule day
        public void Delete(Int64 ID)
        {
            var scheduleDayNote = _scheduleDayNoteRepository.GetSingle(ID);

            _scheduleDayNoteRepository.Delete(scheduleDayNote);

            _scheduleDayNoteRepository.Commit();
        }
    }
}