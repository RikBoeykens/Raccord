using System.Linq;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Images;
using Raccord.Application.Core.Services.Callsheets.CallsheetScenes;
using Raccord.Application.Services.Callsheets;
using Raccord.Application.Services.Characters;
using Raccord.Application.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Domain.Model.Callsheets.Scenes;

namespace Raccord.Application.Services.Callsheets.CallsheetScenes
{
    // Utilities and helper methods for Schedule Scenes
    public static class Utilities
    {
        public static FullCallsheetSceneDto TranslateFull(this CallsheetScene callsheetScene)
        {
            var dto = new FullCallsheetSceneDto
            {
                ID = callsheetScene.ID,
                PageLength = callsheetScene.PageLength,
                Callsheet = callsheetScene.Callsheet.TranslateSummary(),
                Scene = callsheetScene.Scene.TranslateSummary(),
                Characters = callsheetScene.Characters.Select(c=> c.TranslateCharacter()),
                LocationSet = callsheetScene.LocationSetID.HasValue ? callsheetScene.LocationSet.TranslateSummary() : new LocationSetSummaryDto(),
            };

            return dto;
        }
        public static CallsheetSceneCallsheetDto TranslateCallsheet(this CallsheetScene callsheetScene)
        {
            var dto = new CallsheetSceneCallsheetDto
            {
                ID = callsheetScene.ID,
                PageLength = callsheetScene.PageLength,
                Callsheet = callsheetScene.Callsheet.TranslateSummary(),
                LocationSet = callsheetScene.LocationSetID.HasValue ? callsheetScene.LocationSet.TranslateSummary() : new LocationSetSummaryDto(),
            };

            return dto;
        }
        public static CallsheetSceneSceneDto TranslateScene(this CallsheetScene callsheetScene)
        {
            var dto = new CallsheetSceneSceneDto
            {
                ID = callsheetScene.ID,
                PageLength = callsheetScene.PageLength,
                Scene = callsheetScene.Scene.TranslateSummary(),
                Characters = callsheetScene.Characters.Select(c=> c.TranslateCharacter()),
                LocationSet = callsheetScene.LocationSetID.HasValue ? callsheetScene.LocationSet.TranslateSummary() : new LocationSetSummaryDto(),
            };

            return dto;
        }
        public static CallsheetSceneDto Translate(this CallsheetScene callsheetScene)
        {
            var dto = new CallsheetSceneDto
            {
                ID = callsheetScene.ID,
                PageLength = callsheetScene.PageLength,
                CallsheetID = callsheetScene.CallsheetID,
                SceneID = callsheetScene.SceneID,
                LocationSetID = callsheetScene.LocationSetID,
            };

            return dto;
        }

        public static CallsheetSceneSummaryDto TranslateSummary(this CallsheetScene callsheetScene)
        {
            var dto = new CallsheetSceneSummaryDto
            {
                ID = callsheetScene.ID,
                PageLength = callsheetScene.PageLength,
                Callsheet = callsheetScene.Callsheet.TranslateSummary(),
                Scene = callsheetScene.Scene.TranslateSummary(),
                LocationSet = callsheetScene.LocationSetID.HasValue ? callsheetScene.LocationSet.TranslateSummary() : new LocationSetSummaryDto(),
            };

            return dto;
        }
        
        public static LinkedCallsheetSceneDto TranslateCallsheetScene(this CallsheetSceneCharacter callsheetSceneCharacter)
        {
            var dto = new LinkedCallsheetSceneDto
            {
                ID = callsheetSceneCharacter.CallsheetScene.ID,
                PageLength = callsheetSceneCharacter.CallsheetScene.PageLength,
                Callsheet = callsheetSceneCharacter.CallsheetScene.Callsheet.TranslateSummary(),
                Scene = callsheetSceneCharacter.CallsheetScene.Scene.TranslateSummary(),
                LocationSet = callsheetSceneCharacter.CallsheetScene.LocationSetID.HasValue ? callsheetSceneCharacter.CallsheetScene.LocationSet.TranslateSummary() : new LocationSetSummaryDto(),
                LinkID = callsheetSceneCharacter.ID,
            };

            return dto;
        }
        public static CallsheetSceneLocationDto TranslateLocation(this CallsheetScene callsheetScene)
        {
            var dto = new CallsheetSceneLocationDto
            {
                ID = callsheetScene.ID,
                PageLength = callsheetScene.PageLength,
                Scene = callsheetScene.Scene.TranslateSummary(),
                LocationSet = callsheetScene.LocationSetID.HasValue ? callsheetScene.LocationSet.TranslateSummary() : new LocationSetSummaryDto(),
                AvailableLocations = callsheetScene.Scene.ScriptLocation.LocationSets.Select(ls=> ls.TranslateSummary()),
            };

            return dto;
        }
    }
}