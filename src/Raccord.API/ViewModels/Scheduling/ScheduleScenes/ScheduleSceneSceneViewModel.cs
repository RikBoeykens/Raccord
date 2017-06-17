using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;

namespace Raccord.API.ViewModels.Scheduling.ScheduleScenes
{
    // Viewmodel to represent a summary of a schedule scene with scene info
    public class ScheduleSceneSceneViewModel
    {
        private SceneSummaryViewModel _scene;
        private IEnumerable<LinkedCharacterViewModel> _characters;

        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // Linked scene
        public SceneSummaryViewModel Scene
        {
            get
            {
                return _scene ?? (_scene = new SceneSummaryViewModel()); 
            }
            set
            {
                _scene = value;
            }
        }

        // Linked characters
        public IEnumerable<LinkedCharacterViewModel> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<LinkedCharacterViewModel>()); 
            }
            set
            {
                _characters = value;
            }
        }
    }
}