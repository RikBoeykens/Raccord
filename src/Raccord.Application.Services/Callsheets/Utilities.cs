using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Callsheets;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Services.Callsheets.CallsheetScenes;
using Raccord.Application.Services.Callsheets.Characters;
using Raccord.Application.Services.Locations.Locations;
using Raccord.Application.Services.Locations.LocationSets;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Services.ShootingDays;
using Raccord.Domain.Model.Callsheets;
using Raccord.Domain.Model.Scenes;

namespace Raccord.Application.Services.Callsheets
{
    // Utilities and helper methods for callsheets
    public static class Utilities
    {
        public static FullCallsheetDto TranslateFull(this Callsheet callsheet)
        {
            var scenes = callsheet.CallsheetScenes.OrderBy(cs=> cs.SortingOrder);
            var locations = new List<CallsheetLocationDto>();
            if(scenes.Count(s=> s.LocationSetID.HasValue)>=1)
            {
                var locationScenes = new List<Scene>();
                var locationSets = new List<CallsheetLocationSetDto>();
                var currentLocationSet = scenes.First(s=> s.LocationSetID.HasValue).LocationSet;
                var currentLocation = currentLocationSet.Location;
                foreach(var scene in scenes.Where(s => s.LocationSetID.HasValue))
                {
                    if(scene.LocationSetID == currentLocationSet.ID)
                    {
                        locationScenes.Add(scene.Scene);
                    }
                    else
                    {
                        locationSets.Add(currentLocationSet.TranslateCallsheet(locationScenes));
                        locationScenes.Clear();
                        locationScenes.Add(scene.Scene);
                        currentLocationSet = scene.LocationSet;

                        if(currentLocation.ID != currentLocationSet.LocationID)
                        {
                            locations.Add(currentLocation.TranslateCallsheet(locationSets, $"{locations.Count() +1}"));
                            currentLocation = currentLocationSet.Location;
                        }
                    }
                }
                
                locations.Add(currentLocation.TranslateCallsheet(locationSets, $"{locations.Count() +1}"));
            }


            var dto = new FullCallsheetDto
            {
                ID = callsheet.ID,
                Start = callsheet.Start,
                End = callsheet.End,
                CrewCall = callsheet.CrewCall,
                ProjectID = callsheet.ProjectID,
                ShootingDay = callsheet.ShootingDay.Translate(),
                Scenes = scenes.Select(cs=> cs.TranslateScene()),
                Characters = callsheet.CallsheetCharacters.Select(cc=> cc.TranslateCharacter()),
                Locations = locations
            };

            return dto;
        }

        public static CallsheetSummaryDto TranslateSummary(this Callsheet callsheet)
        {
            var dto = new CallsheetSummaryDto
            {
                ID = callsheet.ID,
                Start = callsheet.Start,
                End = callsheet.End,
                CrewCall = callsheet.CrewCall,
                ProjectID = callsheet.ProjectID,
                ShootingDay = callsheet.ShootingDay.Translate(),
            };

            return dto;
        }

        public static CallsheetDto Translate(this Callsheet callsheet)
        {
            var dto = new CallsheetDto
            {
                ID = callsheet.ID,
                Start = callsheet.Start,
                End = callsheet.End,
                CrewCall = callsheet.CrewCall,
                ProjectID = callsheet.ProjectID,
                ShootingDay = callsheet.ShootingDay.Translate(),
            };

            return dto;
        }
    }
}