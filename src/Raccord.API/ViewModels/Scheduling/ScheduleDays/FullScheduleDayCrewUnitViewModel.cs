using System.Collections.Generic;
using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.API.ViewModels.Scheduling.ScheduleDayNotes;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.ViewModels.Scheduling.ScheduleDays
{
    // Vm to represent a full schedule day
    public class FullScheduleDayCrewUnitViewModel: BaseScheduleDayViewModel
    {
        private IEnumerable<ScheduleSceneSceneViewModel> _scenes;
        private IEnumerable<ScheduleDayNoteViewModel> _notes;
        private ShootingDayViewModel _shootingDay;
        private CrewUnitViewModel _crewUnit;

        // Scenes scheduled for the day
        public IEnumerable<ScheduleSceneSceneViewModel> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<ScheduleSceneSceneViewModel>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Notes added to the day
        public IEnumerable<ScheduleDayNoteViewModel> Notes
        {
            get
            {
                return _notes ?? (_notes = new List<ScheduleDayNoteViewModel>());
            }
            set
            {
                _notes = value;
            }
        }

        // Shooting day associated to the schedule day
        public ShootingDayViewModel ShootingDay
        {
            get
            {
                return _shootingDay ?? (_shootingDay = new ShootingDayViewModel());
            }
            set
            {
                _shootingDay = value;
            }
        }

        public CrewUnitViewModel CrewUnit
        {
            get
            {
                return _crewUnit ?? new CrewUnitViewModel();
            }
            set
            {
                _crewUnit = value;
            }
        }
    }
}