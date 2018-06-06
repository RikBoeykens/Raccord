using System.Linq;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Domain.Model.Locations.Locations;
using Raccord.Application.Services.ScriptLocations;
using Raccord.Application.Services.Common.Locations;
using Raccord.Application.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Services.Scheduling.ScheduleDays;
using Raccord.Application.Core.Services.Locations.LocationSets;
using System.Collections.Generic;

namespace Raccord.Application.Services.Locations.Locations
{
    // Utilities and helper methods for Locations
    public static class Utilities
    {
        public static FullLocationDto TranslateFull(this Location location)
        {
            var dto = new FullLocationDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                Address = LocationUtilities.TranslateAddress(location.Address1, location.Address2, location.Address3, location.Address4),
                LatLng = LocationUtilities.TranslateLatLng(location.Latitude, location.Longitude),
                Sets = location.LocationSets.Select(ls=> ls.TranslateScriptLocation()),
                ScheduleDays = location.GetLocationScheduleDays(),
                ProjectID = location.ProjectID,
            };

            return dto;
        }
        public static LocationSummaryDto TranslateSummary(this Location location)
        {
            var dto = new LocationSummaryDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                Address = LocationUtilities.TranslateAddress(location.Address1, location.Address2, location.Address3, location.Address4),
                LatLng = LocationUtilities.TranslateLatLng(location.Latitude, location.Longitude),
                SetCount = location.LocationSets.Count(),
                ProjectID = location.ProjectID,
            };

            return dto;
        }

        public static LocationDto Translate(this Location location)
        {
            var dto = new LocationDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                Address = LocationUtilities.TranslateAddress(location.Address1, location.Address2, location.Address3, location.Address4),
                LatLng = LocationUtilities.TranslateLatLng(location.Latitude, location.Longitude),
                ProjectID = location.ProjectID,
            };

            return dto;
        }
        public static CallsheetLocationDto TranslateCallsheet(this Location location, IEnumerable<CallsheetLocationSetDto> locationSets, string number)
        {
            var dto = new CallsheetLocationDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                Address = LocationUtilities.TranslateAddress(location.Address1, location.Address2, location.Address3, location.Address4),
                LatLng = LocationUtilities.TranslateLatLng(location.Latitude, location.Longitude),
                ProjectID = location.ProjectID,
                Sets = locationSets,
                Number = number
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this Location location)
        {
            var dto = new SearchResultDto
            {
                ID = location.ID,
                RouteIDs = new long[]{location.ProjectID, location.ID},
                DisplayName = location.Name,
                Info = $"Project: {location.Project.Title}",
                Type = EntityType.Location,
            };

            return dto;
        }

        public static bool HasLatLng(this Location location)
        {
            if (location==null) return false;
            return location.Latitude.HasValue && location.Longitude.HasValue;
        }
    }
}