using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Crew.CrewUnits
{
    // Interface for crew unit functionality
    public interface ICrewUnitService : IService<CrewUnitDto, CrewUnitSummaryDto, FullCrewUnitDto>, IAllForParentService<CrewUnitSummaryDto>
    {
        FullAdminCrewUnitDto GetForAdmin(long ID);
        IEnumerable<CrewUnitSummaryDto> GetAllForUser(long projectID, string userID);
    }
}