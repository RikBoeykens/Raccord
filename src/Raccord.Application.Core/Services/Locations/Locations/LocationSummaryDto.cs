namespace Raccord.Application.Core.Services.Locations.Locations
{
    // Dto to represent a location summary
    public class LocationSummaryDto: LocationDto
    {
        // Full count of scenes
        public int SetCount {get; set; }
    }
}