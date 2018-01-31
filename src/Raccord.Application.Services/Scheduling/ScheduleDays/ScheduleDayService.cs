using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Raccord.Data.EntityFramework.Repositories.Projects;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDays;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.ShootingDays;

namespace Raccord.Application.Services.Scheduling.ScheduleDays
{
    // Service used for schedule day functionality
    public class ScheduleDayService : IScheduleDayService
    {
        private readonly IScheduleDayRepository _scheduleDayRepository;
        private readonly IShootingDayRepository _shootingDayRepository;
        private readonly IProjectRepository _projectRepository;

        // Initialises a new ScheduleDayService
        public ScheduleDayService(
            IScheduleDayRepository scheduleDayRepository,
            IShootingDayRepository shootingDayRepository,
            IProjectRepository projectRepository
            )
        {
            if(scheduleDayRepository == null)
                throw new ArgumentNullException(nameof(scheduleDayRepository));
            if(shootingDayRepository == null)
                throw new ArgumentNullException(nameof(shootingDayRepository));
            if(projectRepository == null)
                throw new ArgumentNullException(nameof(projectRepository));
            
            _scheduleDayRepository = scheduleDayRepository;
            _shootingDayRepository = shootingDayRepository;
            _projectRepository = projectRepository;
        }

        // Gets all schedule days
        public IEnumerable<FullScheduleDayDto> GetAllForParent(long projectID)
        {
            var scheduleDays = _scheduleDayRepository.GetAllForProject(projectID);

            var dtos = scheduleDays.Select(l => l.TranslateFull());

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

        public void PublishDays(long projectID)
        {
            var scheduleDaysWithScenes = _scheduleDayRepository.GetAllWithScenesForProject(projectID).OrderBy(sd=> sd.Date).ToList();

            var number = 1;
            foreach(var scheduleDay in scheduleDaysWithScenes)
            {
                if(!scheduleDay.ShootingDayID.HasValue)
                {
                    var newShootingDay = new ShootingDay
                    {
                        Date = scheduleDay.Date,
                        Number = number.ToString(),
                        ScheduleDayID = scheduleDay.ID,
                        ProjectID = scheduleDay.ProjectID,
                    };
                    number++;
                    _shootingDayRepository.Add(newShootingDay);
                    _shootingDayRepository.Commit();
                    scheduleDay.ShootingDayID = newShootingDay.ID;
                    _scheduleDayRepository.Edit(scheduleDay);
                    _scheduleDayRepository.Commit();
                }
            }
            var project = _projectRepository.GetSingle(projectID);
            project.PublishedSchedule = true;
            _projectRepository.Edit(project);
            _projectRepository.Commit();
        }
    }
}