using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;

namespace Raccord.Application.Services.SceneProperties
{
    // Service used for day/night functionality
    public class TimeOfDayService : ITimeOfDayService
    {
        private readonly ITimeOfDayRepository _timeOfDayRepository;

        // Initialises a new TimeOfDayService
        public TimeOfDayService(ITimeOfDayRepository timeOfDayRepository)
        {
            if(timeOfDayRepository == null)
                throw new ArgumentNullException(nameof(timeOfDayRepository));
            
            _timeOfDayRepository = timeOfDayRepository;
        }

        // Gets all day/night for a project
        public IEnumerable<TimeOfDaySummaryDto> GetAllForParent(long projectID)
        {
            var timeOfDays = _timeOfDayRepository.GetAllForProject(projectID);

            var dtos = timeOfDays.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single day/night by id
        public FullTimeOfDayDto Get(Int64 ID)
        {
            var timeOfDay = _timeOfDayRepository.GetFull(ID);

            var dto = timeOfDay.TranslateFull();

            return dto;
        }

        // Gets a summary of a single day/night
        public TimeOfDaySummaryDto GetSummary(Int64 ID)
        {
            var timeOfDay = _timeOfDayRepository.GetSummary(ID);

            var dto = timeOfDay.TranslateSummary();

            return dto;
        }

        // Adds a day/night
        public long Add(TimeOfDayDto dto)
        {
            var timeOfDay = new TimeOfDay
            {
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID
            };

            _timeOfDayRepository.Add(timeOfDay);
            _timeOfDayRepository.Commit();

            return timeOfDay.ID;
        }

        // Updates a day/night
        public long Update(TimeOfDayDto dto)
        {
            var timeOfDay = _timeOfDayRepository.GetSingle(dto.ID);

            timeOfDay.Name = dto.Name;
            timeOfDay.Description = dto.Description;

            _timeOfDayRepository.Edit(timeOfDay);
            _timeOfDayRepository.Commit();

            return timeOfDay.ID;
        }

        // Deletes a day/night
        public void Delete(long ID)
        {
            var timeOfDay = _timeOfDayRepository.GetSingle(ID);

            _timeOfDayRepository.Delete(timeOfDay);

            _timeOfDayRepository.Commit();
        }

        public void Merge(long toID, long mergeID)
        {
            var toTimeofDay = _timeOfDayRepository.GetFull(toID);
            var mergeTimeofDay = _timeOfDayRepository.GetFull(mergeID);

            var sceneList = toTimeofDay.Scenes.ToList();
            sceneList.AddRange(mergeTimeofDay.Scenes);

            toTimeofDay.Scenes = sceneList;
            mergeTimeofDay.Scenes.Clear();
            _timeOfDayRepository.Edit(toTimeofDay);
            _timeOfDayRepository.Delete(mergeTimeofDay);

            _timeOfDayRepository.Commit();
        }
    }
}