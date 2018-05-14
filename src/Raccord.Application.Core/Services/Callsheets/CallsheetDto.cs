using System;
using Raccord.Application.Core.Services.ShootingDays;

namespace Raccord.Application.Core.Services.Callsheets
{
    // Dto to represent a callsheet
    public class CallsheetDto : BaseCallsheetDto
    {
        // ID of the crew unit
        public long CrewUnitID { get; set; }
    }
}