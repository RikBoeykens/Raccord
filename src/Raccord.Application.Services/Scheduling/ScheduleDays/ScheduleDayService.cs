using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Raccord.Data.EntityFramework.Repositories.Projects;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDays;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;
using Raccord.Data.EntityFramework.Repositories.Users;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.ShootingDays;

namespace Raccord.Application.Services.Scheduling.ScheduleDays
{
    // Service used for schedule day functionality
    public class ScheduleDayService : IScheduleDayService
    {
        private readonly IScheduleDayRepository _scheduleDayRepository;
        private readonly IShootingDayRepository _shootingDayRepository;
        private readonly IUserRepository _userRepository;

        // Initialises a new ScheduleDayService
        public ScheduleDayService(
            IScheduleDayRepository scheduleDayRepository,
            IShootingDayRepository shootingDayRepository,
            IUserRepository userRepository
            )
        {
            _scheduleDayRepository = scheduleDayRepository;
            _shootingDayRepository = shootingDayRepository;
            _userRepository = userRepository;
        }

        // Gets all schedule days
        public IEnumerable<FullScheduleDayDto> GetAllForParent(long crewUnitID)
        {
            var scheduleDays = _scheduleDayRepository.GetAllForCrewUnit(crewUnitID);

            var dtos = scheduleDays.Select(l => l.TranslateFull());

            return dtos;
        }

        // Gets all schedule days
        public IEnumerable<FullScheduleDayCrewUnitDto> GetForProjectUser(long projectID, string userID)
        {
            var user = _userRepository.GetFull(userID);
            var projectUser = user.ProjectUsers.FirstOrDefault(u => u.ProjectID == projectID);
            if(projectUser == null)
            {
                return new List<FullScheduleDayCrewUnitDto>();
            }
            var scheduleDays = new List<ScheduleDay>();

            var crewUnitIDs = projectUser.CrewUnitMembers.Select(cum => cum.CrewUnitID).ToList();
            foreach(var crewUnitID in crewUnitIDs)
            {
                scheduleDays.AddRange(_scheduleDayRepository.GetAllForCrewUnit(projectID));
            }

            if(projectUser.CastMemberID.HasValue)
            {
                var characterIds = projectUser.CastMember.Characters.Select(c => c.ID).ToArray();
                scheduleDays.AddRange(_scheduleDayRepository.GetAllForCharacters(characterIds));
            }

            var dtos = scheduleDays.Distinct().Select(l => l.TranslateFullCrewUnit());

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
                CrewUnitID = dto.CrewUnitID
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

        public void PublishDays(long crewUnitID)
        {
            var scheduleDaysWithScenes = _scheduleDayRepository.GetAllWithScenesForCrewUnit(crewUnitID).OrderBy(sd=> sd.Date).ToList();

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
                        CrewUnitID = scheduleDay.CrewUnitID,
                    };
                    number++;
                    _shootingDayRepository.Add(newShootingDay);
                    _shootingDayRepository.Commit();
                    scheduleDay.ShootingDayID = newShootingDay.ID;
                    _scheduleDayRepository.Edit(scheduleDay);
                    _scheduleDayRepository.Commit();
                }
            }
        }
    }
}