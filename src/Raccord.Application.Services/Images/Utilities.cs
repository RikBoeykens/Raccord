using System.Linq;
using System.IO;
using Raccord.Application.Core.Services.Images;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Services.Locations;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Images
{
    // Utilities and helper methods for Locations
    public static class Utilities
    {
        public static FullImageDto TranslateFull(this Image image)
        {
            var dto = new FullImageDto
            {
                ID = image.ID,
                Title = image.Title,
                Description = image.Description,
                FileName = image.FileName,
                Scenes = image.ImageScenes.Select(s=> s.Scene.Translate()),
                Locations = image.ImageLocations.Select(il=> il.Location.Translate()),
                ProjectID = image.ProjectID,
                IsPrimaryImage = image.IsPrimaryImage,
            };

            return dto;
        }
        public static ImageSummaryDto TranslateSummary(this Image image)
        {
            var dto = new ImageSummaryDto
            {
                ID = image.ID,
                Title = image.Title,
                Description = image.Description,
                FileName = image.FileName,
                ProjectID = image.ProjectID,
                IsPrimaryImage = image.IsPrimaryImage,
            };

            return dto;
        }

        public static ImageDto Translate(this Image image)
        {
            var dto = new ImageDto
            {
                ID = image.ID,
                Title = image.Title,
                FileName = image.FileName,
                Description = image.Description,
                ProjectID = image.ProjectID,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this Image image)
        {
            var dto = new SearchResultDto
            {
                ID = image.ID,
                RouteIDs = new long[]{image.ProjectID, image.ID},
                DisplayName = image.Title,
                Info = $"Project: {image.Project.Title}",
                Type = EntityType.Image,
            };

            return dto;
        }

        public static byte[] GetBytes(this Stream input)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                input.Position = 0;
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}