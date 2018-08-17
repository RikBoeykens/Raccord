using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Shots;
using Raccord.Application.Core.Services.Shots.Slates;
using Raccord.Data.EntityFramework.Repositories.Shots.Slates;
using Raccord.Application.Core.Services.Comments;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Shots.Slates
{
    // Service used for slate functionality
    public class SlateService : ISlateService
    {
        private readonly ISlateRepository _slateRepository;
        private readonly ICommentService _commentService;

        // Initialises a new DayNightService
        public SlateService(
            ISlateRepository slateRepository,
            ICommentService commentService
            )
        {
            _slateRepository = slateRepository;
            _commentService = commentService;
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

            var comments = _commentService.GetForParent(new GetCommentDto{ ParentID = slate.ID, ParentType = ParentCommentType.Slate});

            var dto = slate.TranslateFull(comments);

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
            var previousSlate = _slateRepository.GetAllForProject(dto.ProjectID).OrderByDescending(s=> s.SortingOrder).FirstOrDefault();

            var slate = new Slate
            {
                Number = dto.Number,
                Description = dto.Description,
                Lens = dto.Lens,
                Distance = dto.Distance,
                Aperture = dto.Aperture,
                Filters = dto.Filters,
                Sound = dto.Sound,
                IsVfx = dto.IsVfx,
                SortingOrder = previousSlate != null ? previousSlate.SortingOrder + 1 : 1,
                SceneID = dto.Scene.ID!=default(long) ? dto.Scene.ID : (long?)null,
                ShootingDayID = dto.ShootingDay.ID!=default(long) ? dto.ShootingDay.ID : (long?)null,
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
            slate.IsVfx = dto.IsVfx;
            slate.SceneID = dto.Scene.ID!=default(long) ? dto.Scene.ID : (long?)null;
            slate.ShootingDayID = dto.ShootingDay.ID!=default(long) ? dto.ShootingDay.ID : (long?)null;

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