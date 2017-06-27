namespace Raccord.Application.Core.Services.Locations.LocationSets
{
    // Dto to represent a set that's linked to something
    public class LinkedLocationSetDto: LocationSetSummaryDto
    {
        // ID of the link
        public long LinkID { get; set; }
    }
}