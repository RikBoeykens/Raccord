using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.ScriptLocations;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Data.EntityFramework.Repositories.ScriptLocations;
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Common.Paging;
using Raccord.Data.EntityFramework.Repositories.Comments;
using Raccord.Core.Enums;
using Raccord.Application.Core.Services.Comments;

namespace Raccord.Application.Services.ScriptLocations
{
    // Service used for location functionality
    public class ScriptLocationService : IScriptLocationService
    {
        private readonly IScriptLocationRepository _scriptLocationRepository;
        private readonly ICommentService _commentService;

        // Initialises a new LocationService
        public ScriptLocationService(
            IScriptLocationRepository locationRepository,
            ICommentService commentService
            )
        {
            _scriptLocationRepository = locationRepository;
            _commentService = commentService;
        }

        // Gets all locations
        public IEnumerable<ScriptLocationSummaryDto> GetAllForParent(long projectID)
        {
            var locations = _scriptLocationRepository.GetAllForProject(projectID);

            var dtos = locations.Select(l => l.TranslateSummary());

            return dtos;
        }

        public PagedDataDto<ScriptLocationSummaryDto> GetPagedForProject(PaginationRequestDto paginationRequest,long projectId)
        {
            var locations = _scriptLocationRepository.GetAllForProject(projectId);
            return locations.GetPaged<ScriptLocation, ScriptLocationSummaryDto>(paginationRequest, x => x.TranslateSummary());
        }

        // Gets a single location by id
        public FullScriptLocationDto Get(long ID)
        {
            var location = _scriptLocationRepository.GetFull(ID);

            var comments = _commentService.GetForParent(new GetCommentDto{ ParentID = location.ID, ParentType = ParentCommentType.ScriptLocation}).ToList();
            var dto = location.TranslateFull(comments);

            return dto;
        }

        // Gets a summary of a single location
        public ScriptLocationSummaryDto GetSummary(long ID)
        {
            var location = _scriptLocationRepository.GetSingle(ID);

            var dto = location.TranslateSummary();

            return dto;
        }

        // Adds a location
        public long Add(ScriptLocationDto dto)
        {
            var location = new ScriptLocation
            {
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID
            };

            _scriptLocationRepository.Add(location);
            _scriptLocationRepository.Commit();

            return location.ID;
        }

        // Updates a location
        public long Update(ScriptLocationDto dto)
        {
            var location = _scriptLocationRepository.GetSingle(dto.ID);

            location.Name = dto.Name;
            location.Description = dto.Description;

            _scriptLocationRepository.Edit(location);
            _scriptLocationRepository.Commit();

            return location.ID;
        }

        // Deletes a location
        public void Delete(Int64 ID)
        {
            var location = _scriptLocationRepository.GetSingle(ID);

            _scriptLocationRepository.Delete(location);

            _scriptLocationRepository.Commit();
        }

        public void Merge(long toID, long mergeID)
        {
            var toLocation = _scriptLocationRepository.GetFull(toID);
            var mergeLocation = _scriptLocationRepository.GetFull(mergeID);

            var sceneList = toLocation.Scenes.ToList();
            sceneList.AddRange(mergeLocation.Scenes);

            toLocation.Scenes = sceneList;
            mergeLocation.Scenes.Clear();

            var imageList = mergeLocation.ImageLocations.ToList();

            foreach(var image in imageList)
            {
                if(!toLocation.ImageLocations.Any(cs=> cs.ImageID == image.ImageID))
                {
                    toLocation.ImageLocations.Add(new ImageScriptLocation{ImageID = image.ImageID});
                }
            }

            _scriptLocationRepository.Edit(toLocation);
            _scriptLocationRepository.Delete(mergeLocation);

            _scriptLocationRepository.Commit();
        }
    }
}