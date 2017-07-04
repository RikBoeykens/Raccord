using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;

namespace Raccord.API.ViewModels.Locations.LocationSets
{
    // Vm to represent a full location set
    public class FullLocationSetViewModel : LocationSetSummaryViewModel
    {
        private IEnumerable<ScheduleDaySceneCollectionViewModel> _scheduleDays;

        // Schedule scenes linked to the location set
        public IEnumerable<ScheduleDaySceneCollectionViewModel> ScheduleDays
        {
            get
            {
                return _scheduleDays ?? (_scheduleDays = new List<ScheduleDaySceneCollectionViewModel>());
            }
            set
            {
                _scheduleDays = value;
            }
        }
    }
}