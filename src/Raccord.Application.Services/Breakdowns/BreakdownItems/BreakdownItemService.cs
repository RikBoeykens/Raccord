using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItems;
using Raccord.Domain.Model.Images;

namespace Raccord.Application.Services.Breakdowns.BreakdownItems
{
    // Service used for breakdown item functionality
    public class BreakdownItemService : IBreakdownItemService
    {
        private readonly IBreakdownItemRepository _breakdownItemRepository;

        // Initialises a new BreakdownItemService
        public BreakdownItemService(IBreakdownItemRepository breakdownitemRepository)
        {
            if(breakdownitemRepository == null)
                throw new ArgumentNullException(nameof(breakdownitemRepository));
            
            _breakdownItemRepository = breakdownitemRepository;
        }

        // Gets all breakdown items
        public IEnumerable<BreakdownItemSummaryDto> GetAllForParent(long typeID)
        {
            var items = _breakdownItemRepository.GetAllForType(typeID);

            var dtos = items.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single breakdown item by id
        public FullBreakdownItemDto Get(long ID)
        {
            var item = _breakdownItemRepository.GetFull(ID);

            var dto = item.TranslateFull();

            return dto;
        }

        // Gets a summary of a single breakdown item
        public BreakdownItemSummaryDto GetSummary(long ID)
        {
            var item = _breakdownItemRepository.GetSingle(ID);

            var dto = item.TranslateSummary();

            return dto;
        }

        // Adds a breakdown item
        public long Add(BreakdownItemDto dto)
        {
            var item = new BreakdownItem
            {
                Name = dto.Name,
                Description = dto.Description,
                BreakdownTypeID = dto.Type.ID
            };

            _breakdownItemRepository.Add(item);
            _breakdownItemRepository.Commit();

            return item.ID;
        }

        // Updates a breakdown item
        public long Update(BreakdownItemDto dto)
        {
            var item = _breakdownItemRepository.GetSingle(dto.ID);

            item.Name = dto.Name;
            item.Description = dto.Description;

            _breakdownItemRepository.Edit(item);
            _breakdownItemRepository.Commit();

            return item.ID;
        }

        // Deletes a breakdown item
        public void Delete(Int64 ID)
        {
            var item = _breakdownItemRepository.GetSingle(ID);

            _breakdownItemRepository.Delete(item);

            _breakdownItemRepository.Commit();
        }

        public void Merge(long toID, long mergeID)
        {
            var toItem = _breakdownItemRepository.GetFull(toID);
            var mergeItem = _breakdownItemRepository.GetFull(mergeID);

            var sceneList = mergeItem.BreakdownItemScenes.ToList();
            foreach(var scene in sceneList)
            {
                if(!toItem.BreakdownItemScenes.Any(cs=> cs.SceneID == scene.SceneID))
                {
                    toItem.BreakdownItemScenes.Add(new BreakdownItemScene{SceneID = scene.SceneID});
                }
            }

            var imageList = mergeItem.ImageBreakdownItems.ToList();
            foreach(var image in imageList)
            {
                if(!toItem.ImageBreakdownItems.Any(cs=> cs.ImageID == image.ImageID))
                {
                    toItem.ImageBreakdownItems.Add(new ImageBreakdownItem{ImageID = image.ImageID});
                }
            }

            _breakdownItemRepository.Edit(toItem);
            _breakdownItemRepository.Delete(mergeItem);

            _breakdownItemRepository.Commit();
        }
    }
}