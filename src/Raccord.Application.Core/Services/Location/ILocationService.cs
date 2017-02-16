namespace Raccord.Application.Core.Services.Locations
{
    // Interface for location functionality
    public interface ILocationService : IService<LocationDto, LocationSummaryDto, FullLocationDto>, IAllForProjectService<LocationSummaryDto>
    {
    }
}