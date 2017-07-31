using System.Collections.Generic;
using Raccord.Domain.Model.Callsheets.Scenes;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.Scheduling;

namespace Raccord.Domain.Model.Characters
{
    // join for character and scene
    public class CharacterScene : Entity
    {
        private ICollection<ScheduleCharacter> _scheduleDays;
        private ICollection<CallsheetSceneCharacter> _callsheets;

        // ID of the linked image
        public long CharacterID { get; set; }

        // Linked image
        public virtual Character Character { get; set; }

        // ID of the linked location
        public long SceneID { get; set; }

        // Linked location
        public virtual Scene Scene { get; set; }

        // Linked schedule days
        public virtual ICollection<ScheduleCharacter> ScheduleDays
        {
            get
            {
                return _scheduleDays ?? (_scheduleDays = new List<ScheduleCharacter>());
            }
            set
            {
                _scheduleDays = value;
            }
        }

        // Linked callsheets
        public virtual ICollection<CallsheetSceneCharacter> CallsheetScenes
        {
            get
            {
                return _callsheets ?? (_callsheets = new List<CallsheetSceneCharacter>());
            }
            set
            {
                _callsheets = value;
            }
        }
    }
}