using System.Collections.Generic;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Locations.LocationSets;
using Raccord.Domain.Model.Scenes;

namespace Raccord.Domain.Model.Scheduling
{
    /// Represents schedule scene on a day
    public class ScheduleScene : Entity
    {
        private ICollection<ScheduleCharacter> _characters;

        // Length in eights
        public int PageLength { get; set; }

        // The sorting order of the scene within the schedule day
        public int SortingOrder { get; set; }

        // ID of the linked schedule day
        public long ScheduleDayID { get; set; }

        // Linked image
        public virtual ScheduleDay ScheduleDay { get; set; }

        // ID of the linked scene
        public long SceneID { get; set; }

        // Linked scene
        public virtual Scene Scene { get; set; }

        public long? LocationSetID { get; set; }

        public virtual LocationSet LocationSet { get; set; }

        // Linked characters
        public virtual ICollection<ScheduleCharacter> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<ScheduleCharacter>());
            }
            set
            {
                _characters = value;
            }
        }
    }
}