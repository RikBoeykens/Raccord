namespace Raccord.Application.Core.Services.Locations
{
    // Dto to represent a full location
    public class LocationSummaryDto: LocationDto
    {
        // Full count of scenes
        public int SceneCount {get; set; }
    }
}