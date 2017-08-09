using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Shots;
using Raccord.Application.Core.Services.Shots.Slates;
using Raccord.Data.EntityFramework.Repositories.Shots.Slates;

namespace Raccord.Application.Services.Shots.Slates
{
    // Service used for slate functionality
    public class SlateService : ISlateService
    {
        private readonly ISlateRepository _slateRepository;

        // Initialises a new DayNightService
        public SlateService(ISlateRepository slateRepository)
        {
            if(slateRepository == null)
                throw new ArgumentNullException(nameof(slateRepository));
            
            _slateRepository = slateRepository;
        }

        // Gets all slates for a project
        public IEnumerable<SlateSummaryDto> GetAllForParent(long projectID)
        {
            var slates = _slateRepository.GetAllForProject(projectID);

            var dtos = slates.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single slate by id
        public FullSlateDto Get(Int64 ID)
        {
            var slate = _slateRepository.GetFull(ID);

            var dto = slate.TranslateFull();

            return dto;
        }

        // Gets a summary of a single day/night
        public SlateSummaryDto GetSummary(Int64 ID)
        {
            var slate = _slateRepository.GetSummary(ID);

            var dto = slate.TranslateSummary();

            return dto;
        }

        // Adds a day/night
        public long Add(SlateDto dto)
        {
            var slate = new Slate
            {
                Number = dto.Number,
                Description = dto.Description,
                Lens = dto.Lens,
                Distance = dto.Distance,
                Aperture = dto.Aperture,
                Filters = dto.Filters,
                Sound = dto.Sound,
                SceneID = dto.Scene.ID,
                ShootingDayID = dto.ShootingDay.ID,
                ProjectID = dto.ProjectID
            };

            _slateRepository.Add(slate);
            _slateRepository.Commit();

            return slate.ID;
        }

        // Updates a slate
        public long Update(SlateDto dto)
        {
            var slate = _slateRepository.GetSingle(dto.ID);

            slate.Number = dto.Number;
            slate.Description = dto.Description;
            slate.Lens = dto.Lens;
            slate.Distance = dto.Distance;
            slate.Aperture = dto.Aperture;
            slate.Filters = dto.Filters;
            slate.Sound = dto.Sound;
            slate.SceneID = dto.Scene.ID;
            slate.ShootingDayID = dto.ShootingDay.ID;

            _slateRepository.Edit(slate);
            _slateRepository.Commit();

            return slate.ID;
        }

        // Deletes a day/night
        public void Delete(long ID)
        {
            var slate = _slateRepository.GetSingle(ID);

            _slateRepository.Delete(slate);

            _slateRepository.Commit();
        }
    }
}