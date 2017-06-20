namespace Raccord.Application.Core.Services.ScriptLocations
{
    // Interface for location functionality
    public interface IScriptLocationService : IService<ScriptLocationDto, ScriptLocationSummaryDto, FullScriptLocationDto>, IAllForParentService<ScriptLocationSummaryDto>
    {
        void Merge(long toID, long mergeID);
    }
}