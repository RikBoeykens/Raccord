using System.Linq;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Domain.Model.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Images;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Services.Locations.Locations;
using Raccord.Application.Services.Characters;
using Raccord.Domain.Model.Locations.LocationSets;
using Raccord.Application.Services.Common.Locations;
using Raccord.Application.Services.ScriptLocations;
using Raccord.Application.Services.Scheduling.ScheduleDays;
using System.Collections.Generic;
using Raccord.Domain.Model.Scenes;

namespace Raccord.Application.Services.Locations.LocationSets
{
    // Utilities and helper methods for Location sets
    public static class Utilities
    {
        public static FullLocationSetDto TranslateFull(this LocationSet location)
        {
            var dto = new FullLocationSetDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                LatLng = LocationUtilities.TranslateLatLng(location.Latitude, location.Longitude),
                Location = location.Location.TranslateSummary(),
                ScriptLocation = location.ScriptLocation.TranslateSummary(),
                ScheduleDays = location.GetLocationSetScheduleDays(),
            };

            return dto;
        }
        public static LocationSetLocationDto TranslateLocation(this LocationSet location)
        {
            var dto = new LocationSetLocationDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                LatLng = LocationUtilities.TranslateLatLng(location.Latitude, location.Longitude),
                Location = location.Location.TranslateSummary(),
            };

            return dto;
        }
        public static LocationSetScriptLocationDto TranslateScriptLocation(this LocationSet location)
        {
            var dto = new LocationSetScriptLocationDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                LatLng = LocationUtilities.TranslateLatLng(location.Latitude, location.Longitude),
                ScriptLocation = location.ScriptLocation.TranslateSummary(),
            };

            return dto;
        }
        public static LocationSetDto Translate(this LocationSet location)
        {
            var dto = new LocationSetDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                LatLng = LocationUtilities.TranslateLatLng(location.Latitude, location.Longitude),
                LocationID = location.LocationID,
                ScriptLocationID = location.ScriptLocationID,
            };

            return dto;
        }

        public static LocationSetSummaryDto TranslateSummary(this LocationSet location)
        {
            var dto = new LocationSetSummaryDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                LatLng = LocationUtilities.TranslateLatLng(location.Latitude, location.Longitude),
                Location = location.Location.TranslateSummary(),
                ScriptLocation = location.ScriptLocation.TranslateSummary(),
            };

            return dto;
        }
        public static CallsheetLocationSetDto TranslateCallsheet(this LocationSet location, IEnumerable<Scene> scenes)
        {
            var dto = new CallsheetLocationSetDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                LatLng = LocationUtilities.TranslateLatLng(location.Latitude, location.Longitude),
                ScriptLocation = location.ScriptLocation.TranslateSummary(),
                Scenes = scenes.Select(s=> s.TranslateSummary()).ToList()
            };

            return dto;
        }

        public static bool HasLatLng(this LocationSet locationSet)
        {
            if (locationSet==null) return false;
            return locationSet.Latitude.HasValue && locationSet.Longitude.HasValue;
        }
    }
}