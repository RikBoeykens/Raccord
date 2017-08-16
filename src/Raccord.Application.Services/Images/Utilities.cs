using System.Linq;
using System.IO;
using Raccord.Application.Core.Services.Images;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Services.ScriptLocations;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Characters;
using Raccord.Application.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Services.Shots.Slates;

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
                Scenes = image.ImageScenes.Select(s=> s.TranslateScene()),
                ScriptLocations = image.ImageScriptLocations.Select(il=> il.TranslateLocation()),
                Characters = image.ImageCharacters.Select(il=> il.TranslateCharacter()),
                BreakdownItems = image.ImageBreakdownItems.Select(ibi=> ibi.TranslateBreakdownItem()),
                Slates = image.ImageSlates.Select(isl=> isl.TranslateSlate()),
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

        public static LinkedImageDto TranslateImage(this ImageScene imageScene)
        {
            var dto = new LinkedImageDto
            {
                ID = imageScene.Image.ID,
                Title = imageScene.Image.Title,
                FileName = imageScene.Image.FileName,
                Description = imageScene.Image.Description,
                ProjectID = imageScene.Image.ProjectID,
                LinkID = imageScene.ID,
                IsPrimaryImage = imageScene.IsPrimaryImage,
            };

            return dto;
        }

        public static LinkedImageDto TranslateImage(this ImageScriptLocation imageLocation)
        {
            var dto = new LinkedImageDto
            {
                ID = imageLocation.Image.ID,
                Title = imageLocation.Image.Title,
                FileName = imageLocation.Image.FileName,
                Description = imageLocation.Image.Description,
                ProjectID = imageLocation.Image.ProjectID,
                LinkID = imageLocation.ID,
                IsPrimaryImage = imageLocation.IsPrimaryImage,
            };

            return dto;
        }

        public static LinkedImageDto TranslateImage(this ImageCharacter imageCharacter)
        {
            var dto = new LinkedImageDto
            {
                ID = imageCharacter.Image.ID,
                Title = imageCharacter.Image.Title,
                FileName = imageCharacter.Image.FileName,
                Description = imageCharacter.Image.Description,
                ProjectID = imageCharacter.Image.ProjectID,
                LinkID = imageCharacter.ID,
                IsPrimaryImage = imageCharacter.IsPrimaryImage,
            };

            return dto;
        }

        public static LinkedImageDto TranslateImage(this ImageBreakdownItem imageBreakdownItem)
        {
            var dto = new LinkedImageDto
            {
                ID = imageBreakdownItem.Image.ID,
                Title = imageBreakdownItem.Image.Title,
                FileName = imageBreakdownItem.Image.FileName,
                Description = imageBreakdownItem.Image.Description,
                ProjectID = imageBreakdownItem.Image.ProjectID,
                LinkID = imageBreakdownItem.ID,
                IsPrimaryImage = imageBreakdownItem.IsPrimaryImage,
            };

            return dto;
        }

        public static LinkedImageDto TranslateImage(this ImageSlate imageSlate)
        {
            var dto = new LinkedImageDto
            {
                ID = imageSlate.Image.ID,
                Title = imageSlate.Image.Title,
                FileName = imageSlate.Image.FileName,
                Description = imageSlate.Image.Description,
                ProjectID = imageSlate.Image.ProjectID,
                LinkID = imageSlate.ID,
                IsPrimaryImage = imageSlate.IsPrimaryImage,
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