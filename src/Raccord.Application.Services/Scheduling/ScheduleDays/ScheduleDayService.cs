using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDays;
using Raccord.Domain.Model.Scheduling;

namespace Raccord.Application.Services.Scheduling.ScheduleDays
{
    // Service used for schedule day functionality
    public class ScheduleDayService : IScheduleDayService
    {
        private readonly IScheduleDayRepository _scheduleDayRepository;

        // Initialises a new ScheduleDayService
        public ScheduleDayService(IScheduleDayRepository scheduleDayRepository)
        {
            if(scheduleDayRepository == null)
                throw new ArgumentNullException(nameof(scheduleDayRepository));
            
            _scheduleDayRepository = scheduleDayRepository;
        }

        // Gets all schedule days
        public IEnumerable<ScheduleDaySummaryDto> GetAllForParent(long projectID)
        {
            var scheduleDays = _scheduleDayRepository.GetAllForProject(projectID);

            var dtos = scheduleDays.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single schedule day by id
        public FullScheduleDayDto Get(long ID)
        {
            var scheduleDay = _scheduleDayRepository.GetFull(ID);

            var dto = scheduleDay.TranslateFull();

            return dto;
        }

        // Gets a summary of a single schedule day
        public ScheduleDaySummaryDto GetSummary(long ID)
        {
            var scheduleDay = _scheduleDayRepository.GetSingle(ID);

            var dto = scheduleDay.TranslateSummary();

            return dto;
        }

        // Adds a schedule day
        public long Add(ScheduleDayDto dto)
        {
            var scheduleDay = new ScheduleDay
            {
                Date = dto.Date,
                Start = dto.Start,
                End = dto.End,
                ProjectID = dto.ProjectID
            };

            _scheduleDayRepository.Add(scheduleDay);
            _scheduleDayRepository.Commit();

            return scheduleDay.ID;
        }

        // Updates a schedule day
        public long Update(ScheduleDayDto dto)
        {
            var scheduleDay = _scheduleDayRepository.GetSingle(dto.ID);

            scheduleDay.Start = dto.Start;
            scheduleDay.End = dto.End;

            _scheduleDayRepository.Edit(scheduleDay);
            _scheduleDayRepository.Commit();

            return scheduleDay.ID;
        }

        // Deletes a schedule day
        public void Delete(Int64 ID)
        {
            var scheduleDay = _scheduleDayRepository.GetSingle(ID);

            _scheduleDayRepository.Delete(scheduleDay);

            _scheduleDayRepository.Commit();
        }
    }
}