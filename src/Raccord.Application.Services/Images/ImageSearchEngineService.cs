using System;
using System.Linq;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.Images;
using Raccord.Core.Enums;
using Raccord.Application.Services.SearchEngine;

namespace Raccord.Application.Services.Images
{
    // Service to search for images
    public class ImageSearchEngineService : IImageSearchEngineService
    {
        private readonly EntityType _type = EntityType.Image;
        private readonly IImageRepository _imageRepository;

        // Initialises a new ImageSearchEngineService
        public ImageSearchEngineService(IImageRepository imageRepository)
        {
            if(imageRepository == null)
                throw new ArgumentNullException(nameof(imageRepository));
            
            _imageRepository = imageRepository;
        }

        public new EntityType GetType()
        {
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var excludeIds = request.GetExcludeLongIDs(_type);
            var imageCount = _imageRepository.SearchCount(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);
            var images = _imageRepository.Search(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);

            return new SearchTypeResultDto
            {
                Count = imageCount,
                Type = "Images",
                Results = images.Select(l=> l.TranslateToSearchResult()),
            };
            
        }
    }
}