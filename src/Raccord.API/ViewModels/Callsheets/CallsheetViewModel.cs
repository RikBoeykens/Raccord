using System;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.Callsheets
{
    // Dto to represent a callsheet
    public class CallsheetViewModel : BaseCallsheetViewModel
    {
        // ID of the project
        public long CrewUnitID { get; set; }
    }
}