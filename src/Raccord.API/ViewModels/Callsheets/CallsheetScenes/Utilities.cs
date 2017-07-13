using System.Linq;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Callsheets;
using Raccord.Application.Core.Services.Callsheets.CallsheetScenes;
using Raccord.API.ViewModels.Locations.LocationSets;

namespace Raccord.API.ViewModels.Callsheets.CallsheetScenes
{
    public static class Utilities
    {
        // Translates a scene dto to a scene viewmodel
        public static FullCallsheetSceneViewModel Translate(this FullCallsheetSceneDto dto)
        {
            return new FullCallsheetSceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Scene = dto.Scene.Translate(),
                Callsheet = dto.Callsheet.Translate(),
                Characters = dto.Characters.Select(c=>c.Translate()),
                LocationSet = dto.LocationSet.ID!= default(long) ? dto.LocationSet.Translate() : new LocationSetSummaryViewModel(),
            };
        }
        // Translates a scene dto to a scene viewmodel
        public static CallsheetSceneCallsheetViewModel Translate(this CallsheetSceneCallsheetDto dto)
        {
            return new CallsheetSceneCallsheetViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Callsheet = dto.Callsheet.Translate(),
                LocationSet = dto.LocationSet.ID!= default(long) ? dto.LocationSet.Translate() : new LocationSetSummaryViewModel(),
            };
        }
        // Translates a scene summary dto to a scene summary viewmodel
        public static CallsheetSceneSceneViewModel Translate(this CallsheetSceneSceneDto dto)
        {
            return new CallsheetSceneSceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Scene = dto.Scene.Translate(),
                Characters = dto.Characters.Select(c=> c.Translate()),
                LocationSet = dto.LocationSet.ID!= default(long) ? dto.LocationSet.Translate() : new LocationSetSummaryViewModel(),
            };
        }
        // Translates a scene dto to a scene viewmodel
        public static CallsheetSceneViewModel Translate(this CallsheetSceneDto dto)
        {
            return new CallsheetSceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                CallsheetID = dto.CallsheetID,
                SceneID = dto.SceneID,
                LocationSetID = dto.LocationSetID,
            };
        }

        // Translates a scene dto to a scene viewmodel
        public static CallsheetSceneSummaryViewModel Translate(this CallsheetSceneSummaryDto dto)
        {
            return new CallsheetSceneSummaryViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Scene = dto.Scene.Translate(),
                Callsheet = dto.Callsheet.Translate(),
                LocationSet = dto.LocationSet.ID!= default(long) ? dto.LocationSet.Translate() : new LocationSetSummaryViewModel(),
            };
        }

        // Translates a scene dto to a scene viewmodel
        public static LinkedCallsheetSceneViewModel Translate(this LinkedCallsheetSceneDto dto)
        {
            return new LinkedCallsheetSceneViewModel
            {
                ID = dto.ID,
                PageLength = dto.PageLength,
                Scene = dto.Scene.Translate(),
                Callsheet = dto.Callsheet.Translate(),
                LocationSet = dto.LocationSet.ID!= default(long) ? dto.LocationSet.Translate() : new LocationSetSummaryViewModel(),
                LinkID = dto.LinkID,
            };
        }

        // Translates a scene summary viewmodel to a dto
        public static CallsheetSceneDto Translate(this CallsheetSceneViewModel vm)
        {
            return new CallsheetSceneDto
            {
                ID = vm.ID,
                PageLength = vm.PageLength,
                CallsheetID = vm.CallsheetID,
                SceneID = vm.SceneID,
                LocationSetID = vm.LocationSetID,
            };
        }
    }
}