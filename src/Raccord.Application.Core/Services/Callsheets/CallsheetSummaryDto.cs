using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Callsheets
{
    // Dto to represent a callsheet summary
    public class CallsheetSummaryDto: BaseCallsheetDto
    {
        // ID of the crew unit
        public long CrewUnitID { get; set; }
    }
}