using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;

namespace Raccord.Application.Services.SceneProperties
{
    // Service used for day/night functionality
    public class DayNightService : IDayNightService
    {
        private readonly IDayNightRepository _dayNightRepository;

        // Initialises a new DayNightService
        public DayNightService(IDayNightRepository dayNightRepository)
        {
            if(dayNightRepository == null)
                throw new ArgumentNullException(nameof(dayNightRepository));
            
            _dayNightRepository = dayNightRepository;
        }

        // Gets all day/night for a project
        public IEnumerable<DayNightSummaryDto> GetAllForProject(long projectID)
        {
            var dayNights = _dayNightRepository.GetAllForProject(projectID);

            var dtos = dayNights.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single day/night by id
        public FullDayNightDto Get(Int64 ID)
        {
            var dayNight = _dayNightRepository.GetFull(ID);

            var dto = dayNight.TranslateFull();

            return dto;
        }

        // Gets a summary of a single day/night
        public DayNightSummaryDto GetSummary(Int64 ID)
        {
            var dayNight = _dayNightRepository.GetSummary(ID);

            var dto = dayNight.TranslateSummary();

            return dto;
        }

        // Adds a day/night
        public long Add(DayNightDto dto)
        {
            var dayNight = new DayNight
            {
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID
            };

            _dayNightRepository.Add(dayNight);
            _dayNightRepository.Commit();

            return dayNight.ID;
        }

        // Updates a day/night
        public long Update(DayNightDto dto)
        {
            var dayNight = _dayNightRepository.GetSingle(dto.ID);

            dayNight.Name = dto.Name;
            dayNight.Description = dto.Description;

            _dayNightRepository.Edit(dayNight);
            _dayNightRepository.Commit();

            return dayNight.ID;
        }

        // Deletes a day/night
        public void Delete(long ID)
        {
            var dayNight = _dayNightRepository.GetSingle(ID);

            _dayNightRepository.Delete(dayNight);

            _dayNightRepository.Commit();
        }
    }
}