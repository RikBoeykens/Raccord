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
using Raccord.Application.Core.Common.Routing;
using Raccord.Domain.Model.Comments;
using Raccord.Application.Core.Services.Comments;
using Raccord.Domain.Model.ShootingDays;
using Raccord.Application.Services.ShootingDays;

namespace Raccord.Application.Services.Locations.Locations
{
    // Utilities and helper methods for Locations
    public static class Utilities
    {
        public static FullLocationDto TranslateFull(this Location location, IEnumerable<CommentDto> comments, IEnumerable<ShootingDay> shootingDays)
        {
            var dto = new FullLocationDto
            {
                ID = location.ID,
                Name = location.Name,
                Description = location.Description,
                Address = LocationUtilities.TranslateAddress(location.Address1, location.Address2, location.Address3, location.Address4),
                LatLng = LocationUtilities.TranslateLatLng(location.Latitude, location.Longitude),
                Sets = location.LocationSets.Select(ls=> ls.TranslateScriptLocation()),
                ShootingDays = shootingDays.GetLocationSetShootingDays(location.LocationSets.Select(ls => ls.ID).ToArray()),
                ProjectID = location.ProjectID,
                Comments = comments
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
                DisplayName = location.Name,
                Info = $"Project: {location.Project.Title}",
                RouteInfo = new RouteInfoDto
                {
                    RouteIDs = new object[]{location.ProjectID, location.ID},
                    Type = EntityType.Location,
                }
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