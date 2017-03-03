namespace Raccord.Application.Core.Services.Locations
{
    // Dto to represent a location that's linked to something
    public class LinkedLocationDto: LocationDto
    {
        // ID of the link
        public long LinkID { get; set; }
    }
}