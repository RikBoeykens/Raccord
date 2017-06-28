using System.Linq;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Domain.Model.Locations.Locations;
using Raccord.Application.Services.ScriptLocations;
using Raccord.Application.Services.Common.Locations;
using Raccord.Application.Services.Locations.LocationSets;

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
    }
}