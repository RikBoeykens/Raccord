using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Shots;
using Raccord.Application.Core.Services.Shots.Takes;
using Raccord.Data.EntityFramework.Repositories.Shots.Takes;

namespace Raccord.Application.Services.Shots.Takes
{
    // Service used for take functionality
    public class TakeService : ITakeService
    {
        private readonly ITakeRepository _takeRepository;

        // Initialises a new DayNightService
        public TakeService(ITakeRepository takeRepository)
        {
            if(takeRepository == null)
                throw new ArgumentNullException(nameof(takeRepository));
            
            _takeRepository = takeRepository;
        }

        // Gets all takes for a slate
        public IEnumerable<TakeSummaryDto> GetAllForParent(long slateID)
        {
            var takes = _takeRepository.GetAllForSlate(slateID);

            var dtos = takes.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single take by id
        public FullTakeDto Get(Int64 ID)
        {
            var take = _takeRepository.GetFull(ID);

            var dto = take.TranslateFull();

            return dto;
        }

        // Gets a summary of a single take
        public TakeSummaryDto GetSummary(Int64 ID)
        {
            var take = _takeRepository.GetSummary(ID);

            var dto = take.TranslateSummary();

            return dto;
        }

        // Adds a take
        public long Add(TakeDto dto)
        {
            var take = new Take
            {
                Number = dto.Number,
                Notes = dto.Notes,
                Length = dto.Length,
                Selected = dto.Selected,
                CameraRoll = dto.CameraRoll,
                SoundRoll = dto.SoundRoll,
                SlateID = dto.Slate.ID,
            };

            _takeRepository.Add(take);
            _takeRepository.Commit();

            return take.ID;
        }

        // Updates a take
        public long Update(TakeDto dto)
        {
            var take = _takeRepository.GetSingle(dto.ID);

            take.Number = dto.Number;
            take.Notes = dto.Notes;
            take.Length = dto.Length;
            take.Selected = dto.Selected;
            take.CameraRoll = dto.CameraRoll;
            take.SoundRoll = dto.SoundRoll;

            _takeRepository.Edit(take);
            _takeRepository.Commit();

            return take.ID;
        }

        // Deletes a take
        public void Delete(long ID)
        {
            var take = _takeRepository.GetSingle(ID);

            _takeRepository.Delete(take);

            _takeRepository.Commit();
        }
    }
}