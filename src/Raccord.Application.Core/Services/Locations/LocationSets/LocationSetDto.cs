namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Dto to represent a scene on a schedule day
    public class LocationSetDto
    {
        // ID of the schedule scene
        public long ID { get; set; }

        // ID of the linked location
        public long LocationID { get; set; }

        // ID of the linked scene
        public long ScriptLocationID { get; set; }
    }
}