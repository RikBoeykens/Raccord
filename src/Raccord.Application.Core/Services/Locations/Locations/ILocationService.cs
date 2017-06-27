namespace Raccord.Application.Core.Services.Locations.Locations
{
    // Interface for location functionality
    public interface ILocationService : IService<LocationDto, LocationSummaryDto, FullLocationDto>, IAllForParentService<FullLocationDto>
    {
    }
}