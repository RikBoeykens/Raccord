using Raccord.Domain.Model.Locations.Locations;
using Raccord.Domain.Model.ScriptLocations;
using Raccord.Domain.Model.Scheduling;
using System.Collections.Generic;
using Raccord.Domain.Model.Callsheets.Scenes;
using Raccord.Domain.Model.ShootingDays.Scenes;
using Raccord.Domain.Model.Comments;

namespace Raccord.Domain.Model.Locations.LocationSets
{
    // Represents a set on a location, linked to a script location
    public class LocationSet : Entity<long>
    {
        private ICollection<ScheduleScene> _scheduleScenes;
        private ICollection<CallsheetScene> _callsheetScenes;
        private ICollection<ShootingDayScene> _shootingDayScenes;
        private ICollection<Comment> _comments;

        /// Name of the set
        public string Name { get; set; }

        /// Description of the set
        public string Description { get; set; }

        // Latitute of the set
        public double? Latitude { get; set; }

        // Longitude of the set
        public double? Longitude { get; set; }

        // ID of the linked location
        public long LocationID { get; set; }

        // Linked location
        public virtual Location Location { get; set; }

        // ID of the linked script location
        public long ScriptLocationID { get; set; }

        // Linked script location
        public virtual ScriptLocation ScriptLocation { get; set; }

        // Linked schedule scenes
        public virtual ICollection<ScheduleScene> ScheduleScenes
        {
            get
            {
                return _scheduleScenes ?? (_scheduleScenes = new List<ScheduleScene>());
            }
            set
            {
                _scheduleScenes = value;
            }
        }

        // Linked schedule scenes
        public virtual ICollection<CallsheetScene> CallsheetScenes
        {
            get
            {
                return _callsheetScenes ?? (_callsheetScenes = new List<CallsheetScene>());
            }
            set
            {
                _callsheetScenes = value;
            }
        }

        // Linked shooting day scenes
        public virtual ICollection<ShootingDayScene> ShootingDayScenes
        {
            get
            {
                return _shootingDayScenes ?? (_shootingDayScenes = new List<ShootingDayScene>());
            }
            set
            {
                _shootingDayScenes = value;
            }
        }
        
        // Comments made to the location
        public virtual ICollection<Comment> Comments
        {
            get
            {
                return _comments ?? (_comments = new List<Comment>());
            }
            set
            {
                _comments = value;
            }
        }
    }
}