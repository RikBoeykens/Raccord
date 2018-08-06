using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItems;
using Raccord.Domain.Model.Images;
using Raccord.Data.EntityFramework.Repositories.Comments;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Breakdowns.BreakdownItems
{
    // Service used for breakdown item functionality
    public class BreakdownItemService : IBreakdownItemService
    {
        private readonly IBreakdownItemRepository _breakdownItemRepository;
        private readonly ICommentRepository _commentRepository;

        // Initialises a new BreakdownItemService
        public BreakdownItemService(
            IBreakdownItemRepository breakdownitemRepository,
            ICommentRepository commentRepository
            )
        {
            _breakdownItemRepository = breakdownitemRepository;
            _commentRepository = commentRepository;
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

            var comments = _commentRepository.GetForParent(item.ID, ParentCommentType.BreakdownItem).ToList();

            var dto = item.TranslateFull(comments);

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
                BreakdownID = dto.BreakdownID,
                BreakdownTypeID = dto.BreakdownTypeID
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

        public IEnumerable<BreakdownItemDto>SearchByType(SearchBreakdownItemRequestDto requestDto)
        {
            var items = _breakdownItemRepository.Search(requestDto.SearchText, null, requestDto.TypeID, requestDto.UserID, requestDto.IsAdmin, requestDto.ExcludeIDs.ToArray());

            return items.Select(i=> i.Translate());
        }
    }
}